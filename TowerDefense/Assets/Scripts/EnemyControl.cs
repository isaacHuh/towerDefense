using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public List<Vector3> Waypoints;
    public float spd = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        /*
        Waypoints = new List<Vector3>();

        Waypoints.Add(new Vector3(1, 0, 1));
        Waypoints.Add(new Vector3(5, 0, 2));
        Waypoints.Add(new Vector3(1, 0, 1));
        Waypoints.Add(new Vector3(-2, 0, -4));
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Waypoints.Count == 0) { return; }

        if (transform.position != Waypoints[0])
        {
            MoveTowardsWaypoints(Waypoints[0]);
        }
        else
        {
            Waypoints.Remove(Waypoints[0]);
        }
    }

    void MoveTowardsWaypoints(Vector3 point) {
        float step = spd * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, point, step);

        if (Vector3.Distance(transform.position, point) < 0.001f)
        {
            transform.position = point;
        }
    }
}
