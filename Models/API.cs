using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WPF_CRYPTO.Models
{
    public class API
    {
        private readonly HttpClient httpClient;
        private const string CoinCapBaseUrl = "https://api.coincap.io/v2/";

        public API()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(CoinCapBaseUrl);
        }

        public async Task<List<Cryptocurrency>> GetTopCurrencies(int count)
        {
            try
            {
                string endpoint = $"assets?limit={count}&sort=rank";
                HttpResponseMessage response = await httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var jsonObject = JsonSerializer.Deserialize<JsonElement>(data);

                    if (jsonObject.TryGetProperty("data", out var dataProperty))
                    {
                        var cryptocurrencies = new List<Cryptocurrency>();

                        foreach (var currencyProperty in dataProperty.EnumerateArray())
                        {
                            var cryptocurrency = new Cryptocurrency
                            {
                                Id = currencyProperty.GetProperty("id").GetString(),
                                Rank = Convert.ToInt32(currencyProperty.GetProperty("rank").GetString()),
                                Symbol = currencyProperty.GetProperty("symbol").GetString(),
                                Name = currencyProperty.GetProperty("name").GetString(),
                                Supply = Math.Round(decimal.Parse(currencyProperty.GetProperty("supply").GetString(), CultureInfo.InvariantCulture)),
                                MarketCapUsd = Math.Round(decimal.Parse(currencyProperty.GetProperty("marketCapUsd").GetString(), CultureInfo.InvariantCulture)),
                                VolumeUsd24Hr = Math.Round(decimal.Parse(currencyProperty.GetProperty("volumeUsd24Hr").GetString(), CultureInfo.InvariantCulture)),
                                PriceUsd = Math.Round(decimal.Parse(currencyProperty.GetProperty("priceUsd").GetString(), CultureInfo.InvariantCulture)),
                                ChangePercent24Hr = Math.Round(decimal.Parse(currencyProperty.GetProperty("changePercent24Hr").GetString(), CultureInfo.InvariantCulture), 5),
                                Vwap24Hr = Math.Round(decimal.Parse(currencyProperty.GetProperty("vwap24Hr").GetString(), CultureInfo.InvariantCulture))
                            };

                            var maxSupplyProperty = currencyProperty.GetProperty("maxSupply");
                            if (maxSupplyProperty.GetString() != null)
                            {
                                cryptocurrency.MaxSupply = Math.Round(decimal.Parse(maxSupplyProperty.GetString(), CultureInfo.InvariantCulture));
                            }
                            else
                            {
                                cryptocurrency.MaxSupply = 0;
                            }

                            cryptocurrencies.Add(cryptocurrency);
                        }

                        return cryptocurrencies;

                    }
                }
            }
            catch
            {
                ;
            }

            return null;
        }
    }
}
