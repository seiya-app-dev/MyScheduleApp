namespace ScheduleApp2
{
    partial class NewUserAddForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NewUserAddButton = new System.Windows.Forms.Button();
            this.CanselButton = new System.Windows.Forms.Button();
            this.NewUserTextBox = new System.Windows.Forms.TextBox();
            this.NewUserPasswordTextBox = new System.Windows.Forms.TextBox();
            this.NewUserFullNameTextBox = new System.Windows.Forms.TextBox();
            this.RoleComboBox = new System.Windows.Forms.ComboBox();
            this.StatusCheckBox = new System.Windows.Forms.CheckBox();
            this.UserNameErrorLabel = new System.Windows.Forms.Label();
            this.PasswordErrorLabel = new System.Windows.Forms.Label();
            this.FullNameErrorLabel = new System.Windows.Forms.Label();
            this.RoleErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ユーザー情報の新規登録";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "ユーザー名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "パスワード：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "氏名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "権限：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "有効：";
            // 
            // NewUserAddButton
            // 
            this.NewUserAddButton.Location = new System.Drawing.Point(75, 353);
            this.NewUserAddButton.Name = "NewUserAddButton";
            this.NewUserAddButton.Size = new System.Drawing.Size(112, 44);
            this.NewUserAddButton.TabIndex = 6;
            this.NewUserAddButton.Text = "登録";
            this.NewUserAddButton.UseVisualStyleBackColor = true;
            this.NewUserAddButton.Click += new System.EventHandler(this.NewUserAddButton_Click);
            // 
            // CanselButton
            // 
            this.CanselButton.Location = new System.Drawing.Point(231, 353);
            this.CanselButton.Name = "CanselButton";
            this.CanselButton.Size = new System.Drawing.Size(112, 44);
            this.CanselButton.TabIndex = 7;
            this.CanselButton.Text = "キャンセル";
            this.CanselButton.UseVisualStyleBackColor = true;
            this.CanselButton.Click += new System.EventHandler(this.CanselButton_Click);
            // 
            // NewUserTextBox
            // 
            this.NewUserTextBox.Location = new System.Drawing.Point(157, 65);
            this.NewUserTextBox.Name = "NewUserTextBox";
            this.NewUserTextBox.Size = new System.Drawing.Size(177, 25);
            this.NewUserTextBox.TabIndex = 8;
            // 
            // NewUserPasswordTextBox
            // 
            this.NewUserPasswordTextBox.Location = new System.Drawing.Point(157, 120);
            this.NewUserPasswordTextBox.Name = "NewUserPasswordTextBox";
            this.NewUserPasswordTextBox.Size = new System.Drawing.Size(177, 25);
            this.NewUserPasswordTextBox.TabIndex = 9;
            this.NewUserPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // NewUserFullNameTextBox
            // 
            this.NewUserFullNameTextBox.Location = new System.Drawing.Point(157, 180);
            this.NewUserFullNameTextBox.Name = "NewUserFullNameTextBox";
            this.NewUserFullNameTextBox.Size = new System.Drawing.Size(177, 25);
            this.NewUserFullNameTextBox.TabIndex = 10;
            // 
            // RoleComboBox
            // 
            this.RoleComboBox.FormattingEnabled = true;
            this.RoleComboBox.Location = new System.Drawing.Point(157, 238);
            this.RoleComboBox.Name = "RoleComboBox";
            this.RoleComboBox.Size = new System.Drawing.Size(177, 26);
            this.RoleComboBox.TabIndex = 11;
            // 
            // StatusCheckBox
            // 
            this.StatusCheckBox.AutoSize = true;
            this.StatusCheckBox.Checked = true;
            this.StatusCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StatusCheckBox.Enabled = false;
            this.StatusCheckBox.Location = new System.Drawing.Point(157, 305);
            this.StatusCheckBox.Name = "StatusCheckBox";
            this.StatusCheckBox.Size = new System.Drawing.Size(22, 21);
            this.StatusCheckBox.TabIndex = 12;
            this.StatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // UserNameErrorLabel
            // 
            this.UserNameErrorLabel.AutoSize = true;
            this.UserNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.UserNameErrorLabel.Location = new System.Drawing.Point(154, 96);
            this.UserNameErrorLabel.Name = "UserNameErrorLabel";
            this.UserNameErrorLabel.Size = new System.Drawing.Size(116, 18);
            this.UserNameErrorLabel.TabIndex = 13;
            this.UserNameErrorLabel.Text = "エラーメッセージ";
            // 
            // PasswordErrorLabel
            // 
            this.PasswordErrorLabel.AutoSize = true;
            this.PasswordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.PasswordErrorLabel.Location = new System.Drawing.Point(154, 155);
            this.PasswordErrorLabel.Name = "PasswordErrorLabel";
            this.PasswordErrorLabel.Size = new System.Drawing.Size(116, 18);
            this.PasswordErrorLabel.TabIndex = 14;
            this.PasswordErrorLabel.Text = "エラーメッセージ";
            // 
            // FullNameErrorLabel
            // 
            this.FullNameErrorLabel.AutoSize = true;
            this.FullNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.FullNameErrorLabel.Location = new System.Drawing.Point(154, 212);
            this.FullNameErrorLabel.Name = "FullNameErrorLabel";
            this.FullNameErrorLabel.Size = new System.Drawing.Size(116, 18);
            this.FullNameErrorLabel.TabIndex = 15;
            this.FullNameErrorLabel.Text = "エラーメッセージ";
            // 
            // RoleErrorLabel
            // 
            this.RoleErrorLabel.AutoSize = true;
            this.RoleErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.RoleErrorLabel.Location = new System.Drawing.Point(154, 267);
            this.RoleErrorLabel.Name = "RoleErrorLabel";
            this.RoleErrorLabel.Size = new System.Drawing.Size(116, 18);
            this.RoleErrorLabel.TabIndex = 16;
            this.RoleErrorLabel.Text = "エラーメッセージ";
            // 
            // NewUserAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 412);
            this.Controls.Add(this.RoleErrorLabel);
            this.Controls.Add(this.FullNameErrorLabel);
            this.Controls.Add(this.PasswordErrorLabel);
            this.Controls.Add(this.UserNameErrorLabel);
            this.Controls.Add(this.StatusCheckBox);
            this.Controls.Add(this.RoleComboBox);
            this.Controls.Add(this.NewUserFullNameTextBox);
            this.Controls.Add(this.NewUserPasswordTextBox);
            this.Controls.Add(this.NewUserTextBox);
            this.Controls.Add(this.CanselButton);
            this.Controls.Add(this.NewUserAddButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewUserAddForm";
            this.Text = "スケジュール帳";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button NewUserAddButton;
        private System.Windows.Forms.Button CanselButton;
        private System.Windows.Forms.TextBox NewUserTextBox;
        private System.Windows.Forms.TextBox NewUserPasswordTextBox;
        private System.Windows.Forms.TextBox NewUserFullNameTextBox;
        private System.Windows.Forms.ComboBox RoleComboBox;
        private System.Windows.Forms.CheckBox StatusCheckBox;
        private System.Windows.Forms.Label UserNameErrorLabel;
        private System.Windows.Forms.Label PasswordErrorLabel;
        private System.Windows.Forms.Label FullNameErrorLabel;
        private System.Windows.Forms.Label RoleErrorLabel;
    }
}