using UnityEngine;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
static class CharactersList
{
    static public List<Character> list = new List<Character>();
    static public List<Character> unselected = new List<Character>();
    static public List <Character> selected = new List<Character>();
}
[System.Serializable]
static class EnermiesList
{
    static public List<Enermy> enermies = new List<Enermy>();
}

[System.Serializable]
public class CharacterListWrapper
{
    public List<Character> Characters;
}
public class SaveLoad
{
    private string path = Application.persistentDataPath + "/characters.json";

    public void saveCharacter()
    {
        CharacterListWrapper wrapper = new CharacterListWrapper { Characters = CharactersList.list };
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(path, json);
        Debug.Log("Characters saved to: " + path);
    }

    public void loadCharacter()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            CharactersList.list = JsonUtility.FromJson<CharacterListWrapper>(json).Characters;
            Debug.Log("Characters loaded from: " + path);
        }
        else
        {
            Debug.LogWarning("No save file found at: " + path);
        }
    }

}
