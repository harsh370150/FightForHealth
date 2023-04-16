using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strome : MonoBehaviour
{
    public GameObject StromeObject;
    public Vector3 StromeArea;
    public float XRange1, XRange2;
    public float YRange;
    public float ZRange1, ZRange2;
    public Transform Player;
    void Update()
    {
        if (EnemyAi.instance.EnemyHealth.value >= 50)
        {
            StromeArea = new Vector3(Random.Range(Player.transform.position.x - 3, Player.transform.position.x + 3), YRange, Random.Range(Player.transform.position.z - 3, Player.transform.position.z + 3));
            Instantiate(StromeObject, StromeArea, Quaternion.identity);
        }
    }

}
