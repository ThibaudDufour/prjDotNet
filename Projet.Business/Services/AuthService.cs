using AutoMapper;
using Projet.Datas.Entities;
using Projet.Datas.Repositories;

namespace Projet.Business.Auth
{
    public class AuthService
    {
        private readonly LoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public AuthService()
        {
			_loginRepository = new LoginRepository();
            _mapper = MappingConfig.Mapper;
		}

        public async Task<int> Register(string nom, string email, string password)
        {
			var existUser = await _loginRepository.GetByEmail(email);
			if (existUser != null)
			{
				return -1;
			}

			var user = new LoginUserDto
			{
				Name = nom,
				Email = email
			};
			user.SetPassword(password);

			return await _loginRepository.Add(_mapper.Map<LoginUser>(user));
		}

        public async Task<LoginUserDto?> Login(string email, string password)
        {
			var user = await _loginRepository.GetByEmail(email);
			var userDto = _mapper.Map<LoginUserDto>(user);

			if (userDto == null || !userDto.VerifyPassword(password))
			{
				return null;
			}
			
			return userDto;
		}
    }
}
