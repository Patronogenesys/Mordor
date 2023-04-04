namespace Mordor
{
    public partial class Form1 : Form
    {
        Morda morda = new Morda(new Point(50, 50), new Size(100, 100));
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            morda.Draw(e.Graphics);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            morda.MovePupilsRelative((float)e.X / Size.Width, (float)e.Y / Size.Height);
            Refresh();
        }
    }
}