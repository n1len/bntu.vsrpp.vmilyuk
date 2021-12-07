using bntu.vsrpp.vmilyuk.Core.Models;
using Newtonsoft.Json;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bntu.vsrpp.vmilyuk.lab2
{
    public partial class MainWindow : Form
    {
        private readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://www.nbrb.by/api/exrates/")
        };

        private List<Currency> currencies;

        public MainWindow()
        {
            InitializeComponent();
            InitializeAllCurrency();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Currency curr = null;
            float count = 0f;
            try
            {
                if (comboBox1.SelectedItem.ToString() != "BYN")
                {
                    curr = currencies.FirstOrDefault(c => c.Cur_Name == comboBox1.SelectedItem.ToString());

                    HttpResponseMessage response = client.GetAsync($"rates/{curr.Cur_Abbreviation}?parammode=2").Result;

                    var result = await response.Content.ReadAsStringAsync();

                    var firstCurrency = JsonConvert.DeserializeObject<Rate>(result);

                    if (comboBox2.SelectedItem.ToString() != "BYN")
                    {
                        curr = currencies.FirstOrDefault(c => c.Cur_Name == comboBox2.SelectedItem.ToString());

                        response = client.GetAsync($"rates/{curr.Cur_Abbreviation}?parammode=2").Result;

                        result = await response.Content.ReadAsStringAsync();

                        var secondCurrency = JsonConvert.DeserializeObject<Rate>(result);

                        float.TryParse(textBox2.Text, out count);

                        textBox1.Text = (count * (firstCurrency.Cur_Scale / secondCurrency.Cur_Scale) *
                            (float)(secondCurrency.Cur_OfficialRate / firstCurrency.Cur_OfficialRate)).ToString();
                    }
                    else
                    {
                        float.TryParse(textBox2.Text, out count);

                        textBox1.Text = (count * (float)(firstCurrency.Cur_Scale) / (float)firstCurrency.Cur_OfficialRate).ToString();
                    }
                }
                else
                {
                    if (comboBox2.SelectedItem.ToString() != "BYN")
                    {
                        curr = currencies.FirstOrDefault(c => c.Cur_Name == comboBox2.SelectedItem.ToString());

                        HttpResponseMessage response = client.GetAsync($"rates/{curr.Cur_Abbreviation}?parammode=2").Result;

                        var result = await response.Content.ReadAsStringAsync();

                        var secondCurrency = JsonConvert.DeserializeObject<Rate>(result);

                        float.TryParse(textBox2.Text, out count);

                        textBox1.Text = (count / (float)secondCurrency.Cur_Scale * (float)secondCurrency.Cur_OfficialRate).ToString();
                    }
                    else
                    {
                        textBox1.Text = textBox2.Text;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка, низя такую конвертацию сделать.");
            }
        }

        private async void InitializeAllCurrency()
        {
            comboBox1.Items.Add("BYN");
            comboBox2.Items.Add("BYN");

            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox2.Items[0];

            HttpResponseMessage response = client.GetAsync("rates?periodicity=0").Result;

            var result = await response.Content.ReadAsStringAsync();

            currencies = JsonConvert.DeserializeObject<List<Currency>>(result);

            foreach(var i in currencies)
            {
                comboBox1.Items.Add(i.Cur_Name);
                comboBox2.Items.Add(i.Cur_Name);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Currency curr = null;
            float count = 0f;
            try
            {
                if (comboBox1.SelectedItem.ToString() != "BYN")
                {
                    curr = currencies.FirstOrDefault(c => c.Cur_Name == comboBox1.SelectedItem.ToString());

                    HttpResponseMessage response = client.GetAsync($"rates/{curr.Cur_Abbreviation}?parammode=2").Result;

                    var result = await response.Content.ReadAsStringAsync();

                    var firstCurrency = JsonConvert.DeserializeObject<Rate>(result);

                    if (comboBox2.SelectedItem.ToString() != "BYN")
                    {
                        curr = currencies.FirstOrDefault(c => c.Cur_Name == comboBox2.SelectedItem.ToString());

                        response = client.GetAsync($"rates/{curr.Cur_Abbreviation}?parammode=2").Result;

                        result = await response.Content.ReadAsStringAsync();

                        var secondCurrency = JsonConvert.DeserializeObject<Rate>(result);

                        float.TryParse(textBox1.Text, out count);

                        textBox2.Text = (count / (firstCurrency.Cur_Scale / secondCurrency.Cur_Scale) * 
                            (float)(firstCurrency.Cur_OfficialRate / secondCurrency.Cur_OfficialRate)).ToString();
                    }
                    else
                    {
                        float.TryParse(textBox1.Text, out count);

                        textBox2.Text = (count / (float)firstCurrency.Cur_Scale * (float)firstCurrency.Cur_OfficialRate).ToString();
                    }
                }
                else
                {
                    if (comboBox2.SelectedItem.ToString() != "BYN")
                    {
                        curr = currencies.FirstOrDefault(c => c.Cur_Name == comboBox2.SelectedItem.ToString());

                        HttpResponseMessage response = client.GetAsync($"rates/{curr.Cur_Abbreviation}?parammode=2").Result;

                        var result = await response.Content.ReadAsStringAsync();

                        var secondCurrency = JsonConvert.DeserializeObject<Rate>(result);

                        float.TryParse(textBox1.Text, out count);

                        textBox2.Text = (count * secondCurrency.Cur_Scale / (float)secondCurrency.Cur_OfficialRate).ToString();
                    }
                    else
                    {
                        textBox2.Text = textBox1.Text;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка, низя такую конвертацию сделать.");
            }
            
        }

        private void btnShowDiagram_Click(object sender, EventArgs e)
        {
            ChartWindow window = new ChartWindow(currencies);
            window.Show();
        }
    }
}
