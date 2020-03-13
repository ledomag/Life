namespace Life.Engine
{
    using System;

    /// <summary>
    /// Предоставляет информацию о карте
    /// </summary>
    public class MapEventArgs : EventArgs
    {
        /// <summary>
        /// Возвращает карту
        /// </summary>
        public IMap Map { get; private set; }

        /// <summary>
        /// Создает MapEventArgs
        /// </summary>
        /// <param name="map">Карта</param>
        public MapEventArgs(IMap map)
        {
            Map = map;
        }
    }

    /// <summary>
    /// Представляет метод, обрабатывающий события
    /// </summary>
    /// <param name="sender">Источник события</param>
    /// <param name="e">Объект MapEventArgs, содержащий данные события</param>
    public delegate void MapEventHandler(object sender, MapEventArgs e);
}
