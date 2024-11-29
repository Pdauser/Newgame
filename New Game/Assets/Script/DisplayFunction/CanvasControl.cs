using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    public GameObject playMenu;         // Danh sách các Canvas cần quản lý.
    public GameObject characterScrollView; // Scroll View hiển thị danh sách nhân vật.
    public CharacterManager characterInventory;
    // Hàm tắt tất cả các Canvas và chỉ hiển thị Scroll View.
    private void Start()
    {
        playMenu.SetActive(true);
        characterScrollView.SetActive(false);
    }
    public void ShowCharacterScrollView()
    {
        characterInventory.DisplayAllCharacters();
        playMenu.SetActive(false);
        characterScrollView.SetActive(true); // Hiển thị Scroll View chứa danh sách nhân vật.
    }
    public void PlayMenuView()
    {
        playMenu.SetActive(true);
        characterScrollView.SetActive(false);
    }
}

