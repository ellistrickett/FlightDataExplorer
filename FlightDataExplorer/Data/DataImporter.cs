using CsvHelper;
using CsvHelper.Configuration;
using FlightDataExplorer.CsvMappings;
using FlightDataExplorer.Models;
using System.Globalization;

namespace FlightDataExplorer.Data
{
    public class DataImporter
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DataImporter(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Airport>> LoadAirportsFromUrl(string url)
        {
            return await LoadDataFromUrl<Airport>(url, new AirportCsvClassMap());
        }

        public async Task<List<Flight>> LoadFlightsFromUrl(string url)
        {
            return await LoadDataFromUrl<Flight>(url, new FlightCsvClassMap());
        }

        private async Task<List<T>> LoadDataFromUrl<T>(string url, ClassMap<T> classMap)
        {
            var httpClient = _httpClientFactory.CreateClient();

            try
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var reader = new StreamReader(stream))
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false }))
                    {
                        csv.Context.RegisterClassMap(classMap);
                        var records = csv.GetRecords<T>().ToList();
                        return records;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading data from URL '{url}': {ex.Message}");
                throw;
            }
        }
    }
}
