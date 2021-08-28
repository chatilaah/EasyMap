
namespace EasyMap.Gui
{
    partial class FrmConfig
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInsertQuery = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeleteQuery = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUpdateQuery = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtConnString = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(334, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 27);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server Name";
            // 
            // txtServerName
            // 
            this.txtServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerName.Location = new System.Drawing.Point(116, 12);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.ReadOnly = true;
            this.txtServerName.Size = new System.Drawing.Size(298, 23);
            this.txtServerName.TabIndex = 10;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(116, 70);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(298, 23);
            this.txtUsername.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(116, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(298, 23);
            this.txtPassword.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Password";
            // 
            // txtTable
            // 
            this.txtTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTable.Location = new System.Drawing.Point(116, 41);
            this.txtTable.Name = "txtTable";
            this.txtTable.ReadOnly = true;
            this.txtTable.Size = new System.Drawing.Size(298, 23);
            this.txtTable.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Table";
            // 
            // txtInsertQuery
            // 
            this.txtInsertQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInsertQuery.Location = new System.Drawing.Point(116, 157);
            this.txtInsertQuery.Multiline = true;
            this.txtInsertQuery.Name = "txtInsertQuery";
            this.txtInsertQuery.ReadOnly = true;
            this.txtInsertQuery.Size = new System.Drawing.Size(298, 68);
            this.txtInsertQuery.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "INSERT Query";
            // 
            // txtDeleteQuery
            // 
            this.txtDeleteQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeleteQuery.Location = new System.Drawing.Point(116, 231);
            this.txtDeleteQuery.Multiline = true;
            this.txtDeleteQuery.Name = "txtDeleteQuery";
            this.txtDeleteQuery.ReadOnly = true;
            this.txtDeleteQuery.Size = new System.Drawing.Size(298, 68);
            this.txtDeleteQuery.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "DELETE Query";
            // 
            // txtUpdateQuery
            // 
            this.txtUpdateQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdateQuery.Location = new System.Drawing.Point(116, 305);
            this.txtUpdateQuery.Multiline = true;
            this.txtUpdateQuery.Name = "txtUpdateQuery";
            this.txtUpdateQuery.ReadOnly = true;
            this.txtUpdateQuery.Size = new System.Drawing.Size(298, 68);
            this.txtUpdateQuery.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "UPDATE Query";
            // 
            // txtConnString
            // 
            this.txtConnString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnString.Location = new System.Drawing.Point(116, 128);
            this.txtConnString.Name = "txtConnString";
            this.txtConnString.ReadOnly = true;
            this.txtConnString.Size = new System.Drawing.Size(298, 23);
            this.txtConnString.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 15);
            this.label8.TabIndex = 23;
            this.label8.Text = "Conn. String";
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(426, 436);
            this.Controls.Add(this.txtConnString);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUpdateQuery);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDeleteQuery);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtInsertQuery);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config Properties";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInsertQuery;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeleteQuery;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUpdateQuery;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtConnString;
        private System.Windows.Forms.Label label8;
    }
}

