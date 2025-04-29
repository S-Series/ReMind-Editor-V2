using System.Collections.Generic;
using UnityEngine;

public class NoteGuide : MonoBehaviour
{
    private static int guideCount = 0;
    private static int parentCount = 0;
    private static int[] maxCount = { 0, 0 };
    [SerializeField] Transform guideField;
    [SerializeField] GameObject guidePrefab;
    private List<GameObject> guideParents;

    public void GuideParentUpdate(int endPos)
    {
        int count = Mathf.FloorToInt(endPos / 1600f) + 1;

        for (int i = parentCount; i < count; i++)
        {
            GameObject copy = new GameObject($"Guide Parent {i + 1}");
            copy.transform.parent = guideField;
            copy.transform.localPosition = new Vector3(0, i * 1600, 0);
            for (int j = 0; j < maxCount[0]; j++)
            {
                GameObject guideCopy = Instantiate(guidePrefab, copy.transform);
                guideCopy.name = $"{j}";
                guideCopy.transform.localPosition = new Vector3(0, GameManager.s_NoteClampData[j], 0);
                guideCopy.SetActive(j < guideCount);
            }
            guideParents.Add(copy);
        }
    }

    public void GuideUpdate (int count = 8)
    {
        guideCount = Mathf.Max(count, guideCount);
    }
}
