namespace card_game
{
    partial class FM_Deck
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
            LP_Deck = new FlowLayoutPanel();
            BT_CreateCard = new Button();
            BT_Back = new Button();
            LP_Cards = new FlowLayoutPanel();
            MainPanel = new Panel();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // LP_Deck
            // 
            LP_Deck.BackColor = Color.SteelBlue;
            LP_Deck.Location = new Point(3, 43);
            LP_Deck.Name = "LP_Deck";
            LP_Deck.Size = new Size(750, 416);
            LP_Deck.TabIndex = 0;
            LP_Deck.AutoSize = true;
            LP_Deck.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LP_Deck.WrapContents = true;
            LP_Deck.FlowDirection = FlowDirection.LeftToRight;
            LP_Deck.MinimumSize = new Size(750, 416);
            // 
            // BT_CreateCard
            // 
            BT_CreateCard.Location = new Point(523, 0);
            BT_CreateCard.Name = "BT_CreateCard";
            BT_CreateCard.Size = new Size(230, 37);
            BT_CreateCard.TabIndex = 0;
            BT_CreateCard.Text = "Create a new card?";
            BT_CreateCard.UseVisualStyleBackColor = true;
            BT_CreateCard.Click += BT_CreateCard_Click;
            // 
            // BT_Back
            // 
            BT_Back.Location = new Point(3, 3);
            BT_Back.Name = "BT_Back";
            BT_Back.Size = new Size(75, 23);
            BT_Back.TabIndex = 1;
            BT_Back.Text = "<-";
            BT_Back.UseVisualStyleBackColor = true;
            // 
            // LP_Cards
            // 
            LP_Cards.BackColor = Color.DeepSkyBlue;
            LP_Cards.Location = new Point(3, 465);
            LP_Cards.Name = "LP_Cards";
            LP_Cards.Size = new Size(750, 340);
            LP_Cards.TabIndex = 2;
            LP_Cards.AutoSize = true;
            LP_Cards.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LP_Cards.WrapContents = true;
            LP_Cards.FlowDirection = FlowDirection.LeftToRight;
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.Controls.Add(BT_Back);
            MainPanel.Controls.Add(LP_Cards);
            MainPanel.Controls.Add(BT_CreateCard);
            MainPanel.Controls.Add(LP_Deck);
            MainPanel.Location = new Point(0, 2);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(756, 808);
            MainPanel.TabIndex = 3;
            MainPanel.AutoScroll = true;
            MainPanel.Dock = DockStyle.Fill;
            // 
            // FM_Deck
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(757, 822);
            Controls.Add(MainPanel);
            Name = "FM_Deck";
            Text = "FM_Deck";
            MainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel LP_Deck;
        private Button BT_CreateCard;
        private Button BT_Back;
        private FlowLayoutPanel LP_Cards;
        private Panel MainPanel;
    }
}