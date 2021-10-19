using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookManagement
{
    public class AddressBooks
    {
        // create empty list of contact
        List<Contact> listOfContacts = new List<Contact>();
        List<string> cityList = new List<string>();
        List<string> stateList = new List<string>();
        Dictionary<string, AddressBooks> addressBooks = new Dictionary<string, AddressBooks>();
        Dictionary<string, Dictionary<string, List<Contact>>> citywiseAddressBooks = new Dictionary<string, Dictionary<string, List<Contact>>>();
        Dictionary<string, Dictionary<string, List<Contact>>> statewiseAddressBooks = new Dictionary<string, Dictionary<string, List<Contact>>>();

        // method to create new contact
        public void CreateContact()
        {
            Console.WriteLine("Enter the first name of the contact: ");
            string firstName = Console.ReadLine();
            List<Contact> listOfContacts1 = listOfContacts.FindAll(x => x.FirstName == firstName);
            if (listOfContacts1.Count != 0)
            {
                Console.WriteLine($"Contact with the first name as {firstName} is already exists.\n");
                return;
            }
            else
            {
                Contact contact = new Contact();
                contact.FirstName = firstName;
                Console.WriteLine("Enter the second name of the contact: ");
                contact.SecondName = Console.ReadLine();

                Console.WriteLine("Enter the Address of the contact seperated by comma: ");
                contact.Address = Console.ReadLine();

                Console.WriteLine("Enter the City of the contact: ");
                contact.City = Console.ReadLine();
                if (!cityList.Contains(contact.City))
                {
                    this.cityList.Add(contact.City);
                }

                Console.WriteLine("Enter the State of the contact: ");
                contact.State = Console.ReadLine();
                if (!stateList.Contains(contact.State))
                {
                    this.stateList.Add(contact.State);
                }

                Console.WriteLine("Enter the Zip of the contact: ");
                contact.ZipCode = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Phone number of the contact: ");
                contact.PhoneNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the email id of the contact: ");
                contact.Email = Console.ReadLine();
                listOfContacts.Add(contact);
            }
        }
        // method to display all contacts in an address book
        public void Display()
        {
            foreach(var item in listOfContacts)
            {
                Console.WriteLine($"First Name: {item.FirstName}\nLast Name: {item.SecondName}\n" +
                    $"Address: {item.Address}\nCity: {item.City}\nState: {item.State}\nZipCode: {item.ZipCode}\n" +
                    $"Phone number: {item.PhoneNumber}\nEmail id: {item.Email}\n");
            }
        }
        // method to add new contact to an address book
        public void AddlistOfContacts()
        {
            CreateContact();
        }
        // method to edit the data of a contact of an address book
        public void EditContact()
        {
            Console.WriteLine("Enter the first name of the contact you want to Edit.");
            string firstNameToEdit = Console.ReadLine().ToLower();
            foreach(var item in listOfContacts)
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
        // method to delete the contact of an address book
        public void DeleteContact()
        {
            Console.WriteLine("Enter the first name of contact which you want to delete.");
            string contactToDel = Console.ReadLine().ToLower();
            foreach(var item in listOfContacts)
            {
                if (item.FirstName.ToLower() == contactToDel)
                {
                    listOfContacts.Remove(item);
                    break;
                }
            }
        }
        // method to add multiple contacts at a tome to an address book
        public void AddMultipleContacts()
        {
            Console.WriteLine("Enter the number of contacts to be added: ");
            int numberOfContacts = Convert.ToInt32(Console.ReadLine());
            while (numberOfContacts > 0)
            {
                CreateContact();
                numberOfContacts--;
            }
        }
        // method to add multiple address books at a time
        public void MultiAddressBook()
        {
            Console.WriteLine("Howmany number of address books you want to add? ");
            int numberOfBooks = Convert.ToInt32(Console.ReadLine());
            while (numberOfBooks>0)
            {
                Console.WriteLine("Enter name of the owner of this address book:");
                string ownerName = Console.ReadLine();
                if (addressBooks.ContainsKey(ownerName))
                {
                    Console.WriteLine($"An address book is already present with the name of {ownerName}.");
                }
                else
                {
                    AddressBooks books = new AddressBooks();
                    books.AddMultipleContacts();
                    addressBooks.Add(ownerName, books);
                    foreach (string city in books.cityList)
                    {
                        List<Contact> cityData = books.listOfContacts.FindAll(c => c.City == city);
                        Dictionary<string, List<Contact>> keyValues = new Dictionary<string, List<Contact>>();
                        keyValues.Add(ownerName, cityData);
                        if (citywiseAddressBooks.ContainsKey(city))
                        {
                            foreach (var data in keyValues)
                            {
                                citywiseAddressBooks[city].Add(data.Key, data.Value);
                            }
                        }
                        else
                        {
                            citywiseAddressBooks.Add(city, keyValues);
                        }
                    }
                    foreach (string state in books.stateList)
                    {
                        List<Contact> stateData = books.listOfContacts.FindAll(c => c.State == state);
                        Dictionary<string, List<Contact>> keyValues = new Dictionary<string, List<Contact>>();
                        keyValues.Add(ownerName, stateData);
                        statewiseAddressBooks[state] = keyValues;
                    }
                    numberOfBooks--;
                }
            }
            foreach(KeyValuePair<string, AddressBooks> keyValuePair in addressBooks)
            {
                Console.WriteLine($"Contacts in {keyValuePair.Key} are: ");
                keyValuePair.Value.Display();
            }
        }
        // method to find contact from addressbook
        public bool SearchContactInAddressBook(string contactName)
        {
            foreach(Contact contact in listOfContacts)
            {
                if(contact.FirstName == contactName)
                {
                    Console.WriteLine("Contact found...");
                    return true;
                }
            }
            Console.WriteLine("Contact not found in the address book.");
            return false;
        }
        // method to search a contact in particular address book
        public bool SearchContactInMultiAddressBook(string owner, string contactName)
        {
            if (addressBooks.ContainsKey(owner))
            {
                if (addressBooks[owner].SearchContactInAddressBook(contactName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Multi address book don't have the address book with given owner name.");
                return false;
            }
        }
        public void SearchByCity(string city)
        {
            if (citywiseAddressBooks.ContainsKey(city))
            {
                foreach(string owner in citywiseAddressBooks[city].Keys)
                {
                    Console.WriteLine($"Contacts in {owner}'s address book from {city} city are: ");
                    foreach(Contact contact in citywiseAddressBooks[city][owner])
                    {
                        Console.WriteLine($"First Name: {contact.FirstName}\nLast Name: {contact.SecondName}\n" +
                        $"Address: {contact.Address}\nCity: {contact.City}\nState: {contact.State}\nZipCode: {contact.ZipCode}\n" +
                        $"Phone number: {contact.PhoneNumber}\nEmail id: {contact.Email}\n");
                    }
                }
            }
            else
            {
                Console.WriteLine($"There is no contact from the city, {city}");
            }
        }
        public void SearchByState(string state)
        {
            if (statewiseAddressBooks.ContainsKey(state))
            {
                foreach (string owner in statewiseAddressBooks[state].Keys)
                {
                    Console.WriteLine($"Contacts in {owner}'s address book from {state} state are: ");
                    foreach (Contact contact in statewiseAddressBooks[state][owner])
                    {
                        Console.WriteLine($"First Name: {contact.FirstName}\nLast Name: {contact.SecondName}\n" +
                        $"Address: {contact.Address}\nCity: {contact.City}\nState: {contact.State}\nZipCode: {contact.ZipCode}\n" +
                        $"Phone number: {contact.PhoneNumber}\nEmail id: {contact.Email}\n");
                    }
                }
            }
            else
            {
                Console.WriteLine($"There is no contact from the state, {state}");
            }
        }
        public void SearchByCityAndFirstName(string city, string firstName)
        {
            if (citywiseAddressBooks.ContainsKey(city))
            {
                foreach (string owner in citywiseAddressBooks[city].Keys)
                {
                    Console.WriteLine($"Contact with first name as {firstName} in {owner}'s address book from {city} city are: ");
                    Contact contact = citywiseAddressBooks[city][owner].FindAll(c => c.FirstName.ToLower() == firstName.ToLower())[0];
                    if (contact != null)
                    {
                        Console.WriteLine($"First Name: {contact.FirstName}\nLast Name: {contact.SecondName}\n" +
                        $"Address: {contact.Address}\nCity: {contact.City}\nState: {contact.State}\nZipCode: {contact.ZipCode}\n" +
                        $"Phone number: {contact.PhoneNumber}\nEmail id: {contact.Email}\n");
                    }
                    else
                    {
                        Console.WriteLine($"No such contact in any address book with first name as {firstName} in the city {city}.");
                    }
                }
            }
            else
            {
                Console.WriteLine($"There is no contact from the city, {city}");
            }
        }
        public void SearchByStateAndFirstName(string state, string firstName)
        {
            if (statewiseAddressBooks.ContainsKey(state))
            {
                foreach (string owner in statewiseAddressBooks[state].Keys)
                {
                    Console.WriteLine($"Contact with first name as {firstName} in {owner}'s address book from {state} state are: ");
                    Contact contact = statewiseAddressBooks[state][owner].FindAll(c => c.FirstName.ToLower() == firstName.ToLower())[0];
                    if(contact != null)
                    {
                        Console.WriteLine($"First Name: {contact.FirstName}\nLast Name: {contact.SecondName}\n" +
                        $"Address: {contact.Address}\nCity: {contact.City}\nState: {contact.State}\nZipCode: {contact.ZipCode}\n" +
                        $"Phone number: {contact.PhoneNumber}\nEmail id: {contact.Email}\n");
                    }
                    else
                    {
                        Console.WriteLine($"No such contact in any address book with first name as {firstName} in state {state}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"There is no contact from the state, {state}");
            }
        }
        public void CountByCity(string city)
        {
            if (citywiseAddressBooks.ContainsKey(city))
            {
                int count = 0;
                foreach(var key in citywiseAddressBooks[city].Keys)
                {
                    count += citywiseAddressBooks[city][key].Count;
                }
                Console.WriteLine($"Number of contacts in {city} city are: {count}");
                Console.WriteLine($"Number of contacts in {city} city are: {citywiseAddressBooks[city].Values.Count}");
            }
            else
            {
                Console.WriteLine($"There is no contact from the city, {city}");
            }
        }
        public void CountByState(string state)
        {
            if (statewiseAddressBooks.ContainsKey(state))
            {
                int count = 0;
                foreach (var key in statewiseAddressBooks[state].Keys)
                {
                    count += statewiseAddressBooks[state][key].Count;
                }
                Console.WriteLine($"Number of contacts in {state} state are: {count}");
                Console.WriteLine($"Number of contacts in {state} state are: {citywiseAddressBooks[state].Values.Count}");
            }
            else
            {
                Console.WriteLine($"There is no contact from the state, {state}");
            }
        }
        public void SortAddressBookByFirstName()
        {
            foreach(KeyValuePair<string, AddressBooks> keyValuePair in addressBooks.OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"Contacts in {keyValuePair.Key} after sorting by first name are: ");
                foreach (var item in keyValuePair.Value.listOfContacts.OrderBy(x => x.FirstName))
                {
                    Console.WriteLine($"First Name: {item.FirstName}\nLast Name: {item.SecondName}\n" +
                        $"Address: {item.Address}\nCity: {item.City}\nState: {item.State}\nZipCode: {item.ZipCode}\n" +
                        $"Phone number: {item.PhoneNumber}\nEmail id: {item.Email}\n");
                }
            }
        }
        public void SortAddressBookByCity()
        {
            foreach (KeyValuePair<string, AddressBooks> keyValuePair in addressBooks.OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"Contacts in {keyValuePair.Key} after sorting by City are: ");
                foreach (var item in keyValuePair.Value.listOfContacts.OrderBy(x => x.City))
                {
                    Console.WriteLine($"First Name: {item.FirstName}\nLast Name: {item.SecondName}\n" +
                        $"Address: {item.Address}\nCity: {item.City}\nState: {item.State}\nZipCode: {item.ZipCode}\n" +
                        $"Phone number: {item.PhoneNumber}\nEmail id: {item.Email}\n");
                }
            }
        }
        public void SortAddressBookByState()
        {
            foreach (KeyValuePair<string, AddressBooks> keyValuePair in addressBooks.OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"Contacts in {keyValuePair.Key} after sorting by State are: ");
                foreach (var item in keyValuePair.Value.listOfContacts.OrderBy(x => x.State))
                {
                    Console.WriteLine($"First Name: {item.FirstName}\nLast Name: {item.SecondName}\n" +
                        $"Address: {item.Address}\nCity: {item.City}\nState: {item.State}\nZipCode: {item.ZipCode}\n" +
                        $"Phone number: {item.PhoneNumber}\nEmail id: {item.Email}\n");
                }
            }
        }
        public void SortAddressBookByZipCode()
        {
            foreach (KeyValuePair<string, AddressBooks> keyValuePair in addressBooks.OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"Contacts in {keyValuePair.Key} after sorting by ZipCode are: ");
                foreach (var item in keyValuePair.Value.listOfContacts.OrderBy(x => x.ZipCode))
                {
                    Console.WriteLine($"First Name: {item.FirstName}\nLast Name: {item.SecondName}\n" +
                        $"Address: {item.Address}\nCity: {item.City}\nState: {item.State}\nZipCode: {item.ZipCode}\n" +
                        $"Phone number: {item.PhoneNumber}\nEmail id: {item.Email}\n");
                }
            }
        }
    }
}