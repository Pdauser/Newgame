using UnityEngine;
[System.Serializable]
public static class Money
{
    public static int Coin = 50;

    public static void AddCoins(int amount)
    {if (Coin + amount >= 0)
        {
            Coin += amount;
        }
        
    }
}

