using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
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
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Colors/Beige"));
        }
        else if (currentWorld == 3 || currentWorld == 4)
        {
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/WoodWall"));
        }
        else if (currentWorld >= 5)
        {          
            this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/WoodWall"));
            this.GetComponent<MeshRenderer>().material.shader = Resources.Load<Shader>("Effects/Morphing");
        }
    }
    void GetVertex()
    {
        verts = new Vector3[]
        {
            //Frente
            new Vector3(-5,8,0), //v0
            new Vector3(5,8,0), //v3
            new Vector3(5,4,0), //v1
            new Vector3(-5,4,0), //v2

            new Vector3(-5,4,0), //v4
            new Vector3(-1,4,0), //v7
            new Vector3(-1,0,0), //v5
            new Vector3(-5,0,0), //v6

            new Vector3(5,4,0), //v8
            new Vector3(1,4,0), //v11
            new Vector3(1,0,0), //v10
            new Vector3(5,0,0), //v9

            //Costas
            new Vector3(-5,4,-12), //v14
            new Vector3(5,4,-12), //v13
            new Vector3(5,8,-12), //v15
            new Vector3(-5,8,-12), //v12          

            new Vector3(-5,0,-12), //v18
            new Vector3(-1,0,-12), //v17
            new Vector3(-1,4,-12), //v19
            new Vector3(-5,4,-12), //v16

            new Vector3(5,4,-12), //v20
            new Vector3(1,4,-12), //v23
            new Vector3(1,0,-12), //v22
            new Vector3(5,0,-12), //v21

              
            //Lateral 1
            new Vector3(5,2,-12), //v24
            new Vector3(5,2,0), //v27
            new Vector3(5,0,0), //v25
            new Vector3(5,0,-12), //v26

            new Vector3(5,8,-12), //v28
            new Vector3(5,6,0), //v31
            new Vector3(5,8,0), //v29
            new Vector3(5,6,-12), //v30

            new Vector3(5,6,-12), //v32
            new Vector3(5,2,-10), //v35
            new Vector3(5,6,-10), //v33
            new Vector3(5,2,-12), //v34

            new Vector3(5,6,-2), //v36
            new Vector3(5,2,0), //v39
            new Vector3(5,6,0), //v37
            new Vector3(5,2,-2), //v38

            new Vector3(5,6,-7), //v40
            new Vector3(5,2,-5), //v43
            new Vector3(5,6,-5), //v41
            new Vector3(5,2,-7), //v42

            //Lateral 2
            new Vector3(-5,2,-12), //v44
            new Vector3(-5,0,0), //v45
            new Vector3(-5,0,-12), //v46
            new Vector3(-5,2,0), //v47

            new Vector3(-5,8,-12), //v48
            new Vector3(-5,8,0), //v49
            new Vector3(-5,6,-12), //v50
            new Vector3(-5,6,0), //v51

            new Vector3(-5,6,-12), //v52
            new Vector3(-5,6,-10), //v53
            new Vector3(-5,2,-12), //v54
            new Vector3(-5,2,-10), //v55

            new Vector3(-5,6,-2), //v56
            new Vector3(-5,6,0), //v57
            new Vector3(-5,2,-2), //v58
            new Vector3(-5,2,0), //v59

            new Vector3(-5,6,-7), //v60
            new Vector3(-5,6,-5), //v61
            new Vector3(-5,2,-7), //v62
            new Vector3(-5,2,-5), //v63
        };

        vertsUV = new Vector2[]
        {
            new Vector2 (0,1), 
            new Vector2 (0,0),
            new Vector2 (1,0),
            new Vector2 (1,1),

            new Vector2 (0,1),
            new Vector2 (0,0),
            new Vector2 (1,0),
            new Vector2 (1,1),

            new Vector2 (0,1),
            new Vector2 (1,1),
            new Vector2 (0,0),
            new Vector2 (1,0),          

            new Vector2 (0,1),
            new Vector2 (0,0),
            new Vector2 (1,0),
            new Vector2 (1,1),

            new Vector2 (0,1),
            new Vector2 (0,0),
            new Vector2 (1,0),
            new Vector2 (1,1),

            new Vector2 (0,1),
            new Vector2 (0,0),
            new Vector2 (1,0),
            new Vector2 (1,1),

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
            new Vector2 (0,0),
            new Vector2 (1,1),

            new Vector2 (0,1),
            new Vector2 (1,0),
            new Vector2 (0,0),
            new Vector2 (1,1),

            new Vector2 (0,0),
            new Vector2 (1,0),
            new Vector2 (0,1),
            new Vector2 (1,1),

            new Vector2 (0,1),
            new Vector2 (1,0),
            new Vector2 (0,0),
            new Vector2 (1,1),

            new Vector2 (0,0),
            new Vector2 (1,0),
            new Vector2 (0,1),
            new Vector2 (1,1),

            new Vector2 (0,0),
            new Vector2 (1,0),
            new Vector2 (0,1),
            new Vector2 (1,1),

            new Vector2 (0,0),
            new Vector2 (1,0),
            new Vector2 (0,1),
            new Vector2 (1,1),

            new Vector2 (0,0),
            new Vector2 (1,0),
            new Vector2 (0,1),
            new Vector2 (1,1),
        };

        index = new int[]
        {
            0,3,2,
            2,1,0,

            4,7,6,
            6,5,4,

            10,11,8,
            8,9,10,

            12,15,14,
            14,13,12,

            16,19,18,
            18,17,16,

            20,23,22,
            22,21,20,

            
            24,25,26,
            26,27,24,

            28,29,30,
            30,31,28,

            32,34,33,
            33,35,34,

            36,38,37,
            37,39,38,

            40,42,41,
            41,43,42,

            44,47,45,
            45,46,44,

            48,49,50,
            50,51,49,

            52,53,54,
            54,55,53,

            56,57,58,
            58,59,57,

            60,61,62,
            62,63,61,
        };
    }
}
