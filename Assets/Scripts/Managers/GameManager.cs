using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static float s_GameStartTime = 0;
    public static float[] s_NoteClampData;

    public static void GameStart()
    {
        s_GameStartTime = Time.realtimeSinceStartup;
    }
    public static void UpdateNoteClamp(int count)
    {
        s_NoteClampData = new float[count + 1];
        for (int i = 0; i < count; i++)
        {
            s_NoteClampData[i] = Mathf.FloorToInt((16000f * i) / count) / 10f;
        }
        s_NoteClampData[count] = 1600f;
    }
}
