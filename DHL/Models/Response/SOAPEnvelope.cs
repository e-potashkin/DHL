using System.Xml.Serialization;

namespace DHL.Models.Response
{
    [XmlType(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class SOAPEnvelope
    {
        [XmlAttribute(AttributeName = "soapenv", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public string soapenva { get; set; }

        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string xsd { get; set; }

        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string xsi { get; set; }

        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public ResponseBody<CreateShipmentOrderResponse> body { get; set; }

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();

        public SOAPEnvelope()
        {
            xmlns.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
        }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class ResponseBody<T>
    {
        [XmlElement(Namespace = "http://xmlns.xyz.com/webservice/version")]
        public T Body { get; set; }
    }

    public class CreateShipmentOrderResponse
    {
        public CreationState CreationState { get; set; }
    }

    public class CreationState
    {
        public LabelData LabelData { get; set; }
    }

    public class LabelData
    {
        public string LabelUrl { get; set; }
    }
}
