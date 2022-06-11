
namespace BalanceControl.Shared.Handler
{
    public static class IsNullHandler
    {
        public static bool IsNull(this object source)
        {
            return source == null;
        }
    }
}
