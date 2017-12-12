namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnReadData = new System.Windows.Forms.Button();
            this.stockID = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLastReadTime = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetValue = new System.Windows.Forms.Button();
            this.txtWordLength = new System.Windows.Forms.TextBox();
            this.txtStartIndex = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.txtSetValue = new System.Windows.Forms.TextBox();
            this.txtSetIndex = new System.Windows.Forms.TextBox();
            this.btnInitialSM = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 72);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(588, 439);
            this.listBox1.TabIndex = 0;
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(618, 494);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(208, 31);
            this.btnReadData.TabIndex = 1;
            this.btnReadData.Text = "Read Data";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Visible = false;
            // 
            // stockID
            // 
            this.stockID.Location = new System.Drawing.Point(485, 9);
            this.stockID.Name = "stockID";
            this.stockID.Size = new System.Drawing.Size(115, 25);
            this.stockID.TabIndex = 4;
            this.stockID.Text = "H1MS500";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(618, 441);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Clear List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(145, 9);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(242, 25);
            this.txtSuffix.TabIndex = 7;
            this.txtSuffix.Text = "-WordData";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Sharememory 後綴:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Stock ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Last Read Data Time:";
            // 
            // lblLastReadTime
            // 
            this.lblLastReadTime.AutoSize = true;
            this.lblLastReadTime.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLastReadTime.Location = new System.Drawing.Point(149, 45);
            this.lblLastReadTime.Name = "lblLastReadTime";
            this.lblLastReadTime.Size = new System.Drawing.Size(91, 15);
            this.lblLastReadTime.TabIndex = 11;
            this.lblLastReadTime.Text = "not read yet.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnGetValue);
            this.groupBox1.Controls.Add(this.txtWordLength);
            this.groupBox1.Controls.Add(this.txtStartIndex);
            this.groupBox1.Location = new System.Drawing.Point(618, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 157);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GetValue";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Word Length:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Start Index:";
            // 
            // btnGetValue
            // 
            this.btnGetValue.Location = new System.Drawing.Point(17, 95);
            this.btnGetValue.Name = "btnGetValue";
            this.btnGetValue.Size = new System.Drawing.Size(185, 42);
            this.btnGetValue.TabIndex = 9;
            this.btnGetValue.Text = "Get Value";
            this.btnGetValue.UseVisualStyleBackColor = true;
            this.btnGetValue.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // txtWordLength
            // 
            this.txtWordLength.Location = new System.Drawing.Point(104, 55);
            this.txtWordLength.Name = "txtWordLength";
            this.txtWordLength.Size = new System.Drawing.Size(98, 25);
            this.txtWordLength.TabIndex = 8;
            this.txtWordLength.Text = "2";
            this.txtWordLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtStartIndex
            // 
            this.txtStartIndex.Location = new System.Drawing.Point(104, 24);
            this.txtStartIndex.Name = "txtStartIndex";
            this.txtStartIndex.Size = new System.Drawing.Size(98, 25);
            this.txtStartIndex.TabIndex = 7;
            this.txtStartIndex.Text = "2520";
            this.txtStartIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.txtSetValue);
            this.groupBox2.Controls.Add(this.txtSetIndex);
            this.groupBox2.Location = new System.Drawing.Point(618, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 157);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SetValue";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Value:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Index:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(17, 95);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 42);
            this.button4.TabIndex = 9;
            this.button4.Text = "Set Value";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtSetValue
            // 
            this.txtSetValue.Location = new System.Drawing.Point(104, 55);
            this.txtSetValue.Name = "txtSetValue";
            this.txtSetValue.Size = new System.Drawing.Size(98, 25);
            this.txtSetValue.TabIndex = 8;
            this.txtSetValue.Text = "2";
            this.txtSetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSetIndex
            // 
            this.txtSetIndex.Location = new System.Drawing.Point(104, 24);
            this.txtSetIndex.Name = "txtSetIndex";
            this.txtSetIndex.Size = new System.Drawing.Size(98, 25);
            this.txtSetIndex.TabIndex = 7;
            this.txtSetIndex.Text = "2520";
            this.txtSetIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnInitialSM
            // 
            this.btnInitialSM.Location = new System.Drawing.Point(17, 55);
            this.btnInitialSM.Name = "btnInitialSM";
            this.btnInitialSM.Size = new System.Drawing.Size(185, 26);
            this.btnInitialSM.TabIndex = 14;
            this.btnInitialSM.Text = "Initial SM (For Semi)";
            this.btnInitialSM.UseVisualStyleBackColor = true;
            this.btnInitialSM.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtSize);
            this.groupBox3.Controls.Add(this.btnInitialSM);
            this.groupBox3.Location = new System.Drawing.Point(618, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 100);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create SM";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Size:";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(104, 24);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(98, 25);
            this.txtSize.TabIndex = 15;
            this.txtSize.Text = "2800";
            this.txtSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 524);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblLastReadTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.stockID);
            this.Controls.Add(this.btnReadData);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "ShareMemoryTool v0.1 by Thor Lin";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.TextBox stockID;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLastReadTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetValue;
        private System.Windows.Forms.TextBox txtWordLength;
        private System.Windows.Forms.TextBox txtStartIndex;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtSetValue;
        private System.Windows.Forms.TextBox txtSetIndex;
        private System.Windows.Forms.Button btnInitialSM;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSize;
    }
}

