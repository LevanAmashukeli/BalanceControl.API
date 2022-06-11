using Balances;

namespace BalanceControl.Services.Common.Interfaces
{
    public interface IResponse<T>
    {
        ErrorCode ErrorCode { get; set; }
        string StatusMessage { get; set; }
    }
}
