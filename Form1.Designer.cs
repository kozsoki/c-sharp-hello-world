namespace interview
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
            this.dataSet1 = new System.Data.DataSet();
            this.first_name_txt = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.last_name_txt = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // first_name_txt
            // 
            this.first_name_txt.Location = new System.Drawing.Point(247, 84);
            this.first_name_txt.Name = "first_name_txt";
            this.first_name_txt.Size = new System.Drawing.Size(198, 22);
            this.first_name_txt.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(38, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 42);
            this.button3.TabIndex = 2;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // last_name_txt
            // 
            this.last_name_txt.Location = new System.Drawing.Point(466, 85);
            this.last_name_txt.Name = "last_name_txt";
            this.last_name_txt.Size = new System.Drawing.Size(213, 22);
            this.last_name_txt.TabIndex = 5;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_delete.Location = new System.Drawing.Point(564, 151);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(133, 67);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(564, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Secon Person LastName";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(564, 300);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(178, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "All People ";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(564, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 49);
            this.button1.TabIndex = 10;
            this.button1.Text = "EXIT";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(126, 146);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(378, 322);
            this.dataGridView1.TabIndex = 11;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(795, 493);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.last_name_txt);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.first_name_txt);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.TextBox first_name_txt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox last_name_txt;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}

