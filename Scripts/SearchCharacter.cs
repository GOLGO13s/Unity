using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour
{

    private Enemy Enemy;

    void Start()
    {
        Enemy = GetComponentInParent<Enemy>();
    }

    void OnTriggerStay(Collider col)
    {
        //　プレイヤーキャラクターを発見
        if (col.tag == "Player")
        {
            //　敵キャラクターの状態を取得
            Enemy.EnemyState state = Enemy.GetState();
            //　敵キャラクターが追いかける状態でなければ追いかける設定に変更
            if (state == Enemy.EnemyState.Wait || state == Enemy.EnemyState.Walk)
            {
                Enemy.SetState(Enemy.EnemyState.Chase, col.transform);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("見失う");
            Enemy.SetState(
                Enemy.EnemyState.Wait);
        }
    }
}
