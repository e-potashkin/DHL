using System.Xml.Serialization;

namespace DHL.Models.Response
{
    [XmlRoot("Envelope")]
    public class SoapResponse
    {
        [XmlAttribute("labelUrl")]
        public string LabelUrl { get; set; }
    }
}
