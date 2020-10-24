using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Person
    {
        [Key]
        [Column(TypeName= "nvarchar(11)")]
        public string Identification { get; set; }
        [Column(TypeName= "nvarchar(30)")]
        public string Name { get; set; }
        [Column(TypeName= "nvarchar(11)")]
        public string Surnames { get; set; }
        [Column(TypeName= "nvarchar(2)")]
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        [Column(TypeName= "nvarchar(20)")]
        public string City { get; set; }
        [Column("IdSupport",TypeName= "nvarchar(20)")]
        public Support Support { get; set; }       
    }
}
