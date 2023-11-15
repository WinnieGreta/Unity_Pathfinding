using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour
{
    public float speed = 2f;
    public Transform target;
    Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        transform.LookAt(target);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(transform.forward *  speed * Time.deltaTime, Space.World);
        rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * speed);
    }
}
