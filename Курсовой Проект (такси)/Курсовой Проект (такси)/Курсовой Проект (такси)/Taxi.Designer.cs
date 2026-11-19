namespace Курсовой_Проект__такси_
{
    partial class Taxi
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
            label1 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            client = new DataGridViewTextBoxColumn();
            adres = new DataGridViewTextBoxColumn();
            summa = new DataGridViewTextBoxColumn();
            button1 = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 217);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 11;
            label1.Text = "id";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(68, 214);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(337, 23);
            textBox1.TabIndex = 10;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, client, adres, summa });
            dataGridView1.Location = new Point(12, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(436, 150);
            dataGridView1.TabIndex = 9;
            // 
            // id
            // 
            id.HeaderText = "id записи";
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // client
            // 
            client.HeaderText = "Клиент";
            client.Name = "client";
            client.ReadOnly = true;
            // 
            // adres
            // 
            adres.HeaderText = "Адрес";
            adres.Name = "adres";
            adres.ReadOnly = true;
            // 
            // summa
            // 
            summa.HeaderText = "Цена поездки";
            summa.Name = "summa";
            summa.ReadOnly = true;
            // 
            // button1
            // 
            button1.Location = new Point(169, 259);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Взять заказ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(192, 9);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 13;
            label2.Text = "label2";
            // 
            // Taxi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 367);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "Taxi";
            Text = "Taxi";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn client;
        private DataGridViewTextBoxColumn adres;
        private DataGridViewTextBoxColumn summa;
        private Button button1;
        private Label label2;
    }
}