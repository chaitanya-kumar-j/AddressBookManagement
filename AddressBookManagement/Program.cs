using System;

namespace AddressBookManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run or exit
            bool isRun = true;
            AddressBooks books = new AddressBooks();
            while (isRun)
            {
                Console.WriteLine(" Hello World!...\n Welcome to address book management system!....");
                Console.WriteLine(" Select and enter query number: \n" +
                    "(1. Create contact list, 2. Add new contact, 3. Edit existing contact,\n " +
                    "4. Delete contact by person name, 5. Add Multiple persons, " +
                    "6. Multiple addressbooks with unique name,\n 7. Ensure no duplicate contact)\n");
                int selectProgram = Convert.ToInt32(Console.ReadLine());
                switch (selectProgram)
                {
                    case 1:
                        books.CreateContact();
                        books.Display();
                        break;
                    case 2:
                        // Add new Contact
                        books.AddNewContact();
                        books.Display();
                        break;
                    case 3:
                        // Edit contact by name
                        books.EditContact();
                        books.Display();
                        break;
                    case 4:
                        // Delete contact
                        books.DeleteContact();
                        books.Display();
                        break;
                    case 5:
                        // Add multiple persons
                        books.AddMultipleContacts();
                        break;
                    case 6:
                        // Multi Addressbooks
                        books.MultiAddressBook();
                        break;
                    case 7:
                        // Multi Addressbooks
                        books.MultiAddressBook();
                        break;
                    default:
                        // exit program
                        isRun = !isRun;
                        break;
                }
            }
        }
    }
}