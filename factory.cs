// Интерфейс платежа
public interface IPayment
{
    void ProcessPayment(); // Выполнение платежа
    bool ValidatePaymentDetails();  // Проверка данных
    string GetTransactionStatus(); // Статус транзакции
}

// Кредитная карта
public class CreditCardPayment : IPayment
{
    public void ProcessPayment()
    {
        Console.WriteLine("Оплата кредитной картой выполнена");
    }

    public bool ValidatePaymentDetails()
    {
        Console.WriteLine("Проверка данных карты");
        return true;
    }

    public string GetTransactionStatus()
    {
        return "Платеж через карту прошел успешно";
    }
}

// Электронный кошелёк
public class EWalletPayment : IPayment
{
    public void ProcessPayment()
    {
        Console.WriteLine("Оплата через электронный кошелёк выполнена");
    }

    public bool ValidatePaymentDetails()
    {
        Console.WriteLine("Проверка данных электронного кошелька");
        return true;
    }

    public string GetTransactionStatus()
    {
        return "Платеж через кошелёк прошел успешно";
    }
}

// Банковский перевод
public class BankTransferPayment : IPayment
{
    public void ProcessPayment()
    {
        Console.WriteLine("Банковский перевод выполнен");
    }

    public bool ValidatePaymentDetails()
    {
        Console.WriteLine("Проверка банковских реквизитов");
        return true;
    }

    public string GetTransactionStatus()
    {
        return "Банковский перевод прошел успешно";
    }
}

// Криптовалюта
public class CryptoPayment : IPayment
{
    public void ProcessPayment()
    {
        Console.WriteLine("Оплата криптовалютой выполнена");
    }

    public bool ValidatePaymentDetails()
    {
        Console.WriteLine("Проверка криптокошелька");
        return true;
    }

    public string GetTransactionStatus()
    {
        return "Криптоплатеж прошел успешно";
    }
}

// Фабрика платежей 
public static class PaymentFactory 
{
    // Создание объекта оплаты в зависимости от выбранного типа
    public static IPayment CreatePayment(string paymentType)
    {
        switch (paymentType)
        {
            case "card":
                return new CreditCardPayment();
            case "wallet":
                return new EWalletPayment();
            case "bank":
                return new BankTransferPayment();
            case "crypto":
                return new CryptoPayment();
            default:
                throw new Exception("Неизвестный способ оплаты");
        }
    }
}

// Клиентский код (пример)
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите способ оплаты: card / wallet / bank / crypto");
        string choice = Console.ReadLine();

        IPayment payment = PaymentFactory.CreatePayment(choice);

        if (payment.ValidatePaymentDetails())
        {
            payment.ProcessPayment();
            Console.WriteLine(payment.GetTransactionStatus());
        }
        else
        {
            Console.WriteLine("Ошибка проверки данных платежа");
        }

        Console.ReadLine();
    }
}
