using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Rule/Cohesion")]
public class Cohesion : FilteredRule
{    
    public override Vector2 DefineMovement(Agent agent, List<Transform> environment, Swarm swarm)
    {
        List<Transform> filteredEnvironment = (filter == null) ? environment : filter.Filter(agent, environment);
        if (filteredEnvironment.Count == 0)
            return Vector2.zero;

        Vector2 move = Vector2.zero;
        foreach (Transform item in filteredEnvironment)
        {
            move += (Vector2)item.position;
        }

        move /= filteredEnvironment.Count; // Получили примерно центральную координату для всех соседей, но мы не можем туда всех отправить, иначе собьются в кучу        
        move -= (Vector2)agent.transform.position; // Учитываем позицию самого агента. Вычитаем её из центрального смещения - механизм не понял до конца!!!        
        return move;                                                                                       
    }
}
