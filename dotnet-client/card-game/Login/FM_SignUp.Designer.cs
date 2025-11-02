namespace card_game
{
    partial class FM_SignUp
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
            PB_SignUp = new PictureBox();
            GB_SignUP = new GroupBox();
            LL_SignUP = new LinkLabel();
            TB_SU_User = new TextBox();
            BT_SignUP = new Button();
            TB_SU_Password = new TextBox();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)PB_SignUp).BeginInit();
            GB_SignUP.SuspendLayout();
            SuspendLayout();
            // 
            // PB_SignUp
            // 
            PB_SignUp.Image = Properties.Resources.PB_SignUp_Img;
            PB_SignUp.InitialImage = null;
            PB_SignUp.Location = new Point(375, 1);
            PB_SignUp.Name = "PB_SignUp";
            PB_SignUp.Size = new Size(428, 451);
            PB_SignUp.TabIndex = 0;
            PB_SignUp.TabStop = false;
            // 
            // GB_SignUP
            // 
            GB_SignUP.Controls.Add(LL_SignUP);
            GB_SignUP.Controls.Add(TB_SU_User);
            GB_SignUP.Controls.Add(BT_SignUP);
            GB_SignUP.Controls.Add(TB_SU_Password);
            GB_SignUP.Controls.Add(label2);
            GB_SignUP.Controls.Add(label1);
            GB_SignUP.Location = new Point(12, 12);
            GB_SignUP.Name = "GB_SignUP";
            GB_SignUP.Size = new Size(357, 426);
            GB_SignUP.TabIndex = 1;
            GB_SignUP.TabStop = false;
            // 
            // LL_SignUP
            // 
            LL_SignUP.AutoSize = true;
            LL_SignUP.Location = new Point(126, 259);
            LL_SignUP.Name = "LL_SignUP";
            LL_SignUP.Size = new Size(128, 15);
            LL_SignUP.TabIndex = 11;
            LL_SignUP.TabStop = true;
            LL_SignUP.Text = "Already have a accont?";
            LL_SignUP.LinkClicked += LL_SignUP_LinkClicked;
            // 
            // TB_SU_User
            // 
            TB_SU_User.Location = new Point(65, 144);
            TB_SU_User.Name = "TB_SU_User";
            TB_SU_User.Size = new Size(273, 23);
            TB_SU_User.TabIndex = 7;
            // 
            // BT_SignUP
            // 
            BT_SignUP.Location = new Point(158, 202);
            BT_SignUP.Name = "BT_SignUP";
            BT_SignUP.Size = new Size(75, 23);
            BT_SignUP.TabIndex = 10;
            BT_SignUP.Text = "Sign up";
            BT_SignUP.UseVisualStyleBackColor = true;
            BT_SignUP.Click += BT_SignUP_Click;
            // 
            // TB_SU_Password
            // 
            TB_SU_Password.Location = new Point(65, 173);
            TB_SU_Password.Name = "TB_SU_Password";
            TB_SU_Password.Size = new Size(273, 23);
            TB_SU_Password.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(2, 176);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 9;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 147);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 8;
            label1.Text = "User:";
            // 
            // FM_SignUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(GB_SignUP);
            Controls.Add(PB_SignUp);
            Name = "FM_SignUp";
            Text = "FM_SignUp";
            ((System.ComponentModel.ISupportInitialize)PB_SignUp).EndInit();
            GB_SignUP.ResumeLayout(false);
            GB_SignUP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PB_SignUp;
        private GroupBox GB_SignUP;
        private LinkLabel LL_SignUP;
        private TextBox TB_SU_User;
        private Button BT_SignUP;
        private TextBox TB_SU_Password;
        private Label label2;
        private Label label1;
    }
}