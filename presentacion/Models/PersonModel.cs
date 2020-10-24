using System.Runtime.CompilerServices;
using System.Reflection.PortableExecutable;
using System.Reflection.Metadata.Ecma335;
using Entity;

namespace presentacion.Models
{
    public class SupportModel
    {
        public string IdSupport { get; set; }
        public decimal Value { get; set; }
        public string Modality { get; set; }
        public string Date { get; set; }
    }
    public class PersonInputModel
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public SupportModel Support { get; set; }

    }

    public class PersonViewModel : PersonInputModel
    {
        public PersonViewModel(){}

        public PersonViewModel(Person person)
        {
            Identification = person.Identification;
            Name = person.Name;
            Surnames = person.Surnames;
            Sex = person.Sex;
            Age = person.Age;
            Department = person.Department;
            City = person.City;
            Support =  new SupportModel();
            Support.IdSupport = person.Support.IdSupport;
            Support.Value = person.Support.Value;
            Support.Modality = person.Support.Modality;
            Support.Date = person.Support.Date;
        }

       
    } 
}