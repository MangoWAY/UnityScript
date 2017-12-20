using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 abstract public class Command  {

    public abstract void execute(ref ActorAction actor);
    public abstract void undo(ref ActorAction actor);
 
}




