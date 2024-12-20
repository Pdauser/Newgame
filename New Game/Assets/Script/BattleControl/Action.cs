using UnityEngine;

public static class Action
{
    public static string AllyDamage(@Character character, @Enermy enermy)
    {
        int be_damage = 0;
        int af_damage = 0;
        int final_Damage;
        if (!Dodge(enermy.base_Agile))
        {
            be_damage = (int)Random.Range(character.real_Strength * 0.8f, character.real_Strength * 1.2f);
            af_damage = be_damage - (int)(enermy.base_Resist * 0.8f);
            final_Damage = Mathf.Clamp(af_damage, 0, character.real_Strength * 3);
            enermy.current_Health -= final_Damage;
            enermy.current_Health = Mathf.Clamp(enermy.current_Health, 0, enermy.max_Health);
            if(enermy.current_Health <= 0)
            {
                BattleControler.killed += 1;
                EnermiesList.enermies.Remove(enermy);
            }
            return $"{character.Name} attack {enermy.Name} for {final_Damage} Damage";
        }else return $"{enermy.Name} dodged {character.Name} attack";
    }
    public static bool Dodge(int agile)
    {
        
        int DodgeChance = (int)(agile * 0.4f);
        DodgeChance = Mathf.Clamp(DodgeChance, 1, 50);
        int DodgeRoll = Random.Range(1, 100);
        bool Success = DodgeRoll < DodgeChance ? true : false;
        return Success;
    }
    public static string EnermyDamage(@Character character, @Enermy enermy)
    {
        int be_damage = 0;
        int af_damage = 0;
        int final_Damage;
        if(character.current_Health <= 0)
        {
            return $"{enermy.Name} attack a dead body!!";
        }
        if (!Dodge(character.real_Agile))
        {
            be_damage = (int)Random.Range(enermy.base_Strength * 0.9f, enermy.base_Strength * 1.1f);
            af_damage = be_damage - (int)(character.real_Resist * 0.95f);
            final_Damage = Mathf.Clamp(af_damage, 0, enermy.base_Strength * 3);
            character.current_Health -= final_Damage;
            character.current_Health = Mathf.Clamp(character.current_Health, 0, character.real_Health);
            return $"{enermy.Name} attack {character.Name} for {final_Damage} Damage";
        }else return $"{character.Name} dodged {enermy.Name} attack";
    }
}
