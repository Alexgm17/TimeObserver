using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void Update()
    {
        AllCoinsCollected();
    }
    public void AllCoinsCollected()
    {
        if (transform.childCount==0)
        {
            Debug.Log("Se han recogido todas las monedas del nivel");
        }
    }
}
