using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newstop : MonoBehaviour
{
    private GameObject player;
    private GameObject StopR;
    private GameObject StopW;

    public float T;
    PlayerController playerScript;

    void Start()
    {
        player = GameObject.Find("accent");
        StopR = GameObject.FindGameObjectWithTag("StopRight");
        StopR.gameObject.SetActive(false);
        StopW = GameObject.FindGameObjectWithTag("StopWrong");
        StopW.gameObject.SetActive(false);
        playerScript = player.GetComponent<PlayerController>();
    }


    void OnTriggerEnter(Collider other)
    {
        T = 0;
        StartCoroutine("Count");

    }
    void OnTriggerExit(Collider other)
    {
        StopCoroutine("Count");
        if (T < 2)
        {
            playerScript.playerScore -= 20;
            StopW.gameObject.SetActive(true);
            Invoke("DisableText", 3);
        }
        else
        {
            playerScript.playerScore += 20;
            StopR.gameObject.SetActive(true);
            Invoke("DisableText", 3);
        }

    }

    void DisableText()
    {
        StopW.gameObject.SetActive(false);
        StopR.gameObject.SetActive(false);

    }
    private IEnumerator Count()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            T++;
        }

    }
}