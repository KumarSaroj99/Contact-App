using System;
using System.Collections.Generic;
using System.Linq;
using ContactApp.Models;
using System;
using System.Collections.Generic;
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


                //Console.WriteLine("Login as Admin (1) or Staff (2) or Exit (0): ");
                //int role = Convert.ToInt32(Console.ReadLine());

                if (userID == 0) break;

                if (isAdminLogingIn(userID))
                {
                    AdminMenu();
                }
                else if (isStaffLogingIn(userID))
                {
                    StaffMenu();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        static void AdminMenu()
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
                    CreateUser();
                    break;
                case 2:
                    ReadUsers();
                    break;
                case 3:
                    UpdateUser();
                    break;
                case 4:
                    DeleteUser();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void StaffMenu()
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
                    CreateContact();
                    break;
                case 2:
                    ReadContacts();
                    break;
                case 3:
                    UpdateContact();
                    break;
                case 4:
                    DeleteContact();
                    break;
                case 5:
                    AddContactDetails();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        // CRUD operations for User (Admin)
        static void CreateUser()
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

        static void ReadUsers()
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

        static void UpdateUser()
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

        static void DeleteUser()
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

        // CRUD operations for Contact (Staff)
        static void CreateContact()
        {
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();

            var contact = new Contact { ContactID = contactCounter++, FirstName = firstName, LastName = lastName };
            Console.WriteLine("Enter UserID to associate with this contact: ");
            int userID = Convert.ToInt32(Console.ReadLine());

            var user = users.Find(u => u.UserID == userID && u.IsActive);
            if (user != null)
            {
                user.Contacts.Add(contact);
                Console.WriteLine("Contact created and associated with user.");
            }
            else
            {
                Console.WriteLine("User not found or inactive.");
            }
        }

        static void ReadContacts()
        {
            Console.WriteLine("Enter UserID to view contacts: ");
            int userID = Convert.ToInt32(Console.ReadLine());

            var user = users.Find(u => u.UserID == userID && u.IsActive);
            if (user != null)
            {
                foreach (var contact in user.Contacts)
                {
                    if (contact.IsActive)
                    {
                        Console.WriteLine($"ContactID: {contact.ContactID}, Name: {contact.FirstName} {contact.LastName}");
                    }
                }
            }
            else
            {
                Console.WriteLine("User not found or inactive.");
            }
        }

        static void UpdateContact()
        {
            Console.WriteLine("Enter UserID to update contact: ");
            int userID = Convert.ToInt32(Console.ReadLine());

            var user = users.Find(u => u.UserID == userID && u.IsActive);
            if (user != null)
            {
                Console.WriteLine("Enter ContactID to update: ");
                int contactID = Convert.ToInt32(Console.ReadLine());

                var contact = user.Contacts.Find(c => c.ContactID == contactID && c.IsActive);
                if (contact != null)
                {
                    Console.WriteLine("Enter new First Name: ");
                    contact.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter new Last Name: ");
                    contact.LastName = Console.ReadLine();

                    Console.WriteLine("Contact updated successfully.");
                }
                else
                {
                    Console.WriteLine("Contact not found or inactive.");
                }
            }
            else
            {
                Console.WriteLine("User not found or inactive.");
            }
        }

        static void DeleteContact()
        {
            Console.WriteLine("Enter UserID to delete contact: ");
            int userID = Convert.ToInt32(Console.ReadLine());

            var user = users.Find(u => u.UserID == userID && u.IsActive);
            if (user != null)
            {
                Console.WriteLine("Enter ContactID to delete: ");
                int contactID = Convert.ToInt32(Console.ReadLine());

                var contact = user.Contacts.Find(c => c.ContactID == contactID && c.IsActive);
                if (contact != null)
                {
                    contact.IsActive = false;
                    Console.WriteLine("Contact deleted (set inactive) successfully.");
                }
                else
                {
                    Console.WriteLine("Contact not found or inactive.");
                }
            }
            else
            {
                Console.WriteLine("User not found or inactive.");
            }
        }

        static void AddContactDetails()
        {
            Console.WriteLine("Enter UserID to add contact details: ");
            int userID = Convert.ToInt32(Console.ReadLine());

            var user = users.Find(u => u.UserID == userID && u.IsActive);
            if (user != null)
            {
                Console.WriteLine("Enter ContactID to add details: ");
                int contactID = Convert.ToInt32(Console.ReadLine());

                var contact = user.Contacts.Find(c => c.ContactID == contactID && c.IsActive);
                if (contact != null)
                {
                    Console.WriteLine("Enter Type (e.g., Phone, Email): ");
                    string type = Console.ReadLine();
                    Console.WriteLine("Enter Number: ");
                    string number = Console.ReadLine();

                    contact.ContactDetails.Add(new ContactDetails { ContactDetailsID = contactDetailsCounter++, Type = type, Number = number });
                    Console.WriteLine("Contact details added successfully.");
                }
                else
                {
                    Console.WriteLine("Contact not found or inactive.");
                }
            }
            else
            {
                Console.WriteLine("User not found or inactive.");
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
