using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour {

    public event System.Action OnCoinTake;

    int coinCount = 0;

    void OnTriggerEnter (Collider other) {
        if (other.tag == "Coin") {
            Destroy(other.gameObject);
            coinCount += 1;
            if(OnCoinTake != null)
            {
                OnCoinTake.Invoke();
            }
        }
	}

    public int GetCoins()
    {
        return coinCount;
    }
}
