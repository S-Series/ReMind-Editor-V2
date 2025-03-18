using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using SFB;

public class FileManager : MonoBehaviour
{
    private static readonly string defaultDir = Application.persistentDataPath;
    private static ExtensionFilter[] extensions;

    private void Awake()
    {
        extensions = new[]{
            new ExtensionFilter("JSON Files", "json"),
            new ExtensionFilter("All Files", "*"),
        };
    }

    public static string GetSaveFilePath()
    {
        string ret = StandaloneFileBrowser.SaveFilePanel(
            "Saving File", defaultDir, 
            "My Chart", extensions
        );
        return ret;
    }
    public static string GetLoadFilePath()
    {
        string ret;
        string[] paths = StandaloneFileBrowser.OpenFilePanel(
            "Loading File", defaultDir,
            extensions, false
        );

        if (paths.Length < 1) { ret = String.Empty; }
        else if (string.IsNullOrEmpty(paths[0])) { ret = String.Empty; }
        else { ret = paths[0]; }

        return ret;
    }

    public static void ReadJson(string path)
    {
        if (path == String.Empty) return;
        string data = File.ReadAllText(path);
    }
    public async static void WriteJson(string path, ChartData data)
    {
        if (path == String.Empty) return;

        if (File.Exists(path))
        {
            if (!await WarningSystem.ShowPopupAsync("정말 파일을 덮어쓰겠습니까?")) { return; };
        }
        
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }
}

[Serializable]
public class ChartData
{
    public string chartName;
    public float startBpm;
    public int startDelay;
    public List<NoteData> notes = new List<NoteData>();
}

[Serializable]
public class NoteData
{
    //int stdMs, lane, length, typeIndex, effectIndex;
    //float effectValue;
    public int stdMs;
    public int[] length = { 0, 0, 0, 0, 0, 0 };
    public int[] typeIndex = { 0, 0, 0, 0, 0, 0 };
    public int[] effectIndex = { 0, 0, 0, 0, 0, 0 };
    public float[] value = { 0f, 0f, 0f, 0f, 0f, 0f };
    public float[] effectValue = { 0f, 0f, 0f, 0f, 0f, 0f };
}
