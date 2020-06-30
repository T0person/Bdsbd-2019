namespace Client
{
    partial class Delete
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
            this.Back_button = new System.Windows.Forms.Button();
            this.Set_id = new System.Windows.Forms.TextBox();
            this.Take_id = new System.Windows.Forms.Label();
            this.Delete_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Back_button
            // 
            this.Back_button.Location = new System.Drawing.Point(199, 145);
            this.Back_button.Name = "Back_button";
            this.Back_button.Size = new System.Drawing.Size(125, 30);
            this.Back_button.TabIndex = 17;
            this.Back_button.Text = "Назад";
            this.Back_button.UseVisualStyleBackColor = true;
            this.Back_button.Click += new System.EventHandler(this.Back_button_Click);
            // 
            // Set_id
            // 
            this.Set_id.Location = new System.Drawing.Point(139, 68);
            this.Set_id.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Set_id.Name = "Set_id";
            this.Set_id.Size = new System.Drawing.Size(70, 26);
            this.Set_id.TabIndex = 16;
            this.Set_id.TextChanged += new System.EventHandler(this.Set_id_TextChanged);
            // 
            // Take_id
            // 
            this.Take_id.AutoSize = true;
            this.Take_id.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Take_id.Location = new System.Drawing.Point(135, 23);
            this.Take_id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Take_id.Name = "Take_id";
            this.Take_id.Size = new System.Drawing.Size(28, 23);
            this.Take_id.TabIndex = 15;
            this.Take_id.Text = "Id";
            // 
            // Delete_button
            // 
            this.Delete_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete_button.Location = new System.Drawing.Point(40, 145);
            this.Delete_button.Margin = new System.Windows.Forms.Padding(4);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(125, 30);
            this.Delete_button.TabIndex = 14;
            this.Delete_button.Text = "Удалить";
            this.Delete_button.UseVisualStyleBackColor = true;
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 197);
            this.Controls.Add(this.Back_button);
            this.Controls.Add(this.Set_id);
            this.Controls.Add(this.Take_id);
            this.Controls.Add(this.Delete_button);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Delete";
            this.Text = "Delete";
            this.Load += new System.EventHandler(this.Delete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back_button;
        private System.Windows.Forms.TextBox Set_id;
        private System.Windows.Forms.Label Take_id;
        private System.Windows.Forms.Button Delete_button;
    }
}