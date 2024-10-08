using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeCircles : MonoBehaviour
{

    public Transform player1;
    public Material material1;

    private Circles[] massive;
    // Start is called before the first frame update
    void Start()
    {
        massive = GetComponentsInChildren<Circles>();
        foreach (var cube in massive)
        {
            cube.setSettings(player1, material1);
        }
    }
}