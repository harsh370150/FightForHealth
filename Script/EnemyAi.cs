using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{
    public float look = 10;
    public Transform Player;
    public NavMeshAgent Agent;
    public Animator EnemyAnimation;
    public Slider EnemyHealth;
    public static float HealthEnemy;
    public float targetDistance;
    public GameObject EnemyAudio;

    public static EnemyAi instance;
    
    private void Awake()
    {
        EnemyHealth.minValue = 0;
        EnemyHealth.maxValue = 100;
        Agent = GetComponent<NavMeshAgent>();
        transform.Translate(0, 0, 1);

        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        targetDistance = Vector3.Distance(Player.position, transform.position);
        if (targetDistance <= look)
        {
            Agent.SetDestination(Player.position);
            EnemyAnimation.SetBool("attack", false);
            EnemyAnimation.SetBool("walk", true);
            EnemyAudio.SetActive(true);
        }
        if (targetDistance < 10)
        {
            EnemyAnimation.SetBool("attack", true);
            EnemyAnimation.SetBool("walk", false);
            EnemyAudio.SetActive(false);
        }
        if (EnemyHealth.value == 100)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("SelectLevel");
        }
        HealthEnemy = EnemyHealth.value;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            EnemyHealth.value += 10;
        }
    }
}
