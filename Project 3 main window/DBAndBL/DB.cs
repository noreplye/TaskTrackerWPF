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
        private int id { get; set; }
        private string login { get; set; }
        private string password { get; set; }
        public User() { }
        public User(int id, string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }
        public int getId() { return id; }
        public string getLogin() { return login; }
        public string getPassword() { return password; }
        public void setId(int id)
        {
            this.id = id;
        }
        public void setLogin(string login)
        {
            this.login = login;
        }
        public void setPassword(string password) 
        { 
            this.password = password;
        }

    }
    public class AppContext : DbContext
    {
        public AppContext() 
        {
            
        }
        public DbSet<User> Users { get; set; } = null!;//не должно быть равно null
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Users.db");
        }
    }
}
