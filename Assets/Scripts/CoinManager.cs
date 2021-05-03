using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public void AllCoinsCollected()
    {
        if (transform.childCount==1)
        {
            Debug.Log("Se han recogido todas las monedas del nivel");
        }
    }
}
