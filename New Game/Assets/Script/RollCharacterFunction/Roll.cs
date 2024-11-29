using System.Collections.Generic;
using UnityEngine;
using static Character;

public class Roll
{
    private static readonly string[] tierOptions = { "SoulBound", "_1", "_2", "_3", "_4", "_5", "Unique" };

    // Trọng số cho mỗi Tier (phần tử thứ n tương ứng với tierOptions[n])
    private static readonly int[] tierWeights = { 1, 40, 30, 15, 10, 3, 1 };

    public string _Tier;
    public static void GenerateRandomCharacter()
    {

        string randomTier = GenerateRandomTier();
        int randomHealth = 10;
        int randomStrength =1;
        int randomAgile= 1;
        int randomResist =1;
        switch (randomTier)
        {
            case "SoulBound":
                randomHealth = Random.Range(10, 25);
                randomStrength = Random.Range(1, 3);
                randomAgile = Random.Range(1, 3);
                randomResist = Random.Range(1, 3); break;
            case "_1":
                randomHealth = Random.Range(20, 35 );
                randomStrength = Random.Range(3, 6);
                randomAgile = Random.Range(3, 6);
                randomResist = Random.Range(3, 6); break;
            case "_2":
                randomHealth = Random.Range(80, 95);
                randomStrength = Random.Range(30, 34);
                randomAgile = Random.Range(30, 34);
                randomResist = Random.Range(30, 34); break;
            case "_3":
                randomHealth = Random.Range(160, 184);
                randomStrength = Random.Range(60, 64);
                randomAgile = Random.Range(60, 64);
                randomResist = Random.Range(60, 64); break;
            case "_4":
                randomHealth = Random.Range(240, 266);
                randomStrength = Random.Range(100, 114);
                randomAgile = Random.Range(100, 114);
                randomResist = Random.Range(100, 114); break;
            case "_5":
                randomHealth = Random.Range(340, 358);
                randomStrength = Random.Range(141, 156);
                randomAgile = Random.Range(141, 156);
                randomResist = Random.Range(141, 156); break;
            case "Unique":
                randomHealth = Random.Range(500, 530);
                randomStrength = Random.Range(190, 200);
                randomAgile = Random.Range(190, 200);
                randomResist = Random.Range(190, 200); break;
            default:
                randomHealth = Random.Range(20, 35);
                randomStrength = Random.Range(3, 6);
                randomAgile = Random.Range(3, 6);
                randomResist = Random.Range(3, 6); break;
        }
        
        string randomTargetAi = Random.value > 0.5f ? "Single" : "Multi";
        Character newCharacter =new Character(randomHealth, randomTier, randomStrength, randomAgile, randomResist, randomTargetAi);
        CharactersList.list.Add(newCharacter);
    }

    public static string GenerateRandomTier()
    {
        List<string> weightedTiers = new List<string>();

        // Thêm Tier vào danh sách theo trọng số
        for (int i = 0; i < tierOptions.Length; i++)
        {
            for (int j = 0; j < tierWeights[i]; j++)
            {
                weightedTiers.Add(tierOptions[i]);
            }
        }

        // Chọn ngẫu nhiên từ danh sách có trọng số
        return weightedTiers[Random.Range(0, weightedTiers.Count)];
    }

}
