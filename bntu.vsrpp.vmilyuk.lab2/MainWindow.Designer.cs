
namespace bntu.vsrpp.vmilyuk.lab2
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFromRightToLeft = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnFromLeftToRight = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnShowDiagram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFromRightToLeft
            // 
            this.btnFromRightToLeft.Location = new System.Drawing.Point(179, 76);
            this.btnFromRightToLeft.Name = "btnFromRightToLeft";
            this.btnFromRightToLeft.Size = new System.Drawing.Size(75, 23);
            this.btnFromRightToLeft.TabIndex = 0;
            this.btnFromRightToLeft.Text = "<-";
            this.btnFromRightToLeft.UseVisualStyleBackColor = true;
            this.btnFromRightToLeft.Click += new System.EventHandler(this.btnFromRightToLeft_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // btnFromLeftToRight
            // 
            this.btnFromLeftToRight.Location = new System.Drawing.Point(179, 21);
            this.btnFromLeftToRight.Name = "btnFromLeftToRight";
            this.btnFromLeftToRight.Size = new System.Drawing.Size(75, 23);
            this.btnFromLeftToRight.TabIndex = 2;
            this.btnFromLeftToRight.Text = "->";
            this.btnFromLeftToRight.UseVisualStyleBackColor = true;
            this.btnFromLeftToRight.Click += new System.EventHandler(this.btnFromLeftToRight_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(260, 22);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(161, 23);
            this.comboBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 23);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(260, 76);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(161, 23);
            this.textBox2.TabIndex = 6;
            // 
            // btnShowDiagram
            // 
            this.btnShowDiagram.Location = new System.Drawing.Point(156, 117);
            this.btnShowDiagram.Name = "btnShowDiagram";
            this.btnShowDiagram.Size = new System.Drawing.Size(123, 23);
            this.btnShowDiagram.TabIndex = 12;
            this.btnShowDiagram.Text = "Display diagram";
            this.btnShowDiagram.UseVisualStyleBackColor = true;
            this.btnShowDiagram.Click += new System.EventHandler(this.btnShowDiagram_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 149);
            this.Controls.Add(this.btnShowDiagram);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.btnFromLeftToRight);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnFromRightToLeft);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFromRightToLeft;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnFromLeftToRight;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnShowDiagram;
    }
}

