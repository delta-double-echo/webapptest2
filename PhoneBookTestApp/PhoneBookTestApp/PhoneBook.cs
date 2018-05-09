using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        public void addPerson(Person newPerson)
        {
            try {
                using (var context = new PhonebookContext()) {
                    var test = context.PHONEBOOK.ToList();
                    context.PHONEBOOK.Add(newPerson);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured adding {newPerson.name}");
                Console.WriteLine($"Error Details: {ex}");
            }
        }

        public Person findPerson(string firstName, string lastName)
        {
            try
            {
                var person = new Person();
                //In a real implementation the firstname and last name would be a separate property of person to allow for better querying etc
                using (var context = new PhonebookContext())
                {
                    person = context.PHONEBOOK.FirstOrDefault(p => p.name.ToUpper().Contains(firstName.ToUpper()) && p.name.ToUpper().Contains(lastName.ToUpper()));
                }

                return person;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured finding person {firstName} {lastName}");
                Console.WriteLine($"Error Details: {ex}");
            }

            return null;
        }

        public IEnumerable<Person> getPhonebook()
        {
            var phonebook = new List<Person>();
            try
            {
                using (var context = new PhonebookContext())
                {
                    phonebook = context.PHONEBOOK.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured getting phonebook");
                Console.WriteLine($"Error Details: {ex}");
            }
            return phonebook;
        }
    }
}