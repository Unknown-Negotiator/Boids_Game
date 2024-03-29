using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Swarm : MonoBehaviour
{
    #region Fields & Properties
    public Agent boidPrefab;        
    public Rule[] rules; // stores all rules to apply on this swarm
    public float[] weights; // SHOULD MANAGE MISMATCH ??? UI eliminates the possibility of thar mismatch
        
    [Range(0, 400)] 
    public int initialSwarmSize; 
    [Range(1f, 100f)]
    public float operationSpeed = 10f; 
    [Range(1f, 100f)]
    public float maxSpeed = 5f; 
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f; 
    [Range(0f, 5f)]
    public float avoidanceRadiusMultiplier = 0.5f; // Сам AvoidanceRadius является функцией от neighbourRadius и avoidanceRadiusMultiplier

    const float swarmDensity = 0.08f;
    float squaredMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;

    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } } // Свойство, чтобы пользователь не мог настроить, а мы могли к нему обраиться из другого класса
    public float SquaredMaxSpeed { get { return squaredMaxSpeed; } }
    #endregion

    private void Awake()
    {
        operationSpeed = 10.6f;
        maxSpeed = 6.8f;
        neighbourRadius = 1.5f;
        avoidanceRadiusMultiplier = 0.5f;      

        initialSwarmSize = SwarmSizeControl.SwarmSizes[name];
        SwarmSizeControl.SwarmSizes[name] = 0; // Нужно, чтобы после перехода в меню базовые значения рамеров стай обнулились
    }
    void Start()
    {
        squareNeighborRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        squaredMaxSpeed = maxSpeed * maxSpeed;

        for (int i = 0; i < initialSwarmSize; i++)
        {
            Agent newBoid = Instantiate( // Returns the clone of the object with certain params
                boidPrefab, // original object
                UnityEngine.Random.insideUnitCircle * initialSwarmSize * swarmDensity, // position of new obj // Пояснение есть в документации!!! ("How density defines spawn radius?")
                Quaternion.Euler(Vector3.forward * UnityEngine.Random.Range(0f, 360f)), // rotation of new obj // "Quaternion.Euler(x,y,z)" - returns a rotation по осям. In our case аргумент метода - случайный вектор с координатой только по z
                transform // parent of new obj || transform of that new object is parent
                );
            newBoid.name = "Boid " + i;
            newBoid.AppendToSwarm(this); // the boid now knows which swarm it belongs
        }
    }    
}
