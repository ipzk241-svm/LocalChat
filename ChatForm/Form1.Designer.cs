namespace ChatForm
{
    partial class Form1
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
			this.ChatBox = new System.Windows.Forms.TextBox();
			this.UsernameBox = new System.Windows.Forms.TextBox();
			this.MessageBox = new System.Windows.Forms.TextBox();
			this.OnlineUsers = new System.Windows.Forms.ListBox();
			this.ConnectButton = new System.Windows.Forms.Button();
			this.SendButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.DisconnectButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ChatBox
			// 
			this.ChatBox.BackColor = System.Drawing.Color.Gray;
			this.ChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ChatBox.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.ChatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ChatBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.ChatBox.Location = new System.Drawing.Point(190, 53);
			this.ChatBox.Margin = new System.Windows.Forms.Padding(2);
			this.ChatBox.Multiline = true;
			this.ChatBox.Name = "ChatBox";
			this.ChatBox.ReadOnly = true;
			this.ChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ChatBox.Size = new System.Drawing.Size(492, 251);
			this.ChatBox.TabIndex = 0;
			// 
			// UsernameBox
			// 
			this.UsernameBox.BackColor = System.Drawing.Color.Silver;
			this.UsernameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.UsernameBox.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.UsernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.UsernameBox.Location = new System.Drawing.Point(192, 7);
			this.UsernameBox.Margin = new System.Windows.Forms.Padding(2);
			this.UsernameBox.Name = "UsernameBox";
			this.UsernameBox.Size = new System.Drawing.Size(187, 30);
			this.UsernameBox.TabIndex = 1;
			// 
			// MessageBox
			// 
			this.MessageBox.BackColor = System.Drawing.Color.Silver;
			this.MessageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MessageBox.Enabled = false;
			this.MessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MessageBox.Location = new System.Drawing.Point(192, 315);
			this.MessageBox.Margin = new System.Windows.Forms.Padding(2);
			this.MessageBox.Name = "MessageBox";
			this.MessageBox.Size = new System.Drawing.Size(406, 30);
			this.MessageBox.TabIndex = 4;
			// 
			// OnlineUsers
			// 
			this.OnlineUsers.BackColor = System.Drawing.Color.Gray;
			this.OnlineUsers.Enabled = false;
			this.OnlineUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.OnlineUsers.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.OnlineUsers.FormattingEnabled = true;
			this.OnlineUsers.ItemHeight = 25;
			this.OnlineUsers.Location = new System.Drawing.Point(6, 53);
			this.OnlineUsers.Margin = new System.Windows.Forms.Padding(2);
			this.OnlineUsers.Name = "OnlineUsers";
			this.OnlineUsers.Size = new System.Drawing.Size(180, 254);
			this.OnlineUsers.TabIndex = 4;
			this.OnlineUsers.SelectedIndexChanged += new System.EventHandler(this.OnlineUsers_SelectedIndexChanged);
			// 
			// ConnectButton
			// 
			this.ConnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ConnectButton.Location = new System.Drawing.Point(382, 6);
			this.ConnectButton.Margin = new System.Windows.Forms.Padding(2);
			this.ConnectButton.Name = "ConnectButton";
			this.ConnectButton.Size = new System.Drawing.Size(100, 30);
			this.ConnectButton.TabIndex = 5;
			this.ConnectButton.Text = "Connect";
			this.ConnectButton.UseVisualStyleBackColor = false;
			this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
			// 
			// SendButton
			// 
			this.SendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.SendButton.BackgroundImage = global::ChatForm.Properties.Resources.send_message;
			this.SendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.SendButton.Enabled = false;
			this.SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SendButton.Location = new System.Drawing.Point(602, 315);
			this.SendButton.Margin = new System.Windows.Forms.Padding(2);
			this.SendButton.Name = "SendButton";
			this.SendButton.Size = new System.Drawing.Size(77, 28);
			this.SendButton.TabIndex = 6;
			this.SendButton.UseVisualStyleBackColor = false;
			this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.label1.Location = new System.Drawing.Point(11, 7);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 29);
			this.label1.TabIndex = 7;
			this.label1.Text = "Online Users";
			// 
			// DisconnectButton
			// 
			this.DisconnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.DisconnectButton.Enabled = false;
			this.DisconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DisconnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DisconnectButton.Location = new System.Drawing.Point(486, 6);
			this.DisconnectButton.Margin = new System.Windows.Forms.Padding(2);
			this.DisconnectButton.Name = "DisconnectButton";
			this.DisconnectButton.Size = new System.Drawing.Size(105, 30);
			this.DisconnectButton.TabIndex = 8;
			this.DisconnectButton.Text = "Disonnect";
			this.DisconnectButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.DisconnectButton.UseVisualStyleBackColor = false;
			this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(690, 357);
			this.Controls.Add(this.DisconnectButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.SendButton);
			this.Controls.Add(this.ConnectButton);
			this.Controls.Add(this.OnlineUsers);
			this.Controls.Add(this.MessageBox);
			this.Controls.Add(this.UsernameBox);
			this.Controls.Add(this.ChatBox);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximumSize = new System.Drawing.Size(708, 404);
			this.MinimumSize = new System.Drawing.Size(708, 404);
			this.Name = "Form1";
			this.Text = "Chat";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.ListBox OnlineUsers;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button DisconnectButton;
	}
}

