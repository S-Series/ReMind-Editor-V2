using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager s_this;
    public static List<NoteStruct> s_Notes;

    void Awake()
    {
        if (s_this = null) { s_this = this; }
        s_Notes = new List<NoteStruct>();
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}

public class NoteStruct
{
    public float stdMs;
    public float stdPosY;
    public BaseNote[] Notes = new BaseNote[6];

    public NoteStruct(float posY)
    {
        stdMs = 0;
        stdPosY = posY;
    }
}
