using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Waypoint currentDestination;
    public WaypointManager waypointManager;
    private int currentIndexWaypoint = 0;
    public float speed = 1;
    public float hp = 1.0f;
    public float damage = 0.5f;

    public void Initialize(WaypointManager waypointManager)
    {
        this.waypointManager = waypointManager;
        GetNextWaypoint();
        transform.position = currentDestination.transform.position; // Move to WP0
        GetNextWaypoint();
    }

    void Update()
    {
        
        if (hp <= 0f) {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerManager>().purse += 5f;

            Destroy(gameObject);
        }

        Vector3 direction = currentDestination.transform.position - transform.position;
        if (direction.magnitude < .2f)
        {
            GetNextWaypoint();
        }

        transform.Translate(direction.normalized * speed * Time.deltaTime);

    }

    public void lowerHp() {
        hp -= damage;
    }

    private void GetNextWaypoint()
    {
        if (currentIndexWaypoint + 1 > waypointManager.waypoints.Length) {
            Destroy(gameObject);
            return;
        }
        currentDestination = waypointManager.GetNeWaypoint(currentIndexWaypoint);
        currentIndexWaypoint++;
    }

}
