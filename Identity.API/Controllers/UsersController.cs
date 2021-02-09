using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestWeb.API.Entities;
using TestWeb.API.Models;
using TestWeb.API.Repositories;

namespace TestWeb.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;

        public UsersController(IUserRepository userRepository, IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }
        
        [HttpGet("GetById")]
        public UserEntity GetById(long id)
        {
            return _userRepository.Get().First(u => u.Id == id);
        }

        [HttpGet("GetByEmail")]
        public IEnumerable<UserEntity> GetByEmail(string email)
        {
            return _userRepository.Get().Where(u => u.Email == email);
        }

        [HttpGet("GetByCountry")]
        public IEnumerable<UserEntity> GetByAddress(string country)
        {
            return _userRepository.Get().Where(u => u.AddressEntity.Country == country);
        }

        [HttpPost("Create")]
        public void Create([FromBody] UserRequest request)
        {
            AddressEntity addressEntity = _addressRepository.Save(new AddressEntity()
            {
                Country = request.Country,
                City = request.City,
                Street = request.Street,
                StreetNumber = request.StreetNumber,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                PostalCode = request.PostalCode,
                State = request.State,
                FlatNumber = request.FlatNumber
            });

            _userRepository.Save(new UserEntity()
            {
                AddressEntity = addressEntity,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            });
        }
    }
}