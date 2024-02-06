using AutoMapper;
using HarmonogramyWebAPI.Dto;
using HarmonogramyWebAPI.Generic;
using HarmonogramyWebAPI.Interfaces;
using HarmonogramyWebAPI.Models;

namespace HarmonogramyWebAPI.Services;

public class UserService(IContext dbContext, IMapper mapper, IConfiguration configuration)
    : GenericCrudService<User, UserDto>(dbContext, mapper)
{
    public async Task<UserDto?> Authenticate(string email, string password)
    {
        var user = await GetBy(x => x.Email == email);
        if (user is null)
        {
            return null;
        }

        return !Security.VerifyPassword(configuration, password, user.Password!) ? null : user;
    }

    public bool IsActive(User user)
    {
        return user.IsActive;
    }

    public bool IsSuperuser(User user)
    {
        return user.IsSuperUser;
    }
}