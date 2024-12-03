using UnityEngine;
using Unity.VisualScripting.FullSerializer;

namespace Sonic2D
{
public class DeathState : State
{
        public SonicScript sb;
        
        public bool grounded;

        public DeathState(SonicScript sonic, StateMachine sm) : base(sonic, sm)
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

            Debug.Log("dead");
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();


            sonic.an.Play("death");
            


        }
    }
}


