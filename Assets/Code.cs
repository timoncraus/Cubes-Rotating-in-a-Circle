using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour
{
    public Transform Player;
    public ParticleSystem playerFire;
    public Light playerLight;
    //
    private float maxIntensityPlayerFire;

    public Transform main;
    public Transform main2;
    public float distanceMain = 1.4f;

    private float distance;
    private float distance2;

    // Start is called before the first frame update
    void Start()
    {
        maxIntensityPlayerFire = playerLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(Player.position, main.position);
        distance2 = Vector3.Distance(Player.position, main2.position);
        if (distance <= distanceMain || distance2 <= distanceMain)
        {
            playerLight.intensity = maxIntensityPlayerFire;
            playerFire.Play();
        }
    }
}
