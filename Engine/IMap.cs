namespace Life.Engine
{
    using System;

    /// <summary>
    /// Карта
    /// </summary>
    public interface IMap
    {
        /// <summary>
        /// Возвращает значение ширины карты
        /// </summary>
        int Width { get; }
        /// <summary>
        /// Возвращает значение высоты карты
        /// </summary>
        int Height { get; }
        /// <summary>
        /// Возвращает значение ячейки
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        /// <returns>Ячейка</returns>
        Cell this[int x, int y] { get; }

        /// <summary>
        /// Произошло создание карты
        /// </summary>
        event EventHandler Created;
        /// <summary>
        /// Произошла очистка карты
        /// </summary>
        event EventHandler Cleaned;
        /// <summary>
        /// Произошло изменение значения в ячейке
        /// </summary>
        event CellChangeEventHandler CellChanged;
        /// <summary>
        /// Произошло обращение за пределы карты
        /// </summary>
        event CellEventHandler SetCellOut;

        /// <summary>
        /// Очистить карту
        /// </summary>
        void Clear();

        /// <summary>
        /// Возвращает значение ячейки
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        /// <returns>Ячейка</returns>
        Cell GetCell(int x, int y);

        /// <summary>
        /// Устанавливает значение ячейки
        /// </summary>
        /// <param name="x">Позиция x</param>
        /// <param name="y">Позиция y</param>
        /// <param name="status">Статус ячейки</param>
        /// <param name="step">Шаг ячейки</param>
        void SetCell(int x, int y, CellStatus status, byte step);
    }
}
