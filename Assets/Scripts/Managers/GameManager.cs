using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static float s_GameStartTime = 0;

    public static void GameStart()
    {
        s_GameStartTime = Time.realtimeSinceStartup;
    }
}
