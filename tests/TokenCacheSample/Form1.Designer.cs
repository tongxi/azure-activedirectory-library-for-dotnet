namespace TokenCacheSample
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
            this.createContextButton = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.RichTextBox();
            this.acquireTokenForUser1Button = new System.Windows.Forms.Button();
            this.enumerateCacheItemsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.persistedInstanceCacheRadioButton = new System.Windows.Forms.RadioButton();
            this.noCacheRadioButton = new System.Windows.Forms.RadioButton();
            this.emptyInstanceCacheButton = new System.Windows.Forms.RadioButton();
            this.defaultStaticCacheRadioButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.user2RadioButton = new System.Windows.Forms.RadioButton();
            this.user1RadioButton = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.resource1radioButton = new System.Windows.Forms.RadioButton();
            this.resource2RadioButton = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.user2RadioButton2 = new System.Windows.Forms.RadioButton();
            this.user1RadioButton2 = new System.Windows.Forms.RadioButton();
            this.removeTokensForUserButton = new System.Windows.Forms.Button();
            this.removeTokensForResourceButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.resource2RadioButton2 = new System.Windows.Forms.RadioButton();
            this.resource1RadioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // createContextButton
            // 
            this.createContextButton.Location = new System.Drawing.Point(626, 15);
            this.createContextButton.Name = "createContextButton";
            this.createContextButton.Size = new System.Drawing.Size(130, 23);
            this.createContextButton.TabIndex = 0;
            this.createContextButton.Text = "Create Context";
            this.createContextButton.UseVisualStyleBackColor = true;
            this.createContextButton.Click += new System.EventHandler(this.CreateContextBbutton_Click);
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(18, 130);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(1104, 626);
            this.statusBox.TabIndex = 1;
            this.statusBox.Text = "";
            // 
            // acquireTokenForUser1Button
            // 
            this.acquireTokenForUser1Button.Location = new System.Drawing.Point(219, 72);
            this.acquireTokenForUser1Button.Name = "acquireTokenForUser1Button";
            this.acquireTokenForUser1Button.Size = new System.Drawing.Size(137, 23);
            this.acquireTokenForUser1Button.TabIndex = 2;
            this.acquireTokenForUser1Button.Text = "Acquire Token For User";
            this.acquireTokenForUser1Button.UseVisualStyleBackColor = true;
            this.acquireTokenForUser1Button.Click += new System.EventHandler(this.AcquireTokenForUserButton_Click);
            // 
            // enumerateCacheItemsButton
            // 
            this.enumerateCacheItemsButton.Location = new System.Drawing.Point(985, 15);
            this.enumerateCacheItemsButton.Name = "enumerateCacheItemsButton";
            this.enumerateCacheItemsButton.Size = new System.Drawing.Size(137, 23);
            this.enumerateCacheItemsButton.TabIndex = 4;
            this.enumerateCacheItemsButton.Text = "Enumerate Cache Items";
            this.enumerateCacheItemsButton.UseVisualStyleBackColor = true;
            this.enumerateCacheItemsButton.Click += new System.EventHandler(this.enumerateCacheItemsButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.persistedInstanceCacheRadioButton);
            this.panel1.Controls.Add(this.noCacheRadioButton);
            this.panel1.Controls.Add(this.emptyInstanceCacheButton);
            this.panel1.Controls.Add(this.defaultStaticCacheRadioButton);
            this.panel1.Location = new System.Drawing.Point(18, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 23);
            this.panel1.TabIndex = 5;
            // 
            // persistedInstanceCacheRadioButton
            // 
            this.persistedInstanceCacheRadioButton.AutoSize = true;
            this.persistedInstanceCacheRadioButton.Location = new System.Drawing.Point(322, 3);
            this.persistedInstanceCacheRadioButton.Name = "persistedInstanceCacheRadioButton";
            this.persistedInstanceCacheRadioButton.Size = new System.Drawing.Size(146, 17);
            this.persistedInstanceCacheRadioButton.TabIndex = 3;
            this.persistedInstanceCacheRadioButton.Text = "Persisted Instance Cache";
            this.persistedInstanceCacheRadioButton.UseVisualStyleBackColor = true;
            // 
            // noCacheRadioButton
            // 
            this.noCacheRadioButton.AutoSize = true;
            this.noCacheRadioButton.Location = new System.Drawing.Point(496, 3);
            this.noCacheRadioButton.Name = "noCacheRadioButton";
            this.noCacheRadioButton.Size = new System.Drawing.Size(73, 17);
            this.noCacheRadioButton.TabIndex = 2;
            this.noCacheRadioButton.Text = "No Cache";
            this.noCacheRadioButton.UseVisualStyleBackColor = true;
            // 
            // emptyInstanceCacheButton
            // 
            this.emptyInstanceCacheButton.AutoSize = true;
            this.emptyInstanceCacheButton.Location = new System.Drawing.Point(163, 3);
            this.emptyInstanceCacheButton.Name = "emptyInstanceCacheButton";
            this.emptyInstanceCacheButton.Size = new System.Drawing.Size(135, 17);
            this.emptyInstanceCacheButton.TabIndex = 1;
            this.emptyInstanceCacheButton.Text = "Emprty Instance Cache";
            this.emptyInstanceCacheButton.UseVisualStyleBackColor = true;
            // 
            // defaultStaticCacheRadioButton
            // 
            this.defaultStaticCacheRadioButton.AutoSize = true;
            this.defaultStaticCacheRadioButton.Checked = true;
            this.defaultStaticCacheRadioButton.Location = new System.Drawing.Point(14, 3);
            this.defaultStaticCacheRadioButton.Name = "defaultStaticCacheRadioButton";
            this.defaultStaticCacheRadioButton.Size = new System.Drawing.Size(123, 17);
            this.defaultStaticCacheRadioButton.TabIndex = 0;
            this.defaultStaticCacheRadioButton.TabStop = true;
            this.defaultStaticCacheRadioButton.Text = "Default Static Cache";
            this.defaultStaticCacheRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.user2RadioButton);
            this.panel2.Controls.Add(this.user1RadioButton);
            this.panel2.Location = new System.Drawing.Point(21, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(80, 50);
            this.panel2.TabIndex = 6;
            // 
            // user2RadioButton
            // 
            this.user2RadioButton.AutoSize = true;
            this.user2RadioButton.Location = new System.Drawing.Point(11, 26);
            this.user2RadioButton.Name = "user2RadioButton";
            this.user2RadioButton.Size = new System.Drawing.Size(56, 17);
            this.user2RadioButton.TabIndex = 1;
            this.user2RadioButton.Text = "User 2";
            this.user2RadioButton.UseVisualStyleBackColor = true;
            // 
            // user1RadioButton
            // 
            this.user1RadioButton.AutoSize = true;
            this.user1RadioButton.Checked = true;
            this.user1RadioButton.Location = new System.Drawing.Point(11, 3);
            this.user1RadioButton.Name = "user1RadioButton";
            this.user1RadioButton.Size = new System.Drawing.Size(56, 17);
            this.user1RadioButton.TabIndex = 0;
            this.user1RadioButton.TabStop = true;
            this.user1RadioButton.Text = "User 1";
            this.user1RadioButton.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.resource1radioButton);
            this.panel3.Controls.Add(this.resource2RadioButton);
            this.panel3.Location = new System.Drawing.Point(113, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(90, 50);
            this.panel3.TabIndex = 7;
            // 
            // resource1radioButton
            // 
            this.resource1radioButton.AutoSize = true;
            this.resource1radioButton.Checked = true;
            this.resource1radioButton.Location = new System.Drawing.Point(6, 2);
            this.resource1radioButton.Name = "resource1radioButton";
            this.resource1radioButton.Size = new System.Drawing.Size(80, 17);
            this.resource1radioButton.TabIndex = 2;
            this.resource1radioButton.TabStop = true;
            this.resource1radioButton.Text = "Resource 1";
            this.resource1radioButton.UseVisualStyleBackColor = true;
            // 
            // resource2RadioButton
            // 
            this.resource2RadioButton.AutoSize = true;
            this.resource2RadioButton.Location = new System.Drawing.Point(6, 27);
            this.resource2RadioButton.Name = "resource2RadioButton";
            this.resource2RadioButton.Size = new System.Drawing.Size(80, 17);
            this.resource2RadioButton.TabIndex = 3;
            this.resource2RadioButton.Text = "Resource 2";
            this.resource2RadioButton.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.user2RadioButton2);
            this.panel4.Controls.Add(this.user1RadioButton2);
            this.panel4.Location = new System.Drawing.Point(392, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(80, 50);
            this.panel4.TabIndex = 7;
            // 
            // user2RadioButton2
            // 
            this.user2RadioButton2.AutoSize = true;
            this.user2RadioButton2.Location = new System.Drawing.Point(11, 26);
            this.user2RadioButton2.Name = "user2RadioButton2";
            this.user2RadioButton2.Size = new System.Drawing.Size(56, 17);
            this.user2RadioButton2.TabIndex = 1;
            this.user2RadioButton2.Text = "User 2";
            this.user2RadioButton2.UseVisualStyleBackColor = true;
            // 
            // user1RadioButton2
            // 
            this.user1RadioButton2.AutoSize = true;
            this.user1RadioButton2.Checked = true;
            this.user1RadioButton2.Location = new System.Drawing.Point(11, 3);
            this.user1RadioButton2.Name = "user1RadioButton2";
            this.user1RadioButton2.Size = new System.Drawing.Size(56, 17);
            this.user1RadioButton2.TabIndex = 0;
            this.user1RadioButton2.TabStop = true;
            this.user1RadioButton2.Text = "User 1";
            this.user1RadioButton2.UseVisualStyleBackColor = true;
            // 
            // removeTokensForUserButton
            // 
            this.removeTokensForUserButton.Location = new System.Drawing.Point(489, 72);
            this.removeTokensForUserButton.Name = "removeTokensForUserButton";
            this.removeTokensForUserButton.Size = new System.Drawing.Size(137, 23);
            this.removeTokensForUserButton.TabIndex = 8;
            this.removeTokensForUserButton.Text = "Remove Tokens For User";
            this.removeTokensForUserButton.UseVisualStyleBackColor = true;
            this.removeTokensForUserButton.Click += new System.EventHandler(this.removeTokensForUserbutton_Click);
            // 
            // removeTokensForResourceButton
            // 
            this.removeTokensForResourceButton.Location = new System.Drawing.Point(776, 72);
            this.removeTokensForResourceButton.Name = "removeTokensForResourceButton";
            this.removeTokensForResourceButton.Size = new System.Drawing.Size(167, 23);
            this.removeTokensForResourceButton.TabIndex = 10;
            this.removeTokensForResourceButton.Text = "Remove Tokens For Resource";
            this.removeTokensForResourceButton.UseVisualStyleBackColor = true;
            this.removeTokensForResourceButton.Click += new System.EventHandler(this.removeTokensForResourceButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.resource2RadioButton2);
            this.panel5.Controls.Add(this.resource1RadioButton2);
            this.panel5.Location = new System.Drawing.Point(663, 58);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(107, 50);
            this.panel5.TabIndex = 9;
            // 
            // resource2RadioButton2
            // 
            this.resource2RadioButton2.AutoSize = true;
            this.resource2RadioButton2.Location = new System.Drawing.Point(11, 26);
            this.resource2RadioButton2.Name = "resource2RadioButton2";
            this.resource2RadioButton2.Size = new System.Drawing.Size(80, 17);
            this.resource2RadioButton2.TabIndex = 1;
            this.resource2RadioButton2.Text = "Resource 2";
            this.resource2RadioButton2.UseVisualStyleBackColor = true;
            // 
            // resource1RadioButton2
            // 
            this.resource1RadioButton2.AutoSize = true;
            this.resource1RadioButton2.Checked = true;
            this.resource1RadioButton2.Location = new System.Drawing.Point(11, 3);
            this.resource1RadioButton2.Name = "resource1RadioButton2";
            this.resource1RadioButton2.Size = new System.Drawing.Size(80, 17);
            this.resource1RadioButton2.TabIndex = 0;
            this.resource1RadioButton2.TabStop = true;
            this.resource1RadioButton2.Text = "Resource 1";
            this.resource1RadioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 776);
            this.Controls.Add(this.removeTokensForResourceButton);
            this.Controls.Add(this.removeTokensForUserButton);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.enumerateCacheItemsButton);
            this.Controls.Add(this.acquireTokenForUser1Button);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.createContextButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createContextButton;
        private System.Windows.Forms.RichTextBox statusBox;
        private System.Windows.Forms.Button acquireTokenForUser1Button;
        private System.Windows.Forms.Button enumerateCacheItemsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton emptyInstanceCacheButton;
        private System.Windows.Forms.RadioButton defaultStaticCacheRadioButton;
        private System.Windows.Forms.RadioButton noCacheRadioButton;
        private System.Windows.Forms.RadioButton persistedInstanceCacheRadioButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton user2RadioButton;
        private System.Windows.Forms.RadioButton user1RadioButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton resource1radioButton;
        private System.Windows.Forms.RadioButton resource2RadioButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton user2RadioButton2;
        private System.Windows.Forms.RadioButton user1RadioButton2;
        private System.Windows.Forms.Button removeTokensForUserButton;
        private System.Windows.Forms.Button removeTokensForResourceButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton resource2RadioButton2;
        private System.Windows.Forms.RadioButton resource1RadioButton2;
    }
}

