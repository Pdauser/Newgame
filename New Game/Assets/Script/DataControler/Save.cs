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

public class Save
{
    private string path = Application.persistentDataPath + "/characters.json";
    public void saveCharacter()
    {
        string json = JsonUtility.ToJson(CharactersList.list, true);
        File.WriteAllText(path, json);
        Debug.Log("Characters saved to: " + path);
    }
}
