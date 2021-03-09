using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class START : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        StartCoroutine(closePanel());
    }

    IEnumerator closePanel()
    {
        yield return new WaitForSeconds(23);
        panel.SetActive(false);

    }


    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
