using TestWeb.API.Entities;

namespace TestWeb.API.Repositories
{
    public interface IAddressRepository
    {
        AddressEntity Save(AddressEntity address);
    }
}