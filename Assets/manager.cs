using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public Animator doctor;
    public GameObject[] patients;
    public Text waitingPatients;
    int waiting = 0;
    bool treating = false;
    public GameObject sanitizeAnim;
    public GameObject positiveAnim;
    public GameObject test;
    public int time = 45;
    public Text timeText;
    int treated = 0;
    int missed = 0;
    bool sanitized = false;
    public GameObject positivePanel;
    public GameObject negativePanel;
    public AudioSource newPatient;
    GameObject currentPatient;
    int pI = -1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        waitingPatients.text = "Waiting Room : " + waiting;
    }

    public void clickNext()
    {
        doctor.SetBool("Talk", false);
        // enter a new patient in
        pI++;
        if (pI > 2)
            pI = 0;
        //instantiate the patient with that index
        // transform (-8,0,-8)
        Vector3 pos = new Vector3(-8, 0, -8);
        if (treating == true)
        {
            waiting++;
            return;
        }
        else if (waiting > 0)
        {

            waiting--;
        }
        if (!sanitized)
        {
            //sanitize warning 
            Debug.Log("PLEASE SANITIZE");
        }

        if (currentPatient)
        {
            Destroy(currentPatient);
        }

        newPatient.Play();
        currentPatient = Instantiate(patients[pI], pos, patients[pI].transform.rotation);
        if (treated >= 14)
            time = 20;
        else if (treated >= 7)
            time = 30;
        else time = 45;
        treating = true;
        StartCoroutine(timeTaken());
    }

    IEnumerator timeTaken()
    {
        yield return new WaitForSeconds(1);
        time -= 1;
        if (time < 0)
        {
            timeOver();
        }
        else
        {
            timeText.text = "TIME LEFT => 00 : " + time;
            StartCoroutine(timeTaken());
        }

    }

    public void sanitize()
    {
        //play sanitize animation 
        sanitizeAnim.SetActive(true);
        StartCoroutine(deactivateAnim(sanitizeAnim));
        sanitized = true;
    }

    IEnumerator deactivateAnim(GameObject go)
    {
        yield return new WaitForSeconds(3);
        go.SetActive(false);
    }
    public void conductTest()
    {
        if (currentPatient)
            StartCoroutine(conduct());


    }

    IEnumerator conduct()
    {
        test.SetActive(true);
        StartCoroutine(deactivateAnim(test));
        yield return new WaitForSeconds(3);
        int n = Random.Range(0, 5);
        if (n < 3)
        {
            //negative
            treated++;
            StartCoroutine(negative());
        }
        else
        {
            //positive
            treated++;
            StartCoroutine(positive());
        }
    }

    IEnumerator negative()
    {
        //activate talking animation 
        //activate medicine panel
        negativePanel.SetActive(true);
        doctor.SetBool("Talk", true);
        yield return new WaitForSeconds(4);
        negativePanel.SetActive(false);
        treating = false;
        Destroy(currentPatient);
        sanitized = false;
        clickNext();

    }

    IEnumerator positive()
    {
        //positivePanel
        //activate talking animation
        doctor.SetBool("Talk", true);
        positivePanel.SetActive(true);
        StartCoroutine(wait());
        yield return new WaitForSeconds(4);
        positiveAnim.SetActive(true);
        positivePanel.SetActive(false);
        StartCoroutine(deactivateAnim(positiveAnim));
        yield return new WaitForSeconds(4);
        treating = false;
        Destroy(currentPatient);
        sanitized = false;
        clickNext();
    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
    }
    public void timeOver()
    {
        missed += 1;
        if (missed == 3)
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("GAME OVER");
        }
        else
        {
            treating = false;
            Destroy(currentPatient);
            clickNext();
        }

    }
}
