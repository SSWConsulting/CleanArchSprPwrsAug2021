using CaWorkshop.Application.Common.Exceptions;

namespace CaWorkshop.Application.Common.Extensions
{
    public static class GuardClauseExtensions
    {
        public static void NotFound<T>(this Ardalis.GuardClauses.IGuardClause guardClause, T entity, object key)
        {
            if (entity is null)
                throw new NotFoundException(typeof(T).Name, key);
        }
    }
}
