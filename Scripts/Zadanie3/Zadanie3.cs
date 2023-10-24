using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3 : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector3[] waypoints;
    private int currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = new Vector3[4];
        waypoints[0] = new Vector3(0.0f, 0.0f, 0.0f);
        waypoints[1] = new Vector3(10.0f, 0.0f, 0.0f);
        waypoints[2] = new Vector3(10.0f, 0.0f, 10.0f);
        waypoints[3] = new Vector3(0.0f, 0.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], step);
        
        if (transform.position == waypoints[currentWaypointIndex])
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Prze³¹czamy siê miêdzy punktami docelowymi
            
            // Obracamy obiekt o 90 stopni w kierunku kolejnego ruchu
            transform.Rotate(Vector3.up, 90.0f);
        }
    }
}
