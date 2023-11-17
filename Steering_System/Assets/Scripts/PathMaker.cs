using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMaker : MonoBehaviour
{
    public List<Transform> waypoints;
    [ContextMenu("Create Path")]
    void CreatePath()
    {
        waypoints = new List<Transform>();
        waypoints.AddRange(GetComponentsInChildren<Transform>());
        waypoints.Remove(this.transform);
    }

    private void OnDrawGizmos()
    {
        if(waypoints != null && waypoints.Count > 0) 
        {
            Gizmos.color = Color.magenta;
            for (int i = 1; i < waypoints.Count; i++)
            {
                Gizmos.DrawLine(waypoints[i - 1].position, waypoints[i].position);
            }
            Gizmos.DrawLine(waypoints[0].position, waypoints[waypoints.Count - 1].position);
        }
    }
}
