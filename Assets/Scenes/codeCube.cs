using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeCube : MonoBehaviour
{

    public Transform player1;
    public Material material1;

    private E[] massive;
    // Start is called before the first frame update
    void Start()
    {
        massive = GetComponentsInChildren<E>();
        foreach (var cube in massive)
        {
            cube.setSettings(player1, material1);
        }
    }
}