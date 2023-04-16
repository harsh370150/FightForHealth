using UnityEngine;

public class CompletedLevels : MonoBehaviour
{
    public GameObject level2;
    public GameObject level3;
    void Update()
    {
        if (Levels.level1complete)
        {
            level2.SetActive(true);
        }
        if (Levels.level2complete)
        {
            level3.SetActive(true);
        }
    }
}
