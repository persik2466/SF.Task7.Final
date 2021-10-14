using System;

namespace SF.Task7.Final
{
    //Класс заказ
    public class Order
    {
        public int Number;
        public double SumOrder;
        public int CountOrder;

        private Random random = new Random();
        public Order()
        {
            Number = random.Next(1000000000);
            SumOrder = 0;
            CountOrder = 0;
        }

        //Класс покупатель
        public class User
        {
            public String fio;
            public String adress;
            public String tel;
            /// <summary>
            /// Информация о покупателе
            /// </summary>
            public void InfoUser()
            {
                Console.WriteLine("{0} вы зарегистрировались, ваш адрес {1}, ваш телефон {2}", fio, adress, tel);
            }
        }

        //Класс продукт
        public class Product
        {
            public String nameProduct;
            public String typeProduct;
            public double cost;
            public double Cost
            {
                get { return cost; }
                set
                {
                    if (value > 0)
                    {
                        cost = value;
                    }
                    else
                    {
                        Console.WriteLine("У товара не определена цена");
                    }
                }
            }

            /// <summary>
            /// Информация о продукте
            /// </summary>
            public void InfoProduct()
            { Console.WriteLine("Вы добавили товар {0}, категория товара {1}, цена {2} руб.", nameProduct, typeProduct, cost); }
        }
        public void DisplayOrder()
        {
            Console.WriteLine("Номер заказа {0}, количество товаров {1}, сумма заказа {2} руб.", Number, CountOrder, SumOrder);
        }

         Product[] p; 
        /// <summary>
        /// добавление продукта
        /// </summary>
        /// <param name="p"></param>
         public void AddProduct(Product p)
        {
            CountOrder++;
            SumOrder += p.cost;
            p.InfoProduct();
            DisplayOrder();
        }

        /// <summary>
        /// Товары в заказе
        /// </summary>
        /// <param name="p"></param>
        public void ListProduct(Product[] p)
        {
            Console.WriteLine("Сформирован заказ:");
            DisplayOrder();
            Console.WriteLine("Товары вашего заказа:");
            for (int i = 0; i < CountOrder; i++)
            {
                Console.WriteLine("{0}, категория {1}, цена {2} руб.", p[i].nameProduct, p[i].typeProduct, p[i].cost);
            }
        }
    }

    abstract class Delivery
    {
        public string Address;
        public int Number;
        /// <summary>
        /// перемещение товара
        /// </summary>
        public abstract void Move();
    }

    class HomeDelivery : Delivery
    {
        private string Courier;
        public HomeDelivery()
        {
            Courier = "'Служба доставки Ласточка'";

        }
        public override void Move()
        {
            Console.WriteLine("Заказ {0} будет доставлен по адресу {1} службой {2}", Number, Address, Courier);
        }
    }

    class PickPointDelivery : Delivery
    {
        public PickPointDelivery()
        {
            Address = "Почтомат №1";

        }
        public override void Move()
        {
            Console.WriteLine("Зааказ {0} будет доставлен в пункт выдачи {1}", Number, Address);
        }
    }

    class ShopDelivery : Delivery
    {
        private string Shop;
        public ShopDelivery()
        {
            Shop = "'Улыбка радуги'";

        }
        public override void Move()
        {
            Console.WriteLine("Заказ {0} находится в магазине {1}", Number, Shop);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Проект: сколько успела - столько натупила
            //Уровень: Минус базовый

            Order.User user = new Order.User();

            Console.WriteLine("Введите своё ФИО");
            user.fio = Console.ReadLine();

            Console.WriteLine("Введите свой адрес");
            user.adress = Console.ReadLine();

            Console.WriteLine("Введите свой телефон");
            user.tel = Console.ReadLine();

            user.InfoUser();
            Console.WriteLine();

            Order ord = new Order();
            int n = 3; //количество товаров, которое возможно купить

            Order.Product[] prod = new Order.Product[n];

            //Выбор товара не успела сделать, поэтому просто добавляю
            prod[0] = new Order.Product { nameProduct = "Творог", typeProduct = "Молочные продукты", cost = 50.00 };
            ord.AddProduct(prod[0]);

            prod[1] = new Order.Product { nameProduct = "Макароны", typeProduct = "Мучные изделия", cost = 35.50 };
            ord.AddProduct(prod[1]);

            prod[2] = new Order.Product { nameProduct = "Ведро", typeProduct = "Хозтовары", cost = 99.99 };
            ord.AddProduct(prod[2]);

            Console.WriteLine();
            Console.WriteLine("Выберите доставку: 1 - курьером, 2 - в пункт выдачи, 3 - получить в магазине");
            int nshop = Convert.ToInt32(Console.ReadLine());

            ord.ListProduct(prod);
            Console.WriteLine();

            switch (nshop)
            {
                case 1:
                    HomeDelivery deliv1 = new HomeDelivery { Address = user.adress, Number = ord.Number };
                    deliv1.Move();
                    break; 
                case 2:
                    PickPointDelivery deliv2 = new PickPointDelivery { Number = ord.Number };
                    deliv2.Move();
                    break;
                case 3:
                    ShopDelivery deliv3 = new ShopDelivery { Number = ord.Number };
                    deliv3.Move();
                    break;
            }

            Console.ReadKey();
        }
    }

}
