namespace Client
{
    partial class Student
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
            this.Find_all = new System.Windows.Forms.Button();
            this.Find_sal = new System.Windows.Forms.Button();
            this.Find_spec = new System.Windows.Forms.Button();
            this.Spec = new System.Windows.Forms.Label();
            this.Sal = new System.Windows.Forms.Label();
            this.Fac = new System.Windows.Forms.Label();
            this.Find_fac = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Exit_button
            // 
            this.Exit_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_button.Location = new System.Drawing.Point(369, 442);
            this.Exit_button.Margin = new System.Windows.Forms.Padding(6);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(289, 44);
            this.Exit_button.TabIndex = 17;
            this.Exit_button.Text = "Выйти из приложения";
            this.Exit_button.UseVisualStyleBackColor = true;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // Close_button
            // 
            this.Close_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close_button.Location = new System.Drawing.Point(20, 442);
            this.Close_button.Margin = new System.Windows.Forms.Padding(6);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(289, 44);
            this.Close_button.TabIndex = 16;
            this.Close_button.Text = "Закрыть";
            this.Close_button.UseVisualStyleBackColor = true;
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // Find_all
            // 
            this.Find_all.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Find_all.Location = new System.Drawing.Point(369, 342);
            this.Find_all.Margin = new System.Windows.Forms.Padding(6);
            this.Find_all.Name = "Find_all";
            this.Find_all.Size = new System.Drawing.Size(289, 44);
            this.Find_all.TabIndex = 15;
            this.Find_all.Text = "Узнать все";
            this.Find_all.UseVisualStyleBackColor = true;
            this.Find_all.Click += new System.EventHandler(this.Find_all_Click);
            // 
            // Find_sal
            // 
            this.Find_sal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Find_sal.Location = new System.Drawing.Point(369, 242);
            this.Find_sal.Margin = new System.Windows.Forms.Padding(6);
            this.Find_sal.Name = "Find_sal";
            this.Find_sal.Size = new System.Drawing.Size(289, 44);
            this.Find_sal.TabIndex = 14;
            this.Find_sal.Text = "Узнать стипендию";
            this.Find_sal.UseVisualStyleBackColor = true;
            this.Find_sal.Click += new System.EventHandler(this.Find_sal_Click);
            // 
            // Find_spec
            // 
            this.Find_spec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Find_spec.Location = new System.Drawing.Point(369, 142);
            this.Find_spec.Margin = new System.Windows.Forms.Padding(6);
            this.Find_spec.Name = "Find_spec";
            this.Find_spec.Size = new System.Drawing.Size(289, 44);
            this.Find_spec.TabIndex = 13;
            this.Find_spec.Text = "Узнать специальность";
            this.Find_spec.UseVisualStyleBackColor = true;
            this.Find_spec.Click += new System.EventHandler(this.Find_spec_Click);
            // 
            // Spec
            // 
            this.Spec.AutoSize = true;
            this.Spec.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Spec.Location = new System.Drawing.Point(16, 152);
            this.Spec.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Spec.Name = "Spec";
            this.Spec.Size = new System.Drawing.Size(0, 23);
            this.Spec.TabIndex = 12;
            // 
            // Sal
            // 
            this.Sal.AutoSize = true;
            this.Sal.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Sal.Location = new System.Drawing.Point(16, 252);
            this.Sal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Sal.Name = "Sal";
            this.Sal.Size = new System.Drawing.Size(0, 23);
            this.Sal.TabIndex = 11;
            // 
            // Fac
            // 
            this.Fac.AutoSize = true;
            this.Fac.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Fac.Location = new System.Drawing.Point(16, 52);
            this.Fac.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Fac.Name = "Fac";
            this.Fac.Size = new System.Drawing.Size(0, 23);
            this.Fac.TabIndex = 10;
            // 
            // Find_fac
            // 
            this.Find_fac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Find_fac.Location = new System.Drawing.Point(369, 42);
            this.Find_fac.Margin = new System.Windows.Forms.Padding(6);
            this.Find_fac.Name = "Find_fac";
            this.Find_fac.Size = new System.Drawing.Size(289, 44);
            this.Find_fac.TabIndex = 9;
            this.Find_fac.Text = "Узнать факультет";
            this.Find_fac.UseVisualStyleBackColor = true;
            this.Find_fac.Click += new System.EventHandler(this.Find_fac_Click);
            // 
            // Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 547);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Close_button);
            this.Controls.Add(this.Find_all);
            this.Controls.Add(this.Find_sal);
            this.Controls.Add(this.Find_spec);
            this.Controls.Add(this.Spec);
            this.Controls.Add(this.Sal);
            this.Controls.Add(this.Fac);
            this.Controls.Add(this.Find_fac);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student";
            this.Load += new System.EventHandler(this.Student_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.Button Close_button;
        private System.Windows.Forms.Button Find_all;
        private System.Windows.Forms.Button Find_sal;
        private System.Windows.Forms.Button Find_spec;
        private System.Windows.Forms.Label Spec;
        private System.Windows.Forms.Label Sal;
        private System.Windows.Forms.Label Fac;
        private System.Windows.Forms.Button Find_fac;
    }
}