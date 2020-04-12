using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            transform.parent.GetComponent<Enemy>().lowerHp(other.gameObject.GetComponent<Bullet>().damage);
            Destroy(other.gameObject);
        }
    }

}
