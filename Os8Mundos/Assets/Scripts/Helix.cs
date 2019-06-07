using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helix : MonoBehaviour
{
    private Quad quad;
    Vector3[] verts;
    Vector2[] vertsUV;
    int[] index;
    public int currentWorld;
    float speed;
    float time;
    void Start()
    {
        speed = Random.Range(6,10);

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
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/Helix"));
        }
        else if (currentWorld >= 5)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/Helix"));
            this.GetComponent<MeshRenderer>().material.shader = Resources.Load<Shader>("Effects/Morphing");
        }
    }

    void Update()
    {
        time += 1 * Time.deltaTime;

        if (time >= 10)
        {
            speed = Random.Range(1,5);
            time = 0;
        }

        transform.Rotate(0, 0, speed);
    }
    void GetVertex()
    {
        verts = new Vector3[]
        {
            //Hélice 1
            new Vector3(-2,0,2), //v0
            new Vector3(0,0,2), //v1
            new Vector3(0,-0.5f,2), //v2
            new Vector3(-2,-0.5f,2), //v3

            new Vector3(-8,0,2), //v4
            new Vector3(-2,0,2), //v5
            new Vector3(-2,-2,2), //v6
            new Vector3(-8,-2,2), //v7

            //Hélice 2
            new Vector3(0,2,2), //v8
            new Vector3(0,0,2), //v9
            new Vector3(-0.5f,0,2), //v10
            new Vector3(-0.5f,2,2), //v11

            new Vector3(-2,8,2), //v12
            new Vector3(0,8,2), //v13
            new Vector3(-2,2,2), //v14
            new Vector3(0,2,2), //v15
            
            //Hélice 3
            new Vector3(2,0,2), //v16
            new Vector3(0,0,2), //v17
            new Vector3(0,0.5f,2), //v18
            new Vector3(2,0.5f,2), //v19

            new Vector3(8,0,2), //v20
            new Vector3(2,0,2), //v21
            new Vector3(2,2,2), //v22
            new Vector3(8,2,2), //v23

            //Hélice 4
            new Vector3(0,-2,2), //v24
            new Vector3(0,0,2), //v25
            new Vector3(0.5f,0,2), //v26
            new Vector3(0.5f,-2,2), //v27

            new Vector3(0,-8,2), //v28
            new Vector3(0,-2,2), //v29
            new Vector3(2,-2,2), //v30
            new Vector3(2,-8,2), //v31
        };

        vertsUV = new Vector2[]
        {           
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(1,0),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(0,1),

            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0),
        };

        index = new int[]
        {
            0,1,3,
            3,1,2,

            4,5,7,
            7,5,6,

            8,10,11,
            11,9,10,

            12,13,15,
            15,14,12,

            16,18,19,
            19,17,18,

            20,22,23,
            23,21,22,

            24,26,27,
            27,25,26,

            28,30,31,
            31,29,30,
        };
    }
}
