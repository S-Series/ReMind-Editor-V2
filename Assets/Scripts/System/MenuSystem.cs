using UnityEngine;
using UnityEngine.UIElements;

public class MenuSystem : MonoBehaviour
{
    private VisualElement submenu;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var menuButton = root.Q<Button>("menu-button");
        submenu = root.Q<VisualElement>("submenu");

        menuButton.clicked += () => submenu.style.display = 
            submenu.style.display == DisplayStyle.Flex ? DisplayStyle.None : DisplayStyle.Flex;
    }
}
