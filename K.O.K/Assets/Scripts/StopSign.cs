using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : MonoBehaviour
{
    private GameObject player;
    private float T;
    PlayerController playerScript;

    void Start()
    {
        player = GameObject.Find("accent");
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
        if (T <= 3)
        {
            playerScript.playerScore -= 10;
        }
        else
        {
            playerScript.playerScore += 10;
        }
    }
    private IEnumerator Count()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.8f);
            T++;
        }

    }
}
