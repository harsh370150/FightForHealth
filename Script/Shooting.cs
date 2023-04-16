using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullets;
    public Transform BulletPosition;
    public Transform Aim;
    public Animator ShootingAnimation;
    public GameObject ShootingVFX;
    public AudioSource source;
    public AudioClip clip;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Quaternion rotate = Quaternion.Slerp(BulletPosition.transform.rotation, Aim.transform.rotation, 10);
            Instantiate(Bullets, transform.position, rotate);
            Bullets.transform.rotation = rotate;
            ShootingVFX.SetActive(true);
            AudioManager.instance.PlayFireSound();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ShootingVFX.SetActive(false);
        }

        
    }
}
