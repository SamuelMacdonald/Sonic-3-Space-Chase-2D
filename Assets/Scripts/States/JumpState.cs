using UnityEngine;
using Unity.VisualScripting.FullSerializer;

namespace Sonic2D
{
public class JumpState : State
{
        public SonicScript sb;
        

        public JumpState(SonicScript sonic, StateMachine sm) : base(sonic, sm)
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
            base.LogicUpdate();
            sonic.CheckForIdel();
            sonic.CheckForMovement();
            sonic.CheckForSpinDash();
           
            

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
         



        }
    }
}


