using bntu.vsrpp.vmilyuk.Core.Enums;
using bntu.vsrpp.vmilyuk.Core.XML;
using bntu.vsrpp.vmilyuk.lab1.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using StringResources = bntu.vsrpp.vmilyuk.lab1.Resources.String;

namespace bntu.vsrpp.vmilyuk.lab1.Process
{
    public class MainWindowProcess
    {
        #region Const strings
        private const string FileWasOpened = "File was opened successful.";
        private const string FileWasEditedAndClosed = "File was edited and saved successful.";
        #endregion

        private string path;

        private readonly List<XElement> Node = new List<XElement>();
        private readonly List<string> ChildNode = new List<string>();
        private readonly List<string> AvaliableStringValues = new List<string>();

        private readonly XMLReader reader;
        private readonly XMLEditor editor;
        private readonly MainWindowForm Form;

        public MainWindowProcess(XMLReader reader, XMLEditor editor)
        {
            Form = new MainWindowForm();

            this.reader = reader;
            this.editor = editor;

            InitializeHandle();
        }

        public MainWindowForm Start()
        {
            return Form;
        }

        private void InitializeHandle()
        {
            Form.BtnReadOpenedFile.Click +=
                ReadOpenedFile;
            Form.BtnFindMaxValue.Click +=
                FindMaxValue;
            Form.BtnFindMinValue.Click +=
                FindMinValue;
            Form.BtnFindAverageValue.Click +=
                FindAverageValue;
            Form.BtnFindMaxLength.Click +=
                FindMaxLength;
            Form.BtnFindMinLength.Click +=
                FindMinLength;
            Form.BtnFindAverageLength.Click +=
                FindAverageLength;
            Form.BtnOpenFile.Click +=
                ShowOpenFileDialog;
            Form.BtnEditAndSaveFile.Click +=
                EditAndSaveFile;
            Form.AvailableItemsComboBox.SelectedIndexChanged +=
                ShowAvailiableOperations;
        }

        private void ReadOpenedFile(object sender, EventArgs e)
        {
            var availiableStrings = reader.GetAvailiableStrings(ChildNode, Node, AvaliableStringValues).ToArray();
            var nodesCount = reader.GetNodesCount(Node);

            Form.AvailableItemsComboBox.Items.Clear();

            Form.NodesCountLabel.Text = StringResources.ResourceManager.GetString("MainWindow.NodesCount")
                + nodesCount;
            Form.AvailableItemsComboBox.Items.AddRange(availiableStrings);

            try
            {
                Form.AvailableItemsComboBox.SelectedItem = Form.AvailableItemsComboBox.Items[0];
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(ex);
            }
        }

        private void ExecuteOperation(Operations operation)
        {
            if(Form.AvailableItemsComboBox.SelectedItem != null)
            {
                try
                {
                    switch (operation)
                    {
                        case Operations.FindMinValue:
                            ChangeOperationLabel(StringResources.ResourceManager.GetString("MainWindow.FindMinValueOperation"));
                            int min = reader.GetMin(Form.AvailableItemsComboBox.SelectedItem.ToString(), Node);
                            ChangeResultLabel(min);
                            break;

                        case Operations.FindMaxValue:
                            ChangeOperationLabel(StringResources.ResourceManager.GetString("MainWindow.FindMaxValueOperation"));
                            int max = reader.GetMax(Form.AvailableItemsComboBox.SelectedItem.ToString(), Node);
                            ChangeResultLabel(max);
                            break;

                        case Operations.FindAverageValue:
                            ChangeOperationLabel(StringResources.ResourceManager.GetString("MainWindow.FindAverageValueOperation"));
                            double average = reader.GetAverage(Form.AvailableItemsComboBox.SelectedItem.ToString(), Node);
                            ChangeResultLabel(average);
                            break;

                        case Operations.FindMinLength:
                            ChangeOperationLabel(StringResources.ResourceManager.GetString("MainWindow.FindMinLengthOperation"));
                            int minLength = reader.GetMinLength(Form.AvailableItemsComboBox.SelectedItem.ToString(), Node);
                            ChangeResultLabel(minLength);
                            break;

                        case Operations.FindMaxLength:
                            ChangeOperationLabel(StringResources.ResourceManager.GetString("MainWindow.FindMaxLengthOperation"));
                            int maxLength = reader.GetMaxLength(Form.AvailableItemsComboBox.SelectedItem.ToString(), Node);
                            ChangeResultLabel(maxLength);
                            break;

                        case Operations.FindAverangeLength:
                            ChangeOperationLabel(StringResources.ResourceManager.GetString("MainWindow.FindAverageLengthOperation"));
                            double averageLength = reader.GetAverageLength(Form.AvailableItemsComboBox.SelectedItem.ToString(), Node);
                            ChangeResultLabel(averageLength);
                            break;
                    }
                }
                catch(Exception ex)
                {
                    ShowOperationErrorMessageBox(ex);
                }
                
            }
        }

        private void ChangeOperationLabel(string resourceString)
        {
            Form.OperationNameLabel.Text = StringResources.ResourceManager.GetString("MainWindow.OperationName")
                + resourceString;
        }

        private void ChangeResultLabel(double value)
        {
            Form.OperationResultLabel.Text = StringResources.ResourceManager.GetString("MainWindow.OperationResult")
                        + FormatString(value);
        }

        private string FormatString(double formattedString)
        {
            return formattedString.ToString("#0.00");
        }

        private void ShowOperationErrorMessageBox(Exception ex)
        {
            ChangeLabelTextDueError();
            ShowErrorMessageBox(ex);
        }

        private void ChangeLabelTextDueError()
        {
            Form.OperationResultLabel.Text = StringResources.ResourceManager.GetString("MainWindow.OperationResult")
                    + StringResources.ResourceManager.GetString("MainWindow.OperationError");
        }

        private void ShowErrorMessageBox(Exception ex)
        {
            MessageBox.Show(StringResources.ResourceManager.GetString("MainWindow.MessageBox.OperationError") + ex.Message.ToLower(),
                StringResources.ResourceManager.GetString("MainWindow.MessageBox.Error"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FindMaxValue(object sender, EventArgs e)
        {
            ExecuteOperation(Operations.FindMaxValue);
        }

        private void FindMinValue(object sender, EventArgs e)
        {
            ExecuteOperation(Operations.FindMinValue);
        }

        private void FindAverageValue(object sender, EventArgs e)
        {
            ExecuteOperation(Operations.FindAverageValue);
        }

        private void FindMaxLength(object sender, EventArgs e)
        {
            ExecuteOperation(Operations.FindMaxLength);
        }

        private void FindMinLength(object sender, EventArgs e)
        {
            ExecuteOperation(Operations.FindMinLength);
        }

        private void FindAverageLength(object sender, EventArgs e)
        {
            ExecuteOperation(Operations.FindAverangeLength);
        }

        private void ShowAvailiableOperations(object sender, EventArgs e)
        {
            string availiableOperations = reader.GetAvailiableOperations(Form.AvailableItemsComboBox.SelectedItem.ToString(), Node);

            switch (availiableOperations)
            {
                case "string":
                    VisibleIntValuesOperations(false);
                    VisibleStringValuesOperations(true);
                    break;
                case "int":
                    VisibleIntValuesOperations(true);
                    VisibleStringValuesOperations(false);
                    break;
                case "stringint":
                    VisibleIntValuesOperations(false);
                    VisibleStringValuesOperations(false);
                    break;
                default:
                    VisibleIntValuesOperations(true);
                    VisibleStringValuesOperations(true);
                    break;
            }
        }

        private void VisibleIntValuesOperations(bool isTrue)
        {
            Form.BtnFindMaxValue.Visible = isTrue;
            Form.BtnFindMinValue.Visible = isTrue;
            Form.BtnFindAverageValue.Visible = isTrue;
        }

        private void VisibleStringValuesOperations(bool isTrue)
        {
            Form.BtnFindMaxLength.Visible = isTrue;
            Form.BtnFindMinLength.Visible = isTrue;
            Form.BtnFindAverageLength.Visible = isTrue;
        }

        private void ShowOpenFileDialog(object sender, EventArgs e)
        {
            if (Form.OpenFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            path = Form.OpenFileDialog.FileName;
            var xml = reader.ReadXML(path);
            InitializeLists(xml);
            MessageBox.Show(FileWasOpened, StringResources.ResourceManager.GetString("MainWindow.MessageBox.Success"),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditAndSaveFile(object sender, EventArgs e)
        {
            editor.CreateNewXML(path);
            MessageBox.Show(FileWasEditedAndClosed, StringResources.ResourceManager.GetString("MainWindow.MessageBox.Success"),
                MessageBoxButtons.OK,MessageBoxIcon.Information); 
        }

        private void InitializeLists(XDocument xml)
        {
            ClearAllLists();
            foreach (XElement node in xml.Elements())
            {
                foreach (XElement child in node.Elements())
                {
                    Node.Add(child);
                    foreach (XElement item in child.Elements())
                    {
                        ChildNode.Add(item.Name.ToString());
                    }
                }
            }
        }

        private void ClearAllLists()
        {
            Node.Clear();
            ChildNode.Clear();
            AvaliableStringValues.Clear();
        }
    }
}
