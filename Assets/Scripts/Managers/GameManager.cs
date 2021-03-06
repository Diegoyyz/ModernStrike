﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    [SerializeField]
    public PlayerController player;
    public GameObject QuestTable;
    public GameObject ControlList;
    [SerializeField]
    private Quest[] quests;
    public bool gamestarted;
    public float timeCurrent = 0.0f;
    public int seconds = 3;
    private bool alQuestComplete;
    public int completed;
    SceneCharger _sceneCharger;
    bool charginScene;
    private void Awake()
    {
        charginScene = false;
        completed = 0;
        _instance = this;
        PlayerController.OnDie += heroDeath;
        PlayerController.onFuelOver += FuelOver;
        timeCurrent = 0.0f;
        _sceneCharger = this.GetComponent<SceneCharger>();
        quests = QuestTable.transform.GetComponentsInChildren<Quest>();
    }
    public void FuelOver()
    {
        charginScene = true;
        _sceneCharger.ChargeLevel("EndGameScreen");
    }
    public void heroDeath()
    {
        charginScene = true;
        _sceneCharger.ChargeLevel("EndGameScreen");
    }
    private void Update()
    {
        if (completed >= 3 && !charginScene)
        {
            charginScene = true;
            _sceneCharger.ChargeLevel("EndGameScreen Win");
        }
    }
}
