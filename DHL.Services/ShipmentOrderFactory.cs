using System;
using DHL.Common.Extensions;
using DHL.Common.Models.Authentication;
using DHL.Services.Abstractions;
using DHL.Services.Models;

namespace DHL.Services
{
    public class ShipmentOrderFactory : IShipmentOrderFactory
    {
        private const string SequenceNumber = "1";
        private const string Product = "V01PAK";
        private const string AccountNumber = "22222222220101";
        private const string Country = "Deutschland";

        private readonly AuthConfiguration _authConfig;

        public ShipmentOrderFactory(AuthConfiguration authConfig)
        {
            _authConfig = authConfig;
        }

        public string CreatePayload(ShipmentOrder shipmentOrder, MgTechnoCompanyInfo companyInfo)
        {
            return $@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:cis=""http://dhl.de/webservice/cisbase"" xmlns:bus=""http://dhl.de/webservices/businesscustomershipping"">
               <soapenv:Header>
                  <cis:Authentification>
                     <cis:user>{_authConfig.User}</cis:user>
                     <cis:signature>{_authConfig.Signature}</cis:signature>
                     <cis:apiUser>{_authConfig.ApiUser}</cis:apiUser>
                     <cis:apiPassword>{_authConfig.ApiPassword}</cis:apiPassword>
                  </cis:Authentification>
               </soapenv:Header>
               <soapenv:Body>
                  <bus:CreateShipmentOrderRequest>
                     <bus:Version>
                        <majorRelease>3</majorRelease>
                        <minorRelease>0</minorRelease>
                     </bus:Version>
                     <ShipmentOrder>
                        <sequenceNumber>{SequenceNumber}</sequenceNumber>
                        <Shipment>
                           <ShipmentDetails>
                              <product>{Product}</product>
                              <cis:accountNumber>{AccountNumber}</cis:accountNumber>
                              <customerReference>{shipmentOrder.CustomerReference}</customerReference>
                              <shipmentDate>{DateTime.Now:yyyy-MM-dd}</shipmentDate>
                              <ShipmentItem>
                                 <weightInKG>{shipmentOrder.Weight}</weightInKG>
                              </ShipmentItem>
                           </ShipmentDetails>
                           <Shipper>
                              <Name>
                                 <cis:name1>{companyInfo.Brand}</cis:name1>
                              </Name>
                              <Address>
                                 <cis:streetName>{companyInfo.Address.Street.GetName()}</cis:streetName>
                                 <cis:streetNumber>{companyInfo.Address.Street.GetNumber()}</cis:streetNumber>
                                 <cis:zip>{companyInfo.Address.ZipCode}</cis:zip>
                                 <cis:city>{companyInfo.Address.City}</cis:city>
                                 <cis:Origin>
                                    <cis:countryISOCode>{companyInfo.CountryId}</cis:countryISOCode>
                                 </cis:Origin>
                              </Address>
                           </Shipper>
                           <Receiver>
                              <cis:name1>{shipmentOrder.FirstName}</cis:name1>
                              <Address>
                                 <cis:streetName>{shipmentOrder.StreetName}</cis:streetName>
                                 <cis:streetNumber>{shipmentOrder.StreetNumber}</cis:streetNumber>
                                 <cis:zip>{shipmentOrder.Zip}</cis:zip>
                                 <cis:city>{shipmentOrder.City}</cis:city>
                                 <cis:Origin>
                                    <cis:country>{Country}</cis:country>
                                 </cis:Origin>
                              </Address>
                              <Communication>
                                <cis:contactPerson>{shipmentOrder.FirstName} {shipmentOrder.LastName}</cis:contactPerson>
                              </Communication>
                           </Receiver>
                        </Shipment>
                     </ShipmentOrder>
                  </bus:CreateShipmentOrderRequest>
               </soapenv:Body>
            </soapenv:Envelope>";
        }
    }
}
