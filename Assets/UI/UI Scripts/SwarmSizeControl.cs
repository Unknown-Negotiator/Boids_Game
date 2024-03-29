using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwarmSizeControl : MonoBehaviour
{
    public TMP_Text sizeDisplay;
    public static Dictionary<string, int> SwarmSizes = new Dictionary<string, int>(3)
    {
        {"Pink", 0 }, {"Blue", 0 },{"Green", 0 }
    };

    public void UpdateSwarmSize_0(float value)
    {
        SwarmSizes["Pink"] = (int)value;
        sizeDisplay.text = value.ToString();
    }
    public void UpdateSwarmSize_1(float value)
    {
        SwarmSizes["Blue"] = (int)value;
        sizeDisplay.text = value.ToString();
    }
    public void UpdateSwarmSize_2(float value)
    {
        SwarmSizes["Green"] = (int)value;
        sizeDisplay.text = value.ToString();
    }
}
