namespace card_game
{
    partial class FM_MainScreen
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
            LB_name = new Label();
            groupBox1 = new GroupBox();
            BT_Logoff = new Button();
            groupBox2 = new GroupBox();
            BT_Deck = new Button();
            BT_Play = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // LB_name
            // 
            LB_name.AutoSize = true;
            LB_name.Location = new Point(6, 19);
            LB_name.Name = "LB_name";
            LB_name.Size = new Size(55, 15);
            LB_name.TabIndex = 0;
            LB_name.Text = "LB_name";
            LB_name.Click += LB_name_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BT_Logoff);
            groupBox1.Controls.Add(LB_name);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(584, 45);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // BT_Logoff
            // 
            BT_Logoff.Location = new Point(497, 16);
            BT_Logoff.Name = "BT_Logoff";
            BT_Logoff.Size = new Size(75, 23);
            BT_Logoff.TabIndex = 6;
            BT_Logoff.Text = "Logoff";
            BT_Logoff.UseVisualStyleBackColor = true;
            BT_Logoff.Click += BT_Logoff_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BT_Deck);
            groupBox2.Controls.Add(BT_Play);
            groupBox2.Location = new Point(12, 63);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(584, 234);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            // 
            // BT_Deck
            // 
            BT_Deck.BackgroundImage = Properties.Resources.Deck_img;
            BT_Deck.BackgroundImageLayout = ImageLayout.Stretch;
            BT_Deck.FlatStyle = FlatStyle.Flat;
            BT_Deck.Font = new Font("Times New Roman", 33.75F, FontStyle.Bold);
            BT_Deck.ForeColor = Color.Cyan;
            BT_Deck.Location = new Point(298, 22);
            BT_Deck.Name = "BT_Deck";
            BT_Deck.Size = new Size(280, 206);
            BT_Deck.TabIndex = 1;
            BT_Deck.Text = "Build your deck";
            BT_Deck.UseVisualStyleBackColor = true;
            BT_Deck.Click += BT_Deck_Click;
            // 
            // BT_Play
            // 
            BT_Play.BackgroundImage = Properties.Resources.play_img;
            BT_Play.BackgroundImageLayout = ImageLayout.Stretch;
            BT_Play.FlatStyle = FlatStyle.Flat;
            BT_Play.Font = new Font("Times New Roman", 33.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BT_Play.ForeColor = Color.Gold;
            BT_Play.Location = new Point(6, 22);
            BT_Play.Name = "BT_Play";
            BT_Play.Size = new Size(277, 206);
            BT_Play.TabIndex = 0;
            BT_Play.Text = "Play";
            BT_Play.UseVisualStyleBackColor = true;
            // 
            // FM_MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(604, 308);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FM_MainScreen";
            Text = "FM_MainScreen";
            Load += FM_MainScreen_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label LB_name;
        private GroupBox groupBox1;
        private Button BT_Logoff;
        private GroupBox groupBox2;
        private Button BT_Deck;
        private Button BT_Play;
    }
}