namespace Zabota.Mapper;

public interface IMapper<T, K>
{
    K ToDto(T model);
    T ToModel(K dto);
}