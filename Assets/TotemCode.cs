using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemCode : MonoBehaviour
{
    private Transform Player;
    private ParticleSystem playerFire;
    private Light playerLight;
    //
    private float maxIntensityPlayerFire;


    private Light lightTotem;
    private ParticleSystem fireTotem;
    //
    private bool totemOn = false;

    public float distanceTotem = 4;
    public float waitTimeInSecTotem = 6;
    public float maxIntensityTotem = 0.8f;

    private float fullness = 0;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        lightTotem = GetComponentInChildren<Light>();
        fireTotem = GetComponentInChildren<isFireTotem>().getFire();
        fireTotem.Pause();
    }
    public void SetPlayerSettings(Transform transform1, ParticleSystem fire1, Light light1)
    {
        Player = transform1;
        playerFire = fire1;
        playerLight = light1;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(fullness < waitTimeInSecTotem);
        if (playerFire.isPlaying)
        {
            //totem:
            if (fullness < waitTimeInSecTotem)
            {
                distance = Vector3.Distance(Player.position, transform.position);
                if (distance <= distanceTotem && Mathf.Abs(transform.position.y - Player.position.y) <= 3)
                {
                    fullness += Time.deltaTime;
                    lightTotem.intensity = (fullness / waitTimeInSecTotem) * maxIntensityTotem;
                }
            }
            else
            {
                fireTotem.Play();
                if (!totemOn)
                {
                    playerFire.Clear();
                    playerFire.Pause();
                    playerLight.intensity = 0;
                    totemOn = true;
                    fullness = 0;
                }
            }
        }
    }
}
