using System.IO;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    private const string FileName = "_.json";

    #region Saving
    public static string defaultChartPath = "";
    public static string defaultMusicPath = "";
    public static float ScreenFps;
    public static bool isNoteClamp = true;
    public static bool[] isGuideAccent = { true, false };

    #endregion

    #region Runtime
    public static bool isGenerating = false;

    #endregion

    private void Awake() { LoadSetting(); }

    private static void SaveSetting()
    {
        string path = Path.Combine(Application.persistentDataPath, FileName);
    }
    private static void LoadSetting()
    {
        string path = Path.Combine(Application.persistentDataPath, FileName);
    }
    private void OnApplicationQuit() { SaveSetting(); }

    [ContextMenu("Reset Saving")]
    public void ResetSaveing()
    {
        string path = Path.Combine(Application.persistentDataPath, FileName);
    }
}
