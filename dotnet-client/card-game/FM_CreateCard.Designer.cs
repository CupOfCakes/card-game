namespace card_game
{
    partial class FM_CreateCard
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
            label1 = new Label();
            BT_CC_Back = new Button();
            TB_CardName = new TextBox();
            label2 = new Label();
            BT_ChooseImg = new Button();
            TB_Life = new TextBox();
            label3 = new Label();
            TB_Damage = new TextBox();
            label4 = new Label();
            TB_shield = new TextBox();
            label5 = new Label();
            BT_SendCard = new Button();
            PB_CreateImg = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PB_CreateImg).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 54);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // BT_CC_Back
            // 
            BT_CC_Back.Location = new Point(12, 11);
            BT_CC_Back.Name = "BT_CC_Back";
            BT_CC_Back.Size = new Size(75, 23);
            BT_CC_Back.TabIndex = 1;
            BT_CC_Back.Text = "<-";
            BT_CC_Back.UseVisualStyleBackColor = true;
            BT_CC_Back.Click += BT_CC_Back_Click;
            // 
            // TB_CardName
            // 
            TB_CardName.Location = new Point(72, 51);
            TB_CardName.MaxLength = 20;
            TB_CardName.Name = "TB_CardName";
            TB_CardName.Size = new Size(157, 23);
            TB_CardName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(247, 19);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 3;
            label2.Text = "Image:";
            // 
            // BT_ChooseImg
            // 
            BT_ChooseImg.Location = new Point(312, 12);
            BT_ChooseImg.Name = "BT_ChooseImg";
            BT_ChooseImg.Size = new Size(97, 23);
            BT_ChooseImg.TabIndex = 4;
            BT_ChooseImg.Text = "Choose image";
            BT_ChooseImg.UseVisualStyleBackColor = true;
            BT_ChooseImg.Click += BT_ChooseImg_Click;
            // 
            // TB_Life
            // 
            TB_Life.Location = new Point(72, 90);
            TB_Life.MaxLength = 3;
            TB_Life.Name = "TB_Life";
            TB_Life.Size = new Size(157, 23);
            TB_Life.TabIndex = 6;
            TB_Life.KeyPress += TB_NumericOnly_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 93);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 5;
            label3.Text = "Life:";
            // 
            // TB_Damage
            // 
            TB_Damage.Location = new Point(72, 131);
            TB_Damage.MaxLength = 2;
            TB_Damage.Name = "TB_Damage";
            TB_Damage.Size = new Size(157, 23);
            TB_Damage.TabIndex = 8;
            TB_Damage.KeyPress += TB_NumericOnly_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 134);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 7;
            label4.Text = "Damage:";
            // 
            // TB_shield
            // 
            TB_shield.Location = new Point(72, 170);
            TB_shield.MaxLength = 2;
            TB_shield.Name = "TB_shield";
            TB_shield.Size = new Size(157, 23);
            TB_shield.TabIndex = 10;
            TB_shield.KeyPress += TB_NumericOnly_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 173);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 9;
            label5.Text = "Shield:";
            // 
            // BT_SendCard
            // 
            BT_SendCard.Location = new Point(72, 221);
            BT_SendCard.Name = "BT_SendCard";
            BT_SendCard.Size = new Size(81, 22);
            BT_SendCard.TabIndex = 11;
            BT_SendCard.Text = "Create card";
            BT_SendCard.UseVisualStyleBackColor = true;
            BT_SendCard.Click += BT_SendCard_Click;
            // 
            // PB_CreateImg
            // 
            PB_CreateImg.BackgroundImageLayout = ImageLayout.None;
            PB_CreateImg.Image = Properties.Resources.CIMG_null;
            PB_CreateImg.InitialImage = Properties.Resources.CIMG_null;
            PB_CreateImg.Location = new Point(247, 51);
            PB_CreateImg.Name = "PB_CreateImg";
            PB_CreateImg.Size = new Size(162, 192);
            PB_CreateImg.SizeMode = PictureBoxSizeMode.Zoom;
            PB_CreateImg.TabIndex = 12;
            PB_CreateImg.TabStop = false;
            // 
            // FM_CreateCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(421, 261);
            Controls.Add(PB_CreateImg);
            Controls.Add(BT_SendCard);
            Controls.Add(TB_shield);
            Controls.Add(label5);
            Controls.Add(TB_Damage);
            Controls.Add(label4);
            Controls.Add(TB_Life);
            Controls.Add(label3);
            Controls.Add(BT_ChooseImg);
            Controls.Add(label2);
            Controls.Add(TB_CardName);
            Controls.Add(BT_CC_Back);
            Controls.Add(label1);
            Name = "FM_CreateCard";
            Text = "FM_CreateCard";
            ((System.ComponentModel.ISupportInitialize)PB_CreateImg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button BT_CC_Back;
        private TextBox TB_CardName;
        private Label label2;
        private Button BT_ChooseImg;
        private TextBox TB_Life;
        private Label label3;
        private TextBox TB_Damage;
        private Label label4;
        private TextBox TB_shield;
        private Label label5;
        private Button BT_SendCard;
        private PictureBox PB_CreateImg;
    }
}