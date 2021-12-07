using bntu.vsrpp.vmilyuk.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace bntu.vsrpp.vmilyuk.Core.Helper
{
    public class CurrencyHelper
    {
        private static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://www.nbrb.by/api/exrates/")
        };

        public static async Task<List<Currency>> GetCurrencies()
        {
            HttpResponseMessage response = client.GetAsync("rates?periodicity=0").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var currencies = JsonConvert.DeserializeObject<List<Currency>>(result);

                response = client.GetAsync("rates?periodicity=1").Result;
                result = await response.Content.ReadAsStringAsync();
                currencies.AddRange(JsonConvert.DeserializeObject<List<Currency>>(result));

                return currencies;
            }
            throw new Exception("Please verify your internet connection");
        }

        public static async Task<List<Currency>> GetAllCurrencies()
        {
            HttpResponseMessage response = client.GetAsync("currencies").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var currencies = JsonConvert.DeserializeObject<List<Currency>>(result);

                return currencies;
            }
            throw new Exception("Please verify your internet connection");
        }

        public static async Task<List<Currency>> GetDailyCurrencies()
        {
            HttpResponseMessage response = client.GetAsync("rates?periodicity=0").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var currencies = JsonConvert.DeserializeObject<List<Currency>>(result);

                return currencies;
            }
            throw new Exception("Please verify your internet connection");
        }
    }
}
