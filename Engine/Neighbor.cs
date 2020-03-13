namespace Life.Engine
{
    using System;

    /// <summary>
    /// Количество соседей
    /// </summary>
    [Flags]
    public enum Neighbor : ushort
    {
        /// <summary>
        /// Нет
        /// </summary>
        None = 0,
        /// <summary>
        /// 0 соседей
        /// </summary>
        Zero = 1,
        /// <summary>
        /// 1 сосед
        /// </summary>
        One = 2,
        /// <summary>
        /// 2 соседа
        /// </summary>
        Two = 4,
        /// <summary>
        /// 3 соседа
        /// </summary>
        Three = 8,
        /// <summary>
        /// 4 соседа
        /// </summary>
        Four = 16,
        /// <summary>
        /// 5 соседей
        /// </summary>
        Five = 32,
        /// <summary>
        /// 6 соседей
        /// </summary>
        Six = 64,
        /// <summary>
        /// 7 соседей
        /// </summary>
        Seven = 128,
        /// <summary>
        /// 8 соседей
        /// </summary>
        Eight = 256
    }
}
