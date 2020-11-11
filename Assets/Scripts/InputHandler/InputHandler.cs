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
    public Command hookDown = new HookDownCommand();

    private PlayerController actor;

    private void Start()
    {
        actor = GameManager.Instance.player;
    }

    private Command handleInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            accelerate.Execute(actor);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            reverse.Execute(actor);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)||Input.GetKeyUp(KeyCode.DownArrow))
        {
            actor.Acelerating = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.LeftArrow))
        {
            actor.StrifeAcelerating = false;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                strifeR.Execute(actor,1);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                strifeL.Execute(actor,-1);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            turnR.Execute(actor);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnL.Execute(actor);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (actor.flying)
            {
                land.Execute(actor);
            }
            else
            {
                takeOf.Execute(actor);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            hookDown.Execute(actor);
        }
        //tilting
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            accelerate.Trigger(actor, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            reverse.Trigger(actor, -1);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
           decelerate.Trigger(actor,-1);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            decelerate.Trigger(actor, 1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            turnR.Trigger(actor, 1);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            turnR.Trigger(actor);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            turnL.Trigger(actor, -1);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            turnL.Trigger(actor);
        }
        return null;
    }

    private void Update()
    {
        handleInput();
    }
  }
