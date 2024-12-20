using System.IO;
using UnityEngine;
[System.Serializable]
public static class Money
{
    public static int Coin = 50;
    private static string path = Application.persistentDataPath + "/money.json";
    public static void AddCoins(int amount)
    {if (Coin + amount >= 0)
        {
            Coin += amount;
        }
        
    }
    public static void SaveCoins()
    {
        string json = JsonUtility.ToJson(new MoneyData { Coin = Coin }, true);
        File.WriteAllText(path, json);
        Debug.Log("Money saved to: " + path);
    }

    // Đọc Coin từ file JSON
    public static void LoadCoins()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            MoneyData data = JsonUtility.FromJson<MoneyData>(json);
            Coin = data.Coin;
            Debug.Log("Money loaded from: " + path);
        }
        else
        {
            Debug.LogWarning("No money save file found at: " + path);
        }
    }
    [System.Serializable]
    private class MoneyData
    {
        public int Coin;
    }
}

