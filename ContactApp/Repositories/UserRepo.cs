using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactApp.Repositories
{
    internal class UserRepo
    {
        public static void CreateUser(List<User> users,int userCounter)
        {
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Is Admin (true/false): ");
            bool isAdmin = Convert.ToBoolean(Console.ReadLine());

            users.Add(new User { UserID = userCounter++, FirstName = firstName, LastName = lastName, IsAdmin = isAdmin });
            Console.WriteLine("User created successfully.");
        }

        public static void ReadUsers(List<User> users)
        {
            foreach (var user in users)
            {
                if (user.IsActive)
                {
                    Console.WriteLine($"UserID: {user.UserID}, Name: {user.FirstName} {user.LastName}, Admin: {user.IsAdmin}");
                }
                else
                {
                    Console.WriteLine($"IN ACTIVE USER:- UserID: {user.UserID}, Name: {user.FirstName} {user.LastName}, Admin: {user.IsAdmin}");
                }
            }
        }

        public static void UpdateUser(List<User> users)
        {
            Console.WriteLine("Enter UserID to update: ");
            int userID = Convert.ToInt32(Console.ReadLine());

            var user = users.Find(u => u.UserID == userID && u.IsActive);
            if (user != null)
            {
                Console.WriteLine("Enter new First Name: ");
                user.FirstName = Console.ReadLine();
                Console.WriteLine("Enter new Last Name: ");
                user.LastName = Console.ReadLine();
                Console.WriteLine("Is Admin (true/false): ");
                user.IsAdmin = Convert.ToBoolean(Console.ReadLine());

                Console.WriteLine("User updated successfully.");
            }
            else
            {
                Console.WriteLine("User not found or inactive.");
            }
        }

        public static void DeleteUser(List<User> users)
        {
            Console.WriteLine("Enter UserID to delete: ");
            int userID = Convert.ToInt32(Console.ReadLine());

            var user = users.Find(u => u.UserID == userID && u.IsActive);
            if (user != null)
            {
                user.IsActive = false;
                Console.WriteLine("User deleted (set inactive) successfully.");
            }
            else
            {
                Console.WriteLine("User not found or inactive.");
            }
        }
    }
}
