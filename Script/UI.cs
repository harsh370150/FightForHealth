using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Slider Sensitivity;
    
    public void Sensi()
    {
        Sensitivity.maxValue = 500;
        Sensitivity.minValue = 0;
        PlayerController.freelookcamera.m_XAxis.m_MaxSpeed = Sensitivity.value;
    }
}