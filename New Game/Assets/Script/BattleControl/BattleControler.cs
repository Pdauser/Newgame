using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BattleControler : MonoBehaviour
{
    public TMP_Text logPrefab; 
    public Transform logParent;
    public CanvasControl Canvascontrol;

    private float turn_Interval = 15;
    public static int turn;

    private int kill_count;
    private int turn_count;
    public static int killed;

    public bool isSurvival;

    public bool isFast;

    public bool isKill;
    void Start()
    {
        LogInit("Battle Start");
        turn = 0;
        killed = 0;
        if (isSurvival)
        {
            turn_count = 40;
            kill_count = 0;
        }else if (isFast)
        {
            turn_count = 0;
        }else if (isKill)
        {
            kill_count = 10;
            turn_count = 0;
        }
        foreach (Enermy enermy in EnermiesList.enermies)
        {
            LogInit($"{enermy.Name} appear");
        }
    }

    private void FixedUpdate()
    {
        if (isKill)
        {
            if (turn_Interval >= 3)
            {
                turn_Interval = 0;
                turn += 1;
                LogInit($"Turn {turn}:");
                Canvascontrol.alliesView.DisplayBattleCard();
                Canvascontrol.enermiesView.DisplatEnermiesCard();
                AllyAttack();
                EnermyAttack();
                if(EnermiesList.enermies.Count <5 && killed != kill_count)
                {
                    BattleInit.InitEnermies( 5 - EnermiesList.enermies.Count );
                }
                
                CheckBattleEnd();
            }else if (turn_Interval < 3)
            {
                turn_Interval += Time.deltaTime * 1f;
                turn_Interval = Mathf.Clamp(turn_Interval,0f,3f);
            }

        }
        if (isSurvival)
        {
            if (turn_Interval >= 3)
            {
                turn_Interval = 0;
                turn += 1;
                LogInit($"Turn {turn}:");
                Canvascontrol.alliesView.DisplayBattleCard();
                Canvascontrol.enermiesView.DisplatEnermiesCard();
                AllyAttack();
                EnermyAttack();
                if (EnermiesList.enermies.Count < 5 && turn != turn_count)
                {
                    BattleInit.InitEnermies(5 - EnermiesList.enermies.Count);
                }
                
                CheckBattleEnd();
            }
            else if (turn_Interval < 3)
            {
                turn_Interval += Time.deltaTime * 1f;
                turn_Interval = Mathf.Clamp(turn_Interval, 0f, 3f);
            }

        }
        if (isFast)
        {
            if (turn_Interval >= 3)
            {
                turn_Interval = 0;
                turn += 1;
                LogInit($"Turn {turn}:");
                Canvascontrol.alliesView.DisplayBattleCard();
                Canvascontrol.enermiesView.DisplatEnermiesCard();
                AllyAttack();
                EnermyAttack();
                
                CheckBattleEnd();
            }
            else if (turn_Interval < 3)
            {
                turn_Interval += Time.deltaTime * 1f;
                turn_Interval = Mathf.Clamp(turn_Interval, 0f, 3f);
            }

        }
    }
    void AllyAttack()
    {
        foreach (Character character in CharactersList.selected)
        {
            if(character.current_Health > 0)
            {
                if (character.TargetAi == "Single")
                {
                    if (EnermiesList.enermies.Count > 0)
                    {
                        LogInit(Action.AllyDamage(character, EnermiesList.enermies[Random.Range(0, EnermiesList.enermies.Count)]));
                    }
                }else if (character.TargetAi == "Multi")
                {
                    foreach (Enermy enermy in EnermiesList.enermies)
                    {
                        if (enermy.current_Health > 0)
                        {
                            LogInit(Action.AllyDamage(character, enermy));
                        }
                        
                    }
                }
            }
            
        }
    }
    void EnermyAttack()
    {
        foreach (Enermy enermy in EnermiesList.enermies)
        {
            if (enermy.current_Health > 0)
            {
                if (enermy.TargetAi == "Single")
                {
                    LogInit(Action.EnermyDamage(CharactersList.selected[Random.Range(0, CharactersList.selected.Count)], enermy));
                }
                else if (enermy.TargetAi == "Multi")
                {
                    foreach (Character character in CharactersList.selected)
                    {
                        if(character.current_Health > 0)
                        {
                            LogInit(Action.EnermyDamage(character, enermy));
                        }
                        
                    }
                }
            }
        }
    }
    void Update()
    {
        
    }
    public void LogInit(string message)
    {
        TMP_Text newlog = TMP_Text.Instantiate(logPrefab, logParent);
        newlog.text = message;

    }

    public void CheckBattleEnd()
    {
        if (isKill && kill_count == killed)
        {
            Canvascontrol.RewardView();
            foreach (TMP_Text child in logParent)
            {
                Destroy(child);
            }
        }
        if (isSurvival && turn == turn_count)
        {
            Canvascontrol.RewardView();
            foreach (TMP_Text child in logParent)
            {
                Destroy(child);
            }
        }
        if(isFast && EnermiesList.enermies.Count == 0)
        {
            Canvascontrol.RewardView();
            foreach (TMP_Text child in logParent)
            {
                Destroy(child);
            }
        }
        bool teamAlive = false;
        foreach (Character character in CharactersList.selected)
        {
            if (character.current_Health >0)
            {
                teamAlive = true;
                break;
            }
        }
        if (!teamAlive)
        {
            Canvascontrol.RewardView();
            foreach (TMP_Text child in logParent)
            {
                Destroy(child);
            }
        }
    }

}
