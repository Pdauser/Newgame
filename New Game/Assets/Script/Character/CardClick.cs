using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CardClick : MonoBehaviour
{
    public CanvasControl CanvasControl;
    public TMP_Text IdText;
    public void ClickBehav()
    {
        CanvasControl = GameObject.Find("Canvas Control").GetComponent<CanvasControl>();
        
        TMP_Text idText = gameObject.transform.Find("Id")?.GetComponent<TMP_Text>();
        bool Found = false;
        foreach (Character character in CharactersList.unselected)
        {
            if(!Found)
            {
                if (character.Id == idText.text)
                {
                    if(CharactersList.selected.Count < 5)
                    {
                        CharactersList.selected.Add(character);
                        CharactersList.unselected.Remove(character);
                        Found = true;
                        break;
                    }
                    
                    
                }
               
            }
        }
        foreach (Character character in CharactersList.selected)
        {
            if (!Found)
            {   
                if (character.Id == idText.text)
                {
                    CharactersList.unselected.Add(character);
                    CharactersList.selected.Remove(character);
                    Found = true;
                    break;
                }
                
            }
        }
        CanvasControl.unselectedInventory.DisplayUnselected();
        CanvasControl.selectedInventory.DisplaySelected();
    }
    public void ClickDelete()
    {
        CanvasControl = GameObject.Find("Canvas Control").GetComponent<CanvasControl>();
        TMP_Text idText = IdText;
        foreach (Character character in CharactersList.list)
        {
                if (character.Id == idText.text)
                {
                    CharactersList.list.Remove(character);
                    break;
                }

            
        }
        CanvasControl.characterInventory.DisplayAllCharacters();
    }
}
