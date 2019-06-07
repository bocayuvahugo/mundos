using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooftop : MonoBehaviour
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
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Colors/Brick"));
        }
        else if (currentWorld == 3 || currentWorld == 4)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/Rooftop"));
        }
        else if (currentWorld >= 5)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/Rooftop"));
            this.GetComponent<MeshRenderer>().material.shader = Resources.Load<Shader>("Effects/Morphing");
        }
    }
    void GetVertex()
    {
        verts = new Vector3[]
        {
           //Cima
           new Vector3(-7,10,-13), //v0
           new Vector3(-7,10,1), //v1
           new Vector3(7,10,1), //v2
           new Vector3(7,10,-13), //v3

           //Baixo
           new Vector3(-7,8,-13), //v4
           new Vector3(-7,8,1), //v5
           new Vector3(7,8,1), //v6
           new Vector3(-7,8,-13), //v7

           //Frente
           new Vector3(-7,10,1), //v8
           new Vector3(7,10,1), //v9
           new Vector3(-7,8,1), //v10
           new Vector3(7,8,1), //v11

           //Costas
           new Vector3(7,10,-13), //v12
           new Vector3(-7,8,-13), //v13
           new Vector3(7,8,-13), //v14
           new Vector3(-7,10,-13), //v15

           //Lateral 1
           new Vector3(-7,10,-13), //v16
           new Vector3(-7,8,1), //v17
           new Vector3(-7,8,-13), //v18
           new Vector3(-7,10,1), //v19

           //Lateral 2
           new Vector3(7,8,1), //v20
           new Vector3(7,10,-13), //v21
           new Vector3(7,8,-13), //v22
           new Vector3(7,10,1), //v23
        };

        vertsUV = new Vector2[]
        {
            new Vector2 (1,1),
            new Vector2 (0,0),
            new Vector2 (0,1),
            new Vector2 (1,0),

            new Vector2 (1,1),
            new Vector2 (0,0),
            new Vector2 (0,1),
            new Vector2 (1,0),

            new Vector2 (1,0),
            new Vector2 (0,0),
            new Vector2 (1,1),
            new Vector2 (0,1),

            new Vector2 (1,0),
            new Vector2 (0,1),
            new Vector2 (1,1),
            new Vector2 (0,0),

            new Vector2 (1,0),
            new Vector2 (0,1),
            new Vector2 (1,1),
            new Vector2 (0,0),

            new Vector2 (1,1),
            new Vector2 (0,0),
            new Vector2 (0,1),
            new Vector2 (1,0),

        };

        index = new int[]
        {
            0,3,2,
            2,3,1,

            4,7,6,
            6,7,5,

            8,9,11,
            11,10,8,

            12,13,15,
            15,14,12,

            16,17,19,
            19,18,16,

            20,23,22,
            22,23,21,
        };
    }
}
