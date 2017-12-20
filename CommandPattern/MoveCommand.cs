using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command {
    private int x_, y_;
    private int xBefore_, yBefore_;
    public MoveCommand(ActorAction actor, int x,int y)
    {
        x_ = x;
        y_ = y;
        xBefore_ = actor.getX();
        yBefore_ = actor.getY();
    }

    public override void execute(ref ActorAction actor)
    {
        actor.moveTo(x_,y_);
    }
    public override void undo(ref ActorAction actor)
    {
        actor.moveTo(xBefore_, yBefore_);
    }

}
