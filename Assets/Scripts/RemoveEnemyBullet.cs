using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEnemyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "EBULLET")
        {
            Destroy(collision.gameObject);
        }
    }
}
