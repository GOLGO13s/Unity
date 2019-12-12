using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZombi : MonoBehaviour
{
    private int damage = 1;
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            Debug.Log("当たり");
            //Playerがダメージを受けた時の処理を取得する
            // coll.GetComponent<PlayerMovementScript>().Damage(damage);
            coll.GetComponent<LifeGaugeCharacter>().Damage(damage);
        }
    }
}
