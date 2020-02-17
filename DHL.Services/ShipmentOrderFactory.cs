using DHL.Common.Models.Authentication;
using DHL.Services.Abstractions;
using DHL.Services.Models;

namespace DHL.Services
{
    public class ShipmentOrderFactory : IShipmentOrderFactory
    {
        private readonly AuthConfiguration _authConfig;

        public ShipmentOrderFactory(AuthConfiguration authConfig)
        {
            _authConfig = authConfig;
        }

        public string CreatePayload(ShipmentOrder shipmentOrder)
        {
            return string.Empty;
//             return $@"<?xml version=""1.0"" encoding=""utf-8""?>
// <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:cis=""http://dhl.de/webservice/cisbase"" xmlns:bus=""http://dhl.de/webservices/businesscustomershipping"">
//    <soapenv:Header>
//       <cis:Authentification>
//          <cis:user>{_authConfig.User}</cis:user>
//          <cis:signature>{_authConfig.Signature}</cis:signature>
//          <cis:apiUser>{_authConfig.ApiUser}</cis:apiUser>
//          <cis:apiPassword>{_authConfig.ApiPassword}</cis:apiPassword>
//       </cis:Authentification>
//    </soapenv:Header>
//    <soapenv:Body>
//       <bus:CreateShipmentOrderRequest>
//          <bus:Version>
//             <majorRelease>3</majorRelease>
//             <minorRelease>0</minorRelease>
//          </bus:Version>
//          <ShipmentOrder>
//             <sequenceNumber>{shipmentOrder.SequenceNumber}</sequenceNumber>
//             <Shipment>
//                <ShipmentDetails>
//                   <product>{shipmentOrder.Shipment.ShipmentDetails.Product}</product>
//                   <cis:accountNumber>{shipmentOrder.Shipment.ShipmentDetails.AccountNumber}</cis:accountNumber>
//                   <customerReference>{shipmentOrder.Shipment.ShipmentDetails.CustomerReference}</customerReference>
//                   <shipmentDate>{shipmentOrder.Shipment.ShipmentDetails.ShipmentDate}</shipmentDate>
//                   <ShipmentItem>
//                      <weightInKG>{shipmentOrder.Shipment.ShipmentDetails.WeightInKG}</weightInKG>
//                   </ShipmentItem>
//                   <Notification>
//                      {string.Join("\n", shipmentOrder.Shipment.ShipmentDetails.Notifications.Select(x => x.Email))}
//                   </Notification>
//                </ShipmentDetails>
//                <Shipper>
//                   <Name>
//                      <cis:name1>{shipmentOrder.Shipment.Shipper.Name1}</cis:name1>
//                   </Name>
//                   <Address>
//                      <cis:streetName>{shipmentOrder.Shipment.Shipper.Address.StreetName}</cis:streetName>
//                      <cis:streetNumber>{shipmentOrder.Shipment.Shipper.Address.StreetNumber}</cis:streetNumber>
//                      <cis:zip>{shipmentOrder.Shipment.Shipper.Address.ZIP}</cis:zip>
//                      <cis:city>{shipmentOrder.Shipment.Shipper.Address.City}</cis:city>
//                      <cis:Origin>
//                         <cis:country>{shipmentOrder.Shipment.Shipper.Address.Country}</cis:country>
//                      </cis:Origin>
//                   </Address>
//                   <Communication>
//                   <cis:phone>{shipmentOrder.Shipment.Receiver.Phone}</cis:phone>
//                   </Communication>
//                </Shipper>
//                <Receiver>
//                   <cis:name1>{shipmentOrder.Shipment.Receiver.Name1}</cis:name1>
//                   <cis:name2>{shipmentOrder.Shipment.Receiver.Name2}</cis:name2>
//                   <cis:name3>{shipmentOrder.Shipment.Receiver.Name3}</cis:name3>
//                   <Address>
//                     <cis:streetName>{shipmentOrder.Shipment.Receiver.Address.StreetName}</cis:streetName>
//                      <cis:streetNumber>{shipmentOrder.Shipment.Receiver.Address.StreetNumber}</cis:streetNumber>
//                      <cis:zip>{shipmentOrder.Shipment.Receiver.Address.ZIP}</cis:zip>
//                      <cis:city>{shipmentOrder.Shipment.Receiver.Address.City}</cis:city>
//                      <cis:Origin>
//                         <cis:country>{shipmentOrder.Shipment.Receiver.Address.Country}</cis:country>
//                      </cis:Origin>
//                   </Address>
//                   <Communication>
//                   </Communication>
//                </Receiver>
//             </Shipment>
//          </ShipmentOrder>
//       </bus:CreateShipmentOrderRequest>
//    </soapenv:Body>
// </soapenv:Envelope>";
        }
    }
}
