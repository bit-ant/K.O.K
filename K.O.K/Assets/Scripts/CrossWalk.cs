using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossWalk : MonoBehaviour {

    private bool pedestrianIn = false;
    private bool carIn = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pedestrian"))
        {
            pedestrianIn = true;
            Debug.Log("ped");
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            carIn = true;
            Debug.Log("car");
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        BreakTrigger();
    }

    void BreakTrigger()
    {
        pedestrianIn = false;
        carIn = false;
    }

    void LateUpdate()
    {
        if (pedestrianIn && carIn)
        {
            PlayerPrefs.SetString("Game Result", "You are under Arrest!!!");
            // End the game
            Debug.Log("Ending game");
            SceneManager.LoadScene("EndGame");
        }
    }
}
