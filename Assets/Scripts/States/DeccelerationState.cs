using Unity.VisualScripting;
using UnityEngine;
namespace Sonic2D
{
public class DeccelerationState : State
{
        public DeccelerationState(SonicScript sonic, StateMachine sm) : base(sonic, sm)
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
            sonic.CheckForJump();

            

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            sonic.acc += -1000f * Time.fixedDeltaTime;


        }
    }
}


