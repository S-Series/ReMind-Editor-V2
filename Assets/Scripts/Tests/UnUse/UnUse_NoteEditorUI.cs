using UnityEngine;
using UnityEngine.UIElements;

public class UnUse_NoteEditorUI : MonoBehaviour
{
    public VisualTreeAsset noteUxml;  // 노트 1개짜리 템플릿 (또는 C# 생성)

    private ScrollView scrollView;
    private VisualElement content;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        scrollView = root.Q<ScrollView>("note-scroll");
        content = root.Q<VisualElement>("note-content");

        // 예시로 노트 10개 생성
        for (int i = 0; i < 10; i++)
        {
            var note = CreateNoteElement(i * 100);
            content.Add(note);
        }
    }

    private VisualElement CreateNoteElement(float y)
    {
        var note = new VisualElement();
        note.AddToClassList("note");

        // 수동 위치 조정 (절대 위치)
        note.style.position = Position.Absolute;
        note.style.left = 50;
        note.style.top = y;

        note.RegisterCallback<ClickEvent>(evt =>
        {
            Debug.Log($"노트 클릭됨: y={y}");
            // 선택 효과 등 추가 가능
        });

        return note;
    }
}
