using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Swarm/Filter/Layer")]
public class LayerFilter : EnvironmentFilter
{
    public LayerMask mask;

    public override List<Transform> Filter(Agent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform item in original)
        {
            if (mask == (mask | (1 << item.gameObject.layer))) // (1 << item.gameObject.layer) - возвращает слой, на котором находится данный gameObject 
            {
                filtered.Add(item); // если данный item находится на слое заданном by mask, then we take it into filtered context
            }
        }
        return filtered;
    }
}
