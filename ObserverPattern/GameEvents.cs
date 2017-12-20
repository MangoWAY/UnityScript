using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameEventArgs
{
    public float life;
    public float num;
}
public delegate void GameEventHandler(object sender, GameEventArgs e);

public class GameEvents : MonoBehaviour {
    public float life = 0;
    public float num = 0;

    public event GameEventHandler KeyCodeADown;
    public virtual void OnKeyCodeADown(GameEventArgs e)
    {
        if (KeyCodeADown != null)
        {
            KeyCodeADown(this, e);
        }
    }
    private GameEventArgs setGameEventArgs()
    {
        GameEventArgs e;
        e.life = life;
        e.num = num;
        return e;
    }
	
	void Update () {
        life += Time.deltaTime;
        num += Time.deltaTime * 2;

        if(Input.GetKeyDown(KeyCode.A))
        {
            OnKeyCodeADown(setGameEventArgs());
        }

    }
}
