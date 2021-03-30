using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Purchase")]
    public class PurchaseOutputModel
    {
        [Required]
        //[XmlElement("Card")]
        [RegularExpression("[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}")]
        public string Card { get; set; }

        [Required]
        [RegularExpression("[0-9]{3}")]
        public string Cvc { get; set; }

        [Required]
        public string Date { get; set; }

        public GameOutputModel Game { get; set; }
    }
}