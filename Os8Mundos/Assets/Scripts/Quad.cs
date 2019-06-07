using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour
{
    public Mesh Create(Vector3[] verts, Vector2[] vertsUV, int[] indexes)
    {

        Mesh mesh = new Mesh();
        mesh.name = "Quad";

        mesh.vertices = verts;
        mesh.uv = vertsUV;

        mesh.triangles = indexes;
        mesh.RecalculateNormals();

        return mesh;
    }
}
