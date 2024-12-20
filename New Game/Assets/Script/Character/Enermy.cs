using UnityEngine;

public class Enermy
{
    private static readonly string[] Names = {
        "Goblin", "Wolf", "Orc", "Bandit", "Skeleton", "Slime", "Red Dragon", "Wyrm", "Kobold","Hydra", "Ghoul"
    };

    public int max_Health;
    public int current_Health;

    //Strength
    public int base_Strength;

    //Agile
    public int base_Agile;

    //Resist
    public int base_Resist;

    //TargetAi
    public string TargetAi;

    //Name
    public string Name;
    public string Id;

    public Enermy(){
        max_Health = 15;
        base_Strength = 2;
        base_Agile = 1;
        base_Resist = 1;
        TargetAi = "Single";
        Name = GenerateRandomName();
    }
    public Enermy(int max_Health, int base_Strength, int base_Agile, int base_Resist, string targetAi)
    {
        this.max_Health = max_Health;
        this.base_Strength = base_Strength;
        this.base_Agile = base_Agile;
        this.base_Resist = base_Resist;
        TargetAi = targetAi;
        Name = GenerateRandomName();
        Id = InitID();
        
    }

    public static string GenerateRandomName()
    {
        string Name = Names[Random.Range(0, Names.Length)];
        

        return $"{Name}";
    }
    public static string GenerateRandomID()
    {
        string finalID;
        string _char;
        string _num;
        _char = Character.iD[Random.Range(0, Character.iD.Length)] + Character.iD[Random.Range(0, Character.iD.Length)] + Character.iD[Random.Range(0, Character.iD.Length)] + Character.iD[Random.Range(0, Character.iD.Length)];
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
            foreach (Enermy enermy in EnermiesList.enermies)
            {
                if ( enermy.Id == finalID)
                {
                    exist = true;
                }
            }
        }
        while (exist == true);
        return finalID;
    }
}
