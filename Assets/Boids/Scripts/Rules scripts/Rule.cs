using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rule : ScriptableObject
{
    public abstract Vector2 DefineMovement(Agent agent, List<Transform> environment, Swarm swarm);
}
