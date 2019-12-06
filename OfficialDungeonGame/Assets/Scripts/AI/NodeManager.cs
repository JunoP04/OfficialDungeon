using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public GameObject Waypoint;
    public List<SingleNode> Intersection = new List<SingleNode>();

    public void generateNode(Vector3 targetLocation, bool N, bool E, bool S, bool W)
    {
        SingleNode e = new SingleNode(targetLocation, N, E, S, W);
        Intersection.Add(e);
        Instantiate(Waypoint, new Vector3(targetLocation.x, 15, targetLocation.z), Quaternion.identity);


    }
    private void Update()
    {
        foreach(SingleNode waypoint in Intersection)
        {
            Debug.DrawLine(Intersection[Intersection.Count-1].location, this.gameObject.transform.position, Color.red);
            Debug.Log("test");
        }
    }
}
