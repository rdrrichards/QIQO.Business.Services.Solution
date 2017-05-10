namespace QIQO.Common.Contracts
{
    public interface IEntityService
    {
    }

    public interface IEntityService<TModel, TEntity> : IEntityService
        where TModel : IModel
        where TEntity : IEntity
    {
        TModel Map(TEntity ent);
        TEntity Map(TModel ent);
    }
}
