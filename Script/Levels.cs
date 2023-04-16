using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public static bool level1complete;
    public static bool level2complete;
    public static Scene scene;
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }
    void Update()
    {
        if (EnemyAi.HealthEnemy == 100 && scene.name == "Level1")
        {
            level1complete = true;
            Debug.Log(scene.name + " is Complete");
        }
        if (EnemyAi.HealthEnemy == 100 && scene.name == "Level2")
        {
            level2complete = true;
            Debug.Log(scene.name + " is Complete");
        }
        DontDestroyOnLoad(this.gameObject);
    }
}