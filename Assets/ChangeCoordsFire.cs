using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCoordsFire : MonoBehaviour
{
    public Transform fire;
    public Transform sphere;

    // Update is called once per frame
    void Update()
    {
        fire.position = sphere.position;
    }
}
