using System;

namespace ClassLibrary
{
    public class Street
    {
        public string Name { get; private set; }
        public int[] Houses { get; private set; }

        public Street(string name, int[] houses)
        {
            Name = name;
            Houses = houses;
        }

        public static int operator ~(Street street)
        {
            return street.Houses.Length;
        }

        public static bool operator !(Street street)
        {
            bool isPresent = false;
            foreach (var num in street.Houses)
            {
                if (num == 7) {
                    isPresent = true;
                    break;
                }
            }

            return isPresent;
        }

        public override string ToString()
        {
            return $"Name: {Name}, houses: {string.Join(", ", Houses)}";
        }
    }
}
