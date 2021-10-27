using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath1 : MonoBehaviour
{
    public int deathNum = 3;
    public int hitCount = 0;
    public int killedEnemy = 0;
    public Text EnemyHpText;
    public Text EnemyKillText;
    public GameObject gameClear;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerBULLET"))
        {
            deathNum--;
            EnemyHpText.text = "Enemy HP: " + deathNum;

            if (++hitCount == 3)
            {
                killedEnemy++;
                EnemyKillText.text = "Enemy Kill: " + killedEnemy;
                GetComponent<Enemy1Ctrl>().enabled = false;
            }
        }
        if (killedEnemy == 10)
        {
            gameClear.SetActive(true);
        }
    }
}
