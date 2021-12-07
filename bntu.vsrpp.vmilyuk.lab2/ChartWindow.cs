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
using System.Windows.Forms;

namespace bntu.vsrpp.vmilyuk.lab2
{
    public partial class ChartWindow : Form
    {
        private readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://www.nbrb.by/api/exrates/")
        };

        private List<Currency> currencies;
        private List<Currency> allCurrencies;
        private List<Currency> foundCurrencies = new List<Currency>();
        private List<Currency> foundCurrenciesChanged = new List<Currency>();

        public ChartWindow(List<Currency> allCurrencies,List<Currency> currencies)
        {
            this.currencies = currencies;
            this.allCurrencies = allCurrencies;
            InitializeComponent();
            InitializeCurrencies();
        }

        private void InitializeCurrencies()
        {
            comboBox1.Items.Clear();
            foreach(var currency in currencies)
            {
                comboBox1.Items.Add(currency.Cur_Scale + " " + currency.Cur_Name);
            }
        }

        private async void btnShowDiagram_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateDateTime())
                {
                    var rates = new List<ShortRate>();
                    var rateName = comboBox1.SelectedItem.ToString();

                    var curDateTime = startDateTime.Value;
                    var nextDateTime = endDateTime.Value;

                    foundCurrencies = allCurrencies.FindAll(a => a.Cur_QuotName.Equals(rateName));
                    foundCurrenciesChanged = allCurrencies.FindAll(a => a.Cur_QuotName.Equals(rateName));

                    foreach (Currency item in foundCurrencies)
                    {
                        if (item.Cur_DateEnd < startDateTime.Value)
                            foundCurrenciesChanged.Remove(item);
                    }

                    var currentRateId = foundCurrenciesChanged[0].Cur_ID;

                    while (true)
                    {
                        if (curDateTime.AddDays(365) < foundCurrenciesChanged.Find(a => a.
                                Cur_ID.Equals(currentRateId)).Cur_DateEnd)
                        {
                            if (curDateTime.AddDays(365) < endDateTime.Value)
                            {
                                nextDateTime = curDateTime.AddDays(365);
                            }
                            else
                            {
                                nextDateTime = endDateTime.Value;
                            }
                        }
                        else
                            nextDateTime = foundCurrenciesChanged.Find(a => a.
                                Cur_ID.Equals(currentRateId)).Cur_DateEnd;;

                        rates.AddRange(await RateHelper.GetShortRates(currentRateId, curDateTime, nextDateTime));
                        curDateTime = nextDateTime.AddDays(1);

                        if (nextDateTime.Equals(endDateTime.Value))
                            break;

                        if (curDateTime > foundCurrenciesChanged.Find(a => a.
                            Cur_ID.Equals(currentRateId)).Cur_DateEnd)
                        {
                            if (foundCurrenciesChanged.Any(a => a.Cur_DateStart.Equals(curDateTime)))
                                currentRateId = foundCurrenciesChanged.Find(a => a.Cur_DateStart.Equals(curDateTime)).
                                    Cur_ID;
                            else
                                break;
                        }
                    }

                    var line1 = new OxyPlot.Series.LineSeries()
                    {
                        Title = $"Rate",
                        Color = OxyPlot.OxyColors.Blue,
                        StrokeThickness = 1,
                    };
                    var plotModel1 = new PlotModel();
                    int i = 0;
                    foreach (var rate in rates)
                    {
                        line1.Points.Add(new OxyPlot.DataPoint(i, (double)rate.Cur_OfficialRate));
                        i++;
                    }

                    plotModel1.Series.Add(line1);
                    plotDiagram.Model = plotModel1;

                    var max = rates.Select(c => c.Cur_OfficialRate).Max();
                    var min = rates.Select(c => c.Cur_OfficialRate).Min();
                    var average = rates.Select(c => c.Cur_OfficialRate).Average();

                    maxLabel.Text = $"Max: {max}";
                    minLabel.Text = $"Min: {min}";
                    averageLabel.Text = $"Average: {string.Format("{0:F4}", average)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error.{ex.Message}");
            }
        }

        private bool ValidateDateTime()
        {
            if (startDateTime.Value > endDateTime.Value)
            {
                MessageBox.Show("Start date should be less than end date");
                return false;
            }
            return true;
        }
    }
}
