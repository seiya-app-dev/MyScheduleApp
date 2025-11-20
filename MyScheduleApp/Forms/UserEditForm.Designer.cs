namespace MyScheduleApp.Forms
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
            RoleErrorLabel = new Label();
            FullNameErrorLabel = new Label();
            PasswordErrorLabel = new Label();
            NewUserErrorLabel = new Label();
            StatusCheckBox = new CheckBox();
            RoleComboBox = new ComboBox();
            FullNameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            UserTextBox = new TextBox();
            CancelButton = new Button();
            UpdateButton = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // RoleErrorLabel
            // 
            RoleErrorLabel.AutoSize = true;
            RoleErrorLabel.Location = new Point(214, 314);
            RoleErrorLabel.Name = "RoleErrorLabel";
            RoleErrorLabel.Size = new Size(69, 25);
            RoleErrorLabel.TabIndex = 33;
            RoleErrorLabel.Text = "label10";
            // 
            // FullNameErrorLabel
            // 
            FullNameErrorLabel.AutoSize = true;
            FullNameErrorLabel.Location = new Point(213, 239);
            FullNameErrorLabel.Name = "FullNameErrorLabel";
            FullNameErrorLabel.Size = new Size(59, 25);
            FullNameErrorLabel.TabIndex = 32;
            FullNameErrorLabel.Text = "label9";
            // 
            // PasswordErrorLabel
            // 
            PasswordErrorLabel.AutoSize = true;
            PasswordErrorLabel.Location = new Point(214, 158);
            PasswordErrorLabel.Name = "PasswordErrorLabel";
            PasswordErrorLabel.Size = new Size(59, 25);
            PasswordErrorLabel.TabIndex = 31;
            PasswordErrorLabel.Text = "label8";
            // 
            // NewUserErrorLabel
            // 
            NewUserErrorLabel.AutoSize = true;
            NewUserErrorLabel.Location = new Point(211, 89);
            NewUserErrorLabel.Name = "NewUserErrorLabel";
            NewUserErrorLabel.Size = new Size(59, 25);
            NewUserErrorLabel.TabIndex = 30;
            NewUserErrorLabel.Text = "label7";
            // 
            // StatusCheckBox
            // 
            StatusCheckBox.AutoSize = true;
            StatusCheckBox.Location = new Point(213, 357);
            StatusCheckBox.Name = "StatusCheckBox";
            StatusCheckBox.Size = new Size(22, 21);
            StatusCheckBox.TabIndex = 29;
            StatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // RoleComboBox
            // 
            RoleComboBox.FormattingEnabled = true;
            RoleComboBox.Location = new Point(213, 278);
            RoleComboBox.Name = "RoleComboBox";
            RoleComboBox.Size = new Size(146, 33);
            RoleComboBox.TabIndex = 28;
            // 
            // FullNameTextBox
            // 
            FullNameTextBox.Location = new Point(214, 205);
            FullNameTextBox.Name = "FullNameTextBox";
            FullNameTextBox.Size = new Size(195, 31);
            FullNameTextBox.TabIndex = 27;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(213, 124);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(195, 31);
            PasswordTextBox.TabIndex = 26;
            PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // UserTextBox
            // 
            UserTextBox.Location = new Point(213, 55);
            UserTextBox.Name = "UserTextBox";
            UserTextBox.Size = new Size(195, 31);
            UserTextBox.TabIndex = 25;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(265, 400);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(112, 44);
            CancelButton.TabIndex = 24;
            CancelButton.Text = "キャンセル";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(78, 400);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(112, 44);
            UpdateButton.TabIndex = 23;
            UpdateButton.Text = "更新";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(79, 355);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 22;
            label6.Text = "有効：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(78, 281);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 21;
            label5.Text = "権限：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(79, 211);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 20;
            label4.Text = "氏名：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 130);
            label3.Name = "label3";
            label3.Size = new Size(97, 25);
            label3.TabIndex = 19;
            label3.Text = "パスワード：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 54);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 18;
            label2.Text = "ユーザー名：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 9);
            label1.Name = "label1";
            label1.Size = new Size(153, 25);
            label1.TabIndex = 17;
            label1.Text = "ユーザー情報の編集";
            // 
            // UserEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 467);
            Controls.Add(RoleErrorLabel);
            Controls.Add(FullNameErrorLabel);
            Controls.Add(PasswordErrorLabel);
            Controls.Add(NewUserErrorLabel);
            Controls.Add(StatusCheckBox);
            Controls.Add(RoleComboBox);
            Controls.Add(FullNameTextBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(UserTextBox);
            Controls.Add(CancelButton);
            Controls.Add(UpdateButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UserEditForm";
            Text = "スケジュール帳";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label RoleErrorLabel;
        private Label FullNameErrorLabel;
        private Label PasswordErrorLabel;
        private Label NewUserErrorLabel;
        private CheckBox StatusCheckBox;
        private ComboBox RoleComboBox;
        private TextBox FullNameTextBox;
        private TextBox PasswordTextBox;
        private TextBox UserTextBox;
        private Button CancelButton;
        private Button UpdateButton;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}