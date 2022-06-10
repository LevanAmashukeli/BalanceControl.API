using Balances;

namespace BalanceControl.Shared.Handler
{
    public static class IsNotSuccessHandler
    {
        public static bool IsNotSuccess(this ErrorCode source)
        {
            return source != ErrorCode.Success;
        }
    }
}
