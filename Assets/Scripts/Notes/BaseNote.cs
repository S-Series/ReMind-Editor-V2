using System;
using UnityEngine;

public class BaseNote : MonoBehaviour
{
    public float ms;
    public int posY;
    public int lane;
    public int length;

    public virtual void UpdateLine(int lane)
    {
        throw new SystemException("Line Override Failed");
    }
    public virtual void UpdatePosY(int posY)
    {
        throw new SystemException("PosY Override Failed");
    }

    public virtual void EffectNote()
    {
        // Nothings Here...
    }
}
