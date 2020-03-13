namespace Life.Engine
{
    /// <summary>
    /// Предоставляет информацию о ячейке
    /// </summary>
    public class CellChangeEventArgs : CellEventArgs
    {
        /// <summary>
        /// Возращает ячейку
        /// </summary>
        public Cell Value { get; private set; }

        /// <summary>
        /// Создает CellChangeEventArgs
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        /// <param name="value">Ячейка</param>
        public CellChangeEventArgs(int x, int y, Cell value)
            : base(x, y)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Представляет метод, обрабатывающий события
    /// </summary>
    /// <param name="sender">Источник события</param>
    /// <param name="e">Объект CellChangeEventArgs, содержащий данные события</param>
    public delegate void CellChangeEventHandler(object sender, CellChangeEventArgs e);
}
