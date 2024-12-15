using UnityEngine;

[System.Serializable]
public class Character
{
    private static readonly string[] firstNames = {
        "Aiden", "Eren", "Kai", "Luna", "Nova", "Zephyr", "Ashe", "Ivy", "Theo", "Raven", "Rarken","Adam","Luccy","Solatta","Mikasha","Yasou","Zenrany"
    };

    private static readonly string[] middleNames = {
        "Shadow", "Blaze", "Storm", "Frost", "Dawn", "Wraith", "Flame", "Bane", "Light", "Void","Wraithful","Flow"
    };

    private static readonly string[] lastNames = {
        "Hunter", "Walker", "Seeker", "Blade", "Guardian", "Knight", "Sage", "Ranger", "Mage", "Sentinel","Brawler"
    };
    private static readonly string[] iD = {
        "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","s","r","t","w","z","u","v","y","x"
    };


    //Health
    public int base_Health;
    public int real_Health;
    public int current_Health;

    //Tier
    public enum TierList
    {
        SoulBound,
        _1,
        _2,
        _3,
        _4,
        _5,
        Unique
    }
    public TierList _Tier;
    public bool can_Tier_Up;

    //Level
    public int current_Level;
    public int max_Level;

    //Exp
    public int current_Exp;
    public int max_Exp;

    //Strength
    public int base_Strength;
    public int real_Strength;

    //Agile
    public int base_Agile;
    public int real_Agile;

    //Resist
    public int base_Resist;
    public int real_Resist;

    //TargetAi
    public string TargetAi;

    //Name
    public string Name;
    public string Id;
    public Character()
    {
        base_Health = 10;
        _Tier = TierList._1;
        can_Tier_Up = false;
        current_Exp = 0;
        current_Level = 1;
        max_Level = 20;
        base_Strength = 1;
        base_Agile = 1;
        base_Resist = 1;
        TargetAi = "Single";
        Name = GenerateRandomName();
        Id = InitID();
        
    }

    public Character(int health, string Tier, int strength, int agile, int resist, string targetAi)
    {
        if (health >= 10)
        {
            base_Health = health;
        }
        else base_Health = 10;

        switch (Tier)
        {
            case "SoulBound": _Tier = TierList.SoulBound; break;
            case "_1": _Tier = TierList._1; break;
            case "_2": _Tier = TierList._2; break;
            case "_3": _Tier = TierList._3; break;
            case "_4": _Tier = TierList._4; break;
            case "_5": _Tier = TierList._5; break;
            case "Unique": _Tier = TierList.Unique; break;
            default: _Tier = TierList._1; break;
        }
        can_Tier_Up = false;

        current_Level = 1;
        switch (_Tier)
        {
            case TierList.SoulBound:
                break;
            case TierList._1: max_Level = 30;
                break;
            case TierList._2: max_Level = 50;
                break;
            case TierList._3: max_Level = 75;
                break;
            case TierList._4: max_Level = 100;
                break;
            case TierList._5: max_Level = 150;
                break;
            case TierList.Unique: max_Level = 300;
                break;
            default:
                break;
        }

        current_Exp = 0;
        max_Exp = current_Level * 100;

        if (strength >= 1)
        {
            base_Strength = strength;
        } else base_Strength = 1;

        if (agile >= 1)
        {
            base_Agile = agile;
        } else base_Agile = 1;

        if (resist >= 1)
        {
            base_Resist = resist;
        }else base_Resist= 1;

        if (targetAi == "Single" || targetAi == "Multi")
        {
            TargetAi = targetAi;
        }
        else TargetAi = "Single";
        Name = GenerateRandomName();
        Id = InitID();
    }
    public static string GenerateRandomName()
    {
        string firstName = firstNames[Random.Range(0, firstNames.Length)];
        string middleName = middleNames[Random.Range(0, middleNames.Length)];
        string lastName = lastNames[Random.Range(0, lastNames.Length)];

        return $"{firstName} {middleName} {lastName}";
    }
    public static string GenerateRandomID()
    {
        string finalID;
        string _char;
        string _num;
        _char = iD[Random.Range(0, iD.Length)] + iD[Random.Range(0, iD.Length)] + iD[Random.Range(0, iD.Length)] + iD[Random.Range(0, iD.Length)];
        _num = Random.Range(10000, 99999).ToString();
        finalID = _char + _num;
        return finalID;
    }
    public static string InitID()
    {
        string finalID;
        bool exist;
        do
        {
            exist = false;
            finalID = GenerateRandomID();
            foreach(Character character in CharactersList.list){
                if(character.Id == finalID)
                {
                    exist = true;
                }
            }
        }
        while (exist == true);
        return finalID;
    }
    public void RollResult()
    {

        Debug.Log($"Generated Character: {Name}");
        Debug.Log($"Health: {base_Health}");
        Debug.Log($"Tier: {_Tier}");
        Debug.Log($"Strength: {base_Strength}");
        Debug.Log($"Agile: {base_Agile}");
        Debug.Log($"Resist: {base_Resist}");
        Debug.Log($"Target AI: {TargetAi}");
    }
}
