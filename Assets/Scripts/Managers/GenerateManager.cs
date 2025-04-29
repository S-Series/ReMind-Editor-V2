using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GenerateManager : MonoBehaviour
{
    public static GenerateManager s_this;

    private static bool isPreviewAvailable = false;
    private static BaseNote.NoteType s_noteType = BaseNote.NoteType.Default;
    private static readonly Vector2 MaxRange = new Vector2(+0.0f, +5.0f);
    private static readonly Vector2 MinRange = new Vector2(-3.2f, -5.0f);
    public static int indexer;
    [SerializeField] private GameObject _prevObject;
    private static GameObject prevObject;
    [SerializeField] private Texture[] _prevTexture;
    private static Texture[] prevTexture;
    private static Transform prevSelect;
    private static Vector3 prevVec = new Vector3();

    [SerializeField] InputAction input;

    private void OnEnable() { input.Enable(); }
    private void OnDisable() { input.Disable(); }

    private void Awake()
    {
        //isGenerating = true;

        prevObject = _prevObject;
        _prevObject = null;

        prevTexture = _prevTexture;
        _prevTexture = null;

        input.performed += Generate;
    }
    private void LateUpdate()
    {
        if (!SettingManager.isGenerating) return;
        if (s_noteType == BaseNote.NoteType.Default) return;
        if (prevSelect == null) return;

        UpdatePreviewPos();
    }

    private static void Generate(InputAction.CallbackContext context)
    {
        if (!isPreviewAvailable) { return; }
        Vector3 targetVec = ConvertToNotepos(prevVec);
    }
    private static Vector3 ConvertToNotepos(Vector2 rawVec)
    {
        Vector3 ret = new Vector3();
        
        return ret;
    }

    private void UpdatePreviewType(BaseNote.NoteType type)
    {
        int index = (int)type;
        if (index == -1 || index > prevTexture.Length) return;
        prevObject.GetComponent<RawImage>().texture = prevTexture[index];
    }
    private static void UpdatePreviewPos()
    {
        if (prevVec == InputManager.s_WorldMousePos) { return; }

        prevVec = InputManager.s_WorldMousePos;
        if (prevVec.x > MaxRange[0] || prevVec.x < MinRange[0]
            || prevVec.y > MaxRange[1] || prevVec.y < MinRange[1])
        { 
            isPreviewAvailable = false;
            prevObject.SetActive(false);
            return;
        }
        else
        {
            isPreviewAvailable = true;
            prevObject.SetActive(true);
        }

        Vector2 vecValue = new Vector2(
            SnapPreviewX(prevVec.x),
            SnapPreviewY(prevVec.y)
        );
        prevSelect.position = new Vector3(vecValue.x, vecValue.y, 0);
    }
    private static float SnapPreviewX(float rawX)
    {
        float ret = 0f;
        //ToDo: 계산 알고리즘 작성
        return ret;
    }
    private static float SnapPreviewY(float rawY)
    {
        float ret = 0f;
        //ToDo: 계산 알고리즘 작성
        return ret;
    }
}
