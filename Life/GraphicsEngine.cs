namespace Life
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Life.Engine;

    /// <summary>
    /// Графический движок Life
    /// </summary>
    public sealed class GraphicsEngine : IDisposable
    {
        #region " Fields and prop "

        private IntPtr _handle;
        private Engine.Life _life;
        private byte _cellSize;

        private GraphicsDevice _device = null;
        private PresentationParameters _presentParams;
        private VertexPositionColor[] _vertSharp = null;
        private VertexPositionColor[] _vertCells = null;
        private VertexDeclaration _vertDecl = null;
        private BasicEffect _effect = null;

        private short _colorRStep;
        private short _colorGStep;
        private short _colorBStep;

        private bool _disposed = false;

        /// <summary>
        /// Возвращает размер области отрисовки
        /// </summary>
        public System.Drawing.Size ClientSize { get; private set; }

        private bool _isDrawSharp;
        /// <summary>
        /// Возвращает и устанавливает значение следует ли отрисовать решетку
        /// </summary>
        public bool IsDrawSharp
        {
            get { return _isDrawSharp; }
            set { _isDrawSharp = value; }
        }

        private byte _colorStep;
        /// <summary>
        /// Возвращает и устанавливает количество шагов при изменении цвета
        /// </summary>
        public byte ColorStep
        {
            get { return _colorStep; }
            set
            {
                _colorStep = value;
                ResetColorStep();
            }
        }

        private Color _sharpColor;
        /// <summary>
        /// Возвращает и устанавливает цвет решетки
        /// </summary>
        public Color SharpColor
        {
            get { return _sharpColor; }
            set { _sharpColor = value; }
        }

        private Color _cellStartColor;
        /// <summary>
        /// Возвращает и устанавливает начальный цвет ячейки
        /// </summary>
        public Color СellStartColor
        {
            get { return _cellStartColor; }
            set 
            {
                _cellStartColor = value;
                ResetColorStep();
            }
        }

        private Color _cellEndColor;
        /// <summary>
        /// Возвращает и устанавливает конечный цвет ячейки
        /// </summary>
        public Color CellEndColor
        {
            get { return _cellEndColor; }
            set
            {
                _cellEndColor = value;
                ResetColorStep();
            }
        }

        private Color _mapBackground;
        /// <summary>
        /// Возвращает и устанавливает цвет карты
        /// </summary>
        public Color MapBackground
        {
            get { return _mapBackground; }
            set
            {
                _mapBackground = value;
            }
        }

        #endregion

        /// <summary>
        /// Создает GraphicsEngine
        /// </summary>
        /// <param name="handle">Handle поверхности</param>
        /// <param name="life">Игровой движок</param>
        /// <param name="cellSize">Размер клетки</param>
        public GraphicsEngine(IntPtr handle, Engine.Life life, byte cellSize)
        {
            if (handle == null)
                throw new ArgumentNullException("handle");
            if (life == null)
                throw new ArgumentNullException("life");

            _handle = handle;
            _cellSize = cellSize;
            _life = life;
            _life.MapChanged += Life_MapChanged;
            _life.MapCleaned += Life_MapCleaned;
            _life.StartGame += Life_StartGame;
            _life.Step += Life_Step;

            Init(_life.Map, _cellSize);
            ResetColorStep();
            VertexCellsInit(_life.Map);
            VertexSharpInit(_life.Map);

            IsDrawSharp = true;
            _sharpColor = Color.Black;
        }

        ~GraphicsEngine()
        {
            Dispose(false);
        }

        #region " Basic methods "

        private void ResetColorStep()
        {
            if (_colorStep > 0)
            {
                _colorRStep = (short)((_cellStartColor.R - _cellEndColor.R) / _colorStep * -1);
                _colorGStep = (short)((_cellStartColor.G - _cellEndColor.G) / _colorStep * -1);
                _colorBStep = (short)((_cellStartColor.B - _cellEndColor.B) / _colorStep * -1);
            }
        }

        private void VertexSharpInit(IMap map)
        {
            if (_device != null)
            {
                float width = map.Width + 1;
                float height = map.Height + 1;
                _vertSharp = new VertexPositionColor[(int)(width + height) * 2 - 8];

                #region " Заполняем _vert "

                int _length = (int)width * 2 - 4;

                for (int i = 0; i < _length; i += 2)
                {
                    _vertSharp[i] = new VertexPositionColor(new Vector3((float)(i + 2) / (width - 1) - 1.0f, -1.0f, 0.0f), _sharpColor);
                    _vertSharp[i + 1] = new VertexPositionColor(new Vector3((float)(i + 2) / (width - 1) - 1.0f, 1.1f, 0.0f), _sharpColor);
                }

                for (int i = 0; i < height * 2 - 4; i += 2)
                {
                    _vertSharp[i + _length] = new VertexPositionColor(new Vector3(-1.0f, (float)(i + 2) / (height - 1) - 1.0f, 0.0f), _sharpColor);
                    _vertSharp[i + _length + 1] = new VertexPositionColor(new Vector3(1.0f, (float)(i + 2) / (height - 1) - 1.0f, 0.0f), _sharpColor);
                }

                #endregion
            }
        }

        private void VertexCellsInit(IMap map)
        {
            if (_device != null)
            {
                short step = 0;
                Color color;
                List<VertexPositionColor> cells = new List<VertexPositionColor>();

                for (int x = 0; x < map.Width; x++)
                {
                    for (int y = 0; y < map.Height; y++)
                    {
                        if (map[x, y] != null && map[x, y].Status == CellStatus.Normal)
                        {
                            step = (short)map[x, y].Step;
                            color = new Color((byte)(_cellStartColor.R + _colorRStep * step), (byte)(_cellStartColor.G + _colorGStep * step), (byte)(_cellStartColor.B + _colorBStep * step));

                            cells.Add(new VertexPositionColor(new Vector3((float)x * 2 / map.Width - 1.0f, 1 - (float)y * 2 / map.Height, 0.0f), color));
                            cells.Add(new VertexPositionColor(new Vector3((float)(x + 1) * 2 / map.Width - 1.0f, 1 - (float)y * 2 / map.Height, 0.0f), color));
                            cells.Add(new VertexPositionColor(new Vector3((float)x * 2 / map.Width - 1.0f, 1 - (float)(y + 1) * 2 / map.Height, 0.0f), color));

                            cells.Add(new VertexPositionColor(new Vector3((float)(x + 1) * 2 / map.Width - 1.0f, 1 - (float)y * 2 / map.Height, 0.0f), color));
                            cells.Add(new VertexPositionColor(new Vector3((float)(x + 1) * 2 / map.Width - 1.0f, 1 - (float)(y + 1) * 2 / map.Height, 0.0f), color));
                            cells.Add(new VertexPositionColor(new Vector3((float)x * 2 / map.Width - 1.0f, 1 - (float)(y + 1) * 2 / map.Height, 0.0f), color));
                        }
                    }
                }

                _vertCells = cells.ToArray();
            }
        }

        private void Init(IMap map, byte cellSize)
        {
            _presentParams = new PresentationParameters();
            _presentParams.IsFullScreen = false;
            _presentParams.BackBufferCount = 1;
            _presentParams.SwapEffect = SwapEffect.Discard;

            ClientSize = new System.Drawing.Size(map.Width * cellSize, map.Height * cellSize);
            _presentParams.BackBufferWidth = ClientSize.Width;
            _presentParams.BackBufferHeight = ClientSize.Height;

            _device = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, DeviceType.Hardware, _handle, _presentParams);

            _vertDecl = new VertexDeclaration(_device, VertexPositionColor.VertexElements);
            _effect = new BasicEffect(_device, null);
            _effect.VertexColorEnabled = true;
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _effect.Dispose();
                    _vertDecl.Dispose();
                    _device.Dispose();
                    _presentParams.Dispose();
                }

                _handle = IntPtr.Zero;

                _disposed = true;
            }
        }

        /// <summary>
        /// Уничтожить объект
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Сброс
        /// </summary>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        /// <param name="cellSize">Размер клетки</param>
        public void Reset(int width, int height, byte cellSize)
        {
            ClientSize = new System.Drawing.Size(width * cellSize, height * cellSize);
            _presentParams.BackBufferWidth = ClientSize.Width;
            _presentParams.BackBufferHeight = ClientSize.Height;

            _device.Reset(_presentParams);
        }

        /// <summary>
        /// Отрисовать
        /// </summary>
        public void Draw()
        {
            if (_device.GraphicsDeviceStatus == GraphicsDeviceStatus.NotReset)
                _device.Reset(_presentParams);

            _device.Clear(_mapBackground);
            _device.VertexDeclaration = _vertDecl;

            _effect.Begin();

            foreach (EffectPass pass in _effect.CurrentTechnique.Passes)
            {
                pass.Begin();
                // Отрисовка ячеек
                if (_vertCells.Length > 0)
                    _device.DrawUserPrimitives(PrimitiveType.TriangleList, _vertCells, 0, _vertCells.Length / 3);
                // Отрисовка сетки
                if (_isDrawSharp && _vertSharp.Length > 0)
                    _device.DrawUserPrimitives(PrimitiveType.LineList, _vertSharp, 0, _vertSharp.Length / 2);
                pass.End();
            }
            _effect.End();

            _device.Present();
        }
        
        /// <summary>
        /// Обновить клетки
        /// </summary>
        public void RefreshCells()
        {
            VertexCellsInit(_life.Map);
        }

        /// <summary>
        /// Обновить сетку
        /// </summary>
        public void RefreshSharp()
        {
            VertexSharpInit(_life.Map);
        }

        #endregion

        #region " Method for events "

        private void Life_MapChanged(object sender, MapEventArgs e)
        {
            VertexSharpInit(e.Map);
        }

        private void Life_MapCleaned(object sender, MapEventArgs e)
        {
            VertexCellsInit(e.Map);
        }

        private void Life_StartGame(object sender, EventArgs e)
        {
            Reset(_life.Map.Width, _life.Map.Height, _cellSize);
            VertexCellsInit(_life.Map);
            VertexSharpInit(_life.Map);
        }

        private void Life_Step(object sender, EventArgs e)
        {
            VertexCellsInit(_life.Map);
        }

        #endregion
    }
}
