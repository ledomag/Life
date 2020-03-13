namespace Life.Engine
{
    using System;

    /// <summary>
    /// Предоставляет информацию об ошибке
    /// </summary>
    public class ErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Возвращает сообщение об ошибке
        /// 
        /// Примечание: Текущее сообщение может не совпадать с сообщением в объекте Exception поля Error
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// Возвращает Exception
        /// </summary>
        public Exception Error { get; private set; }

        /// <summary>
        /// Создает ErrorEventArgs
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="error">Ошибка</param>
        public ErrorEventArgs(string message, Exception error)
        {
            Message = message;
            Error = error;
        }

        /// <summary>
        /// Создает ErrorEventArgs
        /// </summary>
        /// <param name="error">Ошибка</param>
        public ErrorEventArgs(Exception error)
            : this(null, error)
        {
            if (error != null)
                Message = error.Message;
        }

        /// <summary>
        /// Создает ErrorEventArgs
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public ErrorEventArgs(string message)
            : this(new Exception(message)) { }

        /// <summary>
        /// Создает ErrorEventArgs с сообщением "Неизвестная ошибка."
        /// </summary>
        public ErrorEventArgs()
            : this("Неизвестная ошибка.") { }
    }

    /// <summary>
    /// Представляет метод, обрабатывающий события
    /// </summary>
    /// <param name="sender">Источник события</param>
    /// <param name="e">Объект ErrorEventArgs, содержащий данные события</param>
    public delegate void ErrorEventHandler(object sender, ErrorEventArgs e); 
}
