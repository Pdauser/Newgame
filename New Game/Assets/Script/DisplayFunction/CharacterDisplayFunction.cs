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
}
