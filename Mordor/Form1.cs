namespace Mordor
{
    public partial class Form1 : Form
    {
        //Morda morda = new Morda(new Point(50, 50), new Size(100, 100));
        Random rnd = new Random();
        List<Morda> mordor = new List<Morda>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Morda m in mordor)
                m.Draw(e.Graphics);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Morda m in mordor)
                m.MovePupilsRelative((float)e.X / Size.Width, (float)e.Y / Size.Height);
            Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            var p = new Point(e.X, e.Y);
            var s = new Size(rnd.Next(60, 100), rnd.Next(60, 100));
            var c = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
            mordor.Add(new Morda(p, s, c));
            Refresh();
        }
    }
}