using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static Pause instance;
    Scene scene;
    public string SceneName;
    public GameObject Level;
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
            SceneName = scene.name;
            Level.SetActive(false);
            if(SceneName == "Level1")
            {
                Resume.instance.start.SetActive(false);
                Resume.instance.pause.SetActive(true);
            }
        }
    }
}
