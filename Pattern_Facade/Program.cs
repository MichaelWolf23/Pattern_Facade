using System;
using System.Collections.Generic;

class Warehouse
{
    public bool CheckProduct(string name)
    {
        Console.WriteLine($"[Склад]: Поиск товара '{name}' в базе данных...");
        Thread.Sleep(1000);
        return true;
    }
}

class PaymentSystem
{
    public bool ProcessPayment(double amount)
    {
        Console.WriteLine($"[Банк]: Запрос на списание {amount} руб. подтвержден.");
        return true;
    }
}

class DeliveryService
{
    public void CreateLabel(string name)
    {
        Console.WriteLine($"[Логистика]: Трек-номер для '{name}' создан. Курьер назначен.");
    }
}


class OrderFacade
{
    private Warehouse _warehouse = new Warehouse();
    private PaymentSystem _payment = new PaymentSystem();
    private DeliveryService _delivery = new DeliveryService();

    public void PlaceOrder(string productName, double price)
    {
        Console.WriteLine("\n>>> ФАСАД: Начинаю обработку заказа...");

        if (_warehouse.CheckProduct(productName))
        {
            if (_payment.ProcessPayment(price))
            {
                _delivery.CreateLabel(productName);
                Console.WriteLine(">>> ФАСАД: Заказ успешно завершен!");
            }
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        OrderFacade shop = new OrderFacade();

        Console.WriteLine("=== ДОБРО ПОЖАЛОВАТЬ В МАГАЗИН ===");

        Console.Write("Что вы хотите купить? ");
        string item = Console.ReadLine();

        Console.Write("Введите сумму к оплате: ");
        if (double.TryParse(Console.ReadLine(), out double price))
        {
            shop.PlaceOrder(item, price);
        }
        else
        {
            Console.WriteLine("Ошибка: неверный формат цены.");
        }

        Console.WriteLine("\nНажмите любую клавишу, чтобы закрыть программу...");
        Console.ReadKey();
    }
}