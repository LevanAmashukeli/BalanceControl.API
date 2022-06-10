using BalanceControl.Application.Interfaces;
using Balances;

namespace BalanceControl.Application.Models
{
    public class ResponseViewModel<T> : IResponse<T>
    {
        public ErrorCode ErrorCode { get; set; } = ErrorCode.Success;
        public string StatusMessage { get; set; }
    }
}
