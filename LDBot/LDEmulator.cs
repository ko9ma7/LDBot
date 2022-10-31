using System;

namespace LDBot
{
    public class LDEmulator : IEquatable<LDEmulator>
    {
        private int _index;
        private string _name;
        private IntPtr _topHandle;
        private IntPtr _bindHandle;
        private bool _isRunning;
        private int _pID;
        private int _vBoxPID;

        #region Constructor
        public LDEmulator() { }

        public LDEmulator(int index, string name, IntPtr topHandle, IntPtr bindHandle, bool isRunning, int pID, int vBoxPID)
        {
            this._index = index;
            this._name = name;
            this._topHandle = topHandle;
            this._bindHandle = bindHandle;
            this._isRunning = isRunning;
            this._pID = pID;
            this._vBoxPID = vBoxPID;
        }
        #endregion

        #region Get_Set
        public int VboxPID
        {
            get { return _vBoxPID; }
            set { _vBoxPID = value; }
        }

        public int pID
        {
            get { return _pID; }
            set { _pID = value; }
        }

        public bool isRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; }
        }

        public IntPtr BindHandle
        {
            get { return _bindHandle; }
            set { _bindHandle = value; }
        }

        public IntPtr TopHandle
        {
            get { return _topHandle; }
            set { _topHandle = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        #endregion
        public bool Equals(LDEmulator other)
        {
            return other.Index == this.Index;
        }
    }
}
