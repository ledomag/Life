namespace Life
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    using Life.Engine;

    public partial class FormOptions : Form
    {
        private Options _options;
        public Options Options
        {
            get { return _options; }
        }

        public FormOptions(Options options)
        {
            InitializeComponent();
            _options = options;
        }

        private void Save()
        {
            try
            {
                Options.Save(Properties.Settings.Default.OptionsFilePath, _options);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            OptionsLoad();
        }

        private void OptionsLoad()
        {
            string s = string.Empty;
            string b = string.Empty;

            foreach (Neighbor n in Enum.GetValues(typeof(Neighbor)))
            {
                if ((Options.S & n) != 0)
                    s += Math.Log((ushort)n, 2).ToString();
                if ((Options.B & n) != 0)
                    b += Math.Log((ushort)n, 2).ToString();
            }

            mtbS.Text = s;
            mtbB.Text = b;
            nudC.Value = Options.C + 1;
            cbtnMapBackground.FillColor = Options.MapBackground;
            cbtSharpColor.FillColor = Options.SharpColor;
            cbtnCellColor1.FillColor = Options.CellColor1;
            cbtnCellColor2.FillColor = Options.CellColor2;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                string[] s = mtbS.Text.Split('.');
                string[] b = mtbB.Text.Split('.');

                _options.S = new Neighbor();
                _options.B = new Neighbor();

                byte count = 0;
                for (int i = 0; i < 8; i++)
                {
                    if(byte.TryParse(s[i], out count) && count > 0 && count < 9)
                        _options.S |= (Neighbor)Math.Pow(2, count);
                    if (byte.TryParse(b[i], out count) && count > 0 && count < 9)
                        _options.B |= (Neighbor)Math.Pow(2, count);
                }

                _options.C = (byte)(nudC.Value - 1);
                _options.MapBackground = cbtnMapBackground.FillColor;
                _options.SharpColor = cbtSharpColor.FillColor;
                _options.CellColor1 = cbtnCellColor1.FillColor;
                _options.CellColor2 = cbtnCellColor2.FillColor;

                Save();
            }

            base.OnClosing(e);
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            _options = Options.Default;
            OptionsLoad();
        }
    }
}
