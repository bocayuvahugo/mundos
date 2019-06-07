using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    Trees trees;
    GameObject treeGO;
    Vector3 position;

    int column, row;

    void Start()
    {
        row = 4;
        column = 4;
        position = new Vector3(15, 0, -35);

        for (int i = 0; i < column; i++)
        {
            for (int j = 0; j < row; j++)
            {
                treeGO = new GameObject("Trees");
                treeGO.AddComponent<Tree>();
                treeGO.transform.position = new Vector3(position.x - i * 10, 0, position.z - j * 10);
            }

        }
    }
}
