using System;
using System.ComponentModel;
using System.Net;
using AddressBook;

internal class AddressBookMain
{
    public static List<Contact> AddressBook = new List<Contact>();
    int count = 0;

    //Method to add a new contact to Address Book
    public void AddContact()
    {
        Console.WriteLine("Enter how many contacts you want to add");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Contact contacts = new Contact();

            Console.WriteLine("Enter the First Name : ");
            contacts.FName = Console.ReadLine();

            Console.WriteLine("Enter the last Name  : ");
            contacts.LName = Console.ReadLine();

            Console.WriteLine("Enter the address  : ");
            contacts.Address = Console.ReadLine();

            Console.WriteLine("Enter the City  : ");
            contacts.City = Console.ReadLine();

            Console.WriteLine("Enter the state : ");
            contacts.State = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Enter Zip Code  : ");
                string code = Console.ReadLine();

                if (code.Length == 6)
                {
                    contacts.Zip = code;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid 6 digit Zip Code.");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter Your Phone Number: ");
                string number = Console.ReadLine();

                if (number.Length == 10)
                {
                    contacts.PhoneNumber = number;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid 10 digit Phone Number.");
                }
            }

            while (true)
            {
                Console.WriteLine("Enter Your Email Address: ");
                string mail = Console.ReadLine();

                if (mail.Contains("@"))
                {
                    contacts.Email = mail;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid Email Address.");
                }
            }

            AddressBook.Add(contacts);
        }
    }

    //Method to view the detail in address book
    public void ViewDetail()
    {
        if (AddressBook.Count > 0)
        {
            foreach (var item in AddressBook)
            {
                PrintDetail(item);
            }
        }
        else
        {
            Console.WriteLine("Address book is empty! ");
        }
    }

    //Method to print all detail in address book
    public void PrintDetail(Contact item)
    {
        Console.WriteLine("First Name :   " + item.FName);
        Console.WriteLine("Last Name :    " + item.LName);
        Console.WriteLine("Address :      " + item.Address);
        Console.WriteLine("City    :      " + item.City);
        Console.WriteLine("State   :      " + item.State);
        Console.WriteLine("Zip     :      " + item.Zip);
        Console.WriteLine("Phone Number  : " + item.PhoneNumber);
        Console.WriteLine("email  :       " + item.Email);
    }

    //Method to edit existing contact person using their name
    public void EditContact()
    {
        if (AddressBook.Count > 0)
        {
            Console.WriteLine("Enter name of the contact you want to edit ");
            string editDetail = Console.ReadLine();
            foreach(var item in AddressBook)
            {
                if (editDetail.ToLower() == item.FName.ToLower())
                {
                    Console.WriteLine("\nChoice what you want to edit \n1.First name \n2.Last name \n3.Address "+"" +
                        "\n4.City \n5.State \n6.Zip Code \n7.Phone Number \n8.Email");
                    int editChoice = int.Parse(Console.ReadLine());
                    switch (editChoice)
                    {
                        case 1:
                            Console.WriteLine("Enter new first name ");
                            item.FName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter new last name ");
                            item.LName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter new address ");
                            item.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter new city name ");
                            item.City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter new state name ");
                            item.State = Console.ReadLine();
                            break;
                        case 6:
                            while (true)
                            {
                                Console.WriteLine("Enter Zip Code  : ");
                                string code = Console.ReadLine();

                                if (code.Length == 6)
                                {
                                    item.Zip = code;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter a valid 6 digit Zip Code.");
                                }
                            }
                            break;
                        case 7:
                            while (true)
                            {
                                Console.WriteLine("Enter Your Phone Number: ");
                                string number = Console.ReadLine();

                                if (number.Length == 10)
                                {
                                    item.PhoneNumber = number;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter a valid 10 digit Phone Number.");
                                }
                            }
                            break;
                        case 8:
                            while (true)
                            {
                                Console.WriteLine("Enter Your Email Address: ");
                                string mail = Console.ReadLine();

                                if (mail.Contains("@"))
                                {
                                    item.Email = mail;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Enter a valid Email Address.");
                                }
                            }
                            break;

                    }
                }
                else
                {
                    Console.WriteLine(editDetail+"Does not exist in AddressBook ");
                }
            }
        }
    }

    //Method to delete a person using person's name
    public void DeleteContact()
    {
        if (AddressBook.Count > 0)
        {
            Console.WriteLine("Enter name of contact you want to delete ");
            string deleteName = Console.ReadLine();
            foreach (var item in AddressBook)
            {
                if (deleteName.ToLower() == item.FName.ToLower())
                {
                    AddressBook.Remove(item);
                    Console.WriteLine(deleteName+"Contact is successfully deleted ");
                    break;
                }
                else
                {
                    Console.WriteLine(deleteName+"does not exist in AddressBook ");
                }
            }
        }
        else
        {
            Console.WriteLine( "Address Book is empty ");
        }
    }

    //Method to Refactor to add multiple Address Book to the System.Each Address Book has a unique Name
    public void AddDictionary()
    {
        count = 0;
        Console.WriteLine("Enter how many address book you want to enter ");
        int addCount = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter how many contact you want to add ");
        int n = Convert.ToInt32(Console.ReadLine());
        for(int i = 1; i <= n; i++)
        {
            AddContact();
        }
        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        for (int i = 1; i <= addCount; i++)
        {
            count++;
            List<AddressBookMain> newAdd = new List<AddressBookMain>();
            dictionary.Add(i, " New Dictionary");

        }
        Console.WriteLine("Address Book created " + count);
    }

    //Method to to ensure there is no Duplicate Entry of the samePerson in a particular AddressBook 
    public void DuplicateContact()
    {
        if (AddressBook.Count > 0)
        {
            Console.WriteLine("Enter the name to check : ");
            string personName = Console.ReadLine();
            bool check = AddressBook.Any(x => x.FName == personName);
            if (check)
            {
                Console.WriteLine("Contact is present ");
            }
            else
            {
                Console.WriteLine("Contact is not present ");
            }
        }
    }

    //Method to search Person in a City or State across the multiple AddressBook 
    public void SearchPersonByCityOrState()
    {
        if (AddressBook.Count > 0)
        {
            Console.WriteLine("Enter name to search ");
            string personName = Console.ReadLine();
            Console.WriteLine("Enter city to search ");
            string cityName = Console.ReadLine();
            foreach(var data in AddressBook.FindAll(x=>x.FName==personName && x.City == cityName))
            {
                Console.WriteLine("The Contact Details of " + data.City + " are: \n" + data.FName + "\n" + data.LName + "\n" + data.Address +
                    "\n" + data.Zip + "\n" + data.PhoneNumber + "\n" + data.Email);
            }
        }
        else
        {
            Console.WriteLine("Address Book is empty");
        }
    }

    //Method to view Persons by City or State
    public void ViewPersonByCityOrState()
    {
        if (AddressBook.Count > 0)
        {
            Console.WriteLine("Enter state to search ");
            string stateName = Console.ReadLine();
            Console.WriteLine("Enter city to search ");
            string cityName = Console.ReadLine();
            foreach (var data in AddressBook.FindAll(x => x.State == stateName && x.City == cityName))
            {
                Console.WriteLine("The Contact Details of " + data.City + " are: \n" + data.FName + "\n" + data.LName + "\n" + data.Address +
                    "\n" + data.Zip + "\n" + data.PhoneNumber + "\n" + data.Email);
            }
        }
        else
        {
            Console.WriteLine("Address Book is empty");
        }
    }

    //Method to get number of contact persons i.e.count by City or State
    public void CountPerson()
    {
        if (AddressBook.Count > 0)
        {
            Console.WriteLine("Enter city to search ");
            string cityName = Console.ReadLine();
            int count = 0;
            foreach(var items in AddressBook.FindAll(x => x.City == cityName))
            {
                count++;
            }
            Console.WriteLine("No of contacts {0} in city {1}",count,cityName);
        }
        else
        {
            Console.WriteLine("Address Book is empty");
        }
    }

    //Method to sort the entries in the address book alphabetically by Person’s name
    public void SortContactByName()
    {
        if (AddressBook.Count > 0)
        {
            foreach(var item in AddressBook.OrderBy(x => x.FName))
            {
                Console.WriteLine("First Name : "+item.FName);
                Console.WriteLine("Last Name : " + item.LName);
                Console.WriteLine("Address : " + item.Address);
                Console.WriteLine("City : " + item.City);
                Console.WriteLine("State : " + item.State);
                Console.WriteLine("Zip : " + item.Zip);
                Console.WriteLine("Phone Number : " + item.PhoneNumber);
                Console.WriteLine("Email : " + item.Email);
            }
        }
        else
        {
            Console.WriteLine("Address Book is empty ");
        }
    }

    //Method to sort the entries in the address book by Zip
    public void SortContactByZipCode()
    {
        if (AddressBook.Count > 0)
        {
            foreach (var item in AddressBook.OrderBy(x => x.Zip))
            {
                Console.WriteLine("First Name : " + item.FName);
                Console.WriteLine("Last Name : " + item.LName);
                Console.WriteLine("Address : " + item.Address);
                Console.WriteLine("City : " + item.City);
                Console.WriteLine("State : " + item.State);
                Console.WriteLine("Zip : " + item.Zip);
                Console.WriteLine("Phone Number : " + item.PhoneNumber);
                Console.WriteLine("Email : " + item.Email);
            }
        }
        else
        {
            Console.WriteLine("Address Book is empty ");
        }
    }

}


