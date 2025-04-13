using System;
using System.Collections.Generic;
using UnityEngine;

public class NormalNote: BaseNote
{
    public async override void UpdatePosY(int posY)
    {
        NoteStruct noteStruct;
        List<NoteStruct> noteList;
        noteList = NoteManager.s_Notes.FindAll(item => item.stdPosY == posY);
        if (noteList.Count < 1) { noteStruct = new NoteStruct(posY); }
        else if (noteList.Count == 1) { noteStruct = noteList[0]; }
        else /**/return;
        {
            
        }

        NoteStruct targetStruct;
        List<NoteStruct> targetList;
        targetList = NoteManager.s_Notes.FindAll(item => item.stdPosY == posY);
        if (targetList.Count < 1) { targetStruct = new NoteStruct(posY); }
        else if (targetList.Count == 1) { targetStruct = targetList[0]; }
        else /**/return;
        {
            
        }

        int lane = base.lane;
        if (targetStruct.Notes[lane] == null)
        {
            if (noteStruct.Notes[lane] != this) { throw new Exception(""); }
            if (targetStruct.Notes[lane] != null)
            {
                bool passed;
                passed = await WarningSystem.ShowPopupAsync("");
                if (!passed) { return; }
            }
            targetStruct.Notes[lane] = this;
            noteStruct.Notes[lane] = null;
        }
    }
    public async override void UpdateLine(int lane)
    {
        
    }
}
