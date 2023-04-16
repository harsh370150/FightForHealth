using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resume : MonoBehaviour
{
    public static Resume instance;
    public GameObject Sound, start, pause;
    public Scene scene;

    public void Awake()
    {
        scene = SceneManager.GetActiveScene();
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        Debug.Log(scene.name);
    }
    public void resume()
    {
        Destroy(Sound);
        if (Pause.instance.SceneName == "Level1")
        {
            loadscene();
            start.SetActive(false);
            pause.SetActive(true);
        }
        if (Pause.instance.SceneName == "Level2")
        {
            loadscene();
        }
        if (Pause.instance.SceneName == "Level3")
        {
            loadscene();
        }
    }
    public void loadscene()
    {
        SceneManager.UnloadSceneAsync("UI");
        Pause.instance.Level.SetActive(true);
        Time.timeScale = 1;
        start.SetActive(false);
        pause.SetActive(true);
    }
}
