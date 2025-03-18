using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager s_this;
    public static Vector3 s_WorldPos;
    private void Awake()
    {
        if (s_this == null) s_this = this;
        else Destroy(this);
    }
    private void LateUpdate()
    {
        s_WorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        s_WorldPos.z = 0f;
    }
}
