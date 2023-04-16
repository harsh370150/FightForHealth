using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    public Ray ray;
    void Update()
    {
        transform.Translate(0, 0, 1, Space.Self);
        Destroy(gameObject, 5);
        Debug.DrawLine(ray.origin, ray.direction);
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Bullet is Touch To Enemy");
        }
        if (other.gameObject.CompareTag("aim"))
        {
            Debug.Log("Bullet is Touch To Aim");
        }
    }

}
