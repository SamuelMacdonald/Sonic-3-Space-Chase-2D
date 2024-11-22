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

        //jump
        public Vector2 boxSize;
        public float castDistance;
        public LayerMask groundLayer;
        public bool jumping;
        public float jumpFroce;

        public StateMachine sm;


        public MoveState movement;
        public IdelState idel;
        public SpinDashState spinDash; 
        public JumpState jump;
      

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
            

            // initialise the statemachine with the default state
            sm.Init(idel);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

           

            //output debug info to the canvas
            string s;
            s = string.Format(" state={0}\nLast state={1}", sm.CurrentState, sm.LastState);

            Debug.Log(sm.CurrentState);
            Debug.Log(stick.Direction.x);


        }

        public bool isGrounded()
        {
            if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void JumpingTrue()
        {
            if (isGrounded())
            {
                jumping = true;
                rb.AddForce(Vector2.up * jumpFroce);
                Debug.Log("true");
            }
           
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
        }
        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
            //increase speed
            if (acc < maxSp && acc >= 1000)
            {
                if (stick.Direction.x >= 0.97f || stick.Direction.x <= -0.97f)
                {
                    acc += 2000f * Time.fixedDeltaTime;
                }
                else
                {
                    acc = 1000f;
                }
            }

            if (acc < 1000)
            {
                acc = 1000;
            }
            //right
            if (v2.x == 1)
            {
                right = true;
            }

            //left
            if (v2.x == -1)
            {
                left = true;
            }
            //idel
            if (v2.x == 0 && acc == 1000)
            {
                left = false;
                right = false;
            }
        }

        public void CheckForMovement()
        {
            
            if(stick.Direction.x >= 0.97f || stick.Direction.x <= -0.97f)
                sm.ChangeState(movement);
            
        }

        public void CheckForIdel()
        {
           
            if(stick.Direction.x == 0 && isGrounded())
                sm.ChangeState(idel);
            
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
            if (jumping == true && isGrounded())
            {
                
                sm.ChangeState(jump);
            }
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



