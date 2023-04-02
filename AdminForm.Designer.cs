namespace Halcyon
{
    partial class AdminForm
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonMaximize = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.panelMoving = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panelProfile = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.labelRole = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelChangePassword = new System.Windows.Forms.Panel();
            this.buttonShowPassword = new System.Windows.Forms.Button();
            this.textBoxOldPassword = new System.Windows.Forms.TextBox();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.buttonCancelChange = new System.Windows.Forms.Button();
            this.buttonFinishChange = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonManageWorks = new System.Windows.Forms.Button();
            this.buttonManageContracts = new System.Windows.Forms.Button();
            this.buttonManageEmployees = new System.Windows.Forms.Button();
            this.buttonManageUsers = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonEditRecord = new System.Windows.Forms.Button();
            this.buttonRemoveRecord = new System.Windows.Forms.Button();
            this.buttonAddRecord = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panelMoving.SuspendLayout();
            this.panelProfile.SuspendLayout();
            this.panelChangePassword.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonMaximize);
            this.panel4.Controls.Add(this.buttonClose);
            this.panel4.Controls.Add(this.buttonMinimize);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1003, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(87, 38);
            this.panel4.TabIndex = 11;
            // 
            // buttonMaximize
            // 
            this.buttonMaximize.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMaximize.FlatAppearance.BorderSize = 0;
            this.buttonMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaximize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.buttonMaximize.Location = new System.Drawing.Point(26, 0);
            this.buttonMaximize.Name = "buttonMaximize";
            this.buttonMaximize.Size = new System.Drawing.Size(16, 38);
            this.buttonMaximize.TabIndex = 11;
            this.buttonMaximize.Text = "□";
            this.buttonMaximize.UseVisualStyleBackColor = false;
            this.buttonMaximize.Click += new System.EventHandler(this.buttonMaximize_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.buttonClose.Location = new System.Drawing.Point(48, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(16, 35);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.buttonMinimize.Location = new System.Drawing.Point(4, 3);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(16, 35);
            this.buttonMinimize.TabIndex = 10;
            this.buttonMinimize.Text = "‒";
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // panelMoving
            // 
            this.panelMoving.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMoving.Controls.Add(this.label5);
            this.panelMoving.Controls.Add(this.panel4);
            this.panelMoving.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMoving.Location = new System.Drawing.Point(0, 0);
            this.panelMoving.Name = "panelMoving";
            this.panelMoving.Size = new System.Drawing.Size(1090, 38);
            this.panelMoving.TabIndex = 1;
            this.panelMoving.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMoving_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(35, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // panelProfile
            // 
            this.panelProfile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelProfile.Controls.Add(this.buttonLogout);
            this.panelProfile.Controls.Add(this.buttonChangePassword);
            this.panelProfile.Controls.Add(this.labelRole);
            this.panelProfile.Controls.Add(this.labelUsername);
            this.panelProfile.Controls.Add(this.label3);
            this.panelProfile.Controls.Add(this.label2);
            this.panelProfile.Controls.Add(this.label1);
            this.panelProfile.Location = new System.Drawing.Point(0, 0);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(205, 137);
            this.panelProfile.TabIndex = 2;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(155, 11);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(28, 23);
            this.buttonLogout.TabIndex = 6;
            this.buttonLogout.Text = "🚪";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Location = new System.Drawing.Point(13, 97);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(170, 23);
            this.buttonChangePassword.TabIndex = 5;
            this.buttonChangePassword.Text = "Change password";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(79, 68);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(29, 15);
            this.labelRole.TabIndex = 4;
            this.labelRole.Text = "user";
            this.labelRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(79, 42);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(70, 15);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "anonymous";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Role:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(79, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelChangePassword
            // 
            this.panelChangePassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelChangePassword.Controls.Add(this.panelProfile);
            this.panelChangePassword.Controls.Add(this.buttonShowPassword);
            this.panelChangePassword.Controls.Add(this.textBoxOldPassword);
            this.panelChangePassword.Controls.Add(this.textBoxNewPassword);
            this.panelChangePassword.Controls.Add(this.buttonCancelChange);
            this.panelChangePassword.Controls.Add(this.buttonFinishChange);
            this.panelChangePassword.Controls.Add(this.label11);
            this.panelChangePassword.Location = new System.Drawing.Point(862, 60);
            this.panelChangePassword.Name = "panelChangePassword";
            this.panelChangePassword.Size = new System.Drawing.Size(205, 137);
            this.panelChangePassword.TabIndex = 9;
            // 
            // buttonShowPassword
            // 
            this.buttonShowPassword.Location = new System.Drawing.Point(41, 102);
            this.buttonShowPassword.Name = "buttonShowPassword";
            this.buttonShowPassword.Size = new System.Drawing.Size(20, 23);
            this.buttonShowPassword.TabIndex = 9;
            this.buttonShowPassword.Text = "👁️";
            this.buttonShowPassword.UseVisualStyleBackColor = true;
            this.buttonShowPassword.Click += new System.EventHandler(this.buttonShowPassword_Click);
            // 
            // textBoxOldPassword
            // 
            this.textBoxOldPassword.Location = new System.Drawing.Point(13, 71);
            this.textBoxOldPassword.Name = "textBoxOldPassword";
            this.textBoxOldPassword.PasswordChar = '●';
            this.textBoxOldPassword.PlaceholderText = "Old password...";
            this.textBoxOldPassword.Size = new System.Drawing.Size(170, 23);
            this.textBoxOldPassword.TabIndex = 8;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(13, 42);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '●';
            this.textBoxNewPassword.PlaceholderText = "New password...";
            this.textBoxNewPassword.Size = new System.Drawing.Size(170, 23);
            this.textBoxNewPassword.TabIndex = 7;
            // 
            // buttonCancelChange
            // 
            this.buttonCancelChange.Location = new System.Drawing.Point(67, 102);
            this.buttonCancelChange.Name = "buttonCancelChange";
            this.buttonCancelChange.Size = new System.Drawing.Size(64, 23);
            this.buttonCancelChange.TabIndex = 6;
            this.buttonCancelChange.Text = "Cancel";
            this.buttonCancelChange.UseVisualStyleBackColor = true;
            this.buttonCancelChange.Click += new System.EventHandler(this.buttonCancelChange_Click);
            // 
            // buttonFinishChange
            // 
            this.buttonFinishChange.Location = new System.Drawing.Point(137, 102);
            this.buttonFinishChange.Name = "buttonFinishChange";
            this.buttonFinishChange.Size = new System.Drawing.Size(46, 23);
            this.buttonFinishChange.TabIndex = 5;
            this.buttonFinishChange.Text = "OK";
            this.buttonFinishChange.UseVisualStyleBackColor = true;
            this.buttonFinishChange.Click += new System.EventHandler(this.buttonFinishChange_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(46, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Change Password";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.buttonManageWorks);
            this.panel2.Controls.Add(this.buttonManageContracts);
            this.panel2.Controls.Add(this.buttonManageEmployees);
            this.panel2.Controls.Add(this.buttonManageUsers);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(862, 203);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 162);
            this.panel2.TabIndex = 3;
            // 
            // buttonManageWorks
            // 
            this.buttonManageWorks.Location = new System.Drawing.Point(13, 131);
            this.buttonManageWorks.Name = "buttonManageWorks";
            this.buttonManageWorks.Size = new System.Drawing.Size(170, 23);
            this.buttonManageWorks.TabIndex = 8;
            this.buttonManageWorks.Text = "Manage work";
            this.buttonManageWorks.UseVisualStyleBackColor = true;
            this.buttonManageWorks.Click += new System.EventHandler(this.buttonManageWorks_Click);
            // 
            // buttonManageContracts
            // 
            this.buttonManageContracts.Location = new System.Drawing.Point(13, 102);
            this.buttonManageContracts.Name = "buttonManageContracts";
            this.buttonManageContracts.Size = new System.Drawing.Size(170, 23);
            this.buttonManageContracts.TabIndex = 7;
            this.buttonManageContracts.Text = "Manage contracts";
            this.buttonManageContracts.UseVisualStyleBackColor = true;
            this.buttonManageContracts.Click += new System.EventHandler(this.buttonManageContracts_Click);
            // 
            // buttonManageEmployees
            // 
            this.buttonManageEmployees.Location = new System.Drawing.Point(13, 73);
            this.buttonManageEmployees.Name = "buttonManageEmployees";
            this.buttonManageEmployees.Size = new System.Drawing.Size(170, 23);
            this.buttonManageEmployees.TabIndex = 6;
            this.buttonManageEmployees.Text = "Manage employees";
            this.buttonManageEmployees.UseVisualStyleBackColor = true;
            this.buttonManageEmployees.Click += new System.EventHandler(this.buttonManageEmployees_Click);
            // 
            // buttonManageUsers
            // 
            this.buttonManageUsers.Location = new System.Drawing.Point(13, 44);
            this.buttonManageUsers.Name = "buttonManageUsers";
            this.buttonManageUsers.Size = new System.Drawing.Size(170, 23);
            this.buttonManageUsers.TabIndex = 5;
            this.buttonManageUsers.Text = "Manage users";
            this.buttonManageUsers.UseVisualStyleBackColor = true;
            this.buttonManageUsers.Click += new System.EventHandler(this.buttonManageUsers_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(63, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Admin Panel";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(35, 60);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(812, 550);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // panelEdit
            // 
            this.panelEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelEdit.Controls.Add(this.buttonDownload);
            this.panelEdit.Controls.Add(this.buttonEditRecord);
            this.panelEdit.Controls.Add(this.buttonRemoveRecord);
            this.panelEdit.Controls.Add(this.buttonAddRecord);
            this.panelEdit.Controls.Add(this.label4);
            this.panelEdit.Location = new System.Drawing.Point(862, 371);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(205, 239);
            this.panelEdit.TabIndex = 8;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(13, 131);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(170, 23);
            this.buttonDownload.TabIndex = 8;
            this.buttonDownload.Text = "Download CSV";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonEditRecord
            // 
            this.buttonEditRecord.Location = new System.Drawing.Point(13, 102);
            this.buttonEditRecord.Name = "buttonEditRecord";
            this.buttonEditRecord.Size = new System.Drawing.Size(170, 23);
            this.buttonEditRecord.TabIndex = 7;
            this.buttonEditRecord.Text = "Edit record";
            this.buttonEditRecord.UseVisualStyleBackColor = true;
            this.buttonEditRecord.Click += new System.EventHandler(this.buttonEditRecord_Click);
            // 
            // buttonRemoveRecord
            // 
            this.buttonRemoveRecord.Location = new System.Drawing.Point(13, 73);
            this.buttonRemoveRecord.Name = "buttonRemoveRecord";
            this.buttonRemoveRecord.Size = new System.Drawing.Size(170, 23);
            this.buttonRemoveRecord.TabIndex = 6;
            this.buttonRemoveRecord.Text = "Remove record";
            this.buttonRemoveRecord.UseVisualStyleBackColor = true;
            this.buttonRemoveRecord.Click += new System.EventHandler(this.buttonRemoveRecord_Click);
            // 
            // buttonAddRecord
            // 
            this.buttonAddRecord.Location = new System.Drawing.Point(13, 44);
            this.buttonAddRecord.Name = "buttonAddRecord";
            this.buttonAddRecord.Size = new System.Drawing.Size(170, 23);
            this.buttonAddRecord.TabIndex = 5;
            this.buttonAddRecord.Text = "Add record";
            this.buttonAddRecord.UseVisualStyleBackColor = true;
            this.buttonAddRecord.Click += new System.EventHandler(this.buttonAddRecord_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(58, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Records Edit";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1090, 641);
            this.Controls.Add(this.panelChangePassword);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelMoving);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminForm";
            this.Text = "MainForm";
            this.panel4.ResumeLayout(false);
            this.panelMoving.ResumeLayout(false);
            this.panelMoving.PerformLayout();
            this.panelProfile.ResumeLayout(false);
            this.panelProfile.PerformLayout();
            this.panelChangePassword.ResumeLayout(false);
            this.panelChangePassword.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel4;
        private Button buttonMaximize;
        private Button buttonClose;
        private Button buttonMinimize;
        private Panel panelMoving;
        private Panel panelProfile;
        private Button buttonChangePassword;
        private Label labelRole;
        private Label labelUsername;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Button buttonManageEmployees;
        private Button buttonManageUsers;
        private Label label8;
        private Button buttonManageContracts;
        private ListView listView;
        private Panel panelEdit;
        private Button buttonEditRecord;
        private Button buttonRemoveRecord;
        private Button buttonAddRecord;
        private Label label4;
        private Label label5;
        private Panel panelChangePassword;
        private Button buttonShowPassword;
        private TextBox textBoxOldPassword;
        private TextBox textBoxNewPassword;
        private Button buttonCancelChange;
        private Button buttonFinishChange;
        private Label label11;
        private Button buttonLogout;
        private Button buttonManageWorks;
        private Button buttonDownload;
    }
}