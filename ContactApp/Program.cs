using System;
using System.Collections.Generic;
using System.Linq;
using ContactApp.Models;
using System;
using System.Collections.Generic;
using ContactApp.ViewController;
namespace ContactApp
{
    class Program
    {
        static List<User> users = new List<User>();
        static int userCounter = 1;
        static int contactCounter = 1;
        static int contactDetailsCounter = 1;

        static bool isAdminLogingIn(int userID)
        {
            var user = users.Find(u => u.UserID == userID && u.IsActive && u.IsAdmin);
            if (user != null)
                return true;
            return false;
        }
        static bool isStaffLogingIn(int userID)
        {
            var user = users.Find(u => u.UserID == userID && u.IsActive && !u.IsAdmin);
            if (user != null)
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            // Dummy data for testing
            SeedData();

            while (true)
            {
                Console.WriteLine("Enter UserID to Login or Exit (0): ");
                int userID = Convert.ToInt32(Console.ReadLine());


                if (userID == 0) break;

                if (isAdminLogingIn(userID))
                {
                    AdminView.AdminMenu(users);
                }
                else if (isStaffLogingIn(userID))
                {
                    StaffView.StaffMenu(users);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        // Dummy data seeding for testing
        static void SeedData()
        {
            var admin = new User { UserID = userCounter++, FirstName = "Admin", LastName = "User", IsAdmin = true };
            var staff = new User { UserID = userCounter++, FirstName = "Staff", LastName = "User", IsAdmin = false };

            users.Add(admin);
            users.Add(staff);
        }
    }


}
