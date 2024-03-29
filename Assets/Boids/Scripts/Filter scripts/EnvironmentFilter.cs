using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnvironmentFilter : ScriptableObject
{
    public abstract List<Transform> Filter(Agent agent, List<Transform> originalEnvironment);
}
