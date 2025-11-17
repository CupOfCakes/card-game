using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace card_game
{
    public partial class FM_loading : Form
    {
        private List<string> loadingTips = new List<string>
        {
            "Carregando… compilando café em bytes.",
            "Aguarde… até o compilador terminar de chorar.",
            "Inicializando… variáveis e expectativas irreais.",
            "Processando… fórmulas que ninguém lembra da faculdade.",
            "Não desligue o PC… sério, não tente.",
            "Calculando quantos loops cabem em 3 segundos.",
            "Otimizando o seu futuro com zeros e uns.",
            "Aguarde… estamos debugando a própria realidade.",
            "Carregando sprites e memes aleatórios.",
            "Tentando rodar a física quântica do projeto… falha esperada.",
            "Checando se você realmente estudou pra isso.",
            "Gerando universos paralelos em background.",
            "Não feche o programa… sério, acredite em mim.",
            "Sincronizando cérebro com teclado… quase pronto.",
            "Loading… como todo bom algoritmo preguiçoso.",
            "Quem fez esse codigo mal otimizado?",
            "\"Sua senha é fraca\" e daí? Ela vai lutar por acaso?"
        };

        private CancellationTokenSource cts = new CancellationTokenSource();

        public int UserIdToOpen { get; set; }

        private FM_Deck deckForm;

        private int dotCount = 0;

        public FM_loading(int userId)
        {
            InitializeComponent();
            UserIdToOpen = userId;

            ChangeLBRandomTip();
            timerLabelFade.Start();

        }

        private async void FM_Loading_Load(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    deckForm = new FM_Deck(UserIdToOpen);
                    deckForm.CreateControl();
                }, cts.Token);

                deckForm.Show();
                this.Hide();

            }
            catch (OperationCanceledException) { this.Close(); }
            catch (Exception ex) { MessageBox.Show("ERRO ON LOADING: " + ex.Message); this.Close(); }
        }

        private void timerLabelFade_Tick(object sender, EventArgs e)
        {
            dotCount = (dotCount + 1) % 4;
            LB_Loading.Text = "Loading" + new string('.', dotCount);
            
        }

        private void ChangeLBRandomTip()
        {
            Random rnd = new Random();
            int rd = rnd.Next(0, loadingTips.Count);

            LB_RandomTip.Text = loadingTips[rd];
            
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!cts.IsCancellationRequested) cts.Cancel();

            timerLabelFade.Stop();
            base.OnFormClosing(e);
        }

    }
}
