using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
            transform.parent.GetComponent<Defense>().enemyEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
            transform.parent.GetComponent<Defense>().enemyExit(other);
    }
}
