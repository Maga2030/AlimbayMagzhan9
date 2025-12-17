// Интерфейс платежа
public interface IPayment
{
    void ProcessPayment();
    bool ValidatePaymentDetails();
    string GetTransactionStatus();
}