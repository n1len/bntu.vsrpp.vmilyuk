using bntu.vsrpp.vmilyuk.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bntu.vsrpp.vmilyuk.lab1
{
    public partial class MainWindow : Form
    {
        private readonly XMLReader _reader;
        private readonly XMLEditor _editor;
        private string path;

        public MainWindow(XMLReader reader, XMLEditor editor)
        {
            _reader = reader;
            _editor = editor;
            InitializeComponent();
            openFileDialog1.Filter = "XML files(*.xml)|*.xml";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            label1.Text = "Кол-во nodes = " + _reader.GetNodesCount();
            comboBox1.Items.AddRange(_reader.GetAvailiableStrings().ToArray());
            try
            {
                comboBox1.SelectedItem = comboBox1.Items[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка.Список параметров не был составлен.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = "Название операции: \"Поиск максимального значения\"";
            try
            {
                label3.Text = "Результат операции: " + _reader.GetMax(comboBox1.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка во время поиска максимального значения.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5.Text = "Название операции: \"Поиск минимального значения\"";
            try
            {
                label3.Text = "Результат операции: " + _reader.GetMin(comboBox1.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка во время поиска минимального значения.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label5.Text = "Название операции: \"Поиск среднего значения\"";
            try
            {
                label3.Text = "Результат операции: " + _reader.GetAverage(comboBox1.SelectedItem.ToString()).ToString("#0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка во время поиска среднего значения.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label5.Text = "Название операции: \"Поиск максимальной длины\"";
            try
            {
                label3.Text = "Результат операции: " + _reader.GetMaxLength(comboBox1.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка во время поиска максимальной длины.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label5.Text = "Название операции: \"Поиск минимальной длины\"";
            try
            {
                label3.Text = "Результат операции: " + _reader.GetMinLength(comboBox1.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка во время поиска минимальной длины.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label5.Text = "Название операции: \"Поиск средней длины\"";
            try
            {
                label3.Text = "Результат операции: " + _reader.GetAverageLength(comboBox1.SelectedItem.ToString()).ToString("#0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка во время поиска средней длины.");
            }
        }

        private void bntOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            path = openFileDialog1.FileName;
            _reader.ReadXML(path);
            MessageBox.Show("Файл открыт");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _editor.CreateNewXML(path);
            MessageBox.Show("Файл успешно изменён и сохранён");
        }
    }
}
