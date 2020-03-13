namespace Life.Engine
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// Карта
    /// </summary>
    [Serializable]
    public class Map : IMap, ISerializable
    {
        #region " Fields and props "

        /// <summary>
        /// Коллекция ячеек
        /// </summary>
        protected Cell[][] _cells;
        /// <summary>
        /// Коллекция ячеек
        /// </summary>
        public Cell[][] Cells
        {
            get { return _cells; }
        }

        /// <summary>
        /// Возвращает значение ширины карты
        /// </summary>
        public int Width { get; protected set; }
        /// <summary>
        /// Возвращает значение высоты карты
        /// </summary>
        public int Height { get; protected set; }

        /// <summary>
        /// Возвращает значение ячейки
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        /// <returns>Ячейка</returns>
        public virtual Cell this[int x, int y]
        {
            get { return (x >= 0 && x < Width && y >= 0 && y < Height) ? _cells[x][y] : null; }
        }

        #endregion

        #region " Events "

        /// <summary>
        /// Произошло создание карты
        /// </summary>
        public event EventHandler Created;
        /// <summary>
        /// Произошла очистка карты
        /// </summary>
        public event EventHandler Cleaned;
        /// <summary>
        /// Произошло изменение значения в ячейке
        /// </summary>
        public event CellChangeEventHandler CellChanged;
        /// <summary>
        /// Произошло обращение за пределы карты
        /// </summary>
        public event CellEventHandler SetCellOut;

        #endregion

        #region " Ctors "

        /// <summary>
        /// Создает Map
        /// </summary>
        protected Map(SerializationInfo info, StreamingContext context)
        {
            Width = info.GetInt32("Width");
            Height = info.GetInt32("Height");
            _cells = (Cell[][])info.GetValue("Cells", typeof(Cell[][]));
        }

        /// <summary>
        /// Создает Map
        /// </summary>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            _cells = new Cell[width][];

            for (int i = 0; i < _cells.Length; i++)
                _cells[i] = new Cell[height];

            Init();
        }

        #endregion

        #region " Basic methods "

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Width", Width);
            info.AddValue("Height", Height);
            info.AddValue("Cells", _cells);
        }

        private void Init()
        {
            Clear();
            OnCreated(new EventArgs());
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Map.Created
        /// </summary>
        /// <param name="e">System.EventArgs содержит информацию о событии</param>
        protected virtual void OnCreated(EventArgs e)
        {
            if (Created != null)
                Created(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Map.Cleaned
        /// </summary>
        /// <param name="e">System.EventArgs содержит информацию о событии</param>
        protected virtual void OnCleaned(EventArgs e)
        {
            if (Cleaned != null)
                Cleaned(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Map.CellChange
        /// </summary>
        /// <param name="e">Life.Engine.CellChangeEventArgs содержит информацию о событии</param>
        protected virtual void OnCellChanged(CellChangeEventArgs e)
        {
            if (CellChanged != null)
                CellChanged(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Map.SetCellOut
        /// </summary>
        /// <param name="e">Life.Engine.CellEventArgs содержит информацию о событии</param>
        protected virtual void OnSetCellOut(CellEventArgs e)
        {
            if (SetCellOut != null)
                SetCellOut(this, e);
        }

        /// <summary>
        /// Очистить карту
        /// </summary>
        public virtual void Clear()
        {
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    _cells[i][j] = new Cell();

            OnCleaned(new EventArgs());
        }

        /// <summary>
        /// Возвращает значение ячейки
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        /// <returns>Ячейка</returns>
        public virtual Cell GetCell(int x, int y)
        {
            return _cells[x][y];
        }

        /// <summary>
        /// Устанавливает значение ячейки
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        /// <param name="status">Статус ячейки</param>
        /// <param name="step">Шаг ячейки</param>
        public virtual void SetCell(int x, int y, CellStatus status, byte step)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                _cells[x][y].Status = status;
                _cells[x][y].Step = step;
                OnCellChanged(new CellChangeEventArgs(x, y, new Cell(status, step)));
            }
            else
            {
                OnSetCellOut(new CellEventArgs(x, y));
            }
        }

        #endregion
    }
}
