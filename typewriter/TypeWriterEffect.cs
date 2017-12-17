using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TypeWriterEffect : MonoBehaviour {
	
    public bool isActive = false;
    private string text;
    private Text textComponent;
    private int currentPosition;
    public float internalTime = 0.5f;
	
	// Use this for initialization
	void Start () 
	{
        textComponent = GetComponent<Text>();
        text = textComponent.text;
        textComponent.text = "";
	}
	// Update is called once per frame
	void Update () 
	{
		if(isActive)
		{
		    InvokeRepeating("writer", 0, internalTime);
		    isActive = false;
		}
		if(currentPosition>text.Length-1)
		{
		    CancelInvoke();
		}	
	}
	
   	 void writer()
   	 {
            textComponent.text += text[currentPosition];
            currentPosition++;
   	 }
}
