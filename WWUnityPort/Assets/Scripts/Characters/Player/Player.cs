using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : BaseCharacter
{
    private int playerCoins = 50;
    public TextMeshProUGUI CoinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = " " + GetPlayerCoins();
    }

    public int GetPlayerCoins()
    {
        return playerCoins;
    }

    public void SubtractCoins(int amount)
    {
        playerCoins -= amount;
    }

    public void AddCoins(int amount)
    {
        playerCoins += amount;
    }
}
