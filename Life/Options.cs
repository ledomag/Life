namespace Life
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Xml.Serialization;

    using Life.Engine;

    /// <summary>
    /// Опции игры
    /// </summary>
    [Serializable]
    public struct Options
    {
        #region " Fields and props "

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
        /// Цвет заливки карты
        /// </summary>
        public UniversalColor MapBackground;
        /// <summary>
        /// Цвет сетки
        /// </summary>
        public UniversalColor SharpColor;
        /// <summary>
        /// Цвет ячейки. Начальный цвет градиента
        /// </summary>
        public UniversalColor CellColor1;
        /// <summary>
        /// Цвет ячейки. Конечный цвет градиента
        /// </summary>
        public UniversalColor CellColor2;

        /// <summary>
        /// Опции по умолчанию
        /// </summary>
        public static Options Default
        {
            get
            {
                Options options = new Options();
                options.S = Neighbor.Two | Neighbor.Three;
                options.B = Neighbor.Three;
                options.C = 0;
                options.MapBackground = Color.White;
                options.SharpColor = Color.Black;
                options.CellColor1 = Color.Red;
                options.CellColor2 = Color.White;

                return options;
            }
        }

        #endregion

        /// <summary>
        /// Загрузить из файла
        /// </summary>
        /// <param name="path">Путь файла</param>
        /// <returns>Опции</returns>
        public static Options Load(string path)
        {
            Options opt = Options.Default;

            using (FileStream fs = File.OpenRead(path))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Options));
                opt = (Options)xs.Deserialize(fs);
            }

            return opt;
        }

        /// <summary>
        /// Сохранить в файл
        /// </summary>
        /// <param name="path">Путь файла</param>
        /// <param name="options">Опции</param>
        public static void Save(string path, Options options)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Options));
                xs.Serialize(fs, options);
            }
        }
    }
}
