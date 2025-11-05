namespace ScheduleApp2.Forms
{
    partial class MainForm
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
            this.MainFormTab = new System.Windows.Forms.TabControl();
            this.ScheduleListTab = new System.Windows.Forms.TabPage();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.UserNameLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.ScheduleListLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ScheduleList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ScheduleTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DayComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MonthComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.YearComboBox = new System.Windows.Forms.ComboBox();
            this.AdminUserListTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.NewUserAddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ScheduleEditButton = new System.Windows.Forms.Button();
            this.UserListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.LogListTab = new System.Windows.Forms.TabPage();
            this.LogListView = new System.Windows.Forms.ListView();
            this.LogID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ActionDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreatedAt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TagetUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainFormTab.SuspendLayout();
            this.ScheduleListTab.SuspendLayout();
            this.AdminUserListTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.LogListTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormTab
            // 
            this.MainFormTab.Controls.Add(this.ScheduleListTab);
            this.MainFormTab.Controls.Add(this.AdminUserListTab);
            this.MainFormTab.Controls.Add(this.LogListTab);
            this.MainFormTab.Location = new System.Drawing.Point(25, 12);
            this.MainFormTab.Name = "MainFormTab";
            this.MainFormTab.SelectedIndex = 0;
            this.MainFormTab.Size = new System.Drawing.Size(548, 386);
            this.MainFormTab.TabIndex = 0;
            this.MainFormTab.SelectedIndexChanged += new System.EventHandler(this.LoadUserList);
            this.MainFormTab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.MainFormTab_Selecting);
            // 
            // ScheduleListTab
            // 
            this.ScheduleListTab.Controls.Add(this.RestoreButton);
            this.ScheduleListTab.Controls.Add(this.UserNameLinkLabel);
            this.ScheduleListTab.Controls.Add(this.label6);
            this.ScheduleListTab.Controls.Add(this.ScheduleListLabel);
            this.ScheduleListTab.Controls.Add(this.ClearButton);
            this.ScheduleListTab.Controls.Add(this.ScheduleList);
            this.ScheduleListTab.Controls.Add(this.DeleteButton);
            this.ScheduleListTab.Controls.Add(this.SaveButton);
            this.ScheduleListTab.Controls.Add(this.label4);
            this.ScheduleListTab.Controls.Add(this.ScheduleTextBox);
            this.ScheduleListTab.Controls.Add(this.label3);
            this.ScheduleListTab.Controls.Add(this.DayComboBox);
            this.ScheduleListTab.Controls.Add(this.label2);
            this.ScheduleListTab.Controls.Add(this.MonthComboBox);
            this.ScheduleListTab.Controls.Add(this.label1);
            this.ScheduleListTab.Controls.Add(this.YearComboBox);
            this.ScheduleListTab.Location = new System.Drawing.Point(4, 28);
            this.ScheduleListTab.Name = "ScheduleListTab";
            this.ScheduleListTab.Padding = new System.Windows.Forms.Padding(3);
            this.ScheduleListTab.Size = new System.Drawing.Size(540, 354);
            this.ScheduleListTab.TabIndex = 0;
            this.ScheduleListTab.Text = "スケジュール";
            this.ScheduleListTab.UseVisualStyleBackColor = true;
            // 
            // RestoreButton
            // 
            this.RestoreButton.Enabled = false;
            this.RestoreButton.Location = new System.Drawing.Point(443, 308);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(63, 35);
            this.RestoreButton.TabIndex = 27;
            this.RestoreButton.Text = "復元";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // UserNameLinkLabel
            // 
            this.UserNameLinkLabel.AutoSize = true;
            this.UserNameLinkLabel.Location = new System.Drawing.Point(429, 20);
            this.UserNameLinkLabel.Name = "UserNameLinkLabel";
            this.UserNameLinkLabel.Size = new System.Drawing.Size(86, 18);
            this.UserNameLinkLabel.TabIndex = 26;
            this.UserNameLinkLabel.TabStop = true;
            this.UserNameLinkLabel.Text = "UserName";
            this.UserNameLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UserNameLinkLabel_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 18);
            this.label6.TabIndex = 25;
            this.label6.Text = "ログインユーザー：";
            // 
            // ScheduleListLabel
            // 
            this.ScheduleListLabel.AutoSize = true;
            this.ScheduleListLabel.Location = new System.Drawing.Point(16, 102);
            this.ScheduleListLabel.Name = "ScheduleListLabel";
            this.ScheduleListLabel.Size = new System.Drawing.Size(138, 18);
            this.ScheduleListLabel.TabIndex = 24;
            this.ScheduleListLabel.Text = "スケジュール一覧：";
            // 
            // ClearButton
            // 
            this.ClearButton.Enabled = false;
            this.ClearButton.Location = new System.Drawing.Point(373, 308);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(63, 36);
            this.ClearButton.TabIndex = 23;
            this.ClearButton.Text = "クリア";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ScheduleList
            // 
            this.ScheduleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.ScheduleList.HideSelection = false;
            this.ScheduleList.Location = new System.Drawing.Point(16, 126);
            this.ScheduleList.Name = "ScheduleList";
            this.ScheduleList.Size = new System.Drawing.Size(499, 176);
            this.ScheduleList.TabIndex = 22;
            this.ScheduleList.UseCompatibleStateImageBehavior = false;
            this.ScheduleList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "予定";
            this.columnHeader2.Width = 319;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(443, 57);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(63, 36);
            this.DeleteButton.TabIndex = 21;
            this.DeleteButton.Text = "削除";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(373, 57);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(64, 36);
            this.SaveButton.TabIndex = 20;
            this.SaveButton.Text = "登録";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "予定：";
            // 
            // ScheduleTextBox
            // 
            this.ScheduleTextBox.Enabled = false;
            this.ScheduleTextBox.Location = new System.Drawing.Point(160, 63);
            this.ScheduleTextBox.Name = "ScheduleTextBox";
            this.ScheduleTextBox.Size = new System.Drawing.Size(207, 25);
            this.ScheduleTextBox.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "日";
            // 
            // DayComboBox
            // 
            this.DayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DayComboBox.Enabled = false;
            this.DayComboBox.FormattingEnabled = true;
            this.DayComboBox.Location = new System.Drawing.Point(17, 63);
            this.DayComboBox.Name = "DayComboBox";
            this.DayComboBox.Size = new System.Drawing.Size(50, 26);
            this.DayComboBox.TabIndex = 16;
            this.DayComboBox.SelectedIndexChanged += new System.EventHandler(this.DayComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "月";
            // 
            // MonthComboBox
            // 
            this.MonthComboBox.FormattingEnabled = true;
            this.MonthComboBox.Location = new System.Drawing.Point(132, 17);
            this.MonthComboBox.Name = "MonthComboBox";
            this.MonthComboBox.Size = new System.Drawing.Size(59, 26);
            this.MonthComboBox.TabIndex = 14;
            this.MonthComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBoxYearOrMonth_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "年";
            // 
            // YearComboBox
            // 
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Location = new System.Drawing.Point(17, 17);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(77, 26);
            this.YearComboBox.TabIndex = 12;
            this.YearComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBoxYearOrMonth_SelectedIndexChanged);
            // 
            // AdminUserListTab
            // 
            this.AdminUserListTab.Controls.Add(this.groupBox2);
            this.AdminUserListTab.Controls.Add(this.groupBox1);
            this.AdminUserListTab.Controls.Add(this.UserListView);
            this.AdminUserListTab.Controls.Add(this.UserLinkLabel);
            this.AdminUserListTab.Controls.Add(this.label5);
            this.AdminUserListTab.Location = new System.Drawing.Point(4, 28);
            this.AdminUserListTab.Name = "AdminUserListTab";
            this.AdminUserListTab.Padding = new System.Windows.Forms.Padding(3);
            this.AdminUserListTab.Size = new System.Drawing.Size(540, 354);
            this.AdminUserListTab.TabIndex = 1;
            this.AdminUserListTab.Text = "管理画面";
            this.AdminUserListTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.NewUserAddButton);
            this.groupBox2.Controls.Add(this.EditButton);
            this.groupBox2.Location = new System.Drawing.Point(215, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 74);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ユーザー情報";
            // 
            // NewUserAddButton
            // 
            this.NewUserAddButton.Enabled = false;
            this.NewUserAddButton.Location = new System.Drawing.Point(20, 24);
            this.NewUserAddButton.Name = "NewUserAddButton";
            this.NewUserAddButton.Size = new System.Drawing.Size(112, 40);
            this.NewUserAddButton.TabIndex = 31;
            this.NewUserAddButton.Text = "新規登録";
            this.NewUserAddButton.UseVisualStyleBackColor = true;
            this.NewUserAddButton.Click += new System.EventHandler(this.NewUserAddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(168, 24);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(112, 40);
            this.EditButton.TabIndex = 32;
            this.EditButton.Text = "編集";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ScheduleEditButton);
            this.groupBox1.Location = new System.Drawing.Point(37, 267);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 81);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "スケジュール";
            // 
            // ScheduleEditButton
            // 
            this.ScheduleEditButton.Enabled = false;
            this.ScheduleEditButton.Location = new System.Drawing.Point(28, 27);
            this.ScheduleEditButton.Name = "ScheduleEditButton";
            this.ScheduleEditButton.Size = new System.Drawing.Size(112, 40);
            this.ScheduleEditButton.TabIndex = 30;
            this.ScheduleEditButton.Text = "編集";
            this.ScheduleEditButton.UseVisualStyleBackColor = true;
            this.ScheduleEditButton.Click += new System.EventHandler(this.ScheduleEditButton_Click);
            // 
            // UserListView
            // 
            this.UserListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.UserListView.FullRowSelect = true;
            this.UserListView.HideSelection = false;
            this.UserListView.Location = new System.Drawing.Point(37, 55);
            this.UserListView.Name = "UserListView";
            this.UserListView.Size = new System.Drawing.Size(477, 193);
            this.UserListView.TabIndex = 29;
            this.UserListView.UseCompatibleStateImageBehavior = false;
            this.UserListView.View = System.Windows.Forms.View.Details;
            this.UserListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserListView_MouseClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ユーザー名";
            this.columnHeader4.Width = 119;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "氏名";
            this.columnHeader5.Width = 77;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "権限";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "状態";
            // 
            // UserLinkLabel
            // 
            this.UserLinkLabel.AutoSize = true;
            this.UserLinkLabel.Location = new System.Drawing.Point(428, 19);
            this.UserLinkLabel.Name = "UserLinkLabel";
            this.UserLinkLabel.Size = new System.Drawing.Size(86, 18);
            this.UserLinkLabel.TabIndex = 28;
            this.UserLinkLabel.TabStop = true;
            this.UserLinkLabel.Text = "UserName";
            this.UserLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UserNameLinkLabel_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 18);
            this.label5.TabIndex = 27;
            this.label5.Text = "ログインユーザー：";
            // 
            // LogListTab
            // 
            this.LogListTab.Controls.Add(this.LogListView);
            this.LogListTab.Location = new System.Drawing.Point(4, 28);
            this.LogListTab.Name = "LogListTab";
            this.LogListTab.Size = new System.Drawing.Size(540, 354);
            this.LogListTab.TabIndex = 2;
            this.LogListTab.Text = "履歴画面";
            this.LogListTab.UseVisualStyleBackColor = true;
            // 
            // LogListView
            // 
            this.LogListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LogID,
            this.UserID,
            this.Action,
            this.ActionDate,
            this.CreatedAt,
            this.TagetUserID});
            this.LogListView.HideSelection = false;
            this.LogListView.Location = new System.Drawing.Point(28, 54);
            this.LogListView.Name = "LogListView";
            this.LogListView.Size = new System.Drawing.Size(483, 260);
            this.LogListView.TabIndex = 0;
            this.LogListView.UseCompatibleStateImageBehavior = false;
            this.LogListView.View = System.Windows.Forms.View.Details;
            // 
            // LogID
            // 
            this.LogID.Text = "ログID";
            // 
            // UserID
            // 
            this.UserID.Text = "ユーザーID";
            this.UserID.Width = 94;
            // 
            // Action
            // 
            this.Action.Text = "アクション";
            this.Action.Width = 78;
            // 
            // ActionDate
            // 
            this.ActionDate.Text = "選択日時";
            this.ActionDate.Width = 94;
            // 
            // CreatedAt
            // 
            this.CreatedAt.Text = "作成日時";
            this.CreatedAt.Width = 90;
            // 
            // TagetUserID
            // 
            this.TagetUserID.Text = "対象ユーザーID";
            this.TagetUserID.Width = 76;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 410);
            this.Controls.Add(this.MainFormTab);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.ScheduleApp2_Load);
            this.MainFormTab.ResumeLayout(false);
            this.ScheduleListTab.ResumeLayout(false);
            this.ScheduleListTab.PerformLayout();
            this.AdminUserListTab.ResumeLayout(false);
            this.AdminUserListTab.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.LogListTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainFormTab;
        private System.Windows.Forms.TabPage ScheduleListTab;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.ListView ScheduleList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ScheduleTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DayComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox MonthComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox YearComboBox;
        private System.Windows.Forms.TabPage AdminUserListTab;
        private System.Windows.Forms.LinkLabel UserNameLinkLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ScheduleListLabel;
        private System.Windows.Forms.ListView UserListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.LinkLabel UserLinkLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button NewUserAddButton;
        private System.Windows.Forms.Button ScheduleEditButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.TabPage LogListTab;
        private System.Windows.Forms.ListView LogListView;
        private System.Windows.Forms.ColumnHeader LogID;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.ColumnHeader Action;
        private System.Windows.Forms.ColumnHeader ActionDate;
        private System.Windows.Forms.ColumnHeader CreatedAt;
        private System.Windows.Forms.ColumnHeader TagetUserID;
    }
}