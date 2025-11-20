namespace MyScheduleApp.Forms
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
            YearComboBox = new ComboBox();
            MonthComboBox = new ComboBox();
            DayComboBox = new ComboBox();
            MainFormTab = new TabControl();
            ScheduleTab = new TabPage();
            ScheduleEditName = new Label();
            UserName = new LinkLabel();
            RestoreButton = new Button();
            ClearButton = new Button();
            ScheduleDeleteButton = new Button();
            ScheduleAddButton = new Button();
            ScheduleList = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            ScheduleTextBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            UserListTab = new TabPage();
            groupBox2 = new GroupBox();
            UserEditButton = new Button();
            NewUserAddButton = new Button();
            groupBox1 = new GroupBox();
            ScheduleEditButton = new Button();
            UserList = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            label8 = new Label();
            LoginUser = new LinkLabel();
            label7 = new Label();
            LogListTab = new TabPage();
            LogList = new ListView();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            MainFormTab.SuspendLayout();
            ScheduleTab.SuspendLayout();
            UserListTab.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            LogListTab.SuspendLayout();
            SuspendLayout();
            // 
            // YearComboBox
            // 
            YearComboBox.FormattingEnabled = true;
            YearComboBox.Location = new Point(21, 16);
            YearComboBox.Name = "YearComboBox";
            YearComboBox.Size = new Size(98, 33);
            YearComboBox.TabIndex = 0;
            YearComboBox.SelectedIndexChanged += ComboBoxYearOrMonth_SelectedIndexChanged;
            // 
            // MonthComboBox
            // 
            MonthComboBox.FormattingEnabled = true;
            MonthComboBox.Location = new Point(161, 16);
            MonthComboBox.Name = "MonthComboBox";
            MonthComboBox.Size = new Size(69, 33);
            MonthComboBox.TabIndex = 1;
            MonthComboBox.SelectedIndexChanged += ComboBoxYearOrMonth_SelectedIndexChanged;
            // 
            // DayComboBox
            // 
            DayComboBox.Enabled = false;
            DayComboBox.FormattingEnabled = true;
            DayComboBox.Location = new Point(21, 69);
            DayComboBox.Name = "DayComboBox";
            DayComboBox.Size = new Size(84, 33);
            DayComboBox.TabIndex = 2;
            // 
            // MainFormTab
            // 
            MainFormTab.Controls.Add(ScheduleTab);
            MainFormTab.Controls.Add(UserListTab);
            MainFormTab.Controls.Add(LogListTab);
            MainFormTab.Location = new Point(12, 12);
            MainFormTab.Name = "MainFormTab";
            MainFormTab.SelectedIndex = 0;
            MainFormTab.Size = new Size(617, 488);
            MainFormTab.TabIndex = 3;
            MainFormTab.Selecting += MainFormTab_Selecting;
            // 
            // ScheduleTab
            // 
            ScheduleTab.Controls.Add(ScheduleEditName);
            ScheduleTab.Controls.Add(UserName);
            ScheduleTab.Controls.Add(RestoreButton);
            ScheduleTab.Controls.Add(ClearButton);
            ScheduleTab.Controls.Add(ScheduleDeleteButton);
            ScheduleTab.Controls.Add(ScheduleAddButton);
            ScheduleTab.Controls.Add(ScheduleList);
            ScheduleTab.Controls.Add(ScheduleTextBox);
            ScheduleTab.Controls.Add(label5);
            ScheduleTab.Controls.Add(label4);
            ScheduleTab.Controls.Add(label3);
            ScheduleTab.Controls.Add(label2);
            ScheduleTab.Controls.Add(label1);
            ScheduleTab.Controls.Add(MonthComboBox);
            ScheduleTab.Controls.Add(YearComboBox);
            ScheduleTab.Controls.Add(DayComboBox);
            ScheduleTab.Location = new Point(4, 34);
            ScheduleTab.Name = "ScheduleTab";
            ScheduleTab.Padding = new Padding(3);
            ScheduleTab.Size = new Size(609, 450);
            ScheduleTab.TabIndex = 0;
            ScheduleTab.Text = "スケジュール";
            ScheduleTab.UseVisualStyleBackColor = true;
            // 
            // ScheduleEditName
            // 
            ScheduleEditName.AutoSize = true;
            ScheduleEditName.Location = new Point(30, 117);
            ScheduleEditName.Name = "ScheduleEditName";
            ScheduleEditName.Size = new Size(59, 25);
            ScheduleEditName.TabIndex = 16;
            ScheduleEditName.Text = "label6";
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.Location = new Point(491, 24);
            UserName.Name = "UserName";
            UserName.Size = new Size(90, 25);
            UserName.TabIndex = 15;
            UserName.TabStop = true;
            UserName.Text = "linkLabel1";
            UserName.LinkClicked += UserName_LinkClicked;
            // 
            // RestoreButton
            // 
            RestoreButton.Enabled = false;
            RestoreButton.Location = new Point(514, 394);
            RestoreButton.Name = "RestoreButton";
            RestoreButton.Size = new Size(67, 50);
            RestoreButton.TabIndex = 14;
            RestoreButton.Text = "復元";
            RestoreButton.UseVisualStyleBackColor = true;
            RestoreButton.Click += RestoreButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Enabled = false;
            ClearButton.Location = new Point(421, 394);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(69, 50);
            ClearButton.TabIndex = 13;
            ClearButton.Text = "クリア";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // ScheduleDeleteButton
            // 
            ScheduleDeleteButton.Enabled = false;
            ScheduleDeleteButton.Location = new Point(514, 72);
            ScheduleDeleteButton.Name = "ScheduleDeleteButton";
            ScheduleDeleteButton.Size = new Size(67, 44);
            ScheduleDeleteButton.TabIndex = 12;
            ScheduleDeleteButton.Text = "削除";
            ScheduleDeleteButton.UseVisualStyleBackColor = true;
            ScheduleDeleteButton.Click += ScheduleDeleteButton_Click;
            // 
            // ScheduleAddButton
            // 
            ScheduleAddButton.Enabled = false;
            ScheduleAddButton.Location = new Point(441, 72);
            ScheduleAddButton.Name = "ScheduleAddButton";
            ScheduleAddButton.Size = new Size(67, 44);
            ScheduleAddButton.TabIndex = 11;
            ScheduleAddButton.Text = "登録";
            ScheduleAddButton.UseVisualStyleBackColor = true;
            ScheduleAddButton.Click += ScheduleAddButton_Click;
            // 
            // ScheduleList
            // 
            ScheduleList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            ScheduleList.Location = new Point(21, 144);
            ScheduleList.Name = "ScheduleList";
            ScheduleList.Size = new Size(560, 234);
            ScheduleList.TabIndex = 9;
            ScheduleList.UseCompatibleStateImageBehavior = false;
            ScheduleList.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "日";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "予定";
            // 
            // ScheduleTextBox
            // 
            ScheduleTextBox.Enabled = false;
            ScheduleTextBox.Location = new Point(231, 71);
            ScheduleTextBox.Name = "ScheduleTextBox";
            ScheduleTextBox.Size = new Size(191, 31);
            ScheduleTextBox.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(337, 25);
            label5.Name = "label5";
            label5.Size = new Size(153, 25);
            label5.TabIndex = 7;
            label5.Text = "ログインユーザー名：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(159, 77);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 6;
            label4.Text = "予定：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(111, 77);
            label3.Name = "label3";
            label3.Size = new Size(30, 25);
            label3.TabIndex = 5;
            label3.Text = "日";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 24);
            label2.Name = "label2";
            label2.Size = new Size(30, 25);
            label2.TabIndex = 4;
            label2.Text = "月";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(125, 24);
            label1.Name = "label1";
            label1.Size = new Size(30, 25);
            label1.TabIndex = 3;
            label1.Text = "年";
            // 
            // UserListTab
            // 
            UserListTab.Controls.Add(groupBox2);
            UserListTab.Controls.Add(groupBox1);
            UserListTab.Controls.Add(UserList);
            UserListTab.Controls.Add(label8);
            UserListTab.Controls.Add(LoginUser);
            UserListTab.Controls.Add(label7);
            UserListTab.Location = new Point(4, 34);
            UserListTab.Name = "UserListTab";
            UserListTab.Padding = new Padding(3);
            UserListTab.Size = new Size(609, 450);
            UserListTab.TabIndex = 1;
            UserListTab.Text = "管理画面";
            UserListTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(UserEditButton);
            groupBox2.Controls.Add(NewUserAddButton);
            groupBox2.Location = new Point(312, 327);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(268, 100);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            groupBox2.Text = "ユーザー情報";
            // 
            // UserEditButton
            // 
            UserEditButton.Enabled = false;
            UserEditButton.Location = new Point(154, 39);
            UserEditButton.Name = "UserEditButton";
            UserEditButton.Size = new Size(95, 44);
            UserEditButton.TabIndex = 22;
            UserEditButton.Text = "編集";
            UserEditButton.UseVisualStyleBackColor = true;
            UserEditButton.Click += UserEditButton_Click;
            // 
            // NewUserAddButton
            // 
            NewUserAddButton.Enabled = false;
            NewUserAddButton.Location = new Point(17, 39);
            NewUserAddButton.Name = "NewUserAddButton";
            NewUserAddButton.Size = new Size(112, 44);
            NewUserAddButton.TabIndex = 1;
            NewUserAddButton.Text = "新規登録";
            NewUserAddButton.UseVisualStyleBackColor = true;
            NewUserAddButton.Click += NewUserAddButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ScheduleEditButton);
            groupBox1.Location = new Point(68, 327);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(156, 89);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "スケジュール";
            // 
            // ScheduleEditButton
            // 
            ScheduleEditButton.Enabled = false;
            ScheduleEditButton.Location = new Point(39, 39);
            ScheduleEditButton.Name = "ScheduleEditButton";
            ScheduleEditButton.Size = new Size(86, 44);
            ScheduleEditButton.TabIndex = 0;
            ScheduleEditButton.Text = "編集";
            ScheduleEditButton.UseVisualStyleBackColor = true;
            ScheduleEditButton.Click += ScheduleEditButton_Click;
            // 
            // UserList
            // 
            UserList.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            UserList.FullRowSelect = true;
            UserList.Location = new Point(34, 97);
            UserList.Name = "UserList";
            UserList.Size = new Size(546, 213);
            UserList.TabIndex = 19;
            UserList.UseCompatibleStateImageBehavior = false;
            UserList.View = View.Details;
            UserList.MouseClick += UserList_MouseClick;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "ID";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "ユーザー名";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "氏名";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "権限";
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "状態";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(32, 59);
            label8.Name = "label8";
            label8.Size = new Size(156, 25);
            label8.TabIndex = 18;
            label8.Text = "ユーザー情報一覧：";
            // 
            // LoginUser
            // 
            LoginUser.AutoSize = true;
            LoginUser.Location = new Point(490, 25);
            LoginUser.Name = "LoginUser";
            LoginUser.Size = new Size(90, 25);
            LoginUser.TabIndex = 17;
            LoginUser.TabStop = true;
            LoginUser.Text = "linkLabel2";
            LoginUser.LinkClicked += UserName_LinkClicked;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(336, 26);
            label7.Name = "label7";
            label7.Size = new Size(153, 25);
            label7.TabIndex = 16;
            label7.Text = "ログインユーザー名：";
            // 
            // LogListTab
            // 
            LogListTab.Controls.Add(LogList);
            LogListTab.Location = new Point(4, 34);
            LogListTab.Name = "LogListTab";
            LogListTab.Padding = new Padding(3);
            LogListTab.Size = new Size(609, 450);
            LogListTab.TabIndex = 2;
            LogListTab.Text = "ログ画面";
            LogListTab.UseVisualStyleBackColor = true;
            // 
            // LogList
            // 
            LogList.Columns.AddRange(new ColumnHeader[] { columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12 });
            LogList.Location = new Point(25, 28);
            LogList.Name = "LogList";
            LogList.Size = new Size(552, 390);
            LogList.TabIndex = 0;
            LogList.UseCompatibleStateImageBehavior = false;
            LogList.View = View.Details;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "ログID";
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "操作ユーザー";
            columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "対象ユーザー";
            columnHeader10.Width = 120;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "操作内容";
            columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "操作日時";
            columnHeader12.Width = 100;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 524);
            Controls.Add(MainFormTab);
            Name = "MainForm";
            Text = "スケジュール帳";
            MainFormTab.ResumeLayout(false);
            ScheduleTab.ResumeLayout(false);
            ScheduleTab.PerformLayout();
            UserListTab.ResumeLayout(false);
            UserListTab.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            LogListTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox YearComboBox;
        private ComboBox MonthComboBox;
        private ComboBox DayComboBox;
        private TabControl MainFormTab;
        private TabPage ScheduleTab;
        private TabPage UserListTab;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private LinkLabel UserName;
        private Button RestoreButton;
        private Button ClearButton;
        private Button ScheduleDeleteButton;
        private Button ScheduleAddButton;
        private ListView ScheduleList;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private TextBox ScheduleTextBox;
        private LinkLabel LoginUser;
        private Label label7;
        private ListView UserList;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Label label8;
        private GroupBox groupBox2;
        private Button UserEditButton;
        private Button NewUserAddButton;
        private GroupBox groupBox1;
        private Button ScheduleEditButton;
        private Label ScheduleEditName;
        private TabPage LogListTab;
        private ListView LogList;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
    }
}