using Balances;

namespace BalanceControl.Application.Interfaces
{
    public interface IResponse<T>
    {
        ErrorCode ErrorCode { get; set; }
        string StatusMessage { get; set; }
        T Model { get; set; }
    }
}
