using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public GameObject Level;
    void Awake()
    {
        Level = GameObject.FindGameObjectWithTag("level");
    }
    public void level1()
    {
        SceneManager.LoadScene("Level1");        
        Destroy(Level);
    }

    public void level2()
    {
        SceneManager.LoadScene("Level2");
        Destroy(Level);
    }

    public void level3()
    {
        SceneManager.LoadScene("Level3");
        Destroy(Level);
    }
}
