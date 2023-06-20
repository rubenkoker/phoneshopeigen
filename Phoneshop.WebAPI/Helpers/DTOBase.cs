using Mapster;

namespace Phoneshop.WebAPI.Helpers
{
    public abstract class DTOBase<TEntity> : IRegister
        where TEntity : class, new()
    {
        public void Register(TypeAdapterConfig config)
        {
            var dtoToEntityMappingConfig = config.ForType(GetType(), typeof(TEntity));
            var entityToDTOMappingConfig = config.ForType(typeof(TEntity), GetType());

            RegisterCustomMappings(dtoToEntityMappingConfig, entityToDTOMappingConfig);
        }

        protected virtual void RegisterCustomMappings(TypeAdapterSetter dtoToEntityMappingConfig, TypeAdapterSetter entityToDTOMappingConfig)
        {
        }
    }
}