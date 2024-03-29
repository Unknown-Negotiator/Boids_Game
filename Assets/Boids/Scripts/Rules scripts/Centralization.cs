using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Rule/Centralization")]
public class Centralization : Rule
{
    public Vector2 center;

    [Range(1f, 50f)]
    public float radius = 15f;

    public override Vector2 DefineMovement(Agent agent, List<Transform> environment, Swarm swarm)
    {
        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        float t = centerOffset.magnitude / radius; // отношение расстояния агента от центра к радиусу
        if (t < 0.9f)                              // if  0 <= t < 1 than agent is inside of the circle
        {                                          // if t > 1 than agent is outside.                                                    
            return Vector2.zero;                   // The bigger is t, the closer is agent to the restricted zone. We consider that 90 % is alright and don't change the direction
        }

        return centerOffset * t * t; // Смещение в сторону центра с множителем. Чем дальше агент от центра, тем больше множитель
    }
}
