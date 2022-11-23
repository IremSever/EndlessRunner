using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    Text coins;
    [SerializeField] int value;
    void Start()
    {
        coins = FindObjectOfType<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            coins.text = (Int32.Parse(coins.text) + value).ToString();
            Destroy(gameObject);
        }
    }
}
