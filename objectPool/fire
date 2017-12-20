using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
    private float time=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > 3)
        {
            ObjectPool.instance.Get("Bullet", Vector3.zero, Quaternion.identity);
            time = 0;
        }
            
	}
}
