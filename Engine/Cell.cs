namespace Life.Engine
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// Ячейка
    /// </summary>
    [Serializable]
    public sealed class Cell : ISerializable
    {
        #region " Fields and props "

        /// <summary>
        /// Статус
        /// </summary>
        private CellStatus _status;
        /// <summary>
        /// Шаг
        /// </summary>
        private byte _step;

        /// <summary>
        /// Возвращает и изменяет статус
        /// </summary>
        public CellStatus Status
        {
            get { return _status; }

            set
            {
                _status = value;
                OnStatusChanged(new EventArgs());
            }
        }

        /// <summary>
        /// Возвращает и изменяет шаг
        /// </summary>
        public byte Step
        {
            get { return _step; }

            set
            {
                _step = value;
                OnStepChanged(new EventArgs());
            }
        }

        #endregion

        #region " Events "

        /// <summary>
        /// Произошло создание ячейки
        /// </summary>
        public event EventHandler Created;
        /// <summary>
        /// Произошло изменение Status
        /// </summary>
        public event EventHandler StatusChanged;
        /// <summary>
        /// Произошло изменение Step
        /// </summary>
        public event EventHandler StepChanged;

        #endregion

        #region " Ctors "

        /// <summary>
        /// Создает Cell
        /// </summary>
        private Cell(SerializationInfo info, StreamingContext context)
        {
            _status = (CellStatus)info.GetValue("Status", typeof(CellStatus));
            _step = info.GetByte("Step");
        }

        /// <summary>
        /// Создает Cell
        /// </summary>
        /// <param name="status">Статус</param>
        /// <param name="step">Шаг</param>
        public Cell(CellStatus status, byte step)
        {
            Status = status;
            Step = step;

            OnCreated(new EventArgs());
        }

        /// <summary>
        /// Создает Cell
        /// </summary>
        public Cell() 
            : this(CellStatus.None, 0) { }

        #endregion

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Status", _status, typeof(CellStatus));
            info.AddValue("Step", _step);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Cell.Created
        /// </summary>
        /// <param name="e">System.EventArgs содержит информацию о событии</param>
        private void OnCreated(EventArgs e)
        {
            if (Created != null)
                Created(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Cell.StatusChanged
        /// </summary>
        /// <param name="e">System.EventArgs содержит информацию о событии</param>
        private void OnStatusChanged(EventArgs e)
        {
            if (StatusChanged != null)
                StatusChanged(this, e);
        }

        /// <summary>
        /// Вызывает событие Life.Engine.Cell.StepChanged
        /// </summary>
        /// <param name="e">System.EventArgs содержит информацию о событии</param>
        private void OnStepChanged(EventArgs e)
        {
            if (StepChanged != null)
                StepChanged(this, e);
        }
    }
}
