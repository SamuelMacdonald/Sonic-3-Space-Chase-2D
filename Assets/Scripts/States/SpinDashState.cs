using UnityEngine;
using Unity.VisualScripting.FullSerializer;
namespace Sonic2D
{
public class SpinDashState : State
{
        
        

        public SpinDashState(SonicScript sonic, StateMachine sm) : base(sonic, sm)
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
            sonic.CheckForJump();
            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            sonic.jumping = false;

            sonic.spinDashSpeed += 5000 * Time.deltaTime;
        }
    }
}


