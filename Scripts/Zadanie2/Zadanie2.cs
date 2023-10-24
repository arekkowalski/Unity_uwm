using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector3 target;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(0.0f, 0.0f, 0.0f);
        target = new Vector3(10.0f, 0.0f, 0.0f);
    }
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        if (transform.position == target)
        {
            Vector3 temp = target;
            target = initialPosition;
            initialPosition = temp;
        }
    }
}
