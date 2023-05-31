using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Project_3
{
    public class BL
    {
        public BL() { }
        public static bool CheckLogin(string login)
        {
            User user = null;
            using (UserContext userContext=new UserContext()) 
            {   

                user=userContext.Users.Where(u=>u.login==login).FirstOrDefault();
            }
            if (user != null)
            {
                return true;
            }
            return false;
        }
        public static void Registration(string login,string password)
        {
            using (UserContext userContext = new UserContext())
            {
                User user = new User();
                user.login = login;
                user.password = password;
                userContext.Users.Add(user);
                userContext.SaveChanges();
            }
            
        }
        public static int LogIn(string login,string password)
        {
            User user = null;
            using (UserContext userContext = new UserContext())
            {

                user = userContext.Users.Where(u => u.login == login && u.password==password).FirstOrDefault();
            }
            if (user != null)
            {
                return user.id;
            }
            return 0;
        }
    }
}
