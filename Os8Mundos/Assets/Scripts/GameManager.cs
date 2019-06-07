using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentWorld;

    Ground ground;
    Wall wall;
    Rooftop rooftop;
    Door door;
    WindowA windowA;
    WindowB windowB;
    CameraM cameraM;
    Windwill windwill;
    Helix helix;
    HeightMap heightMap;

    GameObject cameraMGO, groundGO, wallGO, rooftopGO, doorGO, windowBGO, windowAGO, windwillGO, windwillGO2, helixGO, helixGO2, treeManagerGO, heightmapGO;

    void Start()
    {

        if (SceneManager.GetActiveScene().name == "World1")
        {
            currentWorld = 1;
        }
        if (SceneManager.GetActiveScene().name == "World2")
        {
            currentWorld = 2;
        }
        if (SceneManager.GetActiveScene().name == "World3")
        {
            currentWorld = 3;
        }
        if (SceneManager.GetActiveScene().name == "World4")
        {
            currentWorld = 4;
        }
        if (SceneManager.GetActiveScene().name == "World5")
        {
            currentWorld = 5;
        }
        if (SceneManager.GetActiveScene().name == "World6")
        {
            currentWorld = 6;
        }
        if (SceneManager.GetActiveScene().name == "World7")
        {
            currentWorld = 7;
        }
        if (SceneManager.GetActiveScene().name == "World8")
        {
            currentWorld = 8;
        }

        if (currentWorld == 1)
        {
            cameraMGO = GameObject.Find("Main Camera");
            cameraMGO.AddComponent<CameraM>();
            cameraMGO.GetComponent<CameraM>().currentWorld = this.currentWorld;
            groundGO = new GameObject("Ground");
            groundGO.AddComponent<Ground>();
            groundGO.GetComponent<Ground>().currentWorld = this.currentWorld;
            wallGO = new GameObject("Wall");
            wallGO.AddComponent<Wall>();
            wallGO.GetComponent<Wall>().currentWorld = this.currentWorld;          
            rooftopGO = new GameObject("Rooftop");
            rooftopGO.AddComponent<Rooftop>();
            rooftopGO.GetComponent<Rooftop>().currentWorld = this.currentWorld;
            doorGO = new GameObject("Door");
            doorGO.AddComponent<Door>();
            doorGO.GetComponent<Door>().currentWorld = this.currentWorld;
            windowAGO = new GameObject("WindowA");
            windowAGO.AddComponent<WindowB>();
            windowAGO.GetComponent<WindowB>().currentWorld = this.currentWorld;
            windowBGO = new GameObject("WindowB");
            windowBGO.AddComponent<WindowB>();
            windowBGO.GetComponent<WindowB>().currentWorld = this.currentWorld;
         
        }
        if (currentWorld == 2 || currentWorld == 3 || currentWorld == 4 || currentWorld == 5)
        {
            cameraMGO = GameObject.Find("Main Camera");
            cameraMGO.AddComponent<CameraM>();
            cameraMGO.GetComponent<CameraM>().currentWorld = this.currentWorld;
            groundGO = new GameObject("Ground");
            groundGO.AddComponent<Ground>();
            groundGO.GetComponent<Ground>().currentWorld = this.currentWorld;
            wallGO = new GameObject("Wall");
            wallGO.AddComponent<Wall>();
            wallGO.GetComponent<Wall>().currentWorld = this.currentWorld;
            rooftopGO = new GameObject("Rooftop");
            rooftopGO.AddComponent<Rooftop>();
            rooftopGO.GetComponent<Rooftop>().currentWorld = this.currentWorld;
            doorGO = new GameObject("Door");
            doorGO.AddComponent<Door>();
            doorGO.GetComponent<Door>().currentWorld = this.currentWorld;
            windowAGO = new GameObject("WindowA");
            windowAGO.AddComponent<WindowB>();
            windowAGO.GetComponent<WindowB>().currentWorld = this.currentWorld;
            windowBGO = new GameObject("WindowB");
            windowBGO.AddComponent<WindowB>();
            windowBGO.GetComponent<WindowB>().currentWorld = this.currentWorld;

            windwillGO = new GameObject("Windwill1");
            windwillGO.AddComponent<Windwill>();
            windwillGO.GetComponent<Windwill>().currentWorld = this.currentWorld;
            windwillGO2 = new GameObject("Windwill2");
            windwillGO2.AddComponent<Windwill>();
            windwillGO2.GetComponent<Windwill>().currentWorld = this.currentWorld;            
            helixGO = new GameObject("Helix1");
            helixGO.AddComponent<Helix>();
            helixGO.GetComponent<Helix>().currentWorld = this.currentWorld;
            helixGO.transform.position = new Vector3(0,14.75f,0);
            helixGO.transform.parent = windwillGO.transform;
            helixGO2 = new GameObject("Helix2");
            helixGO2.AddComponent<Helix>();
            helixGO2.GetComponent<Helix>().currentWorld = this.currentWorld;
            helixGO2.transform.position = new Vector3(0,14.75f,0);
            helixGO2.transform.parent = windwillGO2.transform;
            windwillGO.transform.position = new Vector3(15,0,-20);
            windwillGO.transform.Rotate(0,-45,0);
            windwillGO2.transform.position = new Vector3(-15,0,-20);
            windwillGO2.transform.Rotate(0,45,0);
        }

        if (currentWorld == 6)
        {
            cameraMGO = GameObject.Find("Main Camera");
            cameraMGO.AddComponent<CameraM>();
            cameraMGO.GetComponent<CameraM>().currentWorld = this.currentWorld;
            groundGO = new GameObject("Ground");
            groundGO.AddComponent<Ground>();
            groundGO.GetComponent<Ground>().currentWorld = this.currentWorld;
            wallGO = new GameObject("Wall");
            wallGO.AddComponent<Wall>();
            wallGO.GetComponent<Wall>().currentWorld = this.currentWorld;
            rooftopGO = new GameObject("Rooftop");
            rooftopGO.AddComponent<Rooftop>();
            rooftopGO.GetComponent<Rooftop>().currentWorld = this.currentWorld;
            doorGO = new GameObject("Door");
            doorGO.AddComponent<Door>();
            doorGO.GetComponent<Door>().currentWorld = this.currentWorld;
            windowAGO = new GameObject("WindowA");
            windowAGO.AddComponent<WindowB>();
            windowAGO.GetComponent<WindowB>().currentWorld = this.currentWorld;
            windowBGO = new GameObject("WindowB");
            windowBGO.AddComponent<WindowB>();
            windowBGO.GetComponent<WindowB>().currentWorld = this.currentWorld;

            windwillGO = new GameObject("Windwill1");
            windwillGO.AddComponent<Windwill>();
            windwillGO.GetComponent<Windwill>().currentWorld = this.currentWorld;
            windwillGO2 = new GameObject("Windwill2");
            windwillGO2.AddComponent<Windwill>();
            windwillGO2.GetComponent<Windwill>().currentWorld = this.currentWorld;
            helixGO = new GameObject("Helix1");
            helixGO.AddComponent<Helix>();
            helixGO.GetComponent<Helix>().currentWorld = this.currentWorld;
            helixGO.transform.position = new Vector3(0, 14.75f, 0);
            helixGO.transform.parent = windwillGO.transform;
            helixGO2 = new GameObject("Helix2");
            helixGO2.AddComponent<Helix>();
            helixGO2.GetComponent<Helix>().currentWorld = this.currentWorld;
            helixGO2.transform.position = new Vector3(0, 14.75f, 0);
            helixGO2.transform.parent = windwillGO2.transform;
            windwillGO.transform.position = new Vector3(15, 0, -20);
            windwillGO.transform.Rotate(0, -45, 0);
            windwillGO2.transform.position = new Vector3(-15, 0, -20);
            windwillGO2.transform.Rotate(0, 45, 0);
            treeManagerGO = new GameObject("TreeManager");
            treeManagerGO.AddComponent<TreeManager>();
        }

        if (currentWorld == 7)
        {
            cameraMGO = GameObject.Find("Main Camera");
            cameraMGO.AddComponent<CameraM>();
            cameraMGO.GetComponent<CameraM>().currentWorld = this.currentWorld;
            groundGO = new GameObject("Ground");
            groundGO.AddComponent<Ground>();
            groundGO.GetComponent<Ground>().currentWorld = this.currentWorld;
            wallGO = new GameObject("Wall");
            wallGO.AddComponent<Wall>();
            wallGO.GetComponent<Wall>().currentWorld = this.currentWorld;
            rooftopGO = new GameObject("Rooftop");
            rooftopGO.AddComponent<Rooftop>();
            rooftopGO.GetComponent<Rooftop>().currentWorld = this.currentWorld;
            doorGO = new GameObject("Door");
            doorGO.AddComponent<Door>();
            doorGO.GetComponent<Door>().currentWorld = this.currentWorld;
            windowAGO = new GameObject("WindowA");
            windowAGO.AddComponent<WindowB>();
            windowAGO.GetComponent<WindowB>().currentWorld = this.currentWorld;
            windowBGO = new GameObject("WindowB");
            windowBGO.AddComponent<WindowB>();
            windowBGO.GetComponent<WindowB>().currentWorld = this.currentWorld;

            windwillGO = new GameObject("Windwill1");
            windwillGO.AddComponent<Windwill>();
            windwillGO.GetComponent<Windwill>().currentWorld = this.currentWorld;
            windwillGO2 = new GameObject("Windwill2");
            windwillGO2.AddComponent<Windwill>();
            windwillGO2.GetComponent<Windwill>().currentWorld = this.currentWorld;
            helixGO = new GameObject("Helix1");
            helixGO.AddComponent<Helix>();
            helixGO.GetComponent<Helix>().currentWorld = this.currentWorld;
            helixGO.transform.position = new Vector3(0, 14.75f, 0);
            helixGO.transform.parent = windwillGO.transform;
            helixGO2 = new GameObject("Helix2");
            helixGO2.AddComponent<Helix>();
            helixGO2.GetComponent<Helix>().currentWorld = this.currentWorld;
            helixGO2.transform.position = new Vector3(0, 14.75f, 0);
            helixGO2.transform.parent = windwillGO2.transform;
            windwillGO.transform.position = new Vector3(15, 0, -20);
            windwillGO.transform.Rotate(0, -45, 0);
            windwillGO2.transform.position = new Vector3(-15, 0, -20);
            windwillGO2.transform.Rotate(0, 45, 0);

            treeManagerGO = new GameObject("TreeManager");
            treeManagerGO.AddComponent<TreeManager>();

            heightmapGO = new GameObject("HeightMap");
            heightmapGO.AddComponent<HeightMap>();
            heightmapGO.transform.position = new Vector3(4.3f, 236, 6.3f);
        }
    }
}
