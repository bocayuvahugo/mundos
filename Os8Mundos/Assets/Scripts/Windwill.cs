using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windwill : MonoBehaviour
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
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Colors/Gray"));
        }
        else if (currentWorld == 3 || currentWorld == 4)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/BrickWall"));
        }
        else if (currentWorld >= 5)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/BrickWall"));
            this.GetComponent<MeshRenderer>().material.shader = Resources.Load<Shader>("Effects/MorphingTexture");
        }
    }

    void GetVertex()
    {
        verts = new Vector3[]
        {
            //Frente
            new Vector3(-2,0,0), //v0
            new Vector3(-2,16,0), //v1
            new Vector3(2,16,0), //v2
            new Vector3(2,0,0), //v3

            //Lateral 1
            new Vector3(-2,0,-8), //v4
            new Vector3(-2,16,0), //v5
            new Vector3(-2,0,0), //v6
            new Vector3(-2,16,-2),  //v7 

            //Lateral 2
            new Vector3(2,0,-8),  //v8
            new Vector3(2,16,0), //v9
            new Vector3(2,0,0), //v10
            new Vector3(2,16,-2), //v11                   

             //Costas
            new Vector3(2,16,-2), //v12
            new Vector3(-2,16,-2), //v13
            new Vector3(-2,0,-8), //v14
            new Vector3(2,0,-8),  //v15

            //Topo
            new Vector3(-2,16,0),//v16
            new Vector3(-2,16,-2), //v17
            new Vector3(2,16,0), //v18
            new Vector3(2,16,-2), //v19

            //Lateral 1, eixo
            new Vector3(-0.25f,14.5f,0), //v20
            new Vector3(-0.25f,15,0), //v21
            new Vector3(-0.25f,15,2), //v22
            new Vector3(-0.25f,14.5f,2), //v23

            //Lateral 2, eixo
            new Vector3(0.25f,14.5f,0), //v24
            new Vector3(0.25f,15,0), //v25
            new Vector3(0.25f,15,2), //v26
            new Vector3(0.25f,14.5f,2), //v27

            //Topo, eixo
            new Vector3(-0.25f,15,2), //v28
            new Vector3(-0.25f,15,0), //v29
            new Vector3(0.25f,15,0), //v30
            new Vector3(0.25f,15,2), //v31

            //Base, eixo
            new Vector3(-0.25f,14.5f,2), //v32
            new Vector3(-0.25f,14.5f,0), //v33
            new Vector3(0.25f,14.5f,0), //v34
            new Vector3(0.25f,14.5f,2), //v35
        };

        vertsUV = new Vector2[]
        {
            new Vector2(1,1),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(0,1),

            new Vector2(1,1),
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,0),

            new Vector2(1,1),
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,0),         

            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),

            new Vector2(1,1),
            new Vector2(1,0),
            new Vector2(0,1),
            new Vector2(0,0),

            new Vector2(1,0),
            new Vector2(1,1),
            new Vector2(0,1),
            new Vector2(0,0),

            new Vector2(1,0),
            new Vector2(1,1),
            new Vector2(0,1),
            new Vector2(0,0),

            new Vector2(1,1),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(0,1),
           
            new Vector2(1,1),
            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(0,1),
            
        };

        index = new int[]
        {
            0,1,2,
            1,2,3,

            5,4,6,
            6,7,5,

            8,9,10,
            11,10,9,

            14,15,13,
            13,12,14,

            16,17,19,
            19,17,18,

            20,23,22,
            22,21,20,

            24,27,26,
            26,25,24,

            28,31,30,
            30,29,31,

            32,35,34,
            34,33,35,
        };
    }
}
