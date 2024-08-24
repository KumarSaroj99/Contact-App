using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;
using ContactApp.Repositories;

namespace ContactApp.ViewController
{
    internal class StaffView
    {
        //static List<User> users = new List<User>();
        static int contactCounter = 1;
        static int contactDetailsCounter = 1;
        public static void StaffMenu(List<User> users)
        {
            Console.WriteLine("Staff Menu: ");
            Console.WriteLine("1. Create Contact");
            Console.WriteLine("2. Read Contacts");
            Console.WriteLine("3. Update Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Add Contact Details");
            Console.WriteLine("0. Logout");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ContactRepo.CreateContact(users,contactCounter);
                    break;
                case 2:
                    ContactRepo.ReadContacts(users);
                    break;
                case 3:
                    ContactRepo.UpdateContact(users);
                    break;
                case 4:
                    ContactRepo.DeleteContact(users);
                    break;
                case 5:
                    ContactRepo.AddContactDetails(users, contactDetailsCounter);
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
