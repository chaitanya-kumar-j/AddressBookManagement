using System;
using System.IO;

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
                    "6. Multiple addressbooks with unique name,\n 7. Ensure no duplicate contact, 8. Search contacts by City or State,\n " +
                    "9. Search a person from a city or state, 10. count of contacts by city or state,\n " +
                    "11. Sort Address Book By FirstName, 12. Sort addresss book by city or state or zip code)");
                int selectProgram = Convert.ToInt32(Console.ReadLine());
                switch (selectProgram)
                {
                    case 1:
                        books.CreateContact();
                        books.Display();
                        break;
                    case 2:
                        // Add new Contact
                        books.AddlistOfContacts();
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
                    case 8:
                        // Multi Addressbooks
                        books.MultiAddressBook();
                        books.SearchByCity("Hyd");
                        books.SearchByState("TN");
                        break;
                    case 9:
                        // Multi Addressbooks
                        books.MultiAddressBook();
                        books.SearchByCityAndFirstName("Hyd", "Chaitanya");
                        books.SearchByStateAndFirstName("TN", "Chaitanya");
                        break;
                    case 10:
                        // Multi Addressbooks
                        books.MultiAddressBook();
                        books.CountByCity("Hyd");
                        books.CountByState("TN");
                        break;
                    case 11:
                        // Multi Addressbooks
                        books.MultiAddressBook();
                        books.SortAddressBookByFirstName();
                        break;
                    case 12:
                        // Multi Addressbooks
                        books.MultiAddressBook();
                        books.SortAddressBookByFirstName();
                        books.SortAddressBookByCity();
                        books.SortAddressBookByState();
                        books.SortAddressBookByZipCode();
                        break;
                    case 13:
                        string inputTextFilePath = @"G:\BridgeLabz\AddressBookManagement\AddressBookManagement\AddressBooksInputFile.txt";
                        string outputTextFilePath = @"G:\BridgeLabz\AddressBookManagement\AddressBookManagement\AddressBooksOutputFile.txt";
                        books.ReadContactsFromTextFile(inputTextFilePath);
                        books.WriteContactsToTextFile(outputTextFilePath);
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