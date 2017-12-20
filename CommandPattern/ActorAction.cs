using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ActorAction : MonoBehaviour {
    private int x_, y_;
    private Transform actorTrans_;

    void Start()
    {
        actorTrans_ = this.gameObject.GetComponent<Transform>();
    }

    public int getX()
    {
        return x_;
    }
    public int getY()
    {
        return y_;
    }

    public void moveTo(int x,int y)
    {
        x_ = x;
        y_ = y;
        actorTrans_.position = new Vector3(x, y, actorTrans_.position.z);
    }

	public void attack()
    {
        Debug.Log("attack");
    }
    public void jump()
    {
        Debug.Log("jump");
    }
    public void avoid()
    {
        Debug.Log("avoid");
    }

}
