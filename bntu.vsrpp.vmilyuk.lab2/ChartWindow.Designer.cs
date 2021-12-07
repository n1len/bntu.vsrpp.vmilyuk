namespace bntu.vsrpp.vmilyuk.lab2
{
    partial class ChartWindow
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
            this.btnShowDiagram = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.endDateTime = new System.Windows.Forms.DateTimePicker();
            this.startDateTime = new System.Windows.Forms.DateTimePicker();
            this.plotDiagram = new OxyPlot.WindowsForms.PlotView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnShowDiagram
            // 
            this.btnShowDiagram.Location = new System.Drawing.Point(654, 415);
            this.btnShowDiagram.Name = "btnShowDiagram";
            this.btnShowDiagram.Size = new System.Drawing.Size(123, 23);
            this.btnShowDiagram.TabIndex = 17;
            this.btnShowDiagram.Text = "Show diagram";
            this.btnShowDiagram.UseVisualStyleBackColor = true;
            this.btnShowDiagram.Click += new System.EventHandler(this.btnShowDiagram_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "End date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(12, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Start date:";
            // 
            // endDateTime
            // 
            this.endDateTime.Location = new System.Drawing.Point(228, 415);
            this.endDateTime.MaxDate = new System.DateTime(2021, 12, 7, 0, 0, 0, 0);
            this.endDateTime.MinDate = new System.DateTime(2016, 7, 1, 0, 0, 0, 0);
            this.endDateTime.Name = "endDateTime";
            this.endDateTime.Size = new System.Drawing.Size(200, 23);
            this.endDateTime.TabIndex = 14;
            this.endDateTime.Value = new System.DateTime(2021, 12, 7, 0, 0, 0, 0);
            // 
            // startDateTime
            // 
            this.startDateTime.Location = new System.Drawing.Point(12, 415);
            this.startDateTime.MaxDate = new System.DateTime(2021, 12, 7, 0, 0, 0, 0);
            this.startDateTime.MinDate = new System.DateTime(2016, 7, 1, 0, 0, 0, 0);
            this.startDateTime.Name = "startDateTime";
            this.startDateTime.Size = new System.Drawing.Size(200, 23);
            this.startDateTime.TabIndex = 13;
            this.startDateTime.Value = new System.DateTime(2021, 12, 7, 0, 0, 0, 0);
            // 
            // plotDiagram
            // 
            this.plotDiagram.Location = new System.Drawing.Point(12, 12);
            this.plotDiagram.Name = "plotDiagram";
            this.plotDiagram.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotDiagram.Size = new System.Drawing.Size(776, 360);
            this.plotDiagram.TabIndex = 18;
            this.plotDiagram.Text = "plotDiagram";
            this.plotDiagram.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotDiagram.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotDiagram.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(454, 415);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 23);
            this.comboBox1.TabIndex = 19;
            // 
            // ChartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.plotDiagram);
            this.Controls.Add(this.btnShowDiagram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endDateTime);
            this.Controls.Add(this.startDateTime);
            this.Name = "ChartWindow";
            this.Text = "ChartWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowDiagram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker endDateTime;
        private System.Windows.Forms.DateTimePicker startDateTime;
        private OxyPlot.WindowsForms.PlotView plotDiagram;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}