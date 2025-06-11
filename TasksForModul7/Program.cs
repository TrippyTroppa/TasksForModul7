using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TasksForModul7;

namespace TasksForModul7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Базовые классы для системы
    public abstract class Delivery
    {
        public Address Address { get; protected set; }
        public abstract decimal CalculateDeliveryCost();
        public abstract DateTime EstimatedDeliveryDate { get; }
    }

    public class HomeDelivery : Delivery
    {
        public CourierService CourierService { get; }
        public string RecipientContactPhone { get; set; }
        public DateTime PreferredDeliveryTime { get; set; }

        public HomeDelivery(Address address, CourierService courierService, string phone)
        {
            Address = address;
            CourierService = courierService;
            RecipientContactPhone = phone;
        }

        public override decimal CalculateDeliveryCost()
        {
            return CourierService.BaseRate + (Address.IsRemoteArea ? 300 : 0);
        }

        public override DateTime EstimatedDeliveryDate => DateTime.Now.AddDays(CourierService.DeliveryDays);
    }

    public class PickPointDelivery : Delivery
    {
        public string PickPointId { get; }
        public string CompanyName { get; }
        public int StorageDays { get; } = 7;

        public PickPointDelivery(Address address, string pickPointId, string companyName)
        {
            Address = address;
            PickPointId = pickPointId;
            CompanyName = companyName;
        }

        public override decimal CalculateDeliveryCost()
        {
            return 150m; // фиксированная ставка для пунктов выдачи
        }

        public override DateTime EstimatedDeliveryDate => DateTime.Now.AddDays(3);
    }

    public class ShopDelivery : Delivery
    {
        public string ShopId { get; }
        public string ManagerContact { get; }

        public ShopDelivery(Address address, string shopId, string managerContact)
        {
            Address = address;
            ShopId = shopId;
            ManagerContact = managerContact;
        }

        public override decimal CalculateDeliveryCost() => 0; // бесплатная доставка в магазин

        public override DateTime EstimatedDeliveryDate => DateTime.Now.AddDays(2);
    }

    // Класс для работы с адресами
    public class Address
    {
        public string City { get; }
        public string Street { get; }
        public string Building { get; }
        public string Apartment { get; }
        public string PostalCode { get; }
        public bool IsRemoteArea { get; }

        public Address(string city, string street, string building, string apartment, string postalCode, bool isRemote = false)
        {
            City = city;
            Street = street;
            Building = building;
            Apartment = apartment;
            PostalCode = postalCode;
            IsRemoteArea = isRemote;
        }

        public override string ToString() => $"{PostalCode}, {City}, {Street} {Building}, кв. {Apartment}";
    }

    // Класс для товаров
    public abstract class Product
    {
        public string Id { get; }
        public string Name { get; }
        public decimal Price { get; protected set; }
        public string Description { get; }
        public abstract string ProductType { get; }

        protected Product(string id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }
    }

    public class PhysicalProduct : Product
    {
        public double Weight { get; }
        public Dimensions Dimensions { get; }
        public override string ProductType => "Physical";

        public PhysicalProduct(string id, string name, decimal price, string description,
                             double weight, Dimensions dimensions)
            : base(id, name, price, description)
        {
            Weight = weight;
            Dimensions = dimensions;
        }
    }

    public class DigitalProduct : Product
    {
        public string DownloadLink { get; }
        public override string ProductType => "Digital";

        public DigitalProduct(string id, string name, decimal price, string description, string downloadLink)
            : base(id, name, price, description)
        {
            DownloadLink = downloadLink;
        }

       
    }

    public class Dimensions
    {
        public double Length { get; }
        public double Width { get; }
        public double Height { get; }

        public Dimensions(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Volume => Length * Width * Height;
    }

    // Класс для курьерских служб
    public class CourierService
    {
        public string Name { get; }
        public decimal BaseRate { get; }
        public int DeliveryDays { get; }
        public string ContactNumber { get; }

        public CourierService(string name, decimal baseRate, int deliveryDays, string contactNumber)
        {
            Name = name;
            BaseRate = baseRate;
            DeliveryDays = deliveryDays;
            ContactNumber = contactNumber;
        }
    }

    // Класс заказа с обобщениями
    public class Order<TDelivery, TProduct>
        where TDelivery : Delivery
        where TProduct : Product
    {
        private static int _lastOrderNumber = 0;

        public int Number { get; }
        public TDelivery Delivery { get; }
        public List<OrderItem<TProduct>> Items { get; }
        public DateTime OrderDate { get; }
        public Customer Customer { get; }
        public OrderStatus Status { get; private set; }

        public decimal TotalPrice => Items.Sum(item => item.TotalPrice) + Delivery.CalculateDeliveryCost();
        public int TotalItems => Items.Sum(item => item.Quantity);

        public Order(TDelivery delivery, Customer customer)
        {
            Number = ++_lastOrderNumber;
            Delivery = delivery;
            Customer = customer;
            Items = new List<OrderItem<TProduct>>();
            OrderDate = DateTime.Now;
            Status = OrderStatus.New;
        }

        public void AddProduct(TProduct product, int quantity = 1)
        {
            var existingItem = Items.FirstOrDefault(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new OrderItem<TProduct>(product, quantity));
            }
        }

        public bool RemoveProduct(string productId, int quantity = 1)
        {
            var item = Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item == null) return false;

            if (item.Quantity <= quantity)
            {
                Items.Remove(item);
            }
            else
            {
                item.Quantity -= quantity;
            }
            return true;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }

        public void DisplayOrderInfo()
        {
            Console.WriteLine($"Заказ №{Number}");
            Console.WriteLine($"Статус: {Status}");
            Console.WriteLine($"Дата заказа: {OrderDate:g}");
            Console.WriteLine($"Клиент: {Customer.Name}");
            Console.WriteLine($"Адрес доставки: {Delivery.Address}");
            Console.WriteLine($"Тип доставки: {Delivery.GetType().Name}");
            Console.WriteLine($"Стоимость доставки: {Delivery.CalculateDeliveryCost():C}");
            Console.WriteLine("\nТовары:");

            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Product.Name} x{item.Quantity} - {item.TotalPrice:C}");
            }

            Console.WriteLine($"\nИтого: {TotalPrice:C}");
            Console.WriteLine($"Предполагаемая дата доставки: {Delivery.EstimatedDeliveryDate:d}");
        }
    }

    public class OrderItem<T> where T : Product
    {
        public T Product { get; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;

        public OrderItem(T product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }

    public enum OrderStatus
    {
        New,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    public class Customer
    {
        public string Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Phone { get; }
        public List<Address> Addresses { get; }

        public Customer(string id, string name, string email, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Addresses = new List<Address>();
        }

        public void AddAddress(Address address)
        {
            Addresses.Add(address);
        }

        public bool RemoveAddress(Address address)
        {
            return Addresses.Remove(address);
        }
    }

    // Статический класс для работы с заказами
    public static class OrderManager
    {
        private static readonly List<object> _allOrders = new List<object>();

        public static void AddOrder<TDelivery, TProduct>(Order<TDelivery, TProduct> order)
            where TDelivery : Delivery
            where TProduct : Product
        {
            _allOrders.Add(order);
        }

        public static IEnumerable<Order<TDelivery, TProduct>> GetOrdersByCustomer<TDelivery, TProduct>(string customerId)
            where TDelivery : Delivery
            where TProduct : Product
        {
            return _allOrders.OfType<Order<TDelivery, TProduct>>()
                             .Where(o => o.Customer.Id == customerId);
        }

        public static int GetTotalOrdersCount() => _allOrders.Count;
    }

    // Методы расширения
    public static class OrderExtensions
    {
        public static void ApplyDiscountToOrder<TDelivery, TProduct>(this Order<TDelivery, TProduct> order, decimal discountPercent)
            where TDelivery : Delivery
            where TProduct : Product
        {
            foreach (var item in order.Items)
            {
                item.Product.ApplyDiscount(discountPercent);
            }
        }

        public static string GetDeliveryInfo<TDelivery>(this TDelivery delivery) where TDelivery : Delivery
        {
            return $"Адрес: {delivery.Address}. Примерная дата доставки: {delivery.EstimatedDeliveryDate:d}";
        }
    }

    // Пример использования
    class Program
    {
        static void Main()
        {
            // Создаем клиента
            var customer = new Customer("cust1", "Иван Иванов", "ivan@example.com", "+79991234567");
            customer.AddAddress(new Address("Москва", "Ленина", "10", "25", "123456"));

            // Создаем продукты
            var laptop = new PhysicalProduct("prod1", "Ноутбук", 50000, "Мощный ноутбук", 2.5, new Dimensions(40, 25, 3));
            var ebook = new DigitalProduct("prod2", "Электронная книга", 500, "Интересная книга", "http://example.com/download/123");

            // Создаем службу доставки
            var courierService = new CourierService("FastDelivery", 500, 2, "+78005553535");

            // Создаем доставку
            var homeDelivery = new HomeDelivery(customer.Addresses[0], courierService, customer.Phone);

            // Создаем заказ
            var order = new Order<HomeDelivery, Product>(homeDelivery, customer);
            order.AddProduct(laptop);
            order.AddProduct(ebook, 2);

            // Добавляем заказ в менеджер заказов
            OrderManager.AddOrder(order);

            // Выводим информацию о заказе
            order.DisplayOrderInfo();

            // Используем метод расширения
            Console.WriteLine("\nИнформация о доставке:");
            Console.WriteLine(homeDelivery.GetDeliveryInfo());
        }
    }
}