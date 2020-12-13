using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<EnemyIDEnum> OnEnemyDied = delegate { };
    public static event Action<int> OnItemGrabbed = delegate { };
    public static event Action<Quest> OnquestProgresChanged = delegate{ };
    public static event Action<Quest> OnquestCompleted = delegate { };

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public static void EnemyDied(EnemyIDEnum enemyID)
    {
        OnEnemyDied(enemyID);
    }
    public static void ItemGrabbed(int itemId)
    {
        OnItemGrabbed(itemId);
    }
    public static void QuestProgressChanged(Quest quest)
    {
        OnquestProgresChanged(quest);
    }
    public static void QuestCompleted(Quest quest)
    {
        OnquestCompleted(quest);
    }
}
