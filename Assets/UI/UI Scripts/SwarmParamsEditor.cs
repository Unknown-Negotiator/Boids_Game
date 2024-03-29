using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SwarmParamsEditor : MonoBehaviour
{
    public Swarm swarm;

    public TMP_Text[] swarmParams;
    public TMP_InputField[] weightsInputFields;

    public void Awake()
    {
        if (weightsInputFields.Length != swarm.weights.Length)
        {
            Debug.LogError("Input fields mismatch");
            return;
        }

        for (int i = 0; i < weightsInputFields.Length; i++)
            weightsInputFields[i].text = swarm.weights[i].ToString();

        swarmParams[0].text = swarm.operationSpeed.ToString();
        swarmParams[1].text = swarm.maxSpeed.ToString();
        swarmParams[2].text = swarm.neighbourRadius.ToString();
        swarmParams[3].text = swarm.avoidanceRadiusMultiplier.ToString();
    }

    #region Update not rule params
    public void UpdateOperationSpeed(float value)
    {
        swarm.operationSpeed = (int)value;
        swarmParams[0].text = Math.Round(value, 1, MidpointRounding.AwayFromZero).ToString();
    }
    public void UpdateMaxSpeed(float value)
    {
        swarm.maxSpeed = (int)value;
        swarmParams[1].text = Math.Round(value, 1, MidpointRounding.AwayFromZero).ToString();
    }
    public void UpdateNeighbourRadius(float value)
    {
        swarm.neighbourRadius = (int)value;
        swarmParams[2].text = Math.Round(value, 1, MidpointRounding.AwayFromZero).ToString();
    }
    public void UpdateAvoidFactor(float value)
    {
        swarm.avoidanceRadiusMultiplier = (int)value;
        swarmParams[3].text = Math.Round(value, 1, MidpointRounding.AwayFromZero).ToString();
    }
    #endregion

    #region Change weights of rules
    public void ChangeCohesion(string value)
    {
        if (value.Length == 0)
        {
            swarm.weights[0] = 0;
            return; 
        }
            
        value.Replace('.', ','); // float.Parse не хочет принимать числа с точкой в качестве аргумента тут
        try
        {
            if (value[value.Length - 1] == ',') // Do i have to?
            {
                swarm.weights[0] = float.Parse(value.TrimEnd(','));
                return;
            }
                
            swarm.weights[0] = float.Parse(value);
            //Debug.Log("value = " + value);
            //Debug.Log(" float.Parse(value) = " + float.Parse(value));
        }
        catch (Exception ex) 
        {
            
            swarm.weights[0] = 0;
            weightsInputFields[0].image.color = new Color(255, 102, 102); // Does not work
            //Debug.Log("exeption value = " + value);           
        }
            
    }
    public void ChangeAlignment(string value)
    {
        if (value.Length == 0)
        {
            swarm.weights[1] = 0;
            return;
        }

        value.Replace('.', ','); // float.Parse не хочет принимать числа с точкой в качестве аргумента тут
        try
        {
            if (value[value.Length - 1] == ',') // Do i have to?
            {
                swarm.weights[1] = float.Parse(value.TrimEnd(','));
                return;
            }

            swarm.weights[1] = float.Parse(value);
        }
        catch (Exception ex)
        {

            swarm.weights[1] = 0;
            weightsInputFields[1].image.color = new Color(255, 102, 102); // Does not work        
        }
    }
    public void ChangeAvoidance(string value)
    {
        if (value.Length == 0)
        {
            swarm.weights[2] = 0;
            return;
        }

        value.Replace('.', ','); // float.Parse не хочет принимать числа с точкой в качестве аргумента тут
        try
        {
            if (value[value.Length - 1] == ',') // Do i have to?
            {
                swarm.weights[2] = float.Parse(value.TrimEnd(','));
                return;
            }

            swarm.weights[2] = float.Parse(value);
        }
        catch (Exception ex)
        {

            swarm.weights[2] = 0;
            weightsInputFields[2].image.color = new Color(255, 102, 102); // Does not work          
        }
    }
    public void ChangeCentralization(string value)
    {
        if (value.Length == 0)
        {
            swarm.weights[3] = 0;
            return;
        }

        value.Replace('.', ','); // float.Parse не хочет принимать числа с точкой в качестве аргумента тут
        try
        {
            if (value[value.Length - 1] == ',') // Do i have to?
            {
                swarm.weights[3] = float.Parse(value.TrimEnd(','));
                return;
            }

            swarm.weights[3] = float.Parse(value);
        }
        catch (Exception ex)
        {

            swarm.weights[3] = 0;
            weightsInputFields[3].image.color = new Color(255, 102, 102); // Does not work         
        }
    }
    public void ChangeObstacleAvoidance(string value)
    {
        if (value.Length == 0)
        {
            swarm.weights[4] = 0;
            return;
        }

        value.Replace('.', ','); // float.Parse не хочет принимать числа с точкой в качестве аргумента тут
        try
        {
            if (value[value.Length - 1] == ',') // Do i have to?
            {
                swarm.weights[4] = float.Parse(value.TrimEnd(','));
                return;
            }

            swarm.weights[4] = float.Parse(value);
        }
        catch (Exception ex)
        {

            swarm.weights[4] = 0;
            weightsInputFields[4].image.color = new Color(255, 102, 102); // Does not work   
        }
    }
    #endregion

}
