using UnityEngine;

public class NormalNote: BaseNote
{
    public async override void UpdateLine(int lane)
    {
        if (NoteManager.s_Notes.Exists(item 
            => item.posY == base.posY 
            && item.lane == base.lane))
        {
            bool isEdit = await EditManager.EditWarning("");
        };

        base.lane = lane;
    }
    public override void UpdatePosY(int posY)
    {
        base.posY = posY;
    }
}
