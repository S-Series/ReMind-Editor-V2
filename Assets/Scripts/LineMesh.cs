using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class LineMesh : MonoBehaviour
{
    void Start()
    {
        Updatemesh(2, 1, new float[2]{1, 1});
    }

    public void Updatemesh(int length, int ends, float[] widths)
    {
        Mesh mesh = new Mesh();
        MeshFilter meshFilter = GetComponent<MeshFilter>();
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
