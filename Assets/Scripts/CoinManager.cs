using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager coinManager;

    public Text totalCoins;

    public static int globalCoinsCount = 0;

    public static int levelCoinsCount = 0;

    public void Start()
    {
        if (coinManager != null && coinManager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        coinManager = this;
    }

    public void Update()
    {
        if (totalCoins == null)
        {
            totalCoins = GameObject.Find("TotalCoins").GetComponent<Text>();
            totalCoins.text = globalCoinsCount.ToString();
        }
    }

    public void AddCoin(int c)
    {
        levelCoinsCount += c;
        globalCoinsCount += c;

        totalCoins.text = globalCoinsCount.ToString();
    }
}
