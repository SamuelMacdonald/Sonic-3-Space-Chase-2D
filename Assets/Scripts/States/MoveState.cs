
using NUnit.Framework.Constraints;
using System;
using System.Runtime.InteropServices;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Sonic2D
{
    public class MoveState : State
    {

        public MoveState(SonicScript sonic, StateMachine sm) : base(sonic, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }


        public override void LogicUpdate()
        {
            base .LogicUpdate();
            sonic.CheckForIdel();
            sonic.CheckForJump();
            sonic.CheckForSpinDash();
            sonic.CheckForFall();


            Debug.Log(sonic.stick.Direction.x);

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();   
    
            //Movement
            if (sonic.isGrounded())
            {
                if(sonic.acc <= 4499)
                {
                    sonic.an.Play("startRun");
                }
                if(sonic.acc >= 4500 && sonic.acc <= 6000)
                {
                    sonic.an.Play("run");
                }
                
                if(sonic.acc >= 6001)
                {
                    sonic.an.Play("sprint");
                }
                sonic.rb.AddForce(sonic.stick.Direction * sonic.acc * Time.deltaTime, 0);
                
            }


            

        }
    }
}

