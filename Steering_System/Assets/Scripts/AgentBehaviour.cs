using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour
{
    public float speed = 2f;
    public float rotationSpeed = 1.0f;
    public const float distanceToChangeWaypoint = 5f;
    public Transform target;
    Rigidbody rb;

    public PathMaker pathMaker;
    List<Transform> path { get { return pathMaker.waypoints; } }

    private int currentWaypoint = 0;
    private bool isObstructed;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //transform.LookAt(target);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(transform.forward *  speed * Time.deltaTime, Space.World);
        //rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
        if (!isObstructed)
        {
            Steer();
        }
        else
        {
            //Avoid()
        }
        Move();
        CheckWaypoint();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * speed);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
    }

    private void Steer()
    {
        Vector3 targetDirection = path[currentWaypoint].position - rb.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.fixedDeltaTime, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void CheckWaypoint()
    {
        if (Vector3.Distance(rb.position, path[currentWaypoint].position) < distanceToChangeWaypoint)
        {
            currentWaypoint++;
            if (currentWaypoint == path.Count)
            {
                currentWaypoint = 0;
            }
        }
    }
}
