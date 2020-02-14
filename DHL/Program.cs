using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using DHL.Models.Request;
using DHL.Helpers;
using DHL.Models.Response;

namespace DHL
{
    internal static class Program
    {
        private const string User = "2222222222_01";
        private const string Signature = "pass";
        private const string ApiUser = "smart";
        private const string ApiPassword = "gruBA77!.";
        private const string Url = "https://cig.dhl.de/services/sandbox/soap";

        private static void Main()
        {
            var dhl = new DHLHelper(User, Signature, ApiUser, ApiPassword);
            var shipmentOrder = new ShipmentOrder
            {
                SequenceNumber = "3",
                Shipment = new Shipment
                {
                    ShipmentDetails = new ShipmentDetails
                    {
                        Product = "V01PAK",
                        AccountNumber = "22222222220101",
                        ShipmentDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        WeightInKG = "1",
                        CustomerReference = "ADVOKAT",
                        Notifications = new List<Notification>
                        {
                            new Notification("noreply@gmail.com")
                        }
                    },
                    Shipper = new Shipper
                    {
                        Name1 = "TMs",
                        Address = new Address("Westenhellweg", "106", "44137", "Dortmund", "Deutschland"),
                        Phone = "+49-152-5557-919"
                    },
                    Receiver = new Receiver
                    {
                        Name1 = "TMss",
                        Address = new Address("Ettore-Bugatti-Straße", "45", "51149", "Köln", "Deutschland"),
                        Phone = "+49-179-5552-591"
                    }
                }
            };

            var request = dhl.CreateShipmentOrderRequest(shipmentOrder);
            var response = dhl.SendRequest(Url, request);

            if (response.IsSuccessful)
            {
            }

            Console.ReadLine();
        }
    }
}
