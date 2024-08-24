using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactApp.Repositories
{
    internal class ContactRepo
    {
        public static void CreateContact(List<User> users,int contactCounter)
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

        public static void ReadContacts(List<User> users)
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

        public static void UpdateContact(List<User> users)
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

        public static void DeleteContact(List<User> users)
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

        public static void AddContactDetails(List<User> users,int contactDetailsCounter)
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
    }
}
