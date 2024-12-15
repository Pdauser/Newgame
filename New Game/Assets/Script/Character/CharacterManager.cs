using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public GameObject cardPrefab; // Prefab của thẻ bài
    public Transform cardParent; // Nơi chứa các thẻ bài (Content của Scroll View)

    public void DisplayAllCharacters()
    {
        ClearAllCards(); // Xóa thẻ cũ trước khi hiển thị lại

        foreach (Character character in CharactersList.list)
        {
            //Debug.Log($"{character.Name}");
            GenerateCharacterCard(character);
        }
    }
    public void DisplayUnselected()
    {
        ClearAllCards();
        foreach (Character character in CharactersList.unselected)
        {
            //Debug.Log($"{character.Name}");
            GenerateCharacterCard(character);
        }
    }
    public void DisplaySelected()
    {
        ClearAllCards();
        foreach (Character character in CharactersList.selected)
        {
            //Debug.Log($"{character.Name}");
            GenerateCharacterCard(character);
        }
    }

    private void GenerateCharacterCard(Character character)
    {
        // Tạo thẻ bài từ prefab
        GameObject card = Instantiate(cardPrefab, cardParent);

        TMP_Text nameText = card.transform.Find("Name")?.GetComponent<TMP_Text>();
        TMP_Text levelText = card.transform.Find("Level")?.GetComponent<TMP_Text>();
        TMP_Text healthText = card.transform.Find("Health")?.GetComponent<TMP_Text>();
        TMP_Text strengthText = card.transform.Find("StrengthText")?.GetComponent<TMP_Text>();
        TMP_Text agileText = card.transform.Find("AgileText")?.GetComponent<TMP_Text>();
        TMP_Text resistText = card.transform.Find("ResistText")?.GetComponent<TMP_Text>();
        TMP_Text tierText = card.transform.Find("Tier")?.GetComponent<TMP_Text>();
        TMP_Text idText = card.transform.Find("Id")?.GetComponent<TMP_Text>();

        if (nameText != null) nameText.text = character.Name;
        if (levelText != null) levelText.text = $"Lv: {character.current_Level}/{character.max_Level}";
        if (healthText != null) healthText.text = $"HP: {character.base_Health}";
        if (strengthText != null) strengthText.text = $"STR: {character.base_Strength}";
        if (agileText != null) agileText.text = $"AGI: {character.base_Agile}";
        if (resistText != null) resistText.text = $"RES: {character.base_Resist}";
        if (tierText != null) tierText.text = $" Tier: {character._Tier}";
        if (idText !=null)
        {
            idText.text = character.Id;
        }
    }

    private void ClearAllCards()
    {
        foreach (Transform child in cardParent)
        {
            Destroy(child.gameObject);
        }
    }


}