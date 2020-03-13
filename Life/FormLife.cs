namespace Life
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;

    using Life.Engine;

    public partial class FormLife : Form
    {
        #region " Fields and props " 

        private Engine.Life _life;
        private GraphicsEngine _grEng;
        private Options _options;

        private int _xOffset;
        private int _yOffset;
        private bool _isMoving;
        private bool _isSetCell;
        private bool _isClearCell;

        private string _filePath;

        private byte _cellSize = Properties.Settings.Default.CellSize;
        private byte _zoomStep = Properties.Settings.Default.CellSize;
        private int _zoomStepWidth = 0;
        private int _zoomStepHeight = 0;

        #endregion

        public FormLife()
        {
            InitializeComponent();

            this.KeyDown += GameLifeKeyDown;
            this.KeyUp += GameLifeKeyUp;
            tscbGameSpeed.KeyDown += GameLifeKeyDown;
            tscbGameSpeed.KeyUp += GameLifeKeyUp;
        }

        #region " Basic methods "

        private void GraphicsInit()
        {
            _grEng.ColorStep = _options.C;
            _grEng.MapBackground = _options.MapBackground;
            _grEng.SharpColor = _options.SharpColor;
            _grEng.СellStartColor = _options.CellColor1;
            _grEng.CellEndColor = _options.CellColor2;
            _grEng.RefreshSharp();
            _grEng.RefreshCells();

            pnlDraw.ClientSize = _grEng.ClientSize;
        }

        private void ZoomInit()
        {
            _zoomStep = _cellSize;
            _zoomStepWidth = pnlDraw.ClientSize.Width / _cellSize;
            _zoomStepHeight = pnlDraw.ClientSize.Height / _cellSize;
        }

        private void Zoom(bool shift)
        {
            int width = _zoomStep * _zoomStepWidth;
            int height = _zoomStep * _zoomStepHeight;

            if (shift)
                pnlDraw.Location = new Point(pnlDraw.Location.X + (pnlDraw.ClientSize.Width - width) / 2, pnlDraw.Location.Y + (pnlDraw.ClientSize.Height - height) / 2);

            tsBtnZoomUp.Enabled = (_zoomStep < _cellSize);
            tsBtnZoomDown.Enabled = (_zoomStep > 1);

            pnlDraw.ClientSize = new Size(width, height);
            _grEng.Draw();
        }

        private void NewGame()
        {
            bool state = tGame.Enabled;
            GameState(false);

            using (FormNewGame frmNew = new FormNewGame(Properties.Settings.Default.MapWidth, Properties.Settings.Default.MapHeight))
            {
                if (frmNew.ShowDialog(this) == DialogResult.OK)
                {
                    _life.NewGame(new Map(frmNew.MapWidth, frmNew.MapHeight), _options.S, _options.B, _options.C);
                    _grEng.Reset(_life.MapWidth, _life.MapHeight, _cellSize);
                    pnlDraw.ClientSize = _grEng.ClientSize;
                    GraphicsInit();
                    ZoomInit();
                    Zoom(false);
                    _grEng.Draw();

                    Properties.Settings.Default.MapWidth = frmNew.MapWidth;
                    Properties.Settings.Default.MapHeight = frmNew.MapHeight;
                }
                else
                {
                    GameState(state);
                }
            }
        }

        private void Save()
        {
            if (_filePath != null && _filePath != string.Empty)
            {
                using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, _life.Map);
                }
            }
        }

        private void SaveAs()
        {
            bool state = tGame.Enabled;
            GameState(false);

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Life Save File | *.lsf";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    _filePath = sfd.FileName;
                    Save();
                }
            }

            GameState(state);
        }

        private IMap Open()
        {
            IMap map = null;
            bool state = tGame.Enabled;
            GameState(false);

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Life Save File | *.lsf";
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();

                        try
                        {
                            map = (IMap)bf.Deserialize(fs);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        _filePath = ofd.FileName;
                    }
                }
                else
                {
                    GameState(state);
                }
            }

            return map;
        }

        /// <summary>
        /// Изменяет состояние(старт/стоп) игры
        /// </summary>
        /// <param name="state">Состояние(старт/стоп)</param>
        private void GameState(bool state)
        {
            tsBtnStart.Checked = state;
            tsBtnStop.Checked = !state;
            tGame.Enabled = state;
            _grEng.Draw();
        }

        private void NextStep()
        {
            if (tGame.Enabled)
                GameState(false);

            _life.NextStep();
            _grEng.Draw();
        }

        private void SharpVisible(bool visible)
        {
            sharpToolStripMenuItem.Checked = visible;
            tsBtnSharp.Checked = visible;
            _grEng.IsDrawSharp = visible;

            _grEng.Draw();
        }

        private void MapCentering()
        {
            pnlDraw.Location = new Point(Width / 2 - (pnlDraw.Width / 2), Height / 2 - (pnlDraw.Height / 2));
        }

        private void SetCell(int x, int y)
        {
            _life.SetCell(x / (_cellSize - (_cellSize - _zoomStep)), y / (_cellSize - (_cellSize - _zoomStep)));

            _grEng.RefreshCells();
            _grEng.Draw();
        }

        private void ClearCell(int x, int y)
        {
            _life.ClearCell(x / (_cellSize - (_cellSize - _zoomStep)), y / (_cellSize - (_cellSize - _zoomStep)));

            _grEng.RefreshCells();
            _grEng.Draw();
        }

        #endregion

        #region " Methods for events "

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            tscbGameSpeed.ComboBox.DataSource = Enum.GetValues(typeof(GameSpeed));
            tscbGameSpeed.ComboBox.SelectedItem = (GameSpeed)Properties.Settings.Default.Speed;

            try
            {
                _options = Options.Load(Properties.Settings.Default.OptionsFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _options = Options.Default;
                Options.Save(Properties.Settings.Default.OptionsFilePath, _options);
            }

            _life = new Engine.Life(new Map(Properties.Settings.Default.MapWidth, Properties.Settings.Default.MapHeight), _options.S, _options.B, _options.C);
            _grEng = new GraphicsEngine(pnlDraw.Handle, _life, Properties.Settings.Default.CellSize);
            GraphicsInit();
            ZoomInit();
            Zoom(false);
            SharpVisible(Properties.Settings.Default.SharpVisible);

            pnlDraw.Visible = true;
            _grEng.Draw();

            pnlMain.Invalidate();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Properties.Settings.Default.Speed = (ushort)tGame.Interval;
            Properties.Settings.Default.SharpVisible = _grEng.IsDrawSharp;

            Properties.Settings.Default.Save();

            _grEng.Dispose();
            base.OnClosing(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_grEng != null)
                _grEng.Draw();
        }
        
        private void tGame_Tick(object sender, EventArgs e)
        {
            _life.NextStep();
            _grEng.Draw();
        }

        private void pnlMainBoard_Scroll(object sender, ScrollEventArgs e)
        {
            if (_grEng != null)
                _grEng.Draw();
        }

        private void pnlDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMoving)
            {
                Point _pos = pnlDraw.Location;
                _pos.Offset(e.X - _xOffset, e.Y - _yOffset);

                if (_pos.X + pnlDraw.Width > _cellSize && _pos.X < pnlMain.Width - _cellSize && _pos.Y + pnlDraw.Height > _cellSize && _pos.Y < pnlMain.Height - _cellSize)
                    pnlDraw.Location = _pos;

                //if (!tGame.Enabled)
                //    _grEng.Draw();
            }
            else if (_isSetCell)
            {
                SetCell(e.X, e.Y);
            }
            else if (_isClearCell)
            {
                ClearCell(e.X, e.Y);
            }
        }

        private void pnlDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (tsBtnIsMoving.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    _xOffset = e.X;
                    _yOffset = e.Y;

                    _isMoving = true;
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    _isSetCell = true;
                    SetCell(e.X, e.Y);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    _isClearCell = true;
                    ClearCell(e.X, e.Y);
                }
            }
        }

        private void pnlDraw_MouseUp(object sender, MouseEventArgs e)
        {
            _isMoving = false;
            _isSetCell = false;
            _isClearCell = false;
            _grEng.Draw();
        }

        private void GameLifeKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData & Keys.Control) == Keys.Control)
                tsBtnIsMoving.Checked = true;
        }

        private void GameLifeKeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyData | Keys.Control) != Keys.Control)
                tsBtnIsMoving.Checked = false;
        }

        #region " Menu "

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMap map = Open();

            if (map != null)
            {
                _life.NewGame(map);
                _grEng.Reset(map.Width, map.Height, _cellSize);
                pnlDraw.ClientSize = _grEng.ClientSize;
                ZoomInit();
                Zoom(false);
                _grEng.Draw();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(_filePath))
                Save();
            else
                SaveAs();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool state = tGame.Enabled;
            GameState(false);

            using (FormOptions frmOptions = new FormOptions(_options))
            {
                if (frmOptions.ShowDialog(this) == DialogResult.OK)
                {
                    _options = frmOptions.Options;

                    _life.S = _options.S;
                    _life.B = _options.B;
                    _life.C = _options.C;

                    GraphicsInit();
                    Zoom(false);
                }
            }

            GameState(state);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameState(true);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameState(false);
        }

        private void nextStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NextStep();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _life.MapClear();
            _grEng.Draw();
        }

        private void toolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsMain.Visible = tsMain.Enabled = toolBarToolStripMenuItem.Checked;
        }

        private void sharpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SharpVisible(sharpToolStripMenuItem.Checked);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormAbout frmAbout = new FormAbout())
            {
                frmAbout.ShowDialog(this);
            }
        }

        #endregion

        #region " ToolBar "

        private void tsBtnSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void tsBtnStart_Click(object sender, EventArgs e)
        {
            GameState(true);
        }

        private void tsBtnStop_Click(object sender, EventArgs e)
        {
            GameState(false);
        }

        private void tsBtnNextStep_Click(object sender, EventArgs e)
        {
            NextStep();
        }

        private void tsBtnClear_Click(object sender, EventArgs e)
        {
            _life.MapClear();
            _grEng.Draw();
        }

        private void tsBtnIsMoving_CheckedChanged(object sender, EventArgs e)
        {
            pnlDraw.Cursor = (tsBtnIsMoving.Checked) ? Cursors.SizeAll : Cursors.Default;
        }

        private void tsBtnSharp_CheckedChanged(object sender, EventArgs e)
        {
            SharpVisible(tsBtnSharp.Checked);
        }

        private void tscbGameSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            tGame.Interval = (int)(GameSpeed)tscbGameSpeed.SelectedItem;
        }

        private void tsBtnZoomUp_Click(object sender, EventArgs e)
        {
            if (_zoomStep < _cellSize)
            {
                _zoomStep++;
                Zoom(true);
            }
        }

        private void tsBtnZoomDown_Click(object sender, EventArgs e)
        {
            if (_zoomStep > 1)
            {
                _zoomStep--;
                Zoom(true);
            }
        }

        #endregion

        #endregion
    }
}
