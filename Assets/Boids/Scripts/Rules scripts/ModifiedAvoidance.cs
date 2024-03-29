using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Rule/Modified Avoidance")]
public class ModifiedAvoidance : FilteredRule
{
    Vector2 currentVelocity;
    public float smoothTime = 0.5f;
    public override Vector2 DefineMovement(Agent agent, List<Transform> environment, Swarm swarm)
    {
        List<Transform> filteredEnvironment = (filter == null) ? environment : filter.Filter(agent, environment);
        if (filteredEnvironment.Count == 0)
            return Vector2.zero;

        Vector2 move = Vector2.zero;
        int NumberToAvoid = 0;        

        foreach (Transform item in filteredEnvironment)
        {
            Vector2 closestPoint = item.gameObject.GetComponent<Collider2D>().ClosestPoint(agent.transform.position);

            if (Vector2.SqrMagnitude((Vector3)closestPoint - agent.transform.position) < swarm.SquareAvoidanceRadius)  // if (Squared distance between the item and the agent < SquareAvoidanceRadius) => агент находится с item слишком близко 
            {  // Если агенту нужно avoid item, то мы прибавляем к вектору смещения разницу их координат в пространстве. Потом этот вектор смещения усредним делением на кол-во избегаемых
                NumberToAvoid++;
                move += (Vector2)(agent.transform.position - item.position); // пытаемся двигаться от соседа
            }
        }

        if (NumberToAvoid > 0)
            move /= NumberToAvoid;

        return Vector2.SmoothDamp(agent.transform.up, move, ref currentVelocity, smoothTime); 
    }
}
