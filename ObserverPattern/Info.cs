using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour {
    public GameEvents gameEvents;
	// Use this for initialization
	void Start () {
        gameEvents.KeyCodeADown += CodeADown;
	}
	
	private void CodeADown(object sender,GameEventArgs e)
    {
        Debug.Log("Code A is pressed!");
        Debug.Log("life: " + e.life);
        Debug.Log("num: " + e.num);
    }
}
