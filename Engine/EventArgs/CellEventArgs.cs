namespace Life.Engine
{
    using System;

    /// <summary>
    /// Предоставляет информацию о координатах ячейки
    /// </summary>
    public class CellEventArgs : EventArgs
    {
        /// <summary>
        /// Возвращает значение позиции x
        /// </summary>
        public int X { get; private set; }
        /// <summary>
        /// Возвращает значение позиции y
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Создает CellEventArgs
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        public CellEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// Представляет метод, обрабатывающий события
    /// </summary>
    /// <param name="sender">Источник события</param>
    /// <param name="e">Объект CellEventArgs, содержащий данные события</param>
    public delegate void CellEventHandler(object sender, CellEventArgs e);
}
