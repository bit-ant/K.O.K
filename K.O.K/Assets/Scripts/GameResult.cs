using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour {

    private string resultText;
    public Text diplayResult;

	// Use this for initialization
	void Start () {
        diplayResult = gameObject.GetComponent<Text>();
        resultText = PlayerPrefs.GetString("Game Result");
        diplayResult.text = resultText;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
