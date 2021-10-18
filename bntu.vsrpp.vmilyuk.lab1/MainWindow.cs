using bntu.vsrpp.vmilyuk.Core;
using System;
using System.Windows.Forms;
using StringResources = bntu.vsrpp.vmilyuk.lab1.Resources.String;

namespace bntu.vsrpp.vmilyuk.lab1
{
    public partial class MainWindow : Form
    {
        #region Const strings
        private const string FileWasOpened = "File was opened successful.";
        private const string FileWasEditedAndClosed = "File was edited and saved successful.";
        #endregion

        private readonly XMLReader _reader;
        private readonly XMLEditor _editor;

        private string path;

        public MainWindow(XMLReader reader, XMLEditor editor)
        {
            _reader = reader;
            _editor = editor;
            InitializeComponent();
            InitializeHandle();
            openFileDialog1.Filter = "XML files(*.xml)|*.xml";
        }

        private void InitializeHandle()
        {
            button1.Click +=
                ReadOpenedFile;
            button2.Click +=
                FindMaxValue;
            button3.Click +=
                FindMinValue;
            button4.Click +=
                FindAverageValue;
            button5.Click +=
                FindMaxLength;
            button6.Click +=
                FindMinLength;
            button7.Click +=
                FindAverageLength;
            bntOpenFile.Click +=
                ShowOpenFileDialog;
            btnEdit.Click +=
                EditAndSaveFile;
        }

        private void ReadOpenedFile(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            label1.Text = StringResources.ResourceManager.GetString("MainWindow.NodesCount")
                + _reader.GetNodesCount();
            comboBox1.Items.AddRange(_reader.GetAvailiableStrings().ToArray());
            try
            {
                comboBox1.SelectedItem = comboBox1.Items[0];
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(ex);
            }
        }

        private void FindMaxValue(object sender, EventArgs e)
        {
            label5.Text = StringResources.ResourceManager.GetString("MainWindow.OperationName")
                + StringResources.ResourceManager.GetString("MainWindow.FindMaxValueOperation");
            try
            {
                int max = _reader.GetMax(comboBox1.SelectedItem.ToString());
                label3.Text = StringResources.ResourceManager.GetString("MainWindow.OperationResult")
                    + max;
            }
            catch (Exception ex)
            {
                ShowOperationErrorMessageBox(ex);
            }
        }

        private void FindMinValue(object sender, EventArgs e)
        {
            label5.Text = StringResources.ResourceManager.GetString("MainWindow.OperationName")
                + StringResources.ResourceManager.GetString("MainWindow.FindMinValueOperation");
            try
            {
                int min = _reader.GetMin(comboBox1.SelectedItem.ToString());
                label3.Text = StringResources.ResourceManager.GetString("MainWindow.OperationResult")
                    + min;
            }
            catch (Exception ex)
            {
                ShowOperationErrorMessageBox(ex);
            }
        }

        private void FindAverageValue(object sender, EventArgs e)
        {
            label5.Text = StringResources.ResourceManager.GetString("MainWindow.OperationName")
                + StringResources.ResourceManager.GetString("MainWindow.FindAverageValueOperation");
            try
            {
                double result = _reader.GetAverage(comboBox1.SelectedItem.ToString());
                label3.Text = StringResources.ResourceManager.GetString("MainWindow.OperationResult")
                    + FormatString(result);
            }
            catch (Exception ex)
            {
                ShowOperationErrorMessageBox(ex);
            }
        }

        private void FindMaxLength(object sender, EventArgs e)
        {
            label5.Text = StringResources.ResourceManager.GetString("MainWindow.OperationName")
                + StringResources.ResourceManager.GetString("MainWindow.FindMaxLengthOperation");
            try
            {
                int max = _reader.GetMaxLength(comboBox1.SelectedItem.ToString());
                label3.Text = StringResources.ResourceManager.GetString("MainWindow.OperationResult")
                    + max;
            }
            catch (Exception ex)
            {
                ShowOperationErrorMessageBox(ex);
            }
        }

        private void FindMinLength(object sender, EventArgs e)
        {
            label5.Text = StringResources.ResourceManager.GetString("MainWindow.OperationName")
                + StringResources.ResourceManager.GetString("MainWindow.FindMinLengthOperation");
            try
            {
                int min = _reader.GetMinLength(comboBox1.SelectedItem.ToString());
                label3.Text = StringResources.ResourceManager.GetString("MainWindow.OperationResult")
                    + min;
            }
            catch (Exception ex)
            {
                ShowOperationErrorMessageBox(ex);
            }
        }

        private void FindAverageLength(object sender, EventArgs e)
        {
            label5.Text = StringResources.ResourceManager.GetString("MainWindow.OperationName")
                + StringResources.ResourceManager.GetString("MainWindow.FindAverageLengthOperation");
            try
            {
                double result = _reader.GetAverageLength(comboBox1.SelectedItem.ToString());
                label3.Text = StringResources.ResourceManager.GetString("MainWindow.OperationResult")
                    + FormatString(result);
            }
            catch (Exception ex)
            {
                ShowOperationErrorMessageBox(ex);
            }
        }

        private void ShowOpenFileDialog(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            path = openFileDialog1.FileName;
            _reader.ReadXML(path);
            MessageBox.Show(FileWasOpened);
        }

        private void EditAndSaveFile(object sender, EventArgs e)
        {
            _editor.CreateNewXML(path);
            MessageBox.Show(FileWasEditedAndClosed);
        }

        private void ShowErrorMessageBox(Exception ex)
        {
            MessageBox.Show(StringResources.ResourceManager.GetString("MainWindow.MessageBox.OperationError")
                + ex.Message.ToLower());
        }

        private void ShowOperationErrorMessageBox(Exception ex)
        {
            ChangeLabelTextDueError();
            ShowErrorMessageBox(ex);
        }

        private void ChangeLabelTextDueError()
        {
            label3.Text = StringResources.ResourceManager.GetString("MainWindow.OperationResult")
                    + StringResources.ResourceManager.GetString("MainWindow.OperationError");
        }

        private string FormatString(double formattedString)
        {
            return formattedString.ToString("#0.00").TrimEnd('0', ',');
        }
    }
}
