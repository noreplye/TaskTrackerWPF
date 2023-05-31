using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project_3
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public User() { }
        public User(int id,string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }
       

    }
    public class UserContext : DbContext
    {
        public UserContext() 
        {
            
        }
        public DbSet<User> Users { get; set; } = null!;//не должно быть равно null
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\Users.db");
        }
    }
}
