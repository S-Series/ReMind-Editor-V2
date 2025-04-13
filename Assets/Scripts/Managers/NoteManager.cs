using System.Linq;
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

    /// <summary> posY값의 [노트 구조체]를 반환, 없으면 구조체를 생성해서 반환 </summary>
    public static NoteStruct GetNoteStruct(int posY)
    {
        NoteStruct ret;
        ret = s_Notes.Find(item => item.stdPosY == posY);
        if (ret == null)
        {
            ret = new NoteStruct(posY);
            s_Notes.Add(ret);
            s_Notes.OrderBy(item => item.stdPosY);
        }
        return ret;
    }
}

public class NoteStruct
{
    public float stdMs;
    public float stdPosY;
    public BaseNote[] Notes = new BaseNote[10];

    public NoteStruct(float posY)
    {
        stdMs = 0;
        stdPosY = posY;
        Notes = new BaseNote[6];
    }
}
