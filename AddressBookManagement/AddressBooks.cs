using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookManagement
{
    public class AddressBooks
    {
        // create empty list of contact
        List<Contact> newContact = new List<Contact>();

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
            newContact.Add(contact);
        }
        public void Display()
        {
            foreach(var item in newContact)
            {
                Console.WriteLine($"First Name: {item.FirstName}\nLast Name: {item.SecondName}\n" +
                    $"Address: {item.Address}\nCity: {item.City}\nState: {item.State}\nZipCode: {item.ZipCode}\n" +
                    $"Phone number: {item.PhoneNumber}\nEmail id: {item.Email}");
            }
        }
        public void AddNewContact()
        {
            CreateContact();
        }
        public void EditContact()
        {
            Console.WriteLine("Enter the first name of the contact you want to Edit.");
            string firstNameToEdit = Console.ReadLine().ToLower();
            foreach(var item in newContact)
            {
                if (item.FirstName.ToLower() == firstNameToEdit)
                {
                    bool isChange = true;
                    while (isChange)
                    {
                        Console.WriteLine("Select and enter feild number to be changed: " +
                        "(1. First Name, 2. Last Name, 3. Address, 4. City, " +
                        "5. State, 6. ZipCode, 7. Phone number, 8. Email");
                        int fieldOption = Convert.ToInt32(Console.ReadLine());
                        switch (fieldOption)
                        {
                            case 1:
                                Console.WriteLine("Enter new first name");
                                item.FirstName = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Enter new last name");
                                item.SecondName = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Enter new Address");
                                item.Address = Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("Enter new City name");
                                item.City = Console.ReadLine();
                                break;
                            case 5:
                                Console.WriteLine("Enter new State name");
                                item.State = Console.ReadLine();
                                break;
                            case 6:
                                Console.WriteLine("Enter new Zipcode");
                                item.ZipCode = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 7:
                                Console.WriteLine("Enter new Phone number");
                                item.PhoneNumber = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 8:
                                Console.WriteLine("Enter new Email id");
                                item.Email = Console.ReadLine();
                                break;
                            default:
                                isChange = !isChange;
                                break;
                        }
                    }
                }
            }
        }
        public void DeleteContact()
        {
            Console.WriteLine("Enter the first name of contact which you want to delete.");
            string contactToDel = Console.ReadLine().ToLower();
            foreach(var item in newContact)
            {
                if (item.FirstName.ToLower() == contactToDel)
                {
                    newContact.Remove(item);
                }
            }
        }
    }
}