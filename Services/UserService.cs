using Google.Apis.Auth;
using StudyMapAPI.Data;
using StudyMapAPI.DTOs;
using StudyMapAPI.Repository;

namespace StudyMapAPI.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<UserDTO> LoginAsync(string googleToken)
        {
            var payload = await ValidateGoogleToken(googleToken);
            var user = await _userRepository.GetByGoogleIdAsync(payload.Subject);

            if (user == null)
            {
                user = new User
                {
                    GoogleId = payload.Subject,
                    Name = payload.Name,
                    Email = payload.Email,
                };

                await _userRepository.AddAsync(user);
            }

            return new UserDTO
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                Coins = user.Coins,
            };

        }

        private async Task<GoogleJsonWebSignature.Payload> ValidateGoogleToken(string token)
        {
            return await GoogleJsonWebSignature.ValidateAsync(token);
        }

        public async Task<UserDTO> RegisterAsync(RegisterDTO registerDto)
        {
            var userExists = await _userRepository.GetByEmailAsync(registerDto.Email);
            if (userExists != null)
            {
                throw new Exception("User with this email already exists.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            var user = new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                AuthProvider = "Local",
                Coins = 30 // initialCoins
            };

            await _userRepository.AddAsync(user);

            return new UserDTO
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                Coins = user.Coins,
            };

        }

        public async Task<UserDTO> LoginLocalAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || user.AuthProvider != "Local")
            {
                throw new Exception("Invalid credentials");
            }

            // BCrypt automatically handles the salt since it's embedded in the hash.
            bool valid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            if (!valid)
            {
                throw new Exception("Invalid credentials");
            }

            return new UserDTO
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email,
                Coins = user.Coins,
            };
        }
    }
}
