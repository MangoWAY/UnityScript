using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : Command {
    public override void execute(ref ActorAction actor)
    {
        actor.jump();
    }
    public override void undo(ref ActorAction actor)
    {

    }
}
