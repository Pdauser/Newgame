using UnityEngine;

public class CharacterDisplayFunction : MonoBehaviour
{
    public CanvasControl canvasManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CharacterInventory()
    {
        canvasManager.ShowCharacterScrollView();
    }
    public void BacktoPlayMenu()
    {
        canvasManager.PlayMenuView();
    }
    public void ChooseMenu()
    {
        CharactersList.unselected = CharactersList.list;
        CharactersList.selected.Clear();
        canvasManager.ChooseMenuView();
    }
    public void BattleModeMenu()
    {
        canvasManager.BattleModeMenuView();
    }
    public void InitSurvival()
    {
        canvasManager.SurvivalMode();
    }
    public void InitFast()
    {
        canvasManager.FastlMode();
    }
    public void InitKill()
    {
        canvasManager.KillMode();
    }
    public void Save()
    {
        SaveLoad save = new SaveLoad();
        Money.SaveCoins();
        save.saveCharacter();
    }

    public void Load()
    {
        SaveLoad load = new SaveLoad();
        Money.LoadCoins();
        load.loadCharacter();
    }
    public void Exist()
    {
        Save();
        Application.Quit();
    }
}
