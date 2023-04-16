using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public static Play play;
    
    public void playgame()
    {
       SceneManager.LoadScene("SelectLevel");
    }
}
