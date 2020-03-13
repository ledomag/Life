namespace Life.Engine
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// ������
    /// </summary>
    [Serializable]
    public sealed class Cell : ISerializable
    {
        #region " Fields and props "

        /// <summary>
        /// ������
        /// </summary>
        private CellStatus _status;
        /// <summary>
        /// ���
        /// </summary>
        private byte _step;

        /// <summary>
        /// ���������� � �������� ������
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
        /// ���������� � �������� ���
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
        /// ��������� �������� ������
        /// </summary>
        public event EventHandler Created;
        /// <summary>
        /// ��������� ��������� Status
        /// </summary>
        public event EventHandler StatusChanged;
        /// <summary>
        /// ��������� ��������� Step
        /// </summary>
        public event EventHandler StepChanged;

        #endregion

        #region " Ctors "

        /// <summary>
        /// ������� Cell
        /// </summary>
        private Cell(SerializationInfo info, StreamingContext context)
        {
            _status = (CellStatus)info.GetValue("Status", typeof(CellStatus));
            _step = info.GetByte("Step");
        }

        /// <summary>
        /// ������� Cell
        /// </summary>
        /// <param name="status">������</param>
        /// <param name="step">���</param>
        public Cell(CellStatus status, byte step)
        {
            Status = status;
            Step = step;

            OnCreated(new EventArgs());
        }

        /// <summary>
        /// ������� Cell
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
        /// �������� ������� Life.Engine.Cell.Created
        /// </summary>
        /// <param name="e">System.EventArgs �������� ���������� � �������</param>
        private void OnCreated(EventArgs e)
        {
            if (Created != null)
                Created(this, e);
        }

        /// <summary>
        /// �������� ������� Life.Engine.Cell.StatusChanged
        /// </summary>
        /// <param name="e">System.EventArgs �������� ���������� � �������</param>
        private void OnStatusChanged(EventArgs e)
        {
            if (StatusChanged != null)
                StatusChanged(this, e);
        }

        /// <summary>
        /// �������� ������� Life.Engine.Cell.StepChanged
        /// </summary>
        /// <param name="e">System.EventArgs �������� ���������� � �������</param>
        private void OnStepChanged(EventArgs e)
        {
            if (StepChanged != null)
                StepChanged(this, e);
        }
    }
}
