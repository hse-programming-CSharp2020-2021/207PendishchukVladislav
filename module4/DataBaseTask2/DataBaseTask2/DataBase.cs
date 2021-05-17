using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Reflection;

namespace DataBaseTask2
{
    class DataBase
    {
        private readonly IDictionary<Type, object> _tables = new Dictionary<Type, object>();

        public string Name { get; }

        public DataBase(string name)
        {
            Name = name;
        }

        public void CreateTable<T>() where T : IEntity
        {
            Type tableType = typeof(T);

            if (_tables.ContainsKey(tableType))
                throw new DataBaseException($"Table already exists {tableType.Name}!");

            _tables[tableType] = new List<T>();
        }

        public void InsertInto<T>(IEntityFactory<T> values) where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");

            ((List<T>)_tables[tableType]).Add(values.Instance);
        }

        public IEnumerable<T> Table<T>() where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");

            return (IEnumerable<T>)_tables[tableType];
        }

        public void WriteTable<T>() where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");

            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T[]));

            using (FileStream fs = new FileStream($"DB{tableType.Name}.json", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                dataContractJsonSerializer.WriteObject(fs, Table<T>().ToArray());
            }
        }

        public void WriteDataBase()
        {
            foreach (var key in _tables.Keys)
            {
                var fooRef = typeof(DataBase).GetMethod("WriteTable").MakeGenericMethod(key);
                fooRef.Invoke(this, null);
            }
        }

        public void ReadTable<T>() where T : IEntity
        {
            Type tableType = typeof(T);

            CreateTable<T>();

            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T[]));

            using (FileStream fs = new FileStream($"DB{tableType.Name}.json", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                T[] data = (T[])dataContractJsonSerializer.ReadObject(fs);
                foreach (var entry in data) ((List<T>)_tables[tableType]).Add(entry);
            }
        }

        public void LoadDataBase()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string[] filePaths = Directory.GetFiles(currentDirectory, "DB*.json");

            foreach (var filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                string typeName = fileName.Replace("DB", "").Replace(".json", "");

                Type tableType;
                try
                {
                    tableType = Type.GetType("DataBaseTask2." + typeName);
                } catch
                {
                    continue;
                }

                if (tableType == null) continue;

                var fooRef = typeof(DataBase).GetMethod("ReadTable").MakeGenericMethod(tableType);
                fooRef.Invoke(this, null);
            }
        }
    }
}
