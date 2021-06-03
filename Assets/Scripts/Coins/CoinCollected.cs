using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CoinCollected : MonoBehaviour
{
    public AudioSource coinCollectedClip;

    public bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            Destroy(gameObject, 0.5f);

            if (!collected)
            {
                collected = true;
                CoinManager.coinManager.AddCoin(1);
                coinCollectedClip.Play();
            }
        }
    }
}
