using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StromeObject : MonoBehaviour
{
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
            PlayerHealth.instance.HealthBar.value += 10;
        }
    }

}
