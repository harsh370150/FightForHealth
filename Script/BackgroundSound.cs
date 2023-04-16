using UnityEngine;
using UnityEngine.UI;

public class BackgroundSound : MonoBehaviour
{
    public AudioSource Audio;
    public Slider AudioSlider;
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
        AudioSlider.minValue = 0;
        AudioSlider.maxValue = 1;
        Audio.volume = AudioSlider.value;
    }
}
