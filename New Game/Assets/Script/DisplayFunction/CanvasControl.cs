using UnityEngine;
using TMPro;
public class CanvasControl : MonoBehaviour
{
    public GameObject playMenu;         // Danh sách các Canvas cần quản lý.
    public GameObject characterScrollView; // Scroll View hiển thị danh sách nhân vật.
    public CharacterManager characterInventory;
    public TMP_Text MoneyPanel;

    public GameObject chooseMenu;
    public CharacterManager unselectedInventory;
    public CharacterManager selectedInventory;

    public GameObject battleModeMenu;
    public BattleInit battleInit;

    public GameObject BattleView;

    public CharacterManager enermiesView;
    public CharacterManager alliesView;

    public GameObject rewardView;
    public TMP_Text Exp_Text;
    public TMP_Text Money_Text;
    // Hàm tắt tất cả các Canvas và chỉ hiển thị Scroll View.
    private void Start()
    {
        playMenu.SetActive(true);
        characterScrollView.SetActive(false);
        chooseMenu.SetActive(false);
        MoneyPanel.text = $"{Money.Coin}";
        BattleView.SetActive(false);
        battleModeMenu.SetActive(false);
        rewardView.SetActive(false);

    }
    public void ShowCharacterScrollView()
    {
        characterInventory.DisplayAllCharacters();
        playMenu.SetActive(false);
        chooseMenu.SetActive(false);
        characterScrollView.SetActive(true);
        BattleView.SetActive(false);
        battleModeMenu.SetActive(false);
        rewardView.SetActive(false);

    }
    public void PlayMenuView()
    {
        playMenu.SetActive(true);
        MoneyPanel.text = $"{Money.Coin}";
        characterScrollView.SetActive(false);
        chooseMenu.SetActive(false);
        BattleView.SetActive(false);
        battleModeMenu.SetActive(false);
        rewardView.SetActive(false);
        foreach (Character character in CharactersList.selected)
        {
            CharactersList.list.Add(character);
        }
        CharactersList.selected.Clear();
        
    }
    public void ChooseMenuView()
    {
        playMenu.SetActive(false);
        characterScrollView.SetActive(false);
        chooseMenu.SetActive(true);
        unselectedInventory.DisplayUnselected();
        selectedInventory.DisplaySelected();
        BattleView.SetActive(false);
        battleModeMenu.SetActive(false);
        rewardView.SetActive(false);

    }
    public void BattleModeMenuView()
    {
        playMenu.SetActive(false);
        characterScrollView.SetActive(false);
        chooseMenu.SetActive(false);
        battleModeMenu.SetActive(true);
        BattleView.SetActive(false);
        rewardView.SetActive(false);
    }
    public void SurvivalMode()
    {
        playMenu.SetActive(false);
        characterScrollView.SetActive(false);
        chooseMenu.SetActive(false);
        battleModeMenu.SetActive(false);
        BattleView.SetActive(true);
        battleInit.InitSurvival();
        rewardView.SetActive(false);
    }
    public void FastlMode()
    {
        playMenu.SetActive(false);
        characterScrollView.SetActive(false);
        chooseMenu.SetActive(false);
        battleModeMenu.SetActive(false);
        BattleView.SetActive(true);
        battleInit.InitFast();
        rewardView.SetActive(false);
    }
    public void KillMode()
    {
        playMenu.SetActive(false);
        characterScrollView.SetActive(false);
        chooseMenu.SetActive(false);
        battleModeMenu.SetActive(false);
        BattleView.SetActive(true);
        battleInit.InitKill();
        rewardView.SetActive(false);
    }
    public void RewardView()
    {
        playMenu.SetActive(false);
        characterScrollView.SetActive(false);
        chooseMenu.SetActive(false);
        BattleView.SetActive(false);
        battleModeMenu.SetActive(false);
        rewardView.SetActive(true);
        BattleReward(BattleControler.killed, BattleControler.turn);
    }

    public void BattleReward(int kill, int turn)
    {
        int Exp = (int)(((kill * 50) + (turn * 20))* 1.15f / CharactersList.selected.Count); //CharactersList.selected.Count;
        int money = (kill * 2) + (turn * 1);
        Money.AddCoins(money);
        Exp_Text.text = $"Exp: {Exp}";
        Money_Text.text = $"Money: {money}";
        foreach (Character character in CharactersList.selected)
        {
            character.current_Exp += Exp;
            if (character.current_Exp >= character.max_Exp && character.current_Level < character.max_Level)
            {
                character.current_Exp = 0;
                Character.LevelUp(character);
            }
            CharactersList.list.Add(character);
            
        }
        CharactersList.selected.Clear();
    }


}

