using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protection : MonoBehaviour
{
    public Rigidbody Player;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Player.AddForce(Vector3.forward * 50, ForceMode.Impulse);
        }
    }
}
