namespace card_game.UI.Shared
{
    partial class FM_Config
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
            LB_Logged = new Label();
            BT_Logoff = new Button();
            BT_Delete = new Button();
            SuspendLayout();
            // 
            // LB_Logged
            // 
            LB_Logged.AutoSize = true;
            LB_Logged.Font = new Font("Segoe UI", 14F);
            LB_Logged.Location = new Point(12, 9);
            LB_Logged.Name = "LB_Logged";
            LB_Logged.Size = new Size(101, 25);
            LB_Logged.TabIndex = 0;
            LB_Logged.Text = "Logged in ";
            // 
            // BT_Logoff
            // 
            BT_Logoff.Location = new Point(12, 60);
            BT_Logoff.Name = "BT_Logoff";
            BT_Logoff.Size = new Size(75, 23);
            BT_Logoff.TabIndex = 1;
            BT_Logoff.Text = "Logoff";
            BT_Logoff.UseVisualStyleBackColor = true;
            BT_Logoff.Click += BT_Logoff_Click;
            // 
            // BT_Delete
            // 
            BT_Delete.Location = new Point(12, 101);
            BT_Delete.Name = "BT_Delete";
            BT_Delete.Size = new Size(101, 23);
            BT_Delete.TabIndex = 2;
            BT_Delete.Text = "Delete Account";
            BT_Delete.UseVisualStyleBackColor = true;
            BT_Delete.Click += BT_Delete_Click;
            // 
            // FM_Config
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 152);
            Controls.Add(BT_Delete);
            Controls.Add(BT_Logoff);
            Controls.Add(LB_Logged);
            Name = "FM_Config";
            Text = "FM_Config";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LB_Logged;
        private Button BT_Logoff;
        private Button BT_Delete;
    }
}