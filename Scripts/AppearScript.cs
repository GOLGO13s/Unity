using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearScript : MonoBehaviour
{
    //出現させる敵を入れておく
    [SerializeField] GameObject obj;
    //次に敵が出現するまでの時間
    [SerializeField] float NextappearTime;
    //この場所から出現する敵の数
    [SerializeField] int maxNumEnemys;
    //今までに何にの敵が出現したか（総数）
    [SerializeField] int numberOfEnemys;
    //待ち時間計測フィールド
    private float elapsedTime;

    GameObject enemy;
    Enemy enemyscript; //enemyScriptが入る変数
    GameObject objclone;
    int hp;

    // Use this for initialization
    void Start ()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
        enemy = GameObject.FindWithTag("Enemy");
        enemyscript = enemy.GetComponent<Enemy>(); //Enemyの中にあるEnemyScriptを取得して変数に格納する
    }
	
	void Update ()
    {
        //この場所から出現する最大数を超えていたら何もしない
        if (numberOfEnemys >= maxNumEnemys)
        {
            numberOfEnemys = 0;
            return;
        }

        //経過時間を足す
        elapsedTime += Time.deltaTime;

        //経過時間がたったら
        if(elapsedTime> NextappearTime)
        {
            elapsedTime = 0f;
            AppearEnemy();
        }

        //HPを取得してHPがゼロ以下だったら削除
        hp = enemyscript.GetHP();
        if (hp <= 0)
        {
            Destroy(objclone);
            enemy = GameObject.FindWithTag("Enemy");
            enemyscript = enemy.GetComponent<Enemy>(); //Enemyの中にあるEnemyScriptを取得して変数に格納する
        }
    }

    //敵出現メソッド
    void AppearEnemy()
    {
        if (enemy != null)
        {
            //敵の向きをランダムに決定
            var randomRotationY = Random.value * 360f;
            obj = Instantiate(enemy, transform.position, Quaternion.Euler(0f, randomRotationY, 0f)) as GameObject;
            obj.name = "Enemy";
            objclone = obj;
            numberOfEnemys++;
            elapsedTime = 0f;
        }
    }
}
