using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMaze : MonoBehaviour
{
    public GameObject won;
    public Rigidbody rb;
    public Animator player;
    public AudioSource ting;
    int n = 0 ;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("supplies"))
        {
            ting.Play();
            n++;
            other.gameObject.SetActive(false);
            check();
        }
    }

    private void check()
    {
        if( n >= 4)
        {
            won.SetActive(true);
        }
    }

    public void PlayerRotate(float r )
    {

        //Quaternion rotateR = Quaternion.Euler( new Vector3 (0,r,0));
        Quaternion from = rb.gameObject.transform.rotation;
        Quaternion to = rb.gameObject.transform.rotation;
        to *= Quaternion.Euler(Vector3.up * r);
        
        rb.gameObject.transform.rotation = Quaternion.RotateTowards(from, to , Time.deltaTime);
        rb.gameObject.transform.rotation = to;
        
    }

    public void ButtonClick()
    {
        player.SetBool("Run", true);
        rb.AddForce(player.transform.forward * 5000f) ;
        StartCoroutine(StopPlayer());
    }

    IEnumerator StopPlayer()
    {
        yield return new WaitForSeconds(1);
        player.SetBool("Run", false);
    }
}