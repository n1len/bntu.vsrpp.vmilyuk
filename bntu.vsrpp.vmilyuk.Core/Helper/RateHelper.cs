using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using bntu.vsrpp.vmilyuk.Core.Models;
using Newtonsoft.Json;

namespace bntu.vsrpp.vmilyuk.Core.Helper
{
    public class RateHelper
    {
        private static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://www.nbrb.by/api/exrates/")
        };

        public static async Task<Rate> GetRate(Currency curr)
        {
            HttpResponseMessage response = client.GetAsync($"rates/{curr.Cur_Abbreviation}?parammode=2").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var rate = JsonConvert.DeserializeObject<Rate>(result);

                return rate;
            }
            throw new Exception("Please verify your internet connection");
        }

        public static async Task<List<ShortRate>> GetShortRates(int currId, DateTime startDate, DateTime endDate)
        {
            var request = $"rates/dynamics/{currId}?startDate={startDate:yyyy-M-d}&endDate={endDate:yyyy-M-d}";

            HttpResponseMessage response = client.GetAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                List<ShortRate> shortRates = JsonConvert.DeserializeObject<List<ShortRate>>(result);

                return shortRates;
            }
            throw new Exception("Please verify your internet connection");
        }
    }
}
