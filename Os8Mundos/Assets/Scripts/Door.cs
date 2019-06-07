using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
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
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Colors/Brown"));
        }
        else if (currentWorld == 3 || currentWorld == 4)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/Door"));
        }
        else if (currentWorld >= 5)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/Door"));
            this.GetComponent<MeshRenderer>().material.shader = Resources.Load<Shader>("Effects/Morphing");
        }
    }

    void GetVertex()
    {
        verts = new Vector3[]
        {
             //Porta Frente
             new Vector3(-1,4,0), //v0
             new Vector3(1,0,0), //v1 
             new Vector3(-1,0,0), //v2
             new Vector3(1,4,0), //v3

             //Porta Costas
             new Vector3(-1,4,-12), //v4
             new Vector3(1,4,-12), //v7
             new Vector3(1,0,-12), //v5 
             new Vector3(-1,0,-12), //v6

        };

        vertsUV = new Vector2[]
        {
            new Vector2 (1,0),
            new Vector2 (0,0),
            new Vector2 (1,1),
            new Vector2 (0,1),

            new Vector2 (0,0),
            new Vector2 (1,1),
            new Vector2 (1,0),
            new Vector2 (0,1),

        };

        index = new int[]
        {
           0,1,2,
           2,1,3,

           4,7,6,
           6,5,7,
        };

    }
}
