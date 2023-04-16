using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public GameObject Player;
    public NavMeshAgent Agent;

    void Update()
    {
        Agent.SetDestination(Player.transform.position);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            PlayerHealth.instance.HealthBar.value += 5;
        }
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
