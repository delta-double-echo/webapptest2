using System;

namespace PhoneBookTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.initializeDatabase();
                var phonebook = new PhoneBook();
                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */
                var person1 = new Person() { name = "John Smith", phoneNumber = "(248) 123-4567", address = "1234 Sand Hill Dr, Royal Oak, MI" };
                var person2 = new Person() { name = "Cynthia Smith", phoneNumber = "(824) 128-8758", address = "875 Main St, Ann Arbor, MI" };
               
                phonebook.addPerson(person1);
                Console.WriteLine($"Adding John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI");
                phonebook.addPerson(person2);
                Console.WriteLine($"Adding Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI");
                
                // TODO: print the phone book out to System.out
                Console.WriteLine();
                Console.WriteLine($"Phonebook Items:");
                foreach (var person in phonebook.getPhonebook()) {
                    Console.WriteLine($"Name: {person.name}, Phonenumber: {person.phoneNumber}, Address: {person.address}");
                }

                // TODO: find Cynthia Smith and print out just her entry
                var cynthia = phonebook.findPerson("CyNThiA", "smith");
                if (cynthia != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Showing Just Cynthia");
                    Console.WriteLine($"Name: {cynthia.name}, Phonenumber: {cynthia.phoneNumber}, Address: {cynthia.address}");
                }
                else {
                    Console.WriteLine($"Cynthia not found!");
                }

                // TODO: insert the new person objects into the database isn't this the 1st step?

                Console.ReadKey();
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
