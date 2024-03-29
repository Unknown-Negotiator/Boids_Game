using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Rule/Alignment")]
public class Alignment : FilteredRule
{
    public override Vector2 DefineMovement(Agent agent, List<Transform> environment, Swarm swarm)
    {
        List<Transform> filteredEnvironment = (filter == null) ? environment : filter.Filter(agent, environment);
        //if no neighbors, maintain current heading
        if (filteredEnvironment.Count == 0)
            return agent.transform.up;

        //add all направления together and find average
        Vector2 move = Vector2.zero;
        
        foreach (Transform item in filteredEnvironment)
        {
            move += (Vector2)item.up; // Transform.up - get or set position on the Y axis of the transform in world space, considering rotation
        }
        move /= filteredEnvironment.Count;

        return move;
    }
}
