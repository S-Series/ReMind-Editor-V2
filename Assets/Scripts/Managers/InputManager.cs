using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager s_this;
    public static Vector3 s_WorldMousePos;

    private void Awake()
    {
        if (s_this == null) s_this = this;
        else Destroy(gameObject);
    }
    private void LateUpdate()
    {
        s_WorldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        s_WorldMousePos.z = 0f;
        Debug.Log(s_WorldMousePos);
    }

    private void NoteJudge(InputAction.CallbackContext context, int lane)
    {
        double judgeTime = context.time - GameManager.s_GameStartTime;
    }
}
