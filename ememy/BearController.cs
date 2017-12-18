using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BearController : MonoBehaviour {
   
    public RectTransform bloodBar;
    public int maxHealth = 50;
    public string walk;
    public string getHit;
    public string death;
    public string weaponTag;
    public int hitValue = 13;
    private int currentHealth = 50;
    private Animation ani;

    // Use this for initialization
    void Start () {
        ani = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.P))
        {
            OnBloodBarChange();
        }
        if(!ani.isPlaying&&currentHealth>0)
        {
            ani.Play();
        }
		
	}
    private void OnBloodBarChange()
    {
        if(currentHealth<=0)
        {
            return;
        }
        ani.Play(getHit);
        currentHealth -= hitValue;
        bloodBar.sizeDelta = new Vector2(currentHealth, bloodBar.sizeDelta.y);
        if (currentHealth <= 0)
            ani.Play(death);
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag==weaponTag)
        {
            OnBloodBarChange();
        }
    }
}
