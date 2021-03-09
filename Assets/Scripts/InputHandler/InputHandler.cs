using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Command accelerate = new AccelerateCommand();
    private Command reverse = new ReverseCommand();
    private Command turnR = new TurnRCommand();
    private Command turnL = new TurnLCommand();
    private Command fire1 = new FireMachingunCommand();
    private Command fire2 = new FireRocketCommand();
    private Command strifeL = new strifeLCommand();
    public Command strifeR = new strifeRCommand();
    public Command decelerate = new DecelerateCommand();
    public Command land = new LandCommand();
    public Command takeOf = new TakeofCommand();
    private PlayerController actor;

    [SerializeField]
    KeyCode accelerator;
    [SerializeField]
    KeyCode acceleratorReverse;
    [SerializeField]
    KeyCode rightTurn;
    [SerializeField]
    KeyCode leftTurn;
    [SerializeField]
    KeyCode takeofButton;
    private void Start()
    {
        actor = GameManager.Instance.player;
        accelerator = KeyCode.UpArrow;
        acceleratorReverse = KeyCode.DownArrow;
        rightTurn = KeyCode.RightArrow;
        leftTurn = KeyCode.LeftArrow;
        takeofButton = KeyCode.Space;
    }
    private Command handleInput()
    {
        if (Input.GetKey(accelerator))
        {
            accelerate.Execute(actor);
        }
        else if (Input.GetKey(acceleratorReverse))
        {
            reverse.Execute(actor);
        }
        if (Input.GetKeyUp(accelerator) ||Input.GetKeyUp(acceleratorReverse))
        {
            actor.Accelerating = false;
        }
        if (Input.GetKeyUp(rightTurn) || Input.GetKeyUp(leftTurn))
        {
            actor.StrifeAccelerating = false;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            if (Input.GetKey(rightTurn))
            {
                strifeR.Execute(actor,1);
            }
            else if (Input.GetKey(leftTurn))
            {
                strifeL.Execute(actor,-1);
            }
        }       
        else if (Input.GetKey(rightTurn))
        {
            turnR.Execute(actor);
        }
        else if (Input.GetKey(leftTurn))
        {
            turnL.Execute(actor);
        }
        if (Input.GetKeyDown(takeofButton))
        {
            if (actor.Flying)
            {
                land.Execute(actor);
            }
            else
            {
                takeOf.Execute(actor);
            }
        }       
        //tilting
        if (Input.GetKeyDown(accelerator))
        {
            accelerate.Trigger(actor, 1);
        }
        if (Input.GetKeyDown(acceleratorReverse))
        {
            reverse.Trigger(actor, -1);
        }
        if (Input.GetKeyUp(accelerator))
        {
           decelerate.Trigger(actor,-1);
        }
        if (Input.GetKeyUp(acceleratorReverse))
        {
            decelerate.Trigger(actor, 1);
        }
        if (Input.GetKeyDown(rightTurn))
        {
            turnR.Trigger(actor, 1);
        }
        if (Input.GetKeyUp(rightTurn))
        {
            turnR.Trigger(actor);
        }
        if (Input.GetKeyDown(leftTurn))
        {
            turnL.Trigger(actor, -1);
        }
        if (Input.GetKeyUp(leftTurn))
        {
            turnL.Trigger(actor);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            GameManager.Instance.QuestTable.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameManager.Instance.QuestTable.SetActive(true);
        }        
        return null;
    }
    private void Update()
    {
        handleInput();
    }
  }
