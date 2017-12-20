using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Command command; //每一帧接受到的命令
    public InputHandler inputHandler;//处理命令的对象
    private ActorAction actorAction;//玩家的行为
    public GameObject actor;//玩家


    void Start()
    {
        if (actor != null)
        {
            actorAction = actor.GetComponent<ActorAction>();
            if (!actorAction)
                Debug.Log("miss actorAction!");
        }   
        else
            Debug.Log("miss actor!");        
    }

	void Update ()
    {
        command = null;//每帧将所接收到的命令置为空
        if (Input.GetKeyDown(KeyCode.J))
            command = inputHandler.handleInput("J");//如果按下J键，将J传入inputHandler进行处理
        else if (Input.GetKeyDown(KeyCode.K))
            command = inputHandler.handleInput("K");
        else if (Input.GetKeyDown(KeyCode.L))
            command = inputHandler.handleInput("L");
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            command = inputHandler.handleInput("Up");
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            command = inputHandler.handleInput("Down");
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            command = inputHandler.handleInput("Left");
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            command = inputHandler.handleInput("Right");
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {//这里作为实验，当按下left shift时，按键对应的操作会发生变化
            inputHandler.bindCommand("J", new AvoidCommand());
            inputHandler.bindCommand("K", new AttackCommand());
            inputHandler.bindCommand("L", new JumpCommand());
        }
        else if (Input.GetKeyDown(KeyCode.Z))
            inputHandler.undo();
        else if (Input.GetKeyDown(KeyCode.X))
            inputHandler.redo();

        if (command!=null&&actorAction!=null)//执行操作
            command.execute(ref actorAction);
	}
}
