namespace Life.Engine
{
    /// <summary>
    /// Статус ячейки
    /// </summary>
    public enum CellStatus : byte
    {
        /// <summary>
        /// Пусто
        /// </summary>
        None = 0,
        /// <summary>
        /// Нормальный организм
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Умирающий организм
        /// </summary>
        Dead = 2,
        /// <summary>
        /// Рождающийся организм
        /// </summary>
        New = 3
    }
}
