using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public static ObjectPool instance;//当前对象，是运用单例来使用它
    private static Dictionary<string, ArrayList> pool = new Dictionary<string, ArrayList>();
	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Object Return(GameObject o)
    {
        string key = o.gameObject.name;
        if(!pool.ContainsKey(key))
        {
            pool[key] = new ArrayList() { o };
        }
        else
        {
            pool[key].Add(o);
        }
        o.SetActive(false);
        return o;
    }
    public Object Get(string prefabName,Vector3 position,Quaternion quaternion)
    {
        string key = prefabName + "(Clone)";
        Object o;
        if(pool.ContainsKey(key)&&pool[key].Count>0)
        {
            ArrayList list = pool[key];
            o = list[0] as Object;
            list.RemoveAt(0);
            (o as GameObject).SetActive(true);
            (o as GameObject).transform.position = position;
            (o as GameObject).transform.rotation = quaternion;

        }
        else
        {
            o = Instantiate(Resources.Load(prefabName), position, quaternion);
        }
        return o;
    }
}
