using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Agent : MonoBehaviour
{
    Swarm agentSwarm;
    float squaredMaxSpeed;
    private Collider2D agentCollider;

    public Swarm AgentSwarm { get { return agentSwarm; } }  
    public Collider2D AgentCollider { get { return agentCollider; } }
    
    public void AppendToSwarm(Swarm swarm)
    {
        agentSwarm = swarm;
    }

    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector2 velocity = DefineVelocity();
        transform.up = velocity; // движение в сторону направления оси У
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    Vector2 DefineVelocity()
    {
        squaredMaxSpeed = AgentSwarm.maxSpeed * AgentSwarm.maxSpeed;
        Vector2 velocity = ComposeRules(AgentSwarm.rules, AgentSwarm.weights);
        velocity *= AgentSwarm.operationSpeed;

        if (velocity.sqrMagnitude > squaredMaxSpeed) // Сравнение квадратов облегчает вычисления      
            velocity = velocity.normalized * AgentSwarm.maxSpeed;

        return velocity;
    }
    Vector2 ComposeRules(Rule[] rules, float[] weights)
    {
        Vector2 totalMove = Vector2.zero;
        List<Transform> environment = FindNearbyObjects();

        for (int i = 0; i < rules.Length; i++) 
        {
            Vector2 partialMove = rules[i].DefineMovement(this, environment, agentSwarm) * weights[i];

            if (partialMove != Vector2.zero)
            {
                if (partialMove.sqrMagnitude > weights[i] * weights[i]) // вдруг показатель смещения от опредлённого правила больше, чем вес этого правила в определении движения агента
                {                                                         // тогда приравниваем его к весу
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }

                totalMove += partialMove;
            }
        }

        return totalMove;
    }
    List<Transform> FindNearbyObjects()
    {
        List<Transform> environment = new List<Transform>();
        Collider2D[] ObjectsInRadius = Physics2D.OverlapCircleAll(transform.position, AgentSwarm.neighbourRadius); // "OverlapCircleAll(center coordinates, radius)" - get a list of all colliders that fall within a circular area

        foreach (Collider2D collider in ObjectsInRadius)
        {
            if (collider != AgentCollider) // исключаем из списка самого агента, для которого был вызван метод
            {
                environment.Add(collider.transform);
            }
        }

        return environment;
    }

}

