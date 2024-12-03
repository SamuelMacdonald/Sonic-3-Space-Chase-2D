using UnityEngine;
using Unity.VisualScripting.FullSerializer;

namespace Sonic2D
{
public class JumpState : State
{
        public SonicScript sb;

        public bool grounded;

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
            if (sonic.rb.linearVelocity.y > 2f && grounded)
            {
                sonic.CheckForIdel();
            }

            //Debug.Log("grounded=" + grounded + "vel=" + sonic.rb.linearVelocity.y);

            sonic.CheckForMovement();
            sonic.CheckForSpinDash();
            sonic.CheckForFall();
            sonic.CheckForDead();

            Debug.Log("true");

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            sonic.an.Play("jump");
            grounded = sonic.isGrounded();
            sonic.jumping = false;


        }
    }
}


