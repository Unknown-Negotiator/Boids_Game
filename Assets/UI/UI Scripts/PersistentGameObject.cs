using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersistentGameObject : MonoBehaviour // Полезный скрипт. Не пригодился, сделал через статичное поле передачу данных между сценами
{
    //static PersistentGameObject instance;
    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this; // In first scene, make us the singleton.
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else if (instance != this)
    //        Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.

    //    Debug.Log("size = " + swarmSizes[0]);
    //}    
}
