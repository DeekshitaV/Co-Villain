using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collisionScript : MonoBehaviour
{
    public Text scorecard;
    static int score = 0;
     AudioSource ting;
    // Start is called before the first frame update
    void Start()
    {
        ting = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scorecard.text = "SCORE : " + score;
      //  Debug.Log("GAME CHALLING>>");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("cop"))
        {
            Debug.Log("GAME OVER!");
            GameOver();
        }

        else if (other.transform.CompareTag("mask"))
        {
            Destroy(other.gameObject);
            score += 1;
            ting.Play();
        }

    }

   

    private static void GameOver()
    {
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
