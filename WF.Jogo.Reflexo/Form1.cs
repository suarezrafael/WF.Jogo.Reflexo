using System.Diagnostics;

namespace WF.Jogo.Reflexo
{
    public partial class Form1 : Form
    {
        private Button btnIniciar;
        private Button btnAlvo;
        private System.Windows.Forms.Timer timer;
        private Random random;
        private Stopwatch stopwatch;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Jogo de Reflexo";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            btnIniciar = new Button() { Text = "Iniciar", Size = new Size(100, 50), Location = new Point(150, 150) };
            btnIniciar.Click += IniciarJogo;
            this.Controls.Add(btnIniciar);

            btnAlvo = new Button() { Size = new Size(60, 60), BackColor = Color.Red, Visible = false };
            btnAlvo.Click += btnAlvoClick;
            this.Controls.Add(btnAlvo);

            timer = new System.Windows.Forms.Timer();
            timer.Tick += MostrarBotaoAlvo;

            random = new Random();
            stopwatch = new Stopwatch();
        }
        private void IniciarJogo(object sender, EventArgs e)
        {
            btnIniciar.Enabled = false;
            timer.Interval = random.Next(1000, 3000);
            timer.Start();
        }

        private void MostrarBotaoAlvo(object sender, EventArgs e)
        {
            timer.Stop();

            int x = random.Next(50, this.ClientSize.Width - 70);
            int y = random.Next(50, this.ClientSize.Height - 70);

            btnAlvo.Location = new Point(x, y);
            btnAlvo.Visible = true;

            stopwatch.Restart();
        }
        private void btnAlvoClick(object sender, EventArgs e)
        {
            stopwatch.Stop();
            btnAlvo.Visible = false;
            MessageBox.Show($"Seu tempo de reação: {stopwatch.ElapsedMilliseconds} ms", "Resultado");
            btnAlvo.Enabled = true;
        }
    }
}
