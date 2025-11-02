namespace card_game
{
    partial class FM_ForgetPassword
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
            LL_SignUP = new LinkLabel();
            BT_ChangePassword = new Button();
            label2 = new Label();
            LB_FP_User = new Label();
            TB_FP_User = new TextBox();
            TB_FP_Password = new TextBox();
            BT_FP_Back = new Button();
            SuspendLayout();
            // 
            // LL_SignUP
            // 
            LL_SignUP.AutoSize = true;
            LL_SignUP.Location = new Point(341, 409);
            LL_SignUP.Name = "LL_SignUP";
            LL_SignUP.Size = new Size(116, 15);
            LL_SignUP.TabIndex = 11;
            LL_SignUP.TabStop = true;
            LL_SignUP.Text = "don't have a accont?";
            // 
            // BT_ChangePassword
            // 
            BT_ChangePassword.Location = new Point(344, 350);
            BT_ChangePassword.Name = "BT_ChangePassword";
            BT_ChangePassword.Size = new Size(113, 23);
            BT_ChangePassword.TabIndex = 10;
            BT_ChangePassword.Text = "Change password";
            BT_ChangePassword.UseVisualStyleBackColor = true;
            BT_ChangePassword.Click += BT_ChangePassword_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 324);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 9;
            label2.Text = "New password";
            // 
            // LB_FP_User
            // 
            LB_FP_User.AutoSize = true;
            LB_FP_User.Location = new Point(55, 295);
            LB_FP_User.Name = "LB_FP_User";
            LB_FP_User.Size = new Size(33, 15);
            LB_FP_User.TabIndex = 8;
            LB_FP_User.Text = "User:";
            // 
            // TB_FP_User
            // 
            TB_FP_User.Location = new Point(94, 292);
            TB_FP_User.Name = "TB_FP_User";
            TB_FP_User.Size = new Size(694, 23);
            TB_FP_User.TabIndex = 7;
            // 
            // TB_FP_Password
            // 
            TB_FP_Password.Location = new Point(94, 321);
            TB_FP_Password.Name = "TB_FP_Password";
            TB_FP_Password.Size = new Size(694, 23);
            TB_FP_Password.TabIndex = 6;
            // 
            // BT_FP_Back
            // 
            BT_FP_Back.Location = new Point(12, 12);
            BT_FP_Back.Name = "BT_FP_Back";
            BT_FP_Back.Size = new Size(75, 23);
            BT_FP_Back.TabIndex = 12;
            BT_FP_Back.Text = "<-";
            BT_FP_Back.UseVisualStyleBackColor = true;
            BT_FP_Back.Click += BT_FP_Back_Click;
            // 
            // FM_ForgetPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(BT_FP_Back);
            Controls.Add(LL_SignUP);
            Controls.Add(BT_ChangePassword);
            Controls.Add(label2);
            Controls.Add(LB_FP_User);
            Controls.Add(TB_FP_User);
            Controls.Add(TB_FP_Password);
            Name = "FM_ForgetPassword";
            Text = "FM_ForgetPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel LL_SignUP;
        private Button BT_ChangePassword;
        private Label label2;
        private Label LB_FP_User;
        private TextBox TB_FP_User;
        private TextBox TB_FP_Password;
        private Button BT_FP_Back;
    }
}