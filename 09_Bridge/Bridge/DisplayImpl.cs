using System;

namespace Bridge
{
    // NOTE: 全部abstractメソッドならinterfaceで良さそう...
    public abstract class DisplayImpl
    {
        public abstract void RawOpen();
        public abstract void RawPrint();
        public abstract void RawClose();
    }
}