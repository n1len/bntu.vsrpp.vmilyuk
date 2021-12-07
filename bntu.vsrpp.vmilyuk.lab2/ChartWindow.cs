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

        public ChartWindow(List<Currency> currencies)
        {
            this.currencies = currencies;
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
            var curr = currencies.FirstOrDefault(c => (c.Cur_Scale + " " + c.Cur_Name) == comboBox1.SelectedItem.ToString());

            var startDate = startDateTime.Value;
            var endDate = endDateTime.Value;
            
            if (ValidateDateTime())
            {
                var request = $"rates/dynamics/{curr.Cur_ID}?startDate={startDate.ToString("yyyy-M-d")}&endDate={endDate.ToString("yyyy - M - d")}";

                HttpResponseMessage response = client.GetAsync(request).Result;

                var result = await response.Content.ReadAsStringAsync();

                List<ShortRate> firstRates = JsonConvert.DeserializeObject<List<ShortRate>>(result);

                var line1 = new OxyPlot.Series.LineSeries()
                {
                    Title = $"Series 1",
                    Color = OxyPlot.OxyColors.Blue,
                    StrokeThickness = 1,
                };

                var plotModel1 = new PlotModel();
                plotModel1.Title = "Diagram";
                var linearAxis1 = new LinearAxis();
                linearAxis1.Position = AxisPosition.Bottom;
                plotModel1.Axes.Add(linearAxis1);
                var linearAxis2 = new LinearAxis();
                plotModel1.Axes.Add(linearAxis2);
                foreach (var rate in firstRates)
                {
                    line1.Points.Add(new OxyPlot.DataPoint(rate.Date.DayOfYear, (double)rate.Cur_OfficialRate));
                }

                plotModel1.Series.Add(line1);
                plotDiagram.Model = plotModel1;

                var max = firstRates.Select(c => c.Cur_OfficialRate).Max();
                var min = firstRates.Select(c => c.Cur_OfficialRate).Min();
                var average = firstRates.Select(c => c.Cur_OfficialRate).Average();

                maxLabel.Text = $"Max: {max}";
                minLabel.Text = $"Min: {min}";
                averageLabel.Text = $"Average: {string.Format("{0:F4}", average)}";
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
