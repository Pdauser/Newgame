using UnityEngine;
using static Character;

public class BattleInit : MonoBehaviour
{
    public BattleControler battleControl;
    public CanvasControl canvasControl;
    public void InitSurvival()
    {
        battleControl.isFast = false;
        battleControl.isKill = false;
        battleControl.isSurvival = true;
        foreach (Character character in CharactersList.selected)
        {
            character.real_Health = character.base_Health;
            character.real_Agile = character.base_Agile;
            character.real_Resist = character.base_Resist;
            character.real_Strength = character.base_Strength;
            character.current_Health = character.real_Health;
            CharactersList.list.Remove(character);
        }
        InitEnermies(5);
        canvasControl.alliesView.DisplayBattleCard();
        canvasControl.enermiesView.DisplatEnermiesCard();
    }
    public void InitFast()
    {
        battleControl.isFast = true;
        battleControl.isKill = false;
        battleControl.isSurvival = false;
        foreach (Character character in CharactersList.selected)
        {
            character.real_Health = character.base_Health;
            character.real_Agile = character.base_Agile;
            character.real_Resist = character.base_Resist;
            character.real_Strength = character.base_Strength;
            character.current_Health = character.real_Health;
            foreach (Character characterList in CharactersList.list)
            {
                if(characterList.Id == character.Id)
                {
                    CharactersList.list.Remove(characterList);
                    break;
                }
            }
        }
        InitEnermies(5);
        canvasControl.alliesView.DisplayBattleCard();
        canvasControl.enermiesView.DisplatEnermiesCard();
    }
    public void InitKill()
    {
        battleControl.isFast = false;
        battleControl.isKill = true;
        battleControl.isSurvival = false;
        foreach (Character character in CharactersList.selected)
        {
            character.real_Health = character.base_Health;
            character.real_Agile = character.base_Agile;
            character.real_Resist = character.base_Resist;
            character.real_Strength = character.base_Strength;
            character.current_Health = character.real_Health;
            foreach (Character characterList in CharactersList.list)
            {
                if (characterList.Id == character.Id)
                {
                    CharactersList.list.Remove(characterList);
                    break;
                }
            }
        }
        InitEnermies(5);
        canvasControl.alliesView.DisplayBattleCard();
        canvasControl.enermiesView.DisplatEnermiesCard();
    }

    public static void InitEnermies( int Num)
    {
        float average_health = 0;
        float average_strength = 0;
        float average_agile = 0;
        float average_resist = 0;
        string TargetAi;
        foreach (Character character in CharactersList.selected)
        {
            average_health += Random.Range(character.base_Strength * 1.25f, character.base_Strength * 1.75f);
            average_strength += Random.Range(character.base_Health * 0.06f, character.base_Health * 0.11f);
            average_agile += Random.Range(character.base_Agile * 0.15f, character.base_Agile * 0.25f);
            average_resist += Random.Range(character.base_Strength * 0.05f, character.base_Strength * 0.09f);

        }
        TargetAi = Random.value > 0.5f ? "Single" : "Multi";
        for (int i = 0; i < Num; i++)
        {
            Enermy enermy = new Enermy((int)Random.Range(average_health * 0.85f, average_health * 1.15f) , (int)Random.Range(average_strength * 0.9f, average_strength * 1.1f), (int)Random.Range(average_agile * 0.85f, average_agile * 1.15f), (int)Random.Range(average_resist * 0.9f, average_resist * 1.1f), TargetAi);
            enermy.current_Health = enermy.max_Health;
            EnermiesList.enermies.Add(enermy);
            
        }
    }
}
