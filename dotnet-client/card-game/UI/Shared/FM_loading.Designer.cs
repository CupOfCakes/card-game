namespace card_game
{
    partial class FM_loading
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
            components = new System.ComponentModel.Container();
            PB_Loading = new PictureBox();
            LB_Loading = new Label();
            timerLabelFade = new System.Windows.Forms.Timer(components);
            LB_RandomTip = new Label();
            ((System.ComponentModel.ISupportInitialize)PB_Loading).BeginInit();
            SuspendLayout();
            // 
            // PB_Loading
            // 
            PB_Loading.BackgroundImage = Properties.Resources.loading_img;
            PB_Loading.Location = new Point(148, 2);
            PB_Loading.Name = "PB_Loading";
            PB_Loading.Size = new Size(502, 378);
            PB_Loading.SizeMode = PictureBoxSizeMode.Zoom;
            PB_Loading.TabIndex = 0;
            PB_Loading.TabStop = false;
            // 
            // LB_Loading
            // 
            LB_Loading.AutoSize = true;
            LB_Loading.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            LB_Loading.Location = new Point(343, 416);
            LB_Loading.Name = "LB_Loading";
            LB_Loading.Size = new Size(100, 25);
            LB_Loading.TabIndex = 1;
            LB_Loading.Text = "Loading...";
            // 
            // timerLabelFade
            // 
            timerLabelFade.Interval = 500;
            timerLabelFade.Tick += timerLabelFade_Tick;
            // 
            // LB_RandomTip
            // 
            LB_RandomTip.AutoSize = true;
            LB_RandomTip.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            LB_RandomTip.Location = new Point(343, 383);
            LB_RandomTip.Name = "LB_RandomTip";
            LB_RandomTip.Size = new Size(65, 25);
            LB_RandomTip.TabIndex = 2;
            LB_RandomTip.Text = "label1";
            LB_RandomTip.Left = ((ClientSize.Width - LB_RandomTip.Width) / 2) + 30;
            // 
            // FM_loading
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LB_RandomTip);
            Controls.Add(LB_Loading);
            Controls.Add(PB_Loading);
            Name = "FM_loading";
            Text = "FM_loading";
            Load += FM_Loading_Load;
            ((System.ComponentModel.ISupportInitialize)PB_Loading).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PB_Loading;
        private Label LB_Loading;
        private System.Windows.Forms.Timer timerLabelFade;
        private Label LB_RandomTip;
    }
}