namespace Life
{
    using System.Windows.Forms;

    public partial class FormNewGame : Form
    {
        public int MapWidth
        {
            get { return (int)nudWidth.Value; }
        }

        public int MapHeight
        {
            get { return (int)nudHeight.Value; }
        }

        public FormNewGame()
        {
            InitializeComponent();
        }

        public FormNewGame(int mapWidth, int mapHeight)
            : this()
        {
            nudWidth.Value = mapWidth;
            nudHeight.Value = mapHeight;
        }
    }
}
