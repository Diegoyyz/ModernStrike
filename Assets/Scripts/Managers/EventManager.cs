using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<int> OnEnemyDied = delegate { };
    public static event Action<int> OnItemGrabbed = delegate { };
    public static event Action<int> OnItemDelivered = delegate { };
    public static event Action<Quest> OnquestProgrestChanged = delegate{ };
    public static event Action<Quest> OnquestCompleted = delegate { };

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public static void EnemyDied(int enemyID)
    {
        OnEnemyDied(enemyID);
    }
    public static void ItemGrabbed(int itemId)
    {
        OnEnemyDied(itemId);
    }
    public static void ItemDelivered(int itemId)
    {
        OnItemDelivered(itemId);
    }
    public static void QuestProgressChanged(Quest quest)
    {
        OnquestProgrestChanged(quest);
    }
    public static void QuestCompleted(Quest quest)
    {
        OnquestCompleted(quest);
    }
}
