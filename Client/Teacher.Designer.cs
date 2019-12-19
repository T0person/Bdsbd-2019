namespace Client
{
    partial class Teacher
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
            this.Exit_button = new System.Windows.Forms.Button();
            this.Close_button = new System.Windows.Forms.Button();
            this.Sal = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.My_sal = new System.Windows.Forms.Button();
            this.My_spec = new System.Windows.Forms.Button();
            this.My_fac = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit_button
            // 
            this.Exit_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_button.Location = new System.Drawing.Point(14, 623);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(196, 61);
            this.Exit_button.TabIndex = 13;
            this.Exit_button.Text = "Выйти из приложения";
            this.Exit_button.UseVisualStyleBackColor = true;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // Close_button
            // 
            this.Close_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close_button.Location = new System.Drawing.Point(14, 580);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(196, 37);
            this.Close_button.TabIndex = 12;
            this.Close_button.Text = "Закрыть";
            this.Close_button.UseVisualStyleBackColor = true;
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // Sal
            // 
            this.Sal.AutoSize = true;
            this.Sal.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Sal.Location = new System.Drawing.Point(14, 273);
            this.Sal.Name = "Sal";
            this.Sal.Size = new System.Drawing.Size(0, 28);
            this.Sal.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(252, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(935, 676);
            this.dataGridView1.TabIndex = 10;
            // 
            // My_sal
            // 
            this.My_sal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.My_sal.Location = new System.Drawing.Point(14, 167);
            this.My_sal.Name = "My_sal";
            this.My_sal.Size = new System.Drawing.Size(196, 37);
            this.My_sal.TabIndex = 9;
            this.My_sal.Text = "Моя зарплата";
            this.My_sal.UseVisualStyleBackColor = true;
            this.My_sal.Click += new System.EventHandler(this.My_sal_Click);
            // 
            // My_spec
            // 
            this.My_spec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.My_spec.Location = new System.Drawing.Point(14, 79);
            this.My_spec.Name = "My_spec";
            this.My_spec.Size = new System.Drawing.Size(196, 59);
            this.My_spec.TabIndex = 8;
            this.My_spec.Text = "Мои специальности";
            this.My_spec.UseVisualStyleBackColor = true;
            this.My_spec.Click += new System.EventHandler(this.My_spec_Click);
            // 
            // My_fac
            // 
            this.My_fac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.My_fac.Location = new System.Drawing.Point(14, 8);
            this.My_fac.Name = "My_fac";
            this.My_fac.Size = new System.Drawing.Size(196, 37);
            this.My_fac.TabIndex = 7;
            this.My_fac.Text = "Мои факультеты";
            this.My_fac.UseVisualStyleBackColor = true;
            this.My_fac.Click += new System.EventHandler(this.My_fac_Click);
            // 
            // Teacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Close_button);
            this.Controls.Add(this.Sal);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.My_sal);
            this.Controls.Add(this.My_spec);
            this.Controls.Add(this.My_fac);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Teacher";
            this.Text = "Teacher";
            this.Load += new System.EventHandler(this.Teacher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.Button Close_button;
        private System.Windows.Forms.Label Sal;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button My_sal;
        private System.Windows.Forms.Button My_spec;
        private System.Windows.Forms.Button My_fac;
    }
}