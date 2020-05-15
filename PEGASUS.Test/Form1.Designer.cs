namespace PEGASUS.Test
{
    partial class Form1
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
            this.btnTestCom = new System.Windows.Forms.Button();
            this.txt01 = new System.Windows.Forms.TextBox();
            this.btnTextSend = new System.Windows.Forms.Button();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.btnGetConfig = new System.Windows.Forms.Button();
            this.btnStatusMode = new System.Windows.Forms.Button();
            this.btnMeasureMode = new System.Windows.Forms.Button();
            this.lstData = new System.Windows.Forms.ListView();
            this.Datetime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGet1Measure = new System.Windows.Forms.Button();
            this.btnSwitchConfigMode = new System.Windows.Forms.Button();
            this.btnSetBeamOn = new System.Windows.Forms.Button();
            this.btnSetBeamOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestCom
            // 
            this.btnTestCom.Location = new System.Drawing.Point(12, 12);
            this.btnTestCom.Name = "btnTestCom";
            this.btnTestCom.Size = new System.Drawing.Size(82, 23);
            this.btnTestCom.TabIndex = 0;
            this.btnTestCom.Text = "Test COM";
            this.btnTestCom.UseVisualStyleBackColor = true;
            this.btnTestCom.Click += new System.EventHandler(this.btnTestCom_Click);
            // 
            // txt01
            // 
            this.txt01.Location = new System.Drawing.Point(12, 52);
            this.txt01.Name = "txt01";
            this.txt01.Size = new System.Drawing.Size(295, 20);
            this.txt01.TabIndex = 1;
            // 
            // btnTextSend
            // 
            this.btnTextSend.Location = new System.Drawing.Point(12, 98);
            this.btnTextSend.Name = "btnTextSend";
            this.btnTextSend.Size = new System.Drawing.Size(82, 23);
            this.btnTextSend.TabIndex = 0;
            this.btnTextSend.Text = "Test Send";
            this.btnTextSend.UseVisualStyleBackColor = true;
            this.btnTextSend.Click += new System.EventHandler(this.btnTestSend_Click);
            // 
            // cbCom
            // 
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(142, 13);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(121, 21);
            this.cbCom.TabIndex = 2;
            // 
            // btnGetConfig
            // 
            this.btnGetConfig.Location = new System.Drawing.Point(423, 98);
            this.btnGetConfig.Name = "btnGetConfig";
            this.btnGetConfig.Size = new System.Drawing.Size(86, 23);
            this.btnGetConfig.TabIndex = 4;
            this.btnGetConfig.Text = "Get Config";
            this.btnGetConfig.UseVisualStyleBackColor = true;
            this.btnGetConfig.Click += new System.EventHandler(this.btnGetConfig_Click);
            // 
            // btnStatusMode
            // 
            this.btnStatusMode.Location = new System.Drawing.Point(101, 98);
            this.btnStatusMode.Name = "btnStatusMode";
            this.btnStatusMode.Size = new System.Drawing.Size(75, 23);
            this.btnStatusMode.TabIndex = 5;
            this.btnStatusMode.Text = "Status mode";
            this.btnStatusMode.UseVisualStyleBackColor = true;
            this.btnStatusMode.Click += new System.EventHandler(this.btnStatusMode_Click);
            // 
            // btnMeasureMode
            // 
            this.btnMeasureMode.Location = new System.Drawing.Point(291, 98);
            this.btnMeasureMode.Name = "btnMeasureMode";
            this.btnMeasureMode.Size = new System.Drawing.Size(126, 23);
            this.btnMeasureMode.TabIndex = 6;
            this.btnMeasureMode.Text = "Switch to measuring";
            this.btnMeasureMode.UseVisualStyleBackColor = true;
            this.btnMeasureMode.Click += new System.EventHandler(this.btnMeasureMode_Click);
            // 
            // lstData
            // 
            this.lstData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Datetime,
            this.DataHeader,
            this.Message});
            this.lstData.HideSelection = false;
            this.lstData.Location = new System.Drawing.Point(12, 127);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(776, 311);
            this.lstData.TabIndex = 7;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            // 
            // Datetime
            // 
            this.Datetime.Text = "Datetime";
            this.Datetime.Width = 127;
            // 
            // DataHeader
            // 
            this.DataHeader.Text = "DataHeader";
            this.DataHeader.Width = 181;
            // 
            // Message
            // 
            this.Message.Text = "Message";
            this.Message.Width = 521;
            // 
            // btnGet1Measure
            // 
            this.btnGet1Measure.Location = new System.Drawing.Point(515, 98);
            this.btnGet1Measure.Name = "btnGet1Measure";
            this.btnGet1Measure.Size = new System.Drawing.Size(132, 23);
            this.btnGet1Measure.TabIndex = 8;
            this.btnGet1Measure.Text = "Get one measurement";
            this.btnGet1Measure.UseVisualStyleBackColor = true;
            this.btnGet1Measure.Click += new System.EventHandler(this.btnGet1Measure_Click_1);
            // 
            // btnSwitchConfigMode
            // 
            this.btnSwitchConfigMode.Location = new System.Drawing.Point(182, 98);
            this.btnSwitchConfigMode.Name = "btnSwitchConfigMode";
            this.btnSwitchConfigMode.Size = new System.Drawing.Size(103, 23);
            this.btnSwitchConfigMode.TabIndex = 10;
            this.btnSwitchConfigMode.Text = "Switch to config";
            this.btnSwitchConfigMode.UseVisualStyleBackColor = true;
            this.btnSwitchConfigMode.Click += new System.EventHandler(this.btnSwitchConfigMode_Click);
            // 
            // btnSetBeamOn
            // 
            this.btnSetBeamOn.Location = new System.Drawing.Point(653, 98);
            this.btnSetBeamOn.Name = "btnSetBeamOn";
            this.btnSetBeamOn.Size = new System.Drawing.Size(63, 23);
            this.btnSetBeamOn.TabIndex = 11;
            this.btnSetBeamOn.Text = "Beam On";
            this.btnSetBeamOn.UseVisualStyleBackColor = true;
            this.btnSetBeamOn.Click += new System.EventHandler(this.btnSetBeamOn_Click);
            // 
            // btnSetBeamOff
            // 
            this.btnSetBeamOff.Location = new System.Drawing.Point(722, 98);
            this.btnSetBeamOff.Name = "btnSetBeamOff";
            this.btnSetBeamOff.Size = new System.Drawing.Size(63, 23);
            this.btnSetBeamOff.TabIndex = 12;
            this.btnSetBeamOff.Text = "Beam Off";
            this.btnSetBeamOff.UseVisualStyleBackColor = true;
            this.btnSetBeamOff.Click += new System.EventHandler(this.btnSetBeamOff_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSetBeamOff);
            this.Controls.Add(this.btnSetBeamOn);
            this.Controls.Add(this.btnSwitchConfigMode);
            this.Controls.Add(this.btnGet1Measure);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.btnMeasureMode);
            this.Controls.Add(this.btnStatusMode);
            this.Controls.Add(this.btnGetConfig);
            this.Controls.Add(this.cbCom);
            this.Controls.Add(this.txt01);
            this.Controls.Add(this.btnTextSend);
            this.Controls.Add(this.btnTestCom);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestCom;
        private System.Windows.Forms.TextBox txt01;
        private System.Windows.Forms.Button btnTextSend;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.Button btnGetConfig;
        private System.Windows.Forms.Button btnStatusMode;
        private System.Windows.Forms.Button btnMeasureMode;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.ColumnHeader Datetime;
        private System.Windows.Forms.ColumnHeader DataHeader;
        private System.Windows.Forms.ColumnHeader Message;
        private System.Windows.Forms.Button btnGet1Measure;
        private System.Windows.Forms.Button btnSwitchConfigMode;
        private System.Windows.Forms.Button btnSetBeamOn;
        private System.Windows.Forms.Button btnSetBeamOff;
    }
}

