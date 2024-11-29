using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour 
{
    public Text nameText;
    public Text healthText;
    public Text levelText;
    public Text tierText;
    public Text strengthText;
    public Text agileText;
    public Text resistText;

    public void SetCharacterData(Character character)
    {
        nameText.text = $"Name: {character.Name}";
        healthText.text = $"Health: {character.base_Health}/{character.real_Health}";
        levelText.text = $"Level: {character.current_Level}/{character.max_Level}";
        tierText.text = $"Tier: {character._Tier}";
        strengthText.text = $"Strength: {character.base_Strength}";
        agileText.text = $"Agile: {character.base_Agile}";
        resistText.text = $"Resist: {character.base_Resist}";
    }
}
