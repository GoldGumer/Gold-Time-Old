using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int currentRound = 0;
    private GameObject shop;
    private bool startRound = false;
    private bool isShoppingPhase = true;
    private bool stopRound = true;

    // Start is called before the first frame update
    void Start()
    {
        shop = GameObject.FindGameObjectWithTag("Shop");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0) stopRound = true;

        if (Input.GetKeyDown("space") && isShoppingPhase)
        {
            startRound = true;
            isShoppingPhase = false;
        }

        if (startRound)
        {
            GameObject.FindGameObjectWithTag("Enemy Spawner").GetComponent<EnemySpawner>().StartSpawning(currentRound);
            shop.GetComponent<ShopController>().ChangeShop();
            startRound = false;
        }
        else if (stopRound)
        {
            shop.GetComponent<ShopController>().ChangeShop();
            currentRound++;
            stopRound = false;
            isShoppingPhase = true;
        }
    }
}
