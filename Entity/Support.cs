using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Support
    {
        [Key]
        [Column(TypeName= "nvarchar(3)")]
        public string IdSupport { get; set; }
        [Column(TypeName= "decimal(15,2)")]
        public decimal Value { get; set; }
        [Column(TypeName= "nvarchar(15)")]
        public string Modality { get; set; }
        [Column(TypeName= "nvarchar(15)")]
        public string Date { get; set; }
    }
}