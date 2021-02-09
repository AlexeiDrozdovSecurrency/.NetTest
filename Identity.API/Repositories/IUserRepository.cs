using System.Collections.Generic;
using TestWeb.API.Entities;

namespace TestWeb.API.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> Get();

        UserEntity Save(UserEntity user);
    }
}