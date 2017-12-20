using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command {
	public override void execute(ref ActorAction actor)
    {
        actor.attack();
    }
    public override void undo(ref ActorAction actor)
    {
 
    }
}
