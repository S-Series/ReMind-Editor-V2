using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class WarningSystem : MonoBehaviour
{
    public static Text messageText;
    public static Button yesButton;
    public static Button noButton;
    public static GameObject popupPanel;
    public Text _messageText;
    public Button _yesButton;
    public Button _noButton;
    public GameObject _popupPanel;

    private static TaskCompletionSource<bool> tcs;

    void Start()
    {
        messageText = _messageText;
        yesButton = _yesButton;
        noButton = _noButton;
        popupPanel = _popupPanel;

        popupPanel.SetActive(false); // 처음에는 비활성화
        yesButton.onClick.AddListener(() => OnButtonClicked(true));
        noButton.onClick.AddListener(() => OnButtonClicked(false));
    }

    public static Task<bool> ShowPopupAsync(string message)
    {
        popupPanel.SetActive(true);
        messageText.text = message;
        tcs = new TaskCompletionSource<bool>();
        return tcs.Task;
    }

    private static void OnButtonClicked(bool result)
    {
        popupPanel.SetActive(false);
        tcs.TrySetResult(result);
    }
}