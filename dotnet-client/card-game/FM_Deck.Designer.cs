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
            BT_SaveDeck = new Button();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // LP_Deck
            // 
            LP_Deck.AllowDrop = true;
            LP_Deck.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LP_Deck.BackColor = Color.SteelBlue;
            LP_Deck.Location = new Point(3, 46);
            LP_Deck.MinimumSize = new Size(750, 416);
            LP_Deck.Name = "LP_Deck";
            LP_Deck.Size = new Size(1147, 668);
            LP_Deck.TabIndex = 0;
            LP_Deck.DragDrop += Panel_dragDropAnywhere;
            // 
            // BT_CreateCard
            // 
            BT_CreateCard.Location = new Point(929, 3);
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
            BT_Back.Click += BT_Back_Click;
            // 
            // LP_Cards
            // 
            LP_Cards.AllowDrop = true;
            LP_Cards.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LP_Cards.BackColor = Color.DeepSkyBlue;
            LP_Cards.Location = new Point(3, 720);
            LP_Cards.Name = "LP_Cards";
            LP_Cards.Size = new Size(1147, 324);
            LP_Cards.TabIndex = 2;
            LP_Cards.DragDrop += LP_Cards_DragDrop;

            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.Controls.Add(BT_SaveDeck);
            MainPanel.Controls.Add(LP_Cards);
            MainPanel.Controls.Add(BT_Back);
            MainPanel.Controls.Add(BT_CreateCard);
            MainPanel.Controls.Add(LP_Deck);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1183, 1047);
            MainPanel.TabIndex = 3;
            MainPanel.DragDrop += Panel_dragDropAnywhere;
            // 
            // BT_SaveDeck
            // 
            BT_SaveDeck.Location = new Point(471, 3);
            BT_SaveDeck.Name = "BT_SaveDeck";
            BT_SaveDeck.Size = new Size(230, 37);
            BT_SaveDeck.TabIndex = 3;
            BT_SaveDeck.Text = "Save deck";
            BT_SaveDeck.UseVisualStyleBackColor = true;
            BT_SaveDeck.Click += BT_SaveDeck_Click;
            // 
            // FM_Deck
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(1183, 1047);
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
        private Button BT_SaveDeck;
    }
}