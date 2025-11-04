namespace ScheduleApp2
{
    partial class UserEditForm
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
            this.RoleErrorLabel = new System.Windows.Forms.Label();
            this.FullNameErrorLabel = new System.Windows.Forms.Label();
            this.PasswordErrorLabel = new System.Windows.Forms.Label();
            this.UserNameErrorLabel = new System.Windows.Forms.Label();
            this.StatusCheckBox = new System.Windows.Forms.CheckBox();
            this.RoleComboBox = new System.Windows.Forms.ComboBox();
            this.UserFullNameTextBox = new System.Windows.Forms.TextBox();
            this.UserPasswordTextBox = new System.Windows.Forms.TextBox();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.CanselButton = new System.Windows.Forms.Button();
            this.UserEditAddButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RoleErrorLabel
            // 
            this.RoleErrorLabel.AutoSize = true;
            this.RoleErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.RoleErrorLabel.Location = new System.Drawing.Point(159, 269);
            this.RoleErrorLabel.Name = "RoleErrorLabel";
            this.RoleErrorLabel.Size = new System.Drawing.Size(116, 18);
            this.RoleErrorLabel.TabIndex = 33;
            this.RoleErrorLabel.Text = "エラーメッセージ";
            // 
            // FullNameErrorLabel
            // 
            this.FullNameErrorLabel.AutoSize = true;
            this.FullNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.FullNameErrorLabel.Location = new System.Drawing.Point(159, 214);
            this.FullNameErrorLabel.Name = "FullNameErrorLabel";
            this.FullNameErrorLabel.Size = new System.Drawing.Size(116, 18);
            this.FullNameErrorLabel.TabIndex = 32;
            this.FullNameErrorLabel.Text = "エラーメッセージ";
            // 
            // PasswordErrorLabel
            // 
            this.PasswordErrorLabel.AutoSize = true;
            this.PasswordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.PasswordErrorLabel.Location = new System.Drawing.Point(159, 157);
            this.PasswordErrorLabel.Name = "PasswordErrorLabel";
            this.PasswordErrorLabel.Size = new System.Drawing.Size(116, 18);
            this.PasswordErrorLabel.TabIndex = 31;
            this.PasswordErrorLabel.Text = "エラーメッセージ";
            // 
            // UserNameErrorLabel
            // 
            this.UserNameErrorLabel.AutoSize = true;
            this.UserNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.UserNameErrorLabel.Location = new System.Drawing.Point(159, 98);
            this.UserNameErrorLabel.Name = "UserNameErrorLabel";
            this.UserNameErrorLabel.Size = new System.Drawing.Size(116, 18);
            this.UserNameErrorLabel.TabIndex = 30;
            this.UserNameErrorLabel.Text = "エラーメッセージ";
            // 
            // StatusCheckBox
            // 
            this.StatusCheckBox.AutoSize = true;
            this.StatusCheckBox.Location = new System.Drawing.Point(162, 307);
            this.StatusCheckBox.Name = "StatusCheckBox";
            this.StatusCheckBox.Size = new System.Drawing.Size(22, 21);
            this.StatusCheckBox.TabIndex = 29;
            this.StatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // RoleComboBox
            // 
            this.RoleComboBox.FormattingEnabled = true;
            this.RoleComboBox.Location = new System.Drawing.Point(162, 240);
            this.RoleComboBox.Name = "RoleComboBox";
            this.RoleComboBox.Size = new System.Drawing.Size(177, 26);
            this.RoleComboBox.TabIndex = 28;
            // 
            // UserFullNameTextBox
            // 
            this.UserFullNameTextBox.Location = new System.Drawing.Point(162, 182);
            this.UserFullNameTextBox.Name = "UserFullNameTextBox";
            this.UserFullNameTextBox.Size = new System.Drawing.Size(177, 25);
            this.UserFullNameTextBox.TabIndex = 27;
            // 
            // UserPasswordTextBox
            // 
            this.UserPasswordTextBox.Location = new System.Drawing.Point(162, 122);
            this.UserPasswordTextBox.Name = "UserPasswordTextBox";
            this.UserPasswordTextBox.Size = new System.Drawing.Size(177, 25);
            this.UserPasswordTextBox.TabIndex = 26;
            this.UserPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(162, 67);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(177, 25);
            this.UserNameTextBox.TabIndex = 25;
            // 
            // CanselButton
            // 
            this.CanselButton.Location = new System.Drawing.Point(236, 355);
            this.CanselButton.Name = "CanselButton";
            this.CanselButton.Size = new System.Drawing.Size(112, 44);
            this.CanselButton.TabIndex = 24;
            this.CanselButton.Text = "キャンセル";
            this.CanselButton.UseVisualStyleBackColor = true;
            this.CanselButton.Click += new System.EventHandler(this.CanselButton_Click);
            // 
            // UserEditAddButton
            // 
            this.UserEditAddButton.Location = new System.Drawing.Point(80, 355);
            this.UserEditAddButton.Name = "UserEditAddButton";
            this.UserEditAddButton.Size = new System.Drawing.Size(112, 44);
            this.UserEditAddButton.TabIndex = 23;
            this.UserEditAddButton.Text = "更新";
            this.UserEditAddButton.UseVisualStyleBackColor = true;
            this.UserEditAddButton.Click += new System.EventHandler(this.UserEditAddButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "有効：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "権限：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "氏名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "パスワード：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "ユーザー名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "ユーザー情報の編集";
            // 
            // UserEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 426);
            this.Controls.Add(this.RoleErrorLabel);
            this.Controls.Add(this.FullNameErrorLabel);
            this.Controls.Add(this.PasswordErrorLabel);
            this.Controls.Add(this.UserNameErrorLabel);
            this.Controls.Add(this.StatusCheckBox);
            this.Controls.Add(this.RoleComboBox);
            this.Controls.Add(this.UserFullNameTextBox);
            this.Controls.Add(this.UserPasswordTextBox);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.CanselButton);
            this.Controls.Add(this.UserEditAddButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserEditForm";
            this.Text = "スケジュール帳";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RoleErrorLabel;
        private System.Windows.Forms.Label FullNameErrorLabel;
        private System.Windows.Forms.Label PasswordErrorLabel;
        private System.Windows.Forms.Label UserNameErrorLabel;
        private System.Windows.Forms.CheckBox StatusCheckBox;
        private System.Windows.Forms.ComboBox RoleComboBox;
        private System.Windows.Forms.TextBox UserFullNameTextBox;
        private System.Windows.Forms.TextBox UserPasswordTextBox;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Button CanselButton;
        private System.Windows.Forms.Button UserEditAddButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}