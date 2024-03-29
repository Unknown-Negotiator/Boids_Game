using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Filter/Same Swarm")]
public class SwarmFilter : EnvironmentFilter
{
    public override List<Transform> Filter(Agent agent, List<Transform> originalEnvironment)
    {
        List<Transform> filtered = new List<Transform>();

        foreach (Transform item in originalEnvironment)
        {
            Agent temp = item.GetComponent<Agent>(); // GetComponent<type> - возвращает компонент типа type, если он прикреплен к игровому объекту и null, если не прикреплен.
            if (temp != null && temp.AgentSwarm == agent.AgentSwarm) // если ты бойд и ты из нашей стаи, то попадаешь в мой список окружения
            {
                filtered.Add(item);
            }
        }

        return filtered;
    }
}
