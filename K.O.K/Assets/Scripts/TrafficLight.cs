using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour {

    /* Tag Constants */
    private readonly string GreenLight = "GreenLight";
    private readonly string RedLight = "RedLight";
    private readonly string YellowLight = "YellowLight";

    private string OnLight; // Determines which light is on

    private float timeInTrigger;
    private GameObject player;
    private PlayerController playerScript;

    public Material GreenLightMaterial;
    public Material RedLightMaterial;
    public Material YellowLightMaterial;
    public Material OffLightMaterial;

    // Use this for initialization
    void Start()
    {
        OnLight = RedLight; // Intially we have a red light

        InvokeRepeating("ChangeLight", 1.0f, 3.0f); // Change light every 3 seconds

        player = GameObject.Find("accent");
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeLight()
    {
        Debug.Log("Changing Light");
        bool done = false;
        foreach (Transform child in transform)
        {
            // Loop through children to find the active traffic light and toggle with the rest
            if (isLight(child) && (OnLight == child.tag))
            {
                child.GetComponent<Renderer>().material = OffLightMaterial;
                switch (child.tag)
                {
                    case "GreenLight":
                        // Go to yellow
                        Debug.Log("Yellow light shall be on");
                        OnLight = YellowLight;
                        done = true;
                        break;
                    case "RedLight":
                        Debug.Log("Green light shall be on");
                        // Go to green
                        OnLight = GreenLight;
                        done = true;
                        break;
                    case "YellowLight":
                        Debug.Log("Red light shall be on");
                        // Go to red
                        OnLight = RedLight;
                        done = true;
                        break;
                    default:
                        break;
                }

                if (done)
                    break;
            }
        }

        GameObject[] myGameObjects = GameObject.FindGameObjectsWithTag(OnLight);
        switch (OnLight)
        {
            case "GreenLight":
                myGameObjects[0].GetComponent<Renderer>().material = GreenLightMaterial;
                Debug.Log("Green light on");
                break;
            case "RedLight":
                myGameObjects[0].GetComponent<Renderer>().material = RedLightMaterial;
                Debug.Log("Red light on");
                break;
            case "YellowLight":
                myGameObjects[0].GetComponent<Renderer>().material = YellowLightMaterial;
                Debug.Log("Yellow light on");
                break;
            default:
                break;
        }

    }

    // Given a child of the traffic light object, it returns whether is is one of the three lights
    bool isLight(Transform child)
    {
        return (child.tag == GreenLight || child.tag == RedLight || child.tag == YellowLight);
    }

    void OnTriggerExit(Collider other)
    {
        if (RedLight == OnLight)
        {
            playerScript.playerScore -= 20;
        }
        else
        {
            playerScript.playerScore += 20;
        }
    }
}
