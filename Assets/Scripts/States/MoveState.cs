
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
            

           // Debug.Log(sonic.stick.Direction.x);

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            

            //increase speed
            if(sonic.acc < sonic.maxSp && sonic.acc >= 1000)
            {
                if (sonic.stick.Direction.x >= 0.97f || sonic.stick.Direction.x <= -0.97f)
                {
                    sonic.acc += 1000f * Time.fixedDeltaTime;
                }
                else
                {
                   sonic.acc = 1000f;
                }
            }
            
            if(sonic.acc < 1000)
            {
                sonic.acc = 1000;
            }
            //right
            if(sonic.v2.x == 1)
            {
                sonic.right = true;
            }
            
            //left
            if (sonic.v2.x == -1)
            {
                sonic.left = true;
            }
            //idel
             if(sonic.v2.x == 0 && sonic.acc == 1000)
            {
                sonic.left = false;
                sonic.right = false;
            }

            //Movement
            sonic.rb.AddForce(sonic.stick.Direction * sonic.acc * Time.deltaTime, 0);

            

        }
    }
}

