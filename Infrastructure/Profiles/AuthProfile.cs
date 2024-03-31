using AutoMapper;
using Infrastructure.Authentication;

using Core.Entites.Identity;

namespace Infrastructure.Profiles
{
    public class AuthProfile :Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterModel, User>();


        }


    }
}
