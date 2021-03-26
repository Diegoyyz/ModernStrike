using System.Collections;
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
    public int seconds=3;
    private bool alQuestComplete;
    public int completed;
    SceneCharger _sceneCharger;
    private void Awake()
    {        
        completed = 0;
        _instance = this;
        PlayerController.OnDie += heroDeath;
        timeCurrent = 0.0f;
        quests = QuestTable.transform.GetComponentsInChildren<Quest>();
    }
    public void heroDeath()
    {
        SceneManager.LoadScene("Level1");
    }
    private void Update()
    {
        if (completed >=3)
        {
            _sceneCharger.ChargeLevel("EndGameScreen");
        }
    }
}
