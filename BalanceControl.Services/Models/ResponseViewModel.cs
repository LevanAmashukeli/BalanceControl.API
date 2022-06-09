using BalanceControl.Services.Interfaces;
using Balances;

namespace BalanceControl.Services.Models
{
    public class ResponseViewModel<T> : IResponse<T>
    {
        public ErrorCode ErrorCode { get; set; } = ErrorCode.Success;
        public string StatusMessage { get; set; }
        public T Model { get; set; }
    }
}
