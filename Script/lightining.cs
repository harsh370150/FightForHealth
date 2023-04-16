using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightining : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0,0,90);
    }
    void Update()
    {
        Destroy(this.gameObject,3);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
            Debug.Log("Object is Destroy");
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("Object was Touch to Player");
            PlayerHealth.instance.HealthBar.value += 10;
        }
    }
}
