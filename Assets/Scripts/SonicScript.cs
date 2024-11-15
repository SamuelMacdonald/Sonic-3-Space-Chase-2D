using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine.VFX;
using UnityEngine.Rendering;

namespace Sonic2D
{
    public class SonicScript : MonoBehaviour
    {
        //movement
        public Joystick stick;
        public float maxSp;
        public float minSp;
        public float acc ;
        public bool isMoving;
        public bool left;
        public bool right;
        public Vector2 v2;
        public float speedInc;
        public Rigidbody2D rb;

        //slowDown
        float lastHorizontalInput;

        public StateMachine sm;


        public MoveState movement;
        public IdelState idel;
        public SpinDashState spinDash; 
        public JumpState jump;
        public DeccelerationState slowDown;

        // Start is called before the first frame update
        void Start()
        {
            sm = gameObject.AddComponent<StateMachine>();
            rb = gameObject.GetComponent<Rigidbody2D>();
            


            // add new states here
            movement = new MoveState(this, sm);
            idel = new IdelState(this, sm);
            spinDash = new SpinDashState(this, sm);
            jump = new JumpState(this, sm);
            slowDown = new DeccelerationState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(movement);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();  

            //stick.Vertical = Mathf.Clamp(stick.Direction.x, -1, 1);

            //output debug info to the canvas
            string s;
            s = string.Format(" state={0}\nLast state={1}", sm.CurrentState, sm.LastState);

            v2 = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        }


        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
            v2 = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        }

        public void CheckForMovement()
        {
            if(true)
            {
                sm.ChangeState(movement);
            }
        }

        public void CheckForIdel()
        {
            if (Input.GetKey("l"))
            {
                sm.ChangeState(idel);
            }
        }
        
        public void CheckForSpinDash()
        {
            if (Input.GetKey("m"))
            {
                sm.ChangeState(spinDash);
            }
        }
        
        public void CheckForJump()
        {
            if (Input.GetKey("k"))
            {
                sm.ChangeState(jump);
            }
        }


        
        public void CheckForSlowdown()
        {
            float horizontalInput = stick.Direction.x;

            if(horizontalInput != lastHorizontalInput)
            {
                sm.ChangeState(spinDash);
                lastHorizontalInput = horizontalInput;
            }

            //Check if horizontal input = last horizontal input

            // If not, then change state to slowdown state. This is because a change in input means a change in direction

            // Save last horizontal input to new input

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object other)
        {
            return base.Equals(other);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}    



