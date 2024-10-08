using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codePlaces : MonoBehaviour
{
    
    public Material material;
    public Material material2;

    private Places[] massivePlaces;
    private Color color;
    private Color color2;
    private int rezult;
    // Start is called before the first frame update
    void Start()
    {
        massivePlaces = GetComponentsInChildren<Places>();
        ColorUtility.TryParseHtmlString("#848479", out color);
        ColorUtility.TryParseHtmlString("#E6ECEC", out color2);
    }

    // Update is called once per frame
    void Update()
    {
        rezult = 0;
        for (int i = 0; i < massivePlaces.Length; i++)
        {
            if (massivePlaces[i].isReady())
            {
                rezult += 1;
            }
        }
        Debug.Log(rezult);
        if(rezult == massivePlaces.Length)
        {
            material.color = Color.black;
            material2.color = Color.black;
        }
        else
        {
            material.color = color;
            material2.color = color2;
        }
    }
}
