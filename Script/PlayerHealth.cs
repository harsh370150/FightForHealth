using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public Slider HealthBar;
    
    void Awake()
    {
        instance = this;
        HealthBar.minValue = 0;
        HealthBar.maxValue = 100;
    }
    
    void Update()
    {
        if(HealthBar.value == 100)
        {
            Debug.Log("Level was Complete");
            SceneManager.LoadScene("UI");
        }
    }
}