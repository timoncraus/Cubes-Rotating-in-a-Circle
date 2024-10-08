using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMassiveTotem : MonoBehaviour
{
    
    public Transform Player;
    public ParticleSystem playerFire;
    public Light playerLight;

    private TotemCode[] massive;
    // Start is called before the first frame update
    void Start()
    {
        massive = GetComponentsInChildren<TotemCode>();
        foreach (var totem in massive)
        {
            totem.SetPlayerSettings(Player, playerFire, playerLight);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
