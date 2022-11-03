using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Handler;
using WebAPI.Model;
using WebAPI.Repositories.Interface;

namespace WebAPI.Repositories
{
    public class UserRepository : IRepository<User, int>
    {
        private readonly MyContext _context;

        public UserRepository(MyContext _context)
        {
            this._context = _context;
        }
        public int Create(User entity)
        {
             _context.Users.Add(entity);
            var data = _context.SaveChanges();
            return data;
        }

        public int Delete(int id)
        {
            var data = _context.Users.Find(id);
            if(data != null)
            {
                _context.Users.Remove(data);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public ICollection<User> Get()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public int Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var data = _context.SaveChanges();
            return data;
        }

   
        public int Register(string fullname, string email, string birthdate, string password)
        {

            if (_context.Employees.Any(x => x.Email == email))
            {
                return 0;
            }

            Employee employee = new Employee()
            {
                Fullname = fullname,
                Email = email,
                BirthDate = birthdate
            };
            _context.Employees.Add(employee);
            var create = _context.SaveChanges();

            if (create > 0)
            {
                var id = _context.Employees.SingleOrDefault(x => x.Email.Equals(email)).Id;
                User user = new User()
                {
                    employeeId = id,
                    Password = Hashing.HashPassword(password),
                    roleId = 1
                };

                _context.Users.Add(user);
                var result = _context.SaveChanges();
                if (result > 1)
                {
                    return result;
                }
            }
            return 1;
        }

        public User Login(string email, string Password)
        {
            var data = _context.Users.Include(x => x.employee).Include(x => x.role)
               .SingleOrDefault(x => x.employee.Email == email && x.Password == Password );
            return data;
            //if (data != null)
            //{
            //    var vp = Hashing.ValidatePassword(Password, data.Password);
            //    if (vp == true)
            //        return int;
            //}
            
            //return null;
        }

        public int ChangePassword(string OldPassword, string password, string email)
        {
            var data = _context.Users.Include(x => x.employee).FirstOrDefault(x => x.employee.Email.Equals(email));
            var vPass = Hashing.ValidatePassword(OldPassword, data.Password);
            if (data != null && vPass == true)
            {

                data.Password = Hashing.HashPassword(password);
                _context.Entry(data).State = EntityState.Modified;
                var result = _context.SaveChanges();
                if (result > 0)
                    return 1;

            }

            return 0;
        }


        public int ResetPassword(string fullName, string email, string birthDate, string newPassword)
        {
            var data = _context.Users
                          .Include(x => x.employee)
                          .SingleOrDefault(x => x.employee.Email
                          .Equals(email) && x.employee.Fullname.Equals(fullName) && x.employee.BirthDate.Equals(birthDate));

            if (data != null)
            {


                User user = new User()
                {
                    Password = newPassword
                };

                data.Password = user.Password;
                _context.Entry(data).State = EntityState.Modified;
                _context.SaveChanges();


                return 1;
            }


            return 0;
        }


    }
}
