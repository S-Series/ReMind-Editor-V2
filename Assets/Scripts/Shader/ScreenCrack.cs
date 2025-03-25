using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class ScreenCrack : MonoBehaviour
{
    public Material screenCrackMaterial;
    private float distortion = 0f;

    private void Start()
    {
        TriggerCrack();
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (screenCrackMaterial != null)
        {
            screenCrackMaterial.SetFloat("_Distortion", distortion);
            Graphics.Blit(src, dest, screenCrackMaterial);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }

    public void TriggerCrack()
    {
        StartCoroutine(CrackEffect());
    }

    private IEnumerator CrackEffect()
    {
        distortion = 0f;
        while (distortion < 1f)
        {
            distortion += Time.deltaTime * 0.5f;
            yield return null;
        }
    }
}
