using LibraryManagementSystem.DataAccess.Interfaces;
using LibraryManagementSystem.Domain.Domain;
using LibraryManagementSystem.Dtos.Admins;
using LibraryManagementSystem.Dtos.Users;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace LibraryManagementSystem.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        //a method that authenticates an Admin when logging in using a token
        public AdminDto Authenticate(LogInDto model)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(model.Password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);
            var admin = _adminRepository.GetAdmin().SingleOrDefault(x => x.Username == model.UserName && x.Password == hashedPassword);
            if (admin == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Our very secret secret key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, $"{admin.Firstname} {admin.Lastname}"),
                        new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString())
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            //mapping
            var adminModel = new AdminDto()
            {
                Firstname = admin.Firstname,
                Lastname = admin.Lastname,
                Username = admin.Username,
                Email = admin.Email,
                Token = tokenHandler.WriteToken(token)
            };
            return adminModel;
        }
        //a log in method that returns a token, later used for authorization
        public string Login(LogInDto logInDto)
        {
            //validation
            if (string.IsNullOrEmpty(logInDto.UserName) || string.IsNullOrEmpty(logInDto.Password))
            {
                throw new Exception("Username and password are required fields.");
            }
            //generating hash
            string hash = GenerateHash(logInDto.Password);
            Admin admin = _adminRepository.GetAdmin().SingleOrDefault(x => x.Username == logInDto.UserName && x.Password == hash);
            if (admin == null)
            {
                throw new Exception("Invalid admin login.");
            }

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes("Our very secret secret key");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
        new[]
        {
                        new Claim(ClaimTypes.Name, $"{admin.Firstname} {admin.Lastname}"),
                        new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString())
        }
        ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            //generate token
            SecurityToken token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            //convert to string
            string resultToken = jwtSecurityTokenHandler.WriteToken(token);
            return resultToken;
        }
        //a method that generates hashed password
        private static string GenerateHash(string password)
        {
            //MD5 has algorithm
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();

            //Test123 - get the bytes => 5678432
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

            //hash the bytes => 5678432 -> 6493873
            byte[] hashedBytes = mD5CryptoServiceProvider.ComputeHash(passwordBytes);

            //get a string from the hashed bytes, 6493873 => qsd546f
            return Encoding.ASCII.GetString(hashedBytes);
        }
        //a method used for registering(adding) Admin entity
        public void Register(AddAdminDto model)
        {
            //validation
            if (string.IsNullOrEmpty(model.Firstname))
                throw new Exception("First name is required");
            if (string.IsNullOrEmpty(model.Lastname))
                throw new Exception("Last name is required");
            if (string.IsNullOrEmpty(model.UserName))
                throw new Exception("User name is required.");
            if (string.IsNullOrEmpty(model.Email))
                throw new Exception("Email is required");
            if (model.Password != model.ConfirmPassword)
                throw new Exception("Passwords did not match!");

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(model.Password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);
            //mapping
            var admin = new Admin()
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Username = model.UserName,
                Email = model.Email,
                Password = hashedPassword
            };
            //calling repository to add Admin entity
            _adminRepository.Add(admin);
        }
    }
}
