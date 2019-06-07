using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Quad quad;
    Vector3[] verts;
    Vector2[] vertsUV;
    int[] index;
    public int currentWorld;

    void Start()
    {
        quad = this.gameObject.AddComponent<Quad>();
        GetVertex();

        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.AddComponent<MeshRenderer>();
        this.gameObject.AddComponent<Quad>();
        Mesh mesh = quad.Create(verts, vertsUV, index);
        this.GetComponent<MeshFilter>().mesh = mesh;

        if (currentWorld <= 2)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Colors/Green"));
        }
        else if (currentWorld == 3 || currentWorld == 4)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/Grass"));
        }
        if (currentWorld >= 5)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/Grass"));
            this.GetComponent<MeshRenderer>().material.shader = Resources.Load<Shader>("Effects/Morphing");
        }
    }
    void GetVertex()
    {
        verts = new Vector3[]
        {
            new Vector3(-50,0,20), //v0
            new Vector3(-50,0,-100), //v1
            new Vector3(50,0,-100), //v2
            new Vector3(50,0,20), //v3
        };

        vertsUV = new Vector2[]
        {
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(1,1),
        };

        index = new int[]
        {
            0,3,2,
            2,1,0,
        };
    }
}
