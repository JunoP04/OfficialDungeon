using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SingleNode
{
    //public class Node
    //{
        public Vector3 location;
        public bool North;
        public bool East;
        public bool South;
        public bool West;

        public SingleNode(Vector3 targetLocation, bool N, bool E, bool S, bool W)
        {
            location = targetLocation;
            North = N;
            East = E;
            South = E;
            West = W;

        }

        public SingleNode(Vector3 targetLocation)
        {
            location = targetLocation;
            North = true;
            East = true;
            South = true;
            West = true;
        }




    //}

}
