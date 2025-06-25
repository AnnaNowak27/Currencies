using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Currencies
{
    public partial class Form1 : Form
    {
        Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>();

        public Form1()
        {
            InitializeComponent();
            _ = LoadExchangeRatesAsync();
        }

        private async Task LoadExchangeRatesAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://api.nbp.pl/api/exchangerates/tables/A/?format=json";
                    string response = await client.GetStringAsync(url);

                    var tables = JsonConvert.DeserializeObject<List<ExchangeRateResponse>>(response);
                    var rates = tables?[0].rates;

                    if (rates != null)
                    {
                        foreach (var rate in rates)
                        {
                            exchangeRates[rate.code] = rate.mid;
                            comboBox1.Items.Add(rate.code);
                        }

                        if (comboBox1.Items.Count > 0)
                            comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Nie udało się załadować kursów walut.", "Błąd");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania danych: " + ex.Message, "Błąd");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out decimal amountPLN))
            {
                string selectedCurrency = comboBox1.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(selectedCurrency) && exchangeRates.TryGetValue(selectedCurrency, out decimal rate))
                {
                    decimal result = amountPLN / rate;
                    MessageBox.Show($"{amountPLN} PLN = {result:F2} {selectedCurrency}", "Wynik");
                }
                else
                {
                    MessageBox.Show("Nieznany kurs waluty.", "Błąd");
                }
            }
            else
            {
                MessageBox.Show("Wprowadź poprawną wartość liczbową.", "Błąd");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class Rate
    {
        public string currency { get; set; }
        public string code { get; set; }
        public decimal mid { get; set; }
    }

    public class ExchangeRateResponse
    {
        public string table { get; set; }
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public List<Rate> rates { get; set; }
    }
}
