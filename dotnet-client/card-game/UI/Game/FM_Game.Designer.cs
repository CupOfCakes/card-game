namespace card_game.UI.Game
{
    partial class FM_Game
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
            GB_Hand = new GroupBox();
            panel1 = new Panel();
            panel3 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel9 = new Panel();
            panel10 = new Panel();
            panel11 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            GB_Hand.SuspendLayout();
            SuspendLayout();
            // 
            // GB_Hand
            // 
            GB_Hand.BackColor = SystemColors.AppWorkspace;
            GB_Hand.BackgroundImageLayout = ImageLayout.None;
            GB_Hand.Controls.Add(panel1);
            GB_Hand.Location = new Point(1, 578);
            GB_Hand.Name = "GB_Hand";
            GB_Hand.Size = new Size(1478, 251);
            GB_Hand.TabIndex = 0;
            GB_Hand.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.back_card;
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Location = new Point(1307, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(150, 225);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.BackgroundImageLayout = ImageLayout.Zoom;
            panel3.Location = new Point(457, 344);
            panel3.Name = "panel3";
            panel3.Size = new Size(150, 225);
            panel3.TabIndex = 3;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.Window;
            panel7.BackgroundImageLayout = ImageLayout.Zoom;
            panel7.Location = new Point(621, 151);
            panel7.Name = "panel7";
            panel7.Size = new Size(225, 150);
            panel7.TabIndex = 4;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.Window;
            panel8.BackgroundImageLayout = ImageLayout.Zoom;
            panel8.Location = new Point(1118, 344);
            panel8.Name = "panel8";
            panel8.Size = new Size(150, 225);
            panel8.TabIndex = 5;
            // 
            // panel9
            // 
            panel9.BackColor = SystemColors.Window;
            panel9.BackgroundImageLayout = ImageLayout.Zoom;
            panel9.Location = new Point(889, 344);
            panel9.Name = "panel9";
            panel9.Size = new Size(150, 225);
            panel9.TabIndex = 4;
            // 
            // panel10
            // 
            panel10.BackColor = SystemColors.Window;
            panel10.BackgroundImageLayout = ImageLayout.Zoom;
            panel10.Location = new Point(662, 344);
            panel10.Name = "panel10";
            panel10.Size = new Size(150, 225);
            panel10.TabIndex = 4;
            // 
            // panel11
            // 
            panel11.BackColor = SystemColors.Window;
            panel11.BackgroundImageLayout = ImageLayout.Zoom;
            panel11.Location = new Point(248, 344);
            panel11.Name = "panel11";
            panel11.Size = new Size(150, 225);
            panel11.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.Location = new Point(927, 151);
            panel2.Name = "panel2";
            panel2.Size = new Size(225, 150);
            panel2.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.BackgroundImageLayout = ImageLayout.Zoom;
            panel4.Location = new Point(304, 151);
            panel4.Name = "panel4";
            panel4.Size = new Size(225, 150);
            panel4.TabIndex = 7;
            // 
            // FM_Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1481, 829);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel10);
            Controls.Add(panel9);
            Controls.Add(panel11);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel3);
            Controls.Add(GB_Hand);
            Name = "FM_Game";
            Text = "FM_Game";
            GB_Hand.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GB_Hand;
        private Panel panel1;
        private Panel panel3;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panel10;
        private Panel panel11;
        private Panel panel2;
        private Panel panel4;
    }
}