using StringResources = bntu.vsrpp.vmilyuk.lab1.Resources.String;

namespace bntu.vsrpp.vmilyuk.lab1
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bntOpenFile = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = StringResources.ResourceManager.GetString("MainWindow.Button.ReadFile");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = StringResources.ResourceManager.GetString("MainWindow.Label.NodesCount");
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(172, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = StringResources.ResourceManager.GetString("MainWindow.Label.SelectAvailableOption");
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = StringResources.ResourceManager.GetString("MainWindow.Button.FindMaxValueOperation");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(382, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = StringResources.ResourceManager.GetString("MainWindow.Label.OperatonResult");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = StringResources.ResourceManager.GetString("MainWindow.Label.ListAvailableOperations"); 
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(167, 38);
            this.button3.TabIndex = 7;
            this.button3.Text = StringResources.ResourceManager.GetString("MainWindow.Button.FindMinValueOperation");
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 287);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(167, 38);
            this.button4.TabIndex = 8;
            this.button4.Text = StringResources.ResourceManager.GetString("MainWindow.Button.FindAverageValueOperation"); 
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(382, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = StringResources.ResourceManager.GetString("MainWindow.Label.OperationName"); 
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(195, 199);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(167, 38);
            this.button5.TabIndex = 10;
            this.button5.Text = StringResources.ResourceManager.GetString("MainWindow.Button.FindMaxLengthOperation");
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = StringResources.ResourceManager.GetString("MainWindow.Label.OverNumericValues");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = StringResources.ResourceManager.GetString("MainWindow.Label.OverStrings");
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(195, 243);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(167, 38);
            this.button6.TabIndex = 13;
            this.button6.Text = StringResources.ResourceManager.GetString("MainWindow.Button.FindMinLengthOperation");
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(195, 287);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(167, 38);
            this.button7.TabIndex = 14;
            this.button7.Text = StringResources.ResourceManager.GetString("MainWindow.Button.FindAverageLengthOperation");
            this.button7.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bntOpenFile
            // 
            this.bntOpenFile.Location = new System.Drawing.Point(11, 9);
            this.bntOpenFile.Name = "bntOpenFile";
            this.bntOpenFile.Size = new System.Drawing.Size(155, 43);
            this.bntOpenFile.TabIndex = 15;
            this.bntOpenFile.Text = StringResources.ResourceManager.GetString("MainWindow.Button.OpenFile"); 
            this.bntOpenFile.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(172, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(180, 43);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = StringResources.ResourceManager.GetString("MainWindow.Button.EditAndSave"); 
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 342);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.bntOpenFile);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Modern XML Parser";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bntOpenFile;
        private System.Windows.Forms.Button btnEdit;
    }
}