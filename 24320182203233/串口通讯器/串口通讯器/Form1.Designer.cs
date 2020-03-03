namespace 串口通讯器
{
    partial class 串口通讯器
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
            this.comboBox_Port = new System.Windows.Forms.ComboBox();
            this.comboBox_CheckBits = new System.Windows.Forms.ComboBox();
            this.comboBox_StopBits = new System.Windows.Forms.ComboBox();
            this.comboBox_DataBits = new System.Windows.Forms.ComboBox();
            this.button_Switch = new System.Windows.Forms.Button();
            this.textBox_Send = new System.Windows.Forms.TextBox();
            this.textBox_Receive = new System.Windows.Forms.TextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_BaudRate
            // 
            this.comboBox_BaudRate.FormattingEnabled = true;
            this.comboBox_BaudRate.Location = new System.Drawing.Point(136, 27);
            this.comboBox_BaudRate.Name = "comboBox_BaudRate";
            this.comboBox_BaudRate.Size = new System.Drawing.Size(121, 23);
            this.comboBox_BaudRate.TabIndex = 0;
            this.comboBox_BaudRate.Text = "波特率";
            this.comboBox_BaudRate.SelectedIndexChanged += new System.EventHandler(this.baud_SelectedIndexChanged);
            // 
            // comboBox_Port
            // 
            this.comboBox_Port.FormattingEnabled = true;
            this.comboBox_Port.Location = new System.Drawing.Point(12, 27);
            this.comboBox_Port.Name = "comboBox_Port";
            this.comboBox_Port.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Port.TabIndex = 1;
            this.comboBox_Port.Text = "串口";
            // 
            // comboBox_CheckBits
            // 
            this.comboBox_CheckBits.FormattingEnabled = true;
            this.comboBox_CheckBits.Location = new System.Drawing.Point(263, 27);
            this.comboBox_CheckBits.Name = "comboBox_CheckBits";
            this.comboBox_CheckBits.Size = new System.Drawing.Size(121, 23);
            this.comboBox_CheckBits.TabIndex = 2;
            this.comboBox_CheckBits.Text = "奇偶校验";
            // 
            // comboBox_StopBits
            // 
            this.comboBox_StopBits.FormattingEnabled = true;
            this.comboBox_StopBits.Location = new System.Drawing.Point(517, 27);
            this.comboBox_StopBits.Name = "comboBox_StopBits";
            this.comboBox_StopBits.Size = new System.Drawing.Size(121, 23);
            this.comboBox_StopBits.TabIndex = 3;
            this.comboBox_StopBits.Text = "停止位";
            // 
            // comboBox_DataBits
            // 
            this.comboBox_DataBits.FormattingEnabled = true;
            this.comboBox_DataBits.Location = new System.Drawing.Point(390, 27);
            this.comboBox_DataBits.Name = "comboBox_DataBits";
            this.comboBox_DataBits.Size = new System.Drawing.Size(121, 23);
            this.comboBox_DataBits.TabIndex = 4;
            this.comboBox_DataBits.Text = "数据位";
            // 
            // button_Switch
            // 
            this.button_Switch.Location = new System.Drawing.Point(644, 27);
            this.button_Switch.Name = "button_Switch";
            this.button_Switch.Size = new System.Drawing.Size(75, 23);
            this.button_Switch.TabIndex = 5;
            this.button_Switch.Text = "开启";
            this.button_Switch.UseVisualStyleBackColor = true;
            this.button_Switch.Click += new System.EventHandler(this.button_Switch_Click_1);
            // 
            // textBox_Send
            // 
            this.textBox_Send.Location = new System.Drawing.Point(12, 89);
            this.textBox_Send.Multiline = true;
            this.textBox_Send.Name = "textBox_Send";
            this.textBox_Send.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Send.Size = new System.Drawing.Size(629, 150);
            this.textBox_Send.TabIndex = 6;
            // 
            // textBox_Receive
            // 
            this.textBox_Receive.Location = new System.Drawing.Point(12, 279);
            this.textBox_Receive.Multiline = true;
            this.textBox_Receive.Name = "textBox_Receive";
            this.textBox_Receive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Receive.Size = new System.Drawing.Size(629, 150);
            this.textBox_Receive.TabIndex = 8;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(647, 216);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 9;
            this.button_Send.Text = "发送";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "串口";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "波特率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "奇偶校验";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "数据位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(517, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "停止位";
            // 
            // 串口通讯器
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.textBox_Receive);
            this.Controls.Add(this.textBox_Send);
            this.Controls.Add(this.button_Switch);
            this.Controls.Add(this.comboBox_DataBits);
            this.Controls.Add(this.comboBox_StopBits);
            this.Controls.Add(this.comboBox_CheckBits);
            this.Controls.Add(this.comboBox_Port);
            this.Controls.Add(this.comboBox_BaudRate);
            this.Name = "串口通讯器";
            this.Text = "串口通讯器";
            this.Load += new System.EventHandler(this.串口通讯器_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.Windows.Forms.ComboBox comboBox_Port;
        private System.Windows.Forms.ComboBox comboBox_CheckBits;
        private System.Windows.Forms.ComboBox comboBox_StopBits;
        private System.Windows.Forms.ComboBox comboBox_DataBits;
        private System.Windows.Forms.Button button_Switch;
        private System.Windows.Forms.TextBox textBox_Send;
        private System.Windows.Forms.TextBox textBox_Receive;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

