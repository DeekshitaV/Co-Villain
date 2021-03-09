using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    int cI = 0;
    string[] scenes;
    public GameObject choose;
    public GameObject currentAvatar;
    public GameObject[] Avatars;
    public GameObject[] instructions;
    public GameObject loadScene;


    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        scenes = new string[3];
        scenes[0] = "DoctorDash";
        scenes[1] = "PoliceRun";
        scenes[2] = "Maze";
        loadScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instructions()
    {
        instructions[cI].SetActive(true);
    }

    public void changeAvatar()
    {
        choose.SetActive(true);
    }

    public void chooseButton(int i)
    {
        foreach(GameObject go in Avatars)
        {
            go.SetActive(false);
        }
        Avatars[i].SetActive(true);
        cI = i;
    }

    public void close(GameObject go)
    {
        go.SetActive(false);
    }

    public void play()
    {
        loadScene.SetActive(true);
        SceneManager.LoadSceneAsync(scenes[cI]);
    }
}
