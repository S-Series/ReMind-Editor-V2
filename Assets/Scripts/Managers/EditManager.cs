using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class EditManager : MonoBehaviour
{
    public static EditManager s_this;
    public static BaseNote s_noteSelected;

    public static void EditPosY(int inputPosY)
    {
        if (s_noteSelected == null) return;
        if (s_noteSelected.posY == inputPosY) { return; }

        int startPosY, targetPosY;
        startPosY = s_noteSelected.posY;
        targetPosY = inputPosY;

        NoteStruct startStruct, targetStruct;
        startStruct = NoteManager.GetNoteStruct(startPosY);
        targetStruct = NoteManager.GetNoteStruct(targetPosY);

        int laneIndex;
        laneIndex = s_noteSelected.lane - 1;
        if (laneIndex < 0) throw new ArgumentOutOfRangeException(nameof(laneIndex));
        if (s_noteSelected.GetType() == typeof(NormalNote)) {}
        if (s_noteSelected != startStruct.Notes[laneIndex]) 
            throw new Exception("Selected Note doesn't match");
        
        BaseNote dataHolder;
        dataHolder = targetStruct.Notes[laneIndex];

        targetStruct.Notes[laneIndex] = s_noteSelected;
        startStruct.Notes[laneIndex] = dataHolder;
    }
    public static void EditPosY(bool isIncreased, bool isSingle = false)
    {
        if (s_noteSelected == null) return;

        int posY = s_noteSelected.posY;
        if (isIncreased) EditPosY(isSingle ? posY + 1 : posY + 400);
        else EditPosY(Mathf.Max((isSingle ? posY - 1 : posY - 400), 0));
    }
    public static void EditLane(int inputLane)
    {
        if (s_noteSelected == null) return;

    }
    public static void EditLane(bool isIncresed)
    {
        if (s_noteSelected == null) return;

    }
    public static void EditLength(int inputLength)
    {
        if (s_noteSelected == null) return;

    }
    public static void EditLength(bool isIncreased, bool isSingle = false)
    {
        if (s_noteSelected == null) return;

    }
}
