using UnityEngine;
using TMPro;
public class RollFunction : MonoBehaviour
{
    public TMP_Text MoneyPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollCharacter()
    {
        
        if (Money.Coin >= 5)
        {
            Roll.GenerateRandomCharacter();
            Money.AddCoins(-5);
            MoneyPanel.text = $"{Money.Coin}";
        }
        else Debug.Log("Not Enough Money");
        
    }
}
