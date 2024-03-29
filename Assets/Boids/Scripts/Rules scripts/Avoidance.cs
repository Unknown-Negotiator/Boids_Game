using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Rule/Avoidance")]
public class Avoidance : FilteredRule
{
    public override Vector2 DefineMovement(Agent agent, List<Transform> environment, Swarm swarm)
    {
        List<Transform> filteredEnvironment = (filter == null) ? environment : filter.Filter(agent, environment);
        if (filteredEnvironment.Count == 0)
            return Vector2.zero;

        Vector2 move = Vector2.zero;
        int NumberToAvoid = 0;
        
        foreach (Transform item in filteredEnvironment)
        {
            if (Vector2.SqrMagnitude(item.position - agent.transform.position) < swarm.SquareAvoidanceRadius) // if (Squared distance between the item and the agent < SquareAvoidanceRadius) => агент находится с item слишком близко 
            {  // Если агенту нужно avoid item, то мы прибавляем к вектору смещения разницу их координат в пространстве. Потом этот вектор смещения усредним делением на кол-во избегаемых
                NumberToAvoid++;
                move += (Vector2)(agent.transform.position - item.position); // пытаемся двигаться от соседа
            }
        }

        if (NumberToAvoid > 0)
            move /= NumberToAvoid;

        return move;
    }
}
