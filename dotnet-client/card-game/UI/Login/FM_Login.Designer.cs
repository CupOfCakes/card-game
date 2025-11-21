namespace card_game
{
    partial class FM_Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TB_Password = new TextBox();
            TB_User = new TextBox();
            label1 = new Label();
            label2 = new Label();
            BT_SignIn = new Button();
            LL_SignUP = new LinkLabel();
            LL_FP = new LinkLabel();
            SuspendLayout();
            // 
            // TB_Password
            // 
            TB_Password.Location = new Point(75, 309);
            TB_Password.Name = "TB_Password";
            TB_Password.Size = new Size(713, 23);
            TB_Password.TabIndex = 0;
            // 
            // TB_User
            // 
            TB_User.Location = new Point(75, 280);
            TB_User.Name = "TB_User";
            TB_User.Size = new Size(713, 23);
            TB_User.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 283);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 2;
            label1.Text = "User:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 312);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // BT_SignIn
            // 
            BT_SignIn.Location = new Point(370, 350);
            BT_SignIn.Name = "BT_SignIn";
            BT_SignIn.Size = new Size(75, 23);
            BT_SignIn.TabIndex = 4;
            BT_SignIn.Text = "Sign in";
            BT_SignIn.UseVisualStyleBackColor = true;
            BT_SignIn.Click += BT_SignIn_Click;
            // 
            // LL_SignUP
            // 
            LL_SignUP.AutoSize = true;
            LL_SignUP.Location = new Point(345, 420);
            LL_SignUP.Name = "LL_SignUP";
            LL_SignUP.Size = new Size(117, 15);
            LL_SignUP.TabIndex = 5;
            LL_SignUP.TabStop = true;
            LL_SignUP.Text = "Don't have a accont?";
            LL_SignUP.LinkClicked += LL_SignUP_LinkClicked;
            // 
            // LL_FP
            // 
            LL_FP.AutoSize = true;
            LL_FP.Location = new Point(345, 389);
            LL_FP.Name = "LL_FP";
            LL_FP.Size = new Size(126, 15);
            LL_FP.TabIndex = 6;
            LL_FP.TabStop = true;
            LL_FP.Text = "Forget your password?";
            LL_FP.LinkClicked += LL_FP_LinkClicked;
            // 
            // FM_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(LL_FP);
            Controls.Add(LL_SignUP);
            Controls.Add(BT_SignIn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TB_User);
            Controls.Add(TB_Password);
            Name = "FM_Login";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_Password;
        private TextBox TB_User;
        private Label label1;
        private Label label2;
        private Button BT_SignIn;
        private LinkLabel LL_SignUP;
        private LinkLabel LL_FP;
    }
}
