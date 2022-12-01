using Mapster;

namespace PhoneShop.API.Models
{
    public abstract class DTOBase<TEntity> : IRegister
        where TEntity : class, new()
    {
        public void Register(TypeAdapterConfig config)
        {
            var dtoToEntityMappingConfig = config.ForType(this.GetType(), typeof(TEntity));
            var entityToDTOMappingConfig = config.ForType(typeof(TEntity), this.GetType());

            RegisterCustomMappings(dtoToEntityMappingConfig, entityToDTOMappingConfig);
        }

        protected virtual void RegisterCustomMappings(TypeAdapterSetter dtoToEntityMappingConfig, TypeAdapterSetter entityToDTOMappingConfig)
        {
        }
    }
}
