using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class ExMessageDto
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
