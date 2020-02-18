using System.Collections.Generic;
using System.Xml.Serialization;

namespace DHL.Services.Models
{
    [XmlRoot(ElementName = "Version", Namespace = "http://dhl.de/webservices/businesscustomershipping")]
    public class Version
    {
        [XmlElement(ElementName = "majorRelease")]
        public string MajorRelease { get; set; }

        [XmlElement(ElementName = "minorRelease")]
        public string MinorRelease { get; set; }
    }

    [XmlRoot(ElementName = "Status")]
    public class Status
    {
        [XmlElement(ElementName = "statusCode")]
        public string StatusCode { get; set; }

        [XmlElement(ElementName = "statusText")]
        public string StatusText { get; set; }

        [XmlElement(ElementName = "statusMessage")]
        public List<string> StatusMessage { get; set; }
    }

    [XmlRoot(ElementName = "LabelData")]
    public class LabelData
    {
        [XmlElement(ElementName = "Status")]
        public Status Status { get; set; }

        [XmlElement(ElementName = "shipmentNumber", Namespace = "http://dhl.de/webservice/cisbase")]
        public string ShipmentNumber { get; set; }

        [XmlElement(ElementName = "labelUrl")]
        public string LabelUrl { get; set; }
    }

    [XmlRoot(ElementName = "CreationState")]
    public class CreationState
    {
        [XmlElement(ElementName = "sequenceNumber")]
        public string SequenceNumber { get; set; }

        [XmlElement(ElementName = "LabelData")]
        public LabelData LabelData { get; set; }
    }

    [XmlRoot(ElementName = "CreateShipmentOrderResponse", Namespace = "http://dhl.de/webservices/businesscustomershipping")]
    public class CreateShipmentOrderResponse
    {
        [XmlElement(ElementName = "Version", Namespace = "http://dhl.de/webservices/businesscustomershipping")]
        public Version Version { get; set; }

        [XmlElement(ElementName = "Status")]
        public Status Status { get; set; }

        [XmlElement(ElementName = "CreationState")]
        public CreationState CreationState { get; set; }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlElement(ElementName = "CreateShipmentOrderResponse", Namespace = "http://dhl.de/webservices/businesscustomershipping")]
        public CreateShipmentOrderResponse CreateShipmentOrderResponse { get; set; }
    }

    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class ShipmentOrderResponse
    {
        [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public string Header { get; set; }

        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }

        [XmlAttribute(AttributeName = "bcs", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Bcs { get; set; }

        [XmlAttribute(AttributeName = "cis", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Cis { get; set; }

        [XmlAttribute(AttributeName = "soap", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Soap { get; set; }

        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
    }
}
