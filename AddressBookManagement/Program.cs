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
                Console.WriteLine(" Select and enter query number: " +
                    "(1. Create contact list, 2. Add new contact, 3. Edit existing contact, " +
                    "4. Delete contact by person name, 5. Add Multiple persons, " +
                    "6. Multiple addressbooks with unique name)");
                int selectProgram = Convert.ToInt32(Console.ReadLine());
                switch (selectProgram)
                {
                    case 1:
                        books.CreateContact();
                        break;
                    case 2:
                        // Add new Contact
                        break;
                    case 3:
                        // Edit contact by name
                        break;
                    case 4:
                        // Delete contact
                        break;
                    case 5:
                        // Add multiple persons
                        break;
                    case 6:
                        // Multi Addressbooks
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