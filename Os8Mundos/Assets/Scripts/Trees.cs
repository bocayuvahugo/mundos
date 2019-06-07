using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour
{
    private Quad quad;
    Vector3[] verts;
    Vector2[] vertsUV;
    int[] index;

    CameraM cameraM;

    void Start()
    {
        quad = this.gameObject.AddComponent<Quad>();
        GetVertex();

        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.AddComponent<MeshRenderer>();
        this.gameObject.AddComponent<Quad>();
        Mesh mesh = quad.Create(verts, vertsUV, index);
        this.GetComponent<MeshFilter>().mesh = mesh;

        this.GetComponent<MeshRenderer>().material = new Material(Resources.Load<Material>("Materials/Tree"));

        cameraM = FindObjectOfType<CameraM>();
    }
    void Update()
    {
        transform.LookAt(cameraM.transform.position);
    }
    void GetVertex()
    {
        verts = new Vector3[]
        {
             new Vector3(-5,8,0),
             new Vector3(5,8,0),
             new Vector3(-5,-8,0), 
             new Vector3(5,-8,0),
        };

        vertsUV = new Vector2[]
        {
            new Vector2 (0,0),
            new Vector2 (1,0),
            new Vector2 (0,1),
            new Vector2 (1,1),
        };

        index = new int[]
        {
           0,1,2,
           1,2,3,
        };

    }
}
