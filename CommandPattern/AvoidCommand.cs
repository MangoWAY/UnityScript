using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidCommand : Command {
    public override void execute(ref ActorAction actor)
    {
        actor.avoid();
    }
    public override void undo(ref ActorAction actor)
    {

    }
}
