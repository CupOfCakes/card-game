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
            SuspendLayout();
            // 
            // LP_Deck
            // 
            LP_Deck.BackColor = Color.SteelBlue;
            LP_Deck.Location = new Point(15, 55);
            LP_Deck.Name = "LP_Deck";
            LP_Deck.Size = new Size(730, 416);
            LP_Deck.TabIndex = 0;
            // 
            // BT_CreateCard
            // 
            BT_CreateCard.Location = new Point(512, 12);
            BT_CreateCard.Name = "BT_CreateCard";
            BT_CreateCard.Size = new Size(230, 37);
            BT_CreateCard.TabIndex = 0;
            BT_CreateCard.Text = "Create a new card?";
            BT_CreateCard.UseVisualStyleBackColor = true;
            BT_CreateCard.Click += BT_CreateCard_Click;
            // 
            // BT_Back
            // 
            BT_Back.Location = new Point(12, 12);
            BT_Back.Name = "BT_Back";
            BT_Back.Size = new Size(75, 23);
            BT_Back.TabIndex = 1;
            BT_Back.Text = "<-";
            BT_Back.UseVisualStyleBackColor = true;
            // 
            // LP_Cards
            // 
            LP_Cards.Location = new Point(15, 486);
            LP_Cards.Name = "LP_Cards";
            LP_Cards.Size = new Size(730, 416);
            LP_Cards.TabIndex = 2;
            // 
            // FM_Deck
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(757, 598);
            Controls.Add(LP_Cards);
            Controls.Add(BT_Back);
            Controls.Add(BT_CreateCard);
            Controls.Add(LP_Deck);
            Name = "FM_Deck";
            Text = "FM_Deck";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel LP_Deck;
        private Button BT_CreateCard;
        private Button BT_Back;
        private FlowLayoutPanel LP_Cards;
    }
}