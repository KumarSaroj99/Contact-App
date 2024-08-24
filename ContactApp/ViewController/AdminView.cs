using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;
using ContactApp.Repositories;

namespace ContactApp.ViewController
{
    internal class AdminView
    {
        static int userCounter = 1;
        public static void AdminMenu(List<User> users)
        {
            Console.WriteLine("Admin Menu: ");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Read Users");
            Console.WriteLine("3. Update User");
            Console.WriteLine("4. Delete User");
            Console.WriteLine("0. Logout");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    UserRepo.CreateUser(users,userCounter);
                    break;
                case 2:
                    UserRepo.ReadUsers(users);
                    break;
                case 3:
                    UserRepo.UpdateUser(users);
                    break;
                case 4:
                    UserRepo.DeleteUser(users);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
