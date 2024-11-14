
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Sonic2D
{
    public abstract class State
    {
        protected SonicScript sonic;
        protected StateMachine sm;


        // base constructor
        protected State(SonicScript Sonic, StateMachine sm)
        {
            this.sonic = Sonic;
            this.sm = sm;
        }

        // These methods are common to all states
        public virtual void Enter()
        {
            //Debug.Log("This is base.enter");
        }

        public virtual void HandleInput()
        {
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {
        }

    }

}