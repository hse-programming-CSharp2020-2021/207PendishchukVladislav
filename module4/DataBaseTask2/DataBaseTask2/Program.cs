using System;
using System.Linq;

namespace DataBaseTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase("ShopDataBase");

            db.CreateTable<Good>();
            db.CreateTable<Shop>();
            db.CreateTable<Buyer>();
            db.CreateTable<Sale>();

            db.InsertInto<Shop>(new ShopFactory("Auchan", "Moscow", "Krasnoselsky", "Russia", 88000000000));
            db.InsertInto<Shop>(new ShopFactory("Magnit", "Moscow", "Ostankino", "Russia", 88000000001));
            db.InsertInto<Shop>(new ShopFactory("METRO", "Berlin", "Rudolfkiez", "Germany", 88000000002));

            db.InsertInto<Good>(new GoodFactory("Pepsi", 1, "A sweet beverage", "Drinks"));
            db.InsertInto(new GoodFactory("3 korochki", 1, "Smth idk", "Food"));
            db.InsertInto(new GoodFactory("Ohota", 2, "A beer I guess", "Drinks"));
            db.InsertInto(new GoodFactory("Lays", 2, "Dem chips", "Food"));
            db.InsertInto(new GoodFactory("Ritter Sport", 3, "Chocolade bar", "Food"));

            db.InsertInto(new BuyerFactory("Ivan", "Sizov", "Lenina, 4", "Moscow", "Kitay-Gorod", "Russia", 111111));
            db.InsertInto(new BuyerFactory("Grigoriy", "Derevyanko", "Marksa, 4", "Moscow", "Tverskoy", "Russia", 111112));
            db.InsertInto(new BuyerFactory("Pavel", "Razin", "Engelsa, 4", "Moscow", "Basmannyy", "Russia", 111113));

            db.InsertInto(new SaleFactory(1, 1, 2, 3, 23));
            db.InsertInto(new SaleFactory(1, 1, 1, 10, 120));
            db.InsertInto(new SaleFactory(2, 2, 3, 10, 120));
            db.InsertInto(new SaleFactory(3, 2, 4, 10, 220));
            db.InsertInto(new SaleFactory(3, 2, 3, 12, 23));
            db.InsertInto(new SaleFactory(3, 3, 5, 12, 23));

            // Запрос, позволяющий вывести все товары, купленные покупателем с самым длинным именем.
            var maxLengthNameBuyerSales = (db.Table<Sale>()).Where(x => x.BuyerID == (db.Table<Buyer>()).OrderByDescending(y => y.Name.Length).First().Id);

            foreach (var sale in maxLengthNameBuyerSales)
            {
                Console.WriteLine(sale.Id);
            }
            Console.WriteLine();

            // Запрос, позволяющий найти категорию самого дорого товара.
            var mostExpensiveGoodCategory = db.Table<Good>().Where(y => y.Id == db.Table<Sale>().OrderByDescending(x => x.Price).First().GoodID).First().Category;

            Console.WriteLine(mostExpensiveGoodCategory);
            Console.WriteLine();

            // Запрос, позволяющий найти город, в котором общая сумма всех продаж наименьшая.
            var leastIncomeCity = (db.Table<Shop>()).GroupJoin (db.Table<Sale>(), t => t.Id, pl => pl.ShopID, (shop, sales) => new { City = shop.City, Income = sales.Sum(sale => sale.Price) }).
                                    GroupBy(t => t.City, t => t.Income).Select(g => Tuple.Create(g.Key, g.Sum())).OrderBy(g => g.Item2).First().Item1;

            Console.WriteLine(leastIncomeCity);
            Console.WriteLine();

            // Запрос, позволяющий найти фамилии покупателей, купивших самый популярный товар.
            var mostPopularGoodBuyers = db.Table<Buyer>().Where(x => ((db.Table<Sale>()).Where(buyer => buyer.GoodID == (db.Table<Sale>())
                                        .GroupBy(t => t.GoodID, t => t.Amount).Select(g => Tuple.Create(g.Key, g.Sum())).OrderByDescending(g => g.Item2).First().Item1)
                                        .Select(id => id).GroupBy(y => y.BuyerID).Select(r => r.Key)).ToList().Contains(x.Id)).Select(b => b.LastName);

            foreach (var entry in mostPopularGoodBuyers) Console.WriteLine(entry);
            Console.WriteLine();

            // Запрос, позволяющий найти количество магазинов в стране, где их меньше всего.
            var countryWithALeastAmountOfShops = db.Table<Shop>().GroupBy(x => x.Country).Select(g => Tuple.Create(g.Key, g.Count())).OrderBy(t => t.Item2).First().Item1;

            Console.WriteLine(countryWithALeastAmountOfShops);
            Console.WriteLine();

            // Запрос, позволяющий найти покупки, которые были сделаны не в своем городе.
                       var acrossTheBorderSales = db.Table<Sale>().Where(x => (db.Table<Buyer>().Where(t => t.Id == x.BuyerID).Select(buyer => buyer).First().Country) !=
                                        (db.Table<Shop>().Where(t => t.Id == x.ShopID).Select(shop => shop).First().Country)).Select(x => x.Id);

            foreach (var entry in acrossTheBorderSales) Console.WriteLine(entry);
            Console.WriteLine();

            // Запрос, позволяющий найти общую стоимость всех покупок.
            var totalPrice = db.Table<Sale>().Select(x => x.Amount * x.Price).Sum();
            Console.WriteLine(totalPrice);

            Console.ReadKey();
        }
    }
}