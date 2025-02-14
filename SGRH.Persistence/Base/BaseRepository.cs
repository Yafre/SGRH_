using SGRH.Domain.Repository;

namespace SGRH.Persistence.Base
{
    public abstract class BaseRepository <TEntity, TType> : <IBaseRepository <TEntity, TType> where TEntity : class
    {
    }
}
