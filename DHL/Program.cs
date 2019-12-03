﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using DHL.Handlers;
using DHL.Models;
using Refit;

namespace DHL
{
    class Program
    {
        private static IDHLApi _api;
        private const string USER_NAME = "smart";
        private const string USER_PASSWORD = "/2F0WPhur!";
        private const string BASE_ADDRESS = "https://api-qa.dhlecommerce.com";

        static async Task Main(string[] args)
        {
            _api = RestService.For<IDHLApi>(new HttpClient(new AuthenticatedHttpClientHandler(GetAccessToken)) { BaseAddress = new Uri(BASE_ADDRESS) });
            var label = await _api.GetLabelAsync();

            Console.ReadLine();
        }

        private static async Task<AuthResponse> GetAccessToken() => await _api.GetAccessTokenAsync(USER_NAME, USER_PASSWORD);
    }
}