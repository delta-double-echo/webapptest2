using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBookTestApp
{
    [Table("PHONEBOOK")]
    public class Person
    {
        [Key] //normally a name would not be a key but I wanted to avoid editing the table structure
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
    }
}