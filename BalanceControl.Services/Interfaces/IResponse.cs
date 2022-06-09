using Balances;

namespace BalanceControl.Services.Interfaces
{
    public interface IResponse<T>
    {
        ErrorCode ErrorCode { get; set; }
        string StatusMessage { get; set; }
        T Model { get; set; }
    }
}
