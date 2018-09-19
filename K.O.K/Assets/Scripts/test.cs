using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class test : MonoBehaviour
{

    private GameObject player;
    private GameObject Green2;
    private GameObject Yellow2;
    private GameObject Red2;
    private GameObject TLR2;
    private GameObject TLW2;

    private PlayerController playerScript;

    public Material GreenLightMaterial;
    public Material RedLightMaterial;
    public Material YellowLightMaterial;
    public Material OffLightMaterial;
    public float T;
    bool win;

    // Use this for initialization
    void Start()
    {

        Green2 = GameObject.FindGameObjectWithTag("GreenLight");
        Yellow2= GameObject.FindGameObjectWithTag("YellowLight");
        Red2 = GameObject.FindGameObjectWithTag("RedLight");
        TLR2 = GameObject.FindGameObjectWithTag("TLright");
        TLR2.gameObject.SetActive(false);
        TLW2 = GameObject.FindGameObjectWithTag("TLwrong");
        TLW2.gameObject.SetActive(false);

        StartCoroutine(Count());
        player = GameObject.Find("accent");
        playerScript = player.GetComponent<PlayerController>();



    }

    // Update is called once per frame
    void Update()
    {
        if (T == 0)
        {
            Green2.gameObject.SetActive(true);
            Yellow2.gameObject.SetActive(false);
            Red2.gameObject.SetActive(false);
            win = true;
        }
        if (T == 6)
        {
            Green2.gameObject.SetActive(false);
            Yellow2.gameObject.SetActive(true);
            Red2.gameObject.SetActive(false);
            win = true;
        }
        else if (T == 9)
        {
            Green2.gameObject.SetActive(false);
            Yellow2.gameObject.SetActive(false);
            Red2.gameObject.SetActive(true);
            win = false;
        }
        else if (T == 16)
        {
            T = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (win == false)
        {
            playerScript.playerScore -= 20;
            TLW2.gameObject.SetActive(true);
            Invoke("DisableText", 3);
        }
        else //if (Green==true || Yellow==true)
        {
            playerScript.playerScore += 20;
            TLR2.gameObject.SetActive(true);
            Invoke("DisableText", 3);
        }
    }
    void DisableText()
    {
        TLW2.gameObject.SetActive(false);
        TLR2.gameObject.SetActive(false);

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
