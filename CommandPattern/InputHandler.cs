using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputHandler :MonoBehaviour{

    private Command buttonJ_;
    private Command buttonK_;
    private Command buttonL_;
    private Command buttonUp_;
    private Command buttonDown_;
    private Command buttonLeft_;
    private Command buttonRight_;
    private ActorAction actor_;
    private Stack<Command> commands;
    private Stack<Command> redoCommands;

   void Start()
    {
        actor_ = this.gameObject.GetComponent<ActorAction>();
        commands = new Stack<Command>();
        redoCommands = new Stack<Command>();
        buttonJ_ = new AttackCommand();
        if (buttonJ_ == null) Debug.Log("buttonJ_ is null!");

        buttonK_ = new JumpCommand();
        if (buttonK_ == null) Debug.Log("buttonK_ is null!");

        buttonL_ = new AvoidCommand();
        if (buttonL_ == null) Debug.Log("buttonL_ is null!");

    }

    public void bindCommand(string buttonName,Command command)
    {
        switch (buttonName)
        {
            case "J":
            case "j": buttonJ_ = command; break;
            case "K":
            case "k": buttonK_ = command; break;
            case "L":
            case "l": buttonL_ = command; break;
        }
    }

    public Command handleInput(string keyName)
    {
        switch (keyName)
        {
            case "J":
                return buttonJ_;
            case "K":
                return buttonK_;
            case "L":
                return buttonL_;
            case "Up":
                redoCommands.Clear();
                buttonUp_ = new MoveCommand(actor_, actor_.getX(), actor_.getY() + 1);
                if (buttonUp_ == null) Debug.Log("buttonUp_ is null!");
                commands.Push(buttonUp_);
                return buttonUp_;
            case "Down":
                redoCommands.Clear();
                buttonDown_ = new MoveCommand(actor_, actor_.getX(), actor_.getY() - 1);
                if (buttonDown_ == null) Debug.Log("buttonDown_ is null!");
                commands.Push(buttonDown_);
                return buttonDown_;
            case "Left":
                redoCommands.Clear();
                buttonLeft_ = new MoveCommand(actor_, actor_.getX() - 1, actor_.getY());
                if (buttonLeft_ == null) Debug.Log("buttonLeft_ is null!");
                commands.Push(buttonLeft_);
                return buttonLeft_;
            case "Right":
                redoCommands.Clear();
                buttonRight_ = new MoveCommand(actor_, actor_.getX() + 1, actor_.getY());
                if (buttonRight_ == null) Debug.Log("buttonRight_ is null!");
                commands.Push(buttonRight_);
                return buttonRight_;
            default:
                return null;
        }
    }

    public void undo()
    {
        if(commands.Count!=0)
        {
            redoCommands.Push(commands.Peek());
            commands.Pop().undo(ref actor_);
        }
        
    }
    public void redo()
    {
        if (redoCommands.Count != 0)
        {
            commands.Push(redoCommands.Peek());
            redoCommands.Pop().execute(ref actor_);
        }

    }
}
