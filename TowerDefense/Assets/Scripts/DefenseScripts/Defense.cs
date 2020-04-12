using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();
    public GameObject bullet;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(shoot(1.0f));
    }
    private IEnumerator shoot(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (enemies.Count > 0) {
                Instantiate(bullet, transform.position, transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(enemies.Count);
        if (enemies.Count > 0) {
            if (enemies[0] != null)
            {
                GameObject target = enemies[0];
                transform.LookAt(target.transform);
            }
            else
            {
                enemies.RemoveAt(0);
            }
        }
    }

    public void enemyEnter(Collider other)
    {
        enemies.Add(other.gameObject);
    }

    public void enemyExit(Collider other)
    {
        enemies.Remove(other.gameObject);
    }
}
