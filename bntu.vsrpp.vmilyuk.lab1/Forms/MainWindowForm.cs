using System.Windows.Forms;

namespace bntu.vsrpp.vmilyuk.lab1
{
    public partial class MainWindowForm : Form
    {
        public MainWindowForm()
        {
            InitializeComponent();
            
            openFileDialog1.Filter = "XML files(*.xml)|*.xml";        
        }

        /// <summary>
        /// Gets Button btnReadOpenedFile values
        /// </summary>
        public Button BtnReadOpenedFile => btnReadOpenedFile;

        /// <summary>
        /// Gets Button btnEditAndSaveFile values
        /// </summary>
        public Button BtnEditAndSaveFile => btnEditAndSaveFile;

        /// <summary>
        /// Gets Button btnOpenFile values
        /// </summary>
        public Button BtnOpenFile => btnOpenFile;

        /// <summary>
        /// Gets Button btnFindMaxValue values
        /// </summary>
        public Button BtnFindMaxValue => btnFindMaxValue;

        /// <summary>
        /// Gets Button btnFindMinValue values
        /// </summary>
        public Button BtnFindMinValue => btnFindMinValue;

        /// <summary>
        /// Gets Button btnFindAverageValue values
        /// </summary>
        public Button BtnFindAverageValue => btnFindAverageValue;

        /// <summary>
        /// Gets Button btnFindMaxLength values
        /// </summary>
        public Button BtnFindMaxLength => btnFindMaxLength;

        /// <summary>
        /// Gets Button btnFindMinLength values
        /// </summary>
        public Button BtnFindMinLength => btnFindMinLength;

        /// <summary>
        /// Gets Button btnFindAverageLength values
        /// </summary>
        public Button BtnFindAverageLength => btnFindAverageLength;

        /// <summary>
        /// Gets OpenFileDialog openFileDialog1 values
        /// </summary>
        public OpenFileDialog OpenFileDialog => openFileDialog1;

        /// <summary>
        /// Gets ComboBox comboBox1 values
        /// </summary>
        public ComboBox AvailableItemsComboBox => comboBox1;

        /// <summary>
        /// Gets Label label1 values
        /// </summary>
        public Label NodesCountLabel => label1;

        /// <summary>
        /// Gets Label label3 values
        /// </summary>
        public Label OperationResultLabel => label3;

        /// <summary>
        /// Gets Label label5 values
        /// </summary>
        public Label OperationNameLabel => label5;
    }
}
