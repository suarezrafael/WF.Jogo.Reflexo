using System.Diagnostics;

namespace WF.Jogo.Reflexo
{
    public partial class Form1 : Form
    {
        private Button btnStart;
        private Button btnTarget;
        private System.Windows.Forms.Timer timer;
        private Random random;
        private Stopwatch stopwatch;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Jogo de Reflexo";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            btnStart = new Button() { Text = "Iniciar", Size = new Size(100, 50), Location = new Point(150, 150) };
            btnStart.Click += StartGame;
            this.Controls.Add(btnStart);

            btnTarget = new Button() { Size = new Size(60, 60), BackColor = Color.Red, Visible = false };
            btnTarget.Click += TargetClicked;
            this.Controls.Add(btnTarget);

            timer = new System.Windows.Forms.Timer();
            timer.Tick += ShowTarget;

            random = new Random();
            stopwatch = new Stopwatch();
        }
        private void StartGame(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            timer.Interval = random.Next(1000, 3000);
            timer.Start();
        }

        private void ShowTarget(object sender, EventArgs e)
        {
            timer.Stop();

            int x = random.Next(50, this.ClientSize.Width - 70);
            int y = random.Next(50, this.ClientSize.Height - 70);

            btnTarget.Location = new Point(x, y);
            btnTarget.Visible = true;

            stopwatch.Restart();
        }
        private void TargetClicked(object sender, EventArgs e)
        {
            stopwatch.Stop();
            btnTarget.Visible = false;
            MessageBox.Show($"Seu tempo de reação: {stopwatch.ElapsedMilliseconds} ms", "Resultado");
            btnStart.Enabled = true;
        }
    }
}
