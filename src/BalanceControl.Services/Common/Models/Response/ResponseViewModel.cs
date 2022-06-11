using BalanceControl.Services.Common.Interfaces;
using Balances;

namespace BalanceControl.Services.Models.Response
{
    public class ResponseViewModel<T> : IResponse<T>
    {
        public ErrorCode ErrorCode { get; set; } = ErrorCode.Success;
        public string StatusMessage { get; set; }
    }
}
