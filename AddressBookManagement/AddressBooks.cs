using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookManagement
{
    public class AddressBooks
    {
        // method to create new contact
        public void CreateContact()
        {
            Contact contact = new Contact();

            Console.WriteLine("Enter the first name of the contact: ");
            contact.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the second name of the contact: ");
            contact.SecondName = Console.ReadLine();

            Console.WriteLine("Enter the Address of the contact seperated by comma: ");
            contact.Address = Console.ReadLine();

            Console.WriteLine("Enter the City of the contact: ");
            contact.City = Console.ReadLine();

            Console.WriteLine("Enter the State of the contact: ");
            contact.State = Console.ReadLine();

            Console.WriteLine("Enter the Zip of the contact: ");
            contact.ZipCode = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Phone number of the contact: ");
            contact.PhoneNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the email id of the contact: ");
            contact.Email = Console.ReadLine();

        }
    }
}