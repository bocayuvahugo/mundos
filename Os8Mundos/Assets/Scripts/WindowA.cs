using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowA : MonoBehaviour
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
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Colors/Purple"));
        }
        else if (currentWorld == 3 || currentWorld == 4)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/WindowA"));
        }
        else if (currentWorld >= 5)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/WindowA"));
            this.GetComponent<MeshRenderer>().material.shader = Resources.Load<Shader>("Effects/Morphing");
        }
    }

    void GetVertex()
    {
        verts = new Vector3[]
        {
            //Janela de duas portas, lateral 1
            new Vector3(5,6,-2),
            new Vector3(5,2,-2),
            new Vector3(5,6,-3.5f),
            new Vector3(5,2,-3.5f),

            new Vector3(5,6,-5),
            new Vector3(5,6,-3.5f),
            new Vector3(5,2,-5),
            new Vector3(5,2,-3.5f),
                                        
            //Janela de duas portas, lateral 2
            new Vector3(-5,6,-2),
            new Vector3(-5,6,-3.5f),
            new Vector3(-5,2,-2),
            new Vector3(-5,2,-3.5f),

            new Vector3(-5,6,-5),
            new Vector3(-5,2,-5),
            new Vector3(-5,6,-3.5f),
            new Vector3(-5,2,-3.5f),
        };

        vertsUV = new Vector2[]
        {
            new Vector2 (1,0),
            new Vector2 (1,1),
            new Vector2 (0,0),
            new Vector2 (0,1),

            new Vector2 (1,0),
            new Vector2 (0,0),
            new Vector2 (1,1),
            new Vector2 (0,1),

            new Vector2 (1,0),
            new Vector2 (0,0),
            new Vector2 (1,1),
            new Vector2 (0,1),


            new Vector2 (1,0),
            new Vector2 (1,1),
            new Vector2 (0,0),
            new Vector2 (0,1),
        };

        index = new int[]
        {
            0,2,3,
            3,1,0,

            4,5,6,
            6,5,7,

            8,9,10,
            10,9,11,

            12,14,15,
            15,13,12,
        };

    }
}
