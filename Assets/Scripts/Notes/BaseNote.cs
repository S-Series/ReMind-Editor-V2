using System;
using UnityEngine;

public class BaseNote : MonoBehaviour
{
    public enum NoteType
    {
        Default = -1, //! Error Occured || Unuse type
        Normal = 0,
        Sky = 1,
        Bottom = 2,
        Bpm = 3,
        Effect = 4
    }
    public float ms;
    public int posY;
    public int lane;
    public int length;
    public NoteType type = NoteType.Default; //! Override in child class

    public virtual void UpdateLine(int lane)
    {
        throw new Exception("Line Override Failed");
    }
    public virtual void UpdatePosY(int posY)
    {
        throw new Exception("PosY Override Failed");
    }

    public virtual void EffectNote()
    {
        // Nothings Here...
    }

    public BaseNote() { throw new Exception("This Method is Unuse"); }
}
