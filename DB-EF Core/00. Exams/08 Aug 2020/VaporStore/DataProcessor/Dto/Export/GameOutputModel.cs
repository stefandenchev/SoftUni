using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Game")]
    public class GameOutputModel
    {
        [Required]
        [XmlAttribute("title")]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

    }
}