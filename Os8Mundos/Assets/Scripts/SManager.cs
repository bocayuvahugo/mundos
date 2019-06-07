using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SManager : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    private void OnGUI()
    {
        if (SceneManager.GetActiveScene().name == "WorldMenu")
        {
            if (GUI.Button(new Rect(Screen.width - Screen.width / 13 * 3, Screen.height - Screen.height / 7 * 3, Screen.width / 13 * 2, Screen.height / 7), "World 8"))
            {
                SceneManager.LoadScene("World8");
            }
            if (GUI.Button(new Rect(Screen.width - Screen.width / 13 * 6, Screen.height - Screen.height / 7 * 3, Screen.width / 13 * 2, Screen.height / 7), "World 7"))
            {
                SceneManager.LoadScene("World7");
            }
            if (GUI.Button(new Rect(Screen.width - Screen.width / 13 * 9, Screen.height - Screen.height / 7 * 3, Screen.width / 13 * 2, Screen.height / 7), "World 6"))
            {
                SceneManager.LoadScene("World6");
            }
            if (GUI.Button(new Rect(Screen.width - Screen.width / 13 * 12, Screen.height - Screen.height / 7 * 3, Screen.width / 13 * 2, Screen.height / 7), "World 5"))
            {
                SceneManager.LoadScene("World5");
            }
            if (GUI.Button(new Rect(Screen.width - Screen.width / 13 * 3, Screen.height - Screen.height / 7 * 6, Screen.width / 13 * 2, Screen.height / 7), "World 4"))
            {
                SceneManager.LoadScene("World4");
            }
            if (GUI.Button(new Rect(Screen.width - Screen.width / 13 * 6, Screen.height - Screen.height / 7 * 6, Screen.width / 13 * 2, Screen.height / 7), "World 3"))
            {
                SceneManager.LoadScene("World3");
            }
            if (GUI.Button(new Rect(Screen.width - Screen.width / 13 * 9, Screen.height - Screen.height / 7 * 6, Screen.width / 13 * 2, Screen.height / 7), "World 2"))
            {
                SceneManager.LoadScene("World2");
            }
            if (GUI.Button(new Rect(Screen.width - Screen.width / 13 * 12, Screen.height - Screen.height / 7 * 6, Screen.width / 13 * 2, Screen.height / 7), "World 1"))
            {
                SceneManager.LoadScene("World1");
            }
        }
        else
        {
            if (GUI.Button(new Rect(Screen.width - Screen.width / 13 * 5, Screen.height - Screen.height, Screen.width / 13 * 5, Screen.height / 7), "Return to World Menu"))
            {
                SceneManager.LoadScene("WorldMenu");
            }
        }
    }
}
