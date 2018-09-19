using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pedestrian : MonoBehaviour
{
    private GameObject player;
    public GameObject ped;
    private PlayerController playerScript;
    public GameObject[] CrossWalks;


    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("accent");
        playerScript = player.GetComponent<PlayerController>();

    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetString("Game Result", "You are under Arrest!!!");
            Debug.Log("Ending game");
            SceneManager.LoadScene("EndGame");
        }
    }
}
