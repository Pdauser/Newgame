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
    // Hàm tắt tất cả các Canvas và chỉ hiển thị Scroll View.
    private void Start()
    {
        playMenu.SetActive(true);
        characterScrollView.SetActive(false);
        chooseMenu.SetActive(false);
        MoneyPanel.text = $"{Money.Coin}";

    }
    public void ShowCharacterScrollView()
    {
        characterInventory.DisplayAllCharacters();
        playMenu.SetActive(false);
        chooseMenu.SetActive(false);
        characterScrollView.SetActive(true); // Hiển thị Scroll View chứa danh sách nhân vật.
    }
    public void PlayMenuView()
    {
        playMenu.SetActive(true);
        MoneyPanel.text = $"{Money.Coin}";
        characterScrollView.SetActive(false);
        chooseMenu.SetActive(false);
    }
    public void ChooseMenuView()
    {
        playMenu.SetActive(false);
        characterScrollView.SetActive(false);
        chooseMenu.SetActive(true);
        unselectedInventory.DisplayUnselected();

    }
    public void BattleModeMenuView()
    {
        playMenu.SetActive(false);
        characterScrollView.SetActive(false);
        chooseMenu.SetActive(false);
        battleModeMenu.SetActive(true);
    }
}

