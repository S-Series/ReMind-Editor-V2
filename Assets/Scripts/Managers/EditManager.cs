using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class EditManager : MonoBehaviour
{
    public static EditManager s_this;
    [SerializeField] GameObject warningPopup;
    [SerializeField] TextMeshPro warningText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Task<bool> EditWarning(string message)
    {
        TaskCompletionSource<bool> tcs;
        s_this.warningPopup.SetActive(true);
        s_this.warningText.text = message;

        tcs = new TaskCompletionSource<bool>();
        return tcs.Task;
    }
}
