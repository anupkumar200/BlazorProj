using BlazorProj.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BlazorProj.Clients.User
{
    public class UserClients
    {
        private readonly List<Users> users =
        [
            new(){
                Id = 1,
                FirstName = "Mark",
                LastName = "Hood",
                Email = "mark@gmail.com",
                Phone = "1234567890",
                Password = "Mark@123",
                Status = true,
                UpdatedOn = DateTime.Now,
                Role = "Administrator"
            },
            new(){
                Id = 2,
                FirstName = "John",
                LastName = "Wood",
                Email = "john@gmail.com",
                Phone = "1234567890",
                Password = "John@123",
                Status = false,
                UpdatedOn = DateTime.Now,
                Role = "Manager"
            },
            new(){
                Id = 3,
                FirstName = "Peter",
                LastName = "Parker",
                Email = "peter@gmail.com",
                Phone = "1234567890",
                Password = "Peter@123",
                Status = true,
                UpdatedOn = DateTime.Now,
                Role ="Employee"
            },
            new(){
                Id = 4,
                FirstName = "Wed",
                LastName = "William",
                Email = "william@gmail.com",
                Phone = "1234567890",
                Password = "Wed@123",
                Status = false,
                UpdatedOn = DateTime.Now
            },
            new(){
                Id = 5,
                FirstName = "Julio",
                LastName = "Casal",
                Email = "casal@gmail.com",
                Phone = "1234567890",
                Password = "Julio@123",
                Status = true,
                UpdatedOn = DateTime.Now
            }
        ];
        public Users[] GetUsers() => [.. users];

        public Users GetByUserName(string userName)
        {
            return users.FirstOrDefault(x => x.Email == userName);
        }
        public void AddUser(UserDetails objUser)
        {
            var user = new Users
            {
                Id = users.Count + 1,
                FirstName = objUser.FirstName,
                LastName = objUser.LastName,
                Email = objUser.Email,
                Phone = objUser.Phone,
                Password = objUser.Password,
                Status = objUser.Status,
                UpdatedOn = DateTime.Now
            };
            users.Add(user);
        }
        public UserDetails GetUser(long id)
        {
            Users users = GetUserById(id);
            return new UserDetails
            {
                Id = users.Id,
                FirstName = users.FirstName,
                LastName = users.LastName,
                Email = users.Email,
                Phone = users.Phone,
                Password = users.Password,
                Status = users.Status,
                UpdatedOn = DateTime.Now
            };
        }
        private Users GetUserById(long id)
        {
            Users? user = users.Find(user => user.Id == id);
            ArgumentNullException.ThrowIfNull(user);
            return user;
        }
        public void UpdateUser(UserDetails updateUser)
        {
            var existingUser = GetUserById(updateUser.Id);

            existingUser.FirstName = updateUser.FirstName;
            existingUser.LastName = updateUser.LastName;
            existingUser.Email = updateUser.Email;
            existingUser.Phone = updateUser.Phone;
            existingUser.Password = updateUser.Password;
            existingUser.Status = updateUser.Status;
            existingUser.UpdatedOn = DateTime.Now;
        }

        public void DeleteUser(long id)
        {
            var user = GetUserById(id);
            users.Remove(user);
        }

        public bool Authenticate(string username, string password)
        {
            return users.Any(u => u.Email == username && u.Password == password);
        }
    }
}
