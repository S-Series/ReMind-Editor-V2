using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class LineMesh : MonoBehaviour
{
    void Start()
    {
        Updatemesh(2, 0, 1, 1, 1);
    }

    /// <param name="length">메쉬가 얼마만큼의 길이를 가질지</param>
    /// <param name="ends">메쉬의 중심축의 종료 위치 [+: 우측, -: 좌측]</param>
    /// <param name="widths">메쉬의 시작, 종료의 길이</param>
    public void Updatemesh(int length, int ends,params float[] widths)
    {
        if (widths.Length < 2) { widths = new float[2] { 1f, 1f }; }

        TryGetComponent<MeshFilter>(out MeshFilter meshFilter);
        if (meshFilter == null) return;

        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[]{
            new Vector3(-widths[0] / 2, 0, 0),
            new Vector3(+widths[0] / 2, 0, 0),
            new Vector3(-widths[1] / 2 + ends * 2, length, 0),
            new Vector3(+widths[1] / 2 + ends * 2, length, 0)
        };
        mesh.triangles = new int[]{
            0, 1, 2,
            2, 1, 3
        };
        mesh.uv = new Vector2[]{
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        meshFilter.mesh = mesh;
    }
}
