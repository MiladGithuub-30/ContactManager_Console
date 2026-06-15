using Contact_Manager_Console;
using System.Net.Sockets;
using System.Runtime.InteropServices.Marshalling;
using static System.Runtime.InteropServices.JavaScript.JSType;

IContactRepository cr = new ContactRepository();
while (true)
{
    Console.Clear();
    Console.WriteLine("Contact Manager");
    Console.WriteLine($"Total Contact : {cr.Count()}");
    Console.WriteLine("--------------------");
    Console.WriteLine("1.Add Contact");
    Console.WriteLine("2.Edit Contact");
    Console.WriteLine("3.Find Contact");
    Console.WriteLine("4.Remove Contact");
    Console.WriteLine("5.List Contact");
    Console.WriteLine("6.Clear List");
    Console.WriteLine("7.Exit");
    Console.WriteLine();
    Console.WriteLine("-------------------");
    Console.Write("Selected Item : ");
    string? item = Console.ReadLine();
    Console.Clear();
    switch (item)
    {
        case "1":
            {
                Console.WriteLine("Add Contact");
                Console.WriteLine("--------------------");
                Console.Write("Name : ");
                string? name = Console.ReadLine();
                if (name == null)
                {
                    ErrorMassage();
                    Console.ReadKey();
                    continue;
                }
                Console.Write("Phone Number : ");
                if (!long.TryParse(Console.ReadLine(), out long phonenumber))
                {
                    ErrorMassage();
                    Console.ReadKey();
                    continue;
                }
                Contact contact = new Contact() { Name = name, PhoneNumber = phonenumber };

                cr.Add(contact);
                Console.WriteLine("Contact Added Sessyfull...");
                Console.ReadKey();


            }
            break;
        case "2":
            {
                Console.WriteLine("Edit Contact");
                Console.WriteLine("----------------");
                Console.Write("Name : ");
                string? name = Console.ReadLine();
                if (name == null)
                {
                    ErrorMassage();
                    Console.ReadKey();
                    continue;
                }
                var result = cr.Find(name);
                if (result != null)
                    Console.WriteLine($"Name : {result.Name} | PhoneNumber : {result.PhoneNumber}");
                else
                {
                    ErrorMassage();
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine("---------------------");
                Console.Write("New Name : ");
                string? newname = Console.ReadLine();
                if (newname == null)
                {
                    ErrorMassage();
                    Console.ReadKey();

                    continue;
                }
                Console.Write("New Phonenumber : ");
                if (!long.TryParse(Console.ReadLine(), out long phonenumber))
                {
                    ErrorMassage();
                    Console.ReadKey();

                    continue;
                }
                cr.Edit(name, newname, phonenumber);
                Console.WriteLine("Contact Edited.");
                Console.ReadKey();
            }
            break;
        case "3":
            {
                Console.WriteLine("Find Contact");
                Console.WriteLine("------------------");
                Console.Write("Name Find : ");
                string? name = Console.ReadLine();
                if (name == null)
                {
                    ErrorMassage();
                    Console.ReadKey();

                    continue;
                }
                var result = cr.Find(name);
                if (result != null)
                    Console.WriteLine($"Name : {result.Name} | Phonenumber : {result.PhoneNumber}");
                else
                {
                    ErrorMassage();
                    Console.ReadKey();

                    continue;
                }
                Console.ReadKey();
            }
            break;
        case "4":
            {
                Console.WriteLine("Remove Cantact");
                Console.WriteLine("---------------------");
                Console.Write("Input Name : ");
                string? name = Console.ReadLine();
                Console.Write("Input PhoneNumber : ");
                if (!long.TryParse(Console.ReadLine(), out long phonenumber))
                {
                    ErrorMassage();
                    Console.ReadKey();

                    continue;
                }
                if (name != null && cr.Remove(name, phonenumber))
                {
                    Console.WriteLine("Are you sure remove cantact? (1.Yes | 2.No)");
                    var result = Console.ReadLine();
                    if (result != null && result == "1")
                    {
                        cr.Remove(name, phonenumber);
                        Console.WriteLine("Contact Removed.");
                        Console.ReadKey();
                    }
                    else
                    {
                        ErrorMassage();
                        Console.ReadKey();

                        continue;
                    }
                    
                }
               
            }
            break;
        case "5":
            {
                int count = 0;
                Console.WriteLine("List Contact");
                Console.WriteLine("----------------------");
                List<Contact> result = cr.List();

                if (result.Count != 0)
                {
                    foreach (var r in result)
                    {
                        count++;
                        Console.WriteLine($"{count}.Name : {r.Name}  | PhoneNumber : {r.PhoneNumber}");
                        Console.WriteLine("-----------------------------");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Can you delete a contact? (1.yes | 2.No)");
                    var number = Console.ReadLine();
                    if (number != null && number == "1")
                    {
                        Console.Write("Input Contact Index : ");
                        if (!int.TryParse(Console.ReadLine(), out int index))
                        {
                            ErrorMassage();
                            Console.ReadKey();
                            continue;
                        }
                        cr.RemoveByIndex(index);
                        Console.WriteLine("Contact Removed.");
                        Console.WriteLine("Press any kry to continue...");
                        Console.ReadKey();


                    }
                }
            }
            break;
        case "6":
            {
                Console.WriteLine("Are you sure you want to Clear the list? (1.Yes | 2.No)");
                string? number = Console.ReadLine();
                if (number != null && number == "1")
                {
                    cr.ClearList();
                    Console.WriteLine("The list was cleared");
                    Console.WriteLine("Press any key  to continue...");
                    Console.ReadKey();
                }
                else if (number == "2")
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                break;
            }
        case "7":
            return;
        default:
            ErrorMassage();
            continue;
            
    }
}
static void ErrorMassage()
{
    Console.WriteLine("name is not Valid or name is not found!");
    Console.WriteLine("Press any key to continue...");
}