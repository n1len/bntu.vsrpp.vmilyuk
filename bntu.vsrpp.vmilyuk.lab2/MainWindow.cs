using bntu.vsrpp.vmilyuk.Core.Helper;
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
        private List<Currency> currencies;

        public MainWindow()
        {
            InitializeComponent();
            InitializeAllCurrency();
        }

        private async void btnFromRightToLeft_Click(object sender, EventArgs e)
        {
            Currency curr = null;
            float count = 0f;
            try
            {
                if (comboBox1.SelectedItem.ToString() != "BYN")
                {
                    curr = currencies.FirstOrDefault(c => c.Cur_Name == comboBox1.SelectedItem.ToString());
                    var firstRate = await RateHelper.GetRate(curr);

                    if (comboBox2.SelectedItem.ToString() != "BYN")
                    {
                        curr = currencies.FirstOrDefault(c => c.Cur_Name == comboBox2.SelectedItem.ToString());
                        var secondRate = await RateHelper.GetRate(curr);
                        float.TryParse(textBox2.Text, out count);

                        textBox1.Text = (count * (firstRate.Cur_Scale / secondRate.Cur_Scale) *
                            (float)(secondRate.Cur_OfficialRate / firstRate.Cur_OfficialRate)).ToString();
                    }
                    else
                    {
                        float.TryParse(textBox2.Text, out count);

                        textBox1.Text = (count * (float)(firstRate.Cur_Scale) / (float)firstRate.Cur_OfficialRate).ToString();
                    }
                }
                else
                {
                    if (comboBox2.SelectedItem.ToString() != "BYN")
                    {
                        curr = currencies.FirstOrDefault(c => c.Cur_Name == comboBox2.SelectedItem.ToString());
                        var secondCurrency = await RateHelper.GetRate(curr);
                        float.TryParse(textBox2.Text, out count);

                        textBox1.Text = (count / (float)secondCurrency.Cur_Scale * (float)secondCurrency.Cur_OfficialRate).ToString();
                    }
                    else
                    {
                        textBox1.Text = textBox2.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error.{ex.Message}");
            }
        }

        private async void InitializeAllCurrency()
        {
            comboBox1.Items.Add("BYN");
            comboBox2.Items.Add("BYN");

            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox2.Items[0];

            currencies = await CurrencyHelper.GetCurrencies();

            foreach (var i in currencies)
            {
                comboBox1.Items.Add(i.Cur_Name);
                comboBox2.Items.Add(i.Cur_Name);
            }
        }

        private async void btnFromLeftToRight_Click(object sender, EventArgs e)
        {
            Currency curr = null;
            float count = 0f;
            try
            {
                if (comboBox1.SelectedItem.ToString() != "BYN")
                {
                    curr = currencies.FirstOrDefault(c => c.Cur_Name == comboBox1.SelectedItem.ToString());
                    var firstRate = await RateHelper.GetRate(curr);   

                    if (comboBox2.SelectedItem.ToString() != "BYN")
                    {
                        curr = currencies.FirstOrDefault(c => c.Cur_Name == comboBox2.SelectedItem.ToString());
                        var secondRate = await RateHelper.GetRate(curr);
                        float.TryParse(textBox1.Text, out count);

                        textBox2.Text = (count / (firstRate.Cur_Scale / secondRate.Cur_Scale) * 
                            (float)(firstRate.Cur_OfficialRate / secondRate.Cur_OfficialRate)).ToString();
                    }
                    else
                    {
                        float.TryParse(textBox1.Text, out count);

                        textBox2.Text = (count / (float)firstRate.Cur_Scale * (float)firstRate.Cur_OfficialRate).ToString();
                    }
                }
                else
                {
                    if (comboBox2.SelectedItem.ToString() != "BYN")
                    {
                        curr = currencies.FirstOrDefault(c => c.Cur_Name == comboBox2.SelectedItem.ToString());
                        var secondCurrency = await RateHelper.GetRate(curr);
                        float.TryParse(textBox1.Text, out count);

                        textBox2.Text = (count * secondCurrency.Cur_Scale / (float)secondCurrency.Cur_OfficialRate).ToString();
                    }
                    else
                    {
                        textBox2.Text = textBox1.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error.{ex.Message}");
            }
            
        }

        private async void btnShowDiagram_Click(object sender, EventArgs e)
        {
            var allCurrencies = await CurrencyHelper.GetAllCurrencies();
            var dailyCurrencies = await CurrencyHelper.GetDailyCurrencies();

            ChartWindow window = new ChartWindow(allCurrencies, dailyCurrencies);
            window.Show();
        }
    }
}
