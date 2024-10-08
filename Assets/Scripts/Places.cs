using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Places : MonoBehaviour
{
    public Transform cube;

    public bool isReady()
    {
        return Vector3.Distance(transform.position, cube.position) <= 3;
        //return false;
    }
}
