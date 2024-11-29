using UnityEngine;
using Unity.VisualScripting.FullSerializer;
namespace Sonic2D
{
public class FallingState : State
{
        
        

        public FallingState(SonicScript sonic, StateMachine sm) : base(sonic, sm)
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
            sonic.CheckForSpinDash();

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            sonic.jumping = false;
            sonic.an.Play("jump");
            sonic.rb.AddForce(sonic.stick.Direction * sonic.acc * Time.deltaTime, 0);
            sonic.rb.AddForce(Vector2.down * 50);

        }
    }
}


