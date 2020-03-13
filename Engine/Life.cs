namespace Life.Engine
{
    using System;

    /// <summary>
    /// Игра "Жизнь"
    /// </summary>
    public class Life
    {
        #region " Fields and props "

        /// <summary>
        /// Карта
        /// </summary>
        protected IMap _map;

        /// <summary>
        /// Набор цифр от 0 до 8, определяет число "живых" соседей, при котором клетка остается "в живых"
        /// </summary>
        public Neighbor S;
        /// <summary>
        /// Набор цифр от 0 до 8, определяет число "живых" соседей при котором "рождается" новая клетка
        /// </summary>
        public Neighbor B;
        /// <summary>
        /// Число ходов "умирания" клетки
        /// </summary>
        public byte C;

        /// <summary>
        /// Возвращает ширину карты
        /// </summary>
        public virtual int MapWidth
        {
            get { return _map.Width; }
        }

        /// <summary>
        /// Возвращает высоту карты
        /// </summary>
        public virtual int MapHeight
        {
            get { return _map.Height; }
        }

        /// <summary>
        /// Возвращает карту
        /// </summary>
        public virtual IMap Map
        {
            get { return _map; }
        }

        #endregion

        #region " Events "

        /// <summary>
        /// Произошло создание игры Life
        /// </summary>
        public event EventHandler Created;
        /// <summary>
        /// Начало игры
        /// </summary>
        public event EventHandler StartGame;
        /// <summary>
        /// Произошел шаг
        /// </summary>
        public event EventHandler Step;
        /// <summary>
        /// Произошло изменение карты
        /// </summary>
        public event MapEventHandler MapChanged;
        /// <summary>
        /// Произошло создание карты
        /// </summary>
        public event MapEventHandler MapCreated;
        /// <summary>
        /// Произошла очистка карты
        /// </summary>
        public event MapEventHandler MapCleaned;
        /// <summary>
        /// Произошло изменение значения в ячейке
        /// </summary>
        public event CellChangeEventHandler MapCellChanged;
        /// <summary>
        /// Произошло обращение за пределы карты
        /// </summary>
        public event CellEventHandler MapSetCellOut;
        /// <summary>
        /// Произошла ошибка
        /// </summary>
        public event ErrorEventHandler Error;

        #endregion

        /// <summary>
        /// Создает Life
        /// </summary>
        /// <param name="map">Карта</param>
        /// <param name="s">Набор цифр от 0 до 8, определяет число "живых" соседей, при котором клетка остается "в живых"</param>
        /// <param name="b">Набор цифр от 0 до 8, определяет число "живых" соседей при котором "рождается" новая клетка</param>
        /// <param name="c">Число, определяет число ходов "умирания" клетки</param>
        public Life(IMap map, Neighbor s, Neighbor b, byte c)
        {
            Init(map, s, b, c);
        }

        #region " Basic methods "

        private void Init(IMap map, Neighbor s, Neighbor b, byte c)
        {
            _map = map;

            _map.Created += Map_Created;
            _map.Cleaned += Map_Cleaned;
            _map.CellChanged += Map_CellChanged;
            _map.SetCellOut += Map_SetCellOut;

            NewGame(_map, s, b, c);
        }

        /// <summary>
        /// Возвращает количество соседей клетки с координатами (x, y)
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        /// <returns>Количество соседей</returns>
        protected virtual Neighbor GetNeighborCount(int x, int y)
        {
            byte count = 0;

            for (int i = x - 1; i <= x + 1; i++)
                for (int j = y - 1; j <= y + 1; j++)
                    if (_map[i, j] != null && (i != x || j != y) && (_map[i, j].Status == CellStatus.Normal || _map[i, j].Status == CellStatus.Dead))
                        count++;

            return (Neighbor)Math.Pow(2, count);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Life.Created
        /// </summary>
        /// <param name="e">System.EventArg содержит информацию о событии</param>
        protected virtual void OnCreated(EventArgs e)
        {
            if (Created != null)
                Created(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Life.StartGame
        /// </summary>
        /// <param name="e">System.EventArg содержит информацию о событии</param>
        protected virtual void OnStartGame(EventArgs e)
        {
            if (StartGame != null)
                StartGame(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Life.Step
        /// </summary>
        /// <param name="e">System.EventArg содержит информацию о событии</param>
        protected virtual void OnStep(EventArgs e)
        {
            if (Step != null)
                Step(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Life.MapChanged
        /// </summary>
        /// <param name="e">MapEventArgs содержит информацию о карте</param>
        protected virtual void OnMapChanged(MapEventArgs e)
        {
            if (MapChanged != null)
                MapChanged(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Life.MapCreated
        /// </summary>
        /// <param name="e">MapEventArgs содержит информацию о карте</param>
        protected virtual void OnMapCreated(MapEventArgs e)
        {
            if (MapCreated != null)
                MapCreated(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Life.MapCleaned
        /// </summary>
        /// <param name="e">MapEventArgs содержит информацию о карте</param>
        protected virtual void OnMapCleaned(MapEventArgs e)
        {
            if (MapCleaned != null)
                MapCleaned(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Life.MapCellChang
        /// </summary>
        /// <param name="e">Life.Engine.CellChangeEventArgs содержит информацию о событии</param>
        protected virtual void OnMapCellChanged(CellChangeEventArgs e)
        {
            if (MapCellChanged != null)
                MapCellChanged(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Life.MapSetCellOut
        /// </summary>
        /// <param name="e">Life.Engine.CellEventArgs содержит информацию о событии</param>
        protected virtual void OnMapSetCellOut(CellEventArgs e)
        {
            if (MapSetCellOut != null)
                MapSetCellOut(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Life.Error
        /// </summary>
        /// <param name="e">Life.Engine.ErrorEventArgs содержит информацию о событии</param>
        protected virtual void OnError(ErrorEventArgs e)
        {
            if (Error != null)
                Error(this, e);
        }

        /// <summary>
        /// Новая игра
        /// </summary>
        /// <param name="map">Карта</param>
        /// <param name="s">Набор цифр от 0 до 8, определяет число "живых" соседей, при котором клетка остается "в живых"</param>
        /// <param name="b">Набор цифр от 0 до 8, определяет число "живых" соседей при котором "рождается" новая клетка</param>
        /// <param name="c">Число, определяет число ходов "умирания" клетки</param>
        public virtual void NewGame(IMap map, Neighbor s, Neighbor b, byte c)
        {
            S = s;
            B = b;
            C = c;
            _map = map;

            OnMapChanged(new MapEventArgs(_map));
            OnStartGame(new EventArgs());
        }

        /// <summary>
        /// Новая игра
        /// </summary>
        /// <param name="s">Набор цифр от 0 до 8, определяет число "живых" соседей, при котором клетка остается "в живых"</param>
        /// <param name="b">Набор цифр от 0 до 8, определяет число "живых" соседей при котором "рождается" новая клетка</param>
        /// <param name="c">Число, определяет число ходов "умирания" клетки</param>
        public virtual void NewGame(Neighbor s, Neighbor b, byte c)
        {
            _map.Clear();
            NewGame(_map, s, b, c);
        }

        /// <summary>
        /// Новая игра
        /// </summary>
        /// <param name="map">Карта</param>
        public virtual void NewGame(IMap map)
        {
            NewGame(map, S, B, C);
        }

        /// <summary>
        /// Новая игра
        /// </summary>
        public virtual void NewGame()
        {
            NewGame(S, B, C);
        }

        /// <summary>
        /// Следующий шаг
        /// </summary>
        public virtual void NextStep()
        {
            Neighbor count;

            for (int x = 0; x < _map.Width; x++)
            {
                for (int y = 0; y < _map.Height; y++)
                {
                    if (_map[x, y].Status == CellStatus.Normal)
                    {
                        count = GetNeighborCount(x, y);
                        // Клетки умирают
                        if ((count | S) != S && _map[x, y].Step++ >= C)
                            _map.SetCell(x, y, CellStatus.Dead, 0);
                    }
                    else if (_map[x, y].Status == CellStatus.None)
                    {
                        count = GetNeighborCount(x, y);
                        // Клетки рождаются
                        if ((count & B) == B)
                            _map.SetCell(x, y, CellStatus.New, 0);
                    }
                }
            }

            // Убираем мертвые клетки и превращаем новые(рожденные) в обычные
            for (int x = 0; x < _map.Width; x++)
            {
                for (int y = 0; y < _map.Height; y++)
                {
                    if (_map[x, y].Status == CellStatus.Dead)
                        _map.SetCell(x, y, CellStatus.None, 0);
                    else if (_map[x, y].Status == CellStatus.New)
                        _map.SetCell(x, y, CellStatus.Normal, 0);
                }
            }

            OnStep(new EventArgs());
        }

        /// <summary>
        /// Возвращает статус ячейки
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        /// <returns>Статус</returns>
        public virtual CellStatus GetCellStatus(int x, int y)
        {
            if (_map[x, y] == null)
                OnError(new ErrorEventArgs(string.Format("Ячейки в позиции x = {0}, y = {1} не существует.", x, y)));

            return _map[x, y].Status;
        }

        /// <summary>
        /// Возвращает шаг ячейки
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        /// <returns>Шаг</returns>
        public virtual byte GetCellStep(int x, int y)
        {
            if (_map[x, y] == null)
                OnError(new ErrorEventArgs(string.Format("Ячейки в позиции x = {0}, y = {1} не существует.", x, y)));

            return _map[x, y].Step;
        }

        /// <summary>
        /// Устанавливает организм в я чейку
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        public virtual void SetCell(int x, int y)
        {
            _map.SetCell(x, y, CellStatus.Normal, 0);
        }

        /// <summary>
        /// Очищает карту
        /// </summary>
        public virtual void MapClear()
        {
            _map.Clear();
        }

        /// <summary>
        /// Очищает ячейку
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        public virtual void ClearCell(int x, int y)
        {
            _map.SetCell(x, y, CellStatus.None, 0);
        }

        #endregion

        #region " Methods for events "

        private void Map_Created(object sender, EventArgs e)
        {
            OnMapCreated(new MapEventArgs(_map));
        }

        private void Map_Cleaned(object sender, EventArgs e)
        {
            OnMapCleaned(new MapEventArgs(_map));
        }

        private void Map_CellChanged(object sender, CellChangeEventArgs e)
        {
            OnMapCellChanged(new CellChangeEventArgs(e.X, e.Y, e.Value));
        }

        private void Map_SetCellOut(object sender, CellEventArgs e)
        {
            OnMapSetCellOut(new CellEventArgs(e.X, e.Y));
        }

        #endregion
    }
}
