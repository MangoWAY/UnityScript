using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnEnable()
    {
        Init();
    }
    public void Init()
    {
        StartCoroutine(ReturnToPool());
    }
    IEnumerator ReturnToPool()
    {
        yield return new WaitForSeconds(2f);
        ObjectPool.instance.Return(this.gameObject);
    }
}
