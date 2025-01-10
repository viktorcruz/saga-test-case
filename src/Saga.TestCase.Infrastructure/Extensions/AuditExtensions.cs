namespace Saga.TestCase.Infrastructure.Extensions
{
    public static class AuditExtensions
    {
        public static string ToActionTypeName(this ActionType actionType)
        {
            return $"{actionType.ToString()}";
        }
    }
}
