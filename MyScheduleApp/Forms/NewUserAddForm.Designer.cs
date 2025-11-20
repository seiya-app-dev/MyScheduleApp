namespace MyScheduleApp.Forms
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            NewUserAddButton = new Button();
            CancelButton = new Button();
            NewUserTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            FullNameTextBox = new TextBox();
            RoleComboBox = new ComboBox();
            StatusCheckBox = new CheckBox();
            NewUserErrorLabel = new Label();
            PasswordErrorLabel = new Label();
            FullNameErrorLabel = new Label();
            RoleErrorLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 23);
            label1.Name = "label1";
            label1.Size = new Size(189, 25);
            label1.TabIndex = 0;
            label1.Text = "ユーザー情報の新規登録";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 70);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 1;
            label2.Text = "ユーザー名：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 146);
            label3.Name = "label3";
            label3.Size = new Size(97, 25);
            label3.TabIndex = 2;
            label3.Text = "パスワード：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 227);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 3;
            label4.Text = "氏名：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(71, 297);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 4;
            label5.Text = "権限：";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(72, 371);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 5;
            label6.Text = "有効：";
            // 
            // NewUserAddButton
            // 
            NewUserAddButton.Location = new Point(104, 407);
            NewUserAddButton.Name = "NewUserAddButton";
            NewUserAddButton.Size = new Size(112, 49);
            NewUserAddButton.TabIndex = 6;
            NewUserAddButton.Text = "登録";
            NewUserAddButton.UseVisualStyleBackColor = true;
            NewUserAddButton.Click += NewUserAddButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(273, 407);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(112, 49);
            CancelButton.TabIndex = 7;
            CancelButton.Text = "キャンセル";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // NewUserTextBox
            // 
            NewUserTextBox.Location = new Point(206, 71);
            NewUserTextBox.Name = "NewUserTextBox";
            NewUserTextBox.Size = new Size(195, 31);
            NewUserTextBox.TabIndex = 8;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(206, 140);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(195, 31);
            PasswordTextBox.TabIndex = 9;
            PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // FullNameTextBox
            // 
            FullNameTextBox.Location = new Point(207, 221);
            FullNameTextBox.Name = "FullNameTextBox";
            FullNameTextBox.Size = new Size(195, 31);
            FullNameTextBox.TabIndex = 10;
            // 
            // RoleComboBox
            // 
            RoleComboBox.FormattingEnabled = true;
            RoleComboBox.Location = new Point(206, 294);
            RoleComboBox.Name = "RoleComboBox";
            RoleComboBox.Size = new Size(146, 33);
            RoleComboBox.TabIndex = 11;
            // 
            // StatusCheckBox
            // 
            StatusCheckBox.AutoSize = true;
            StatusCheckBox.Checked = true;
            StatusCheckBox.CheckState = CheckState.Checked;
            StatusCheckBox.Enabled = false;
            StatusCheckBox.Location = new Point(206, 373);
            StatusCheckBox.Name = "StatusCheckBox";
            StatusCheckBox.Size = new Size(22, 21);
            StatusCheckBox.TabIndex = 12;
            StatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // NewUserErrorLabel
            // 
            NewUserErrorLabel.AutoSize = true;
            NewUserErrorLabel.Location = new Point(204, 105);
            NewUserErrorLabel.Name = "NewUserErrorLabel";
            NewUserErrorLabel.Size = new Size(59, 25);
            NewUserErrorLabel.TabIndex = 13;
            NewUserErrorLabel.Text = "label7";
            // 
            // PasswordErrorLabel
            // 
            PasswordErrorLabel.AutoSize = true;
            PasswordErrorLabel.Location = new Point(207, 174);
            PasswordErrorLabel.Name = "PasswordErrorLabel";
            PasswordErrorLabel.Size = new Size(59, 25);
            PasswordErrorLabel.TabIndex = 14;
            PasswordErrorLabel.Text = "label8";
            // 
            // FullNameErrorLabel
            // 
            FullNameErrorLabel.AutoSize = true;
            FullNameErrorLabel.Location = new Point(206, 255);
            FullNameErrorLabel.Name = "FullNameErrorLabel";
            FullNameErrorLabel.Size = new Size(59, 25);
            FullNameErrorLabel.TabIndex = 15;
            FullNameErrorLabel.Text = "label9";
            // 
            // RoleErrorLabel
            // 
            RoleErrorLabel.AutoSize = true;
            RoleErrorLabel.Location = new Point(207, 330);
            RoleErrorLabel.Name = "RoleErrorLabel";
            RoleErrorLabel.Size = new Size(69, 25);
            RoleErrorLabel.TabIndex = 16;
            RoleErrorLabel.Text = "label10";
            // 
            // NewUserAddForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 468);
            Controls.Add(RoleErrorLabel);
            Controls.Add(FullNameErrorLabel);
            Controls.Add(PasswordErrorLabel);
            Controls.Add(NewUserErrorLabel);
            Controls.Add(StatusCheckBox);
            Controls.Add(RoleComboBox);
            Controls.Add(FullNameTextBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(NewUserTextBox);
            Controls.Add(CancelButton);
            Controls.Add(NewUserAddButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "NewUserAddForm";
            Text = "スケジュール帳";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button NewUserAddButton;
        private Button CancelButton;
        private TextBox NewUserTextBox;
        private TextBox PasswordTextBox;
        private TextBox FullNameTextBox;
        private ComboBox RoleComboBox;
        private CheckBox StatusCheckBox;
        private Label NewUserErrorLabel;
        private Label PasswordErrorLabel;
        private Label FullNameErrorLabel;
        private Label RoleErrorLabel;
    }
}