using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    [SerializeField]
    public PlayerController player;
    public GameObject QuestTable;
    public GameObject ControlList;

    public bool gamestarted;
    public float timeCurrent = 0.0f;
    public int seconds=3;

    private void Awake()
    {
        _instance = this;
        timeCurrent = 0.0f;
    }
    private void Update()
    {
        // seconds in float
        // turn seconds in float to int
        //seconds = (int)(timeCurrent % 60);
        Debug.Log(seconds);
        if (timeCurrent >= seconds)
        {
            ControlList.SetActive(false);
            gamestarted = true;
        }
        else
        {
            timeCurrent += Time.deltaTime;
        }
    }
}
