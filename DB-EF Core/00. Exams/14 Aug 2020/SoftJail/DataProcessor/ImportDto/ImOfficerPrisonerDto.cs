using SoftJail.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImOfficerPrisonerDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [XmlElement("Name")]
        public string FullName { get; set; }

        [XmlElement("Money")]
        public decimal Salary { get; set; }

        //[EnumDataType(typeof(Position))]
        [Required]
        [XmlElement("Position")]
        public string Position { get; set; }

        //[EnumDataType(typeof(Weapon))]
        [Required]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public virtual ImPrisonerDto[] Prisoners { get; set; }
    }
}