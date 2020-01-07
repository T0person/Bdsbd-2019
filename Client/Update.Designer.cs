namespace Client
{
    partial class Update
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
            this.label1 = new System.Windows.Forms.Label();
            this.Set_str = new System.Windows.Forms.TextBox();
            this.Update_button = new System.Windows.Forms.Button();
            this.Row_box = new System.Windows.Forms.ComboBox();
            this.Set_id = new System.Windows.Forms.TextBox();
            this.Element = new System.Windows.Forms.Label();
            this.Take_id = new System.Windows.Forms.Label();
            this.Table_list = new System.Windows.Forms.Label();
            this.Table_box = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Back_button
            // 
            this.Back_button.Location = new System.Drawing.Point(534, 118);
            this.Back_button.Name = "Back_button";
            this.Back_button.Size = new System.Drawing.Size(97, 26);
            this.Back_button.TabIndex = 20;
            this.Back_button.Text = "Назад";
            this.Back_button.UseVisualStyleBackColor = true;
            this.Back_button.Click += new System.EventHandler(this.Back_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "Наименование:";
            // 
            // Set_str
            // 
            this.Set_str.Location = new System.Drawing.Point(203, 115);
            this.Set_str.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Set_str.Name = "Set_str";
            this.Set_str.Size = new System.Drawing.Size(148, 26);
            this.Set_str.TabIndex = 18;
            this.Set_str.TextChanged += new System.EventHandler(this.Set_str_TextChanged);
            // 
            // Update_button
            // 
            this.Update_button.Location = new System.Drawing.Point(395, 118);
            this.Update_button.Name = "Update_button";
            this.Update_button.Size = new System.Drawing.Size(97, 26);
            this.Update_button.TabIndex = 17;
            this.Update_button.Text = "Изменить";
            this.Update_button.UseVisualStyleBackColor = true;
            this.Update_button.Click += new System.EventHandler(this.Update_button_Click);
            // 
            // Row_box
            // 
            this.Row_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Row_box.FormattingEnabled = true;
            this.Row_box.Location = new System.Drawing.Point(483, 60);
            this.Row_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Row_box.Name = "Row_box";
            this.Row_box.Size = new System.Drawing.Size(148, 28);
            this.Row_box.TabIndex = 16;
            this.Row_box.SelectedIndexChanged += new System.EventHandler(this.Row_box_SelectedIndexChanged);
            // 
            // Set_id
            // 
            this.Set_id.Location = new System.Drawing.Point(281, 64);
            this.Set_id.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Set_id.Name = "Set_id";
            this.Set_id.Size = new System.Drawing.Size(70, 26);
            this.Set_id.TabIndex = 15;
            this.Set_id.TextChanged += new System.EventHandler(this.Set_id_TextChanged);
            // 
            // Element
            // 
            this.Element.AutoSize = true;
            this.Element.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Element.Location = new System.Drawing.Point(479, 19);
            this.Element.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Element.Name = "Element";
            this.Element.Size = new System.Drawing.Size(62, 23);
            this.Element.TabIndex = 14;
            this.Element.Text = "Строка";
            // 
            // Take_id
            // 
            this.Take_id.AutoSize = true;
            this.Take_id.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Take_id.Location = new System.Drawing.Point(277, 19);
            this.Take_id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Take_id.Name = "Take_id";
            this.Take_id.Size = new System.Drawing.Size(28, 23);
            this.Take_id.TabIndex = 13;
            this.Take_id.Text = "Id";
            // 
            // Table_list
            // 
            this.Table_list.AutoSize = true;
            this.Table_list.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Table_list.Location = new System.Drawing.Point(20, 19);
            this.Table_list.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Table_list.Name = "Table_list";
            this.Table_list.Size = new System.Drawing.Size(152, 23);
            this.Table_list.TabIndex = 12;
            this.Table_list.Text = "Название таблицы";
            // 
            // Table_box
            // 
            this.Table_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Table_box.FormattingEnabled = true;
            this.Table_box.Items.AddRange(new object[] {
            "people",
            "students",
            "teachers",
            "staff",
            "specials",
            "faculties",
            "salary",
            "table1",
            "table2",
            "table3"});
            this.Table_box.Location = new System.Drawing.Point(24, 62);
            this.Table_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Table_box.Name = "Table_box";
            this.Table_box.Size = new System.Drawing.Size(148, 28);
            this.Table_box.TabIndex = 11;
            this.Table_box.SelectedIndexChanged += new System.EventHandler(this.Table_box_SelectedIndexChanged);
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 198);
            this.Controls.Add(this.Back_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Set_str);
            this.Controls.Add(this.Update_button);
            this.Controls.Add(this.Row_box);
            this.Controls.Add(this.Set_id);
            this.Controls.Add(this.Element);
            this.Controls.Add(this.Take_id);
            this.Controls.Add(this.Table_list);
            this.Controls.Add(this.Table_box);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update";
            this.Load += new System.EventHandler(this.Update_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Set_str;
        private System.Windows.Forms.Button Update_button;
        private System.Windows.Forms.ComboBox Row_box;
        private System.Windows.Forms.TextBox Set_id;
        private System.Windows.Forms.Label Element;
        private System.Windows.Forms.Label Take_id;
        private System.Windows.Forms.Label Table_list;
        private System.Windows.Forms.ComboBox Table_box;
    }
}