using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class TrafficLight : MonoBehaviour {
    
    private GameObject player;
    private GameObject Green;
    private GameObject Yellow;
    private GameObject Red;
    private GameObject TLR;
    private GameObject TLW;

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

        Green = GameObject.FindGameObjectWithTag("GreenLight");
        Yellow = GameObject.FindGameObjectWithTag("YellowLight");
        Red = GameObject.FindGameObjectWithTag("RedLight");
        TLR = GameObject.FindGameObjectWithTag("TLright");
        TLR.gameObject.SetActive(false);
        TLW = GameObject.FindGameObjectWithTag("TLwrong");
        TLW.gameObject.SetActive(false);

        StartCoroutine(Count());
        player = GameObject.Find("accent");
        playerScript = player.GetComponent<PlayerController>();

        

    }

    // Update is called once per frame
    void Update()
    {   if (T==0)
        {
            Green.gameObject.SetActive(true);
            Yellow.gameObject.SetActive(false);
            Red.gameObject.SetActive(false);
            win = true;
        }
        if (T == 6)
        {
            Green.gameObject.SetActive(false);
            Yellow.gameObject.SetActive(true);
            Red.gameObject.SetActive(false);
            win = true;
        }
        else if (T==9)
        {
            Green.gameObject.SetActive(false);
            Yellow.gameObject.SetActive(false);
            Red.gameObject.SetActive(true);
            win = false;
        }
        else if (T==16)
        {
            T = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (win==false)
        {
            playerScript.playerScore -= 20;
            TLW.gameObject.SetActive(true);
            Invoke("DisableText1", 3);
        }
        else //if (Green==true || Yellow==true)
        {
            playerScript.playerScore += 20;
            TLR.gameObject.SetActive(true);
            Invoke("DisableText2", 3);
        }
    }
    void DisableText1()
    {
        TLW.gameObject.SetActive(false);
    }
    void DisableText2()
    {
        TLR.gameObject.SetActive(false);
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
