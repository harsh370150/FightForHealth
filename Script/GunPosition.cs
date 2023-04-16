using UnityEngine;

public class GunPosition : MonoBehaviour
{
    public Transform Gunpos;
    public Transform Aim;
    void Update()
    {
        Gunpos.transform.rotation = Quaternion.Slerp(transform.rotation, Aim.transform.rotation,10);
    }
}
