
namespace IRF_Projekt_EH515M
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
            this.components = new System.ComponentModel.Container();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFutar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRendeles = new System.Windows.Forms.TextBox();
            this.comboEtterem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnTimerStart = new System.Windows.Forms.Button();
            this.btnTimerStop = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(356, 40);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(132, 43);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generálás";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 238);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1059, 332);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Futárazonosító:";
            // 
            // txtFutar
            // 
            this.txtFutar.Location = new System.Drawing.Point(145, 40);
            this.txtFutar.Name = "txtFutar";
            this.txtFutar.Size = new System.Drawing.Size(169, 22);
            this.txtFutar.TabIndex = 3;
            this.txtFutar.TextChanged += new System.EventHandler(this.txtFutar_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rendelésazonosító:";
            // 
            // txtRendeles
            // 
            this.txtRendeles.Location = new System.Drawing.Point(172, 90);
            this.txtRendeles.Name = "txtRendeles";
            this.txtRendeles.Size = new System.Drawing.Size(142, 22);
            this.txtRendeles.TabIndex = 5;
            this.txtRendeles.TextChanged += new System.EventHandler(this.txtRendeles_TextChanged);
            // 
            // comboEtterem
            // 
            this.comboEtterem.FormattingEnabled = true;
            this.comboEtterem.Location = new System.Drawing.Point(96, 130);
            this.comboEtterem.Name = "comboEtterem";
            this.comboEtterem.Size = new System.Drawing.Size(218, 24);
            this.comboEtterem.TabIndex = 6;
            this.comboEtterem.SelectedIndexChanged += new System.EventHandler(this.comboEtterem_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Étterem";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnTimerStart
            // 
            this.btnTimerStart.Location = new System.Drawing.Point(511, 40);
            this.btnTimerStart.Name = "btnTimerStart";
            this.btnTimerStart.Size = new System.Drawing.Size(120, 43);
            this.btnTimerStart.TabIndex = 8;
            this.btnTimerStart.Text = "START";
            this.btnTimerStart.UseVisualStyleBackColor = true;
            this.btnTimerStart.Click += new System.EventHandler(this.btnTimerStart_Click);
            // 
            // btnTimerStop
            // 
            this.btnTimerStop.Location = new System.Drawing.Point(637, 40);
            this.btnTimerStop.Name = "btnTimerStop";
            this.btnTimerStop.Size = new System.Drawing.Size(116, 45);
            this.btnTimerStop.TabIndex = 9;
            this.btnTimerStop.Text = "STOP";
            this.btnTimerStop.UseVisualStyleBackColor = true;
            this.btnTimerStop.Click += new System.EventHandler(this.btnTimerStop_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(524, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rendelések automatikus betétele";
            // 
            // panelStatus
            // 
            this.panelStatus.Location = new System.Drawing.Point(356, 95);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(715, 135);
            this.panelStatus.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(813, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 45);
            this.button1.TabIndex = 12;
            this.button1.Text = "Rendelések exportálása excelbe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 605);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTimerStop);
            this.Controls.Add(this.btnTimerStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboEtterem);
            this.Controls.Add(this.txtRendeles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFutar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGenerate);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFutar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRendeles;
        private System.Windows.Forms.ComboBox comboEtterem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnTimerStart;
        private System.Windows.Forms.Button btnTimerStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Button button1;
    }
}

