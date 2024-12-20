using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;
using UnityEngine.Rendering;


namespace Sonic2D
{
    public class SonicScript : MonoBehaviour
    {
        //movement
        public SpriteRenderer sp; 
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
        [SerializeField]
        public Vector2 boxSize;
        public float castDistance;
        public LayerMask groundLayer;
        public bool jumping;
        public float jumpFroce;

        //spinDash
        [SerializeField]
        public bool isCharging;
        public bool spinDashCheck;
        public float spinDashMaxSpeed;
        public float spinDashSpeed;

        //death
        public bool hit;

        //Animations
        public Animator an;     

        public StateMachine sm;

        //States
        public MoveState movement;
        public IdelState idel;
        public SpinDashState spinDash; 
        public JumpState jump;
        public FallingState fall;
        public DeathState dead;
      

        // Start is called before the first frame update
        void Start()
        {
            sm = gameObject.AddComponent<StateMachine>();
            rb = gameObject.GetComponent<Rigidbody2D>();
            sp = gameObject.GetComponent<SpriteRenderer>();
            an = gameObject.GetComponent<Animator>();


            // add new states here
            movement = new MoveState(this, sm);
            idel = new IdelState(this, sm);
            spinDash = new SpinDashState(this, sm);
            jump = new JumpState(this, sm);
            fall = new FallingState(this, sm);
            dead = new DeathState(this, sm);
            

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
           // Debug.Log(rb.linearVelocity.x);


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

        public void AButtonPress()
        {
            
           
        }
        public void JumpingAtive()
        {
            if (isGrounded())
            {
                jumping = true;
                isCharging = true;
            }
            else
            {
                jumping = false;
                isCharging = false;
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
            if (acc <= 8000 && acc >= 1000)
            {
                if (stick.Direction.x >= 0.7 || stick.Direction.x <= -0.7)
                {
                    acc += 2000f * Time.fixedDeltaTime;
                }
                else
                {
                    acc = 1000;
                }

                if(acc > maxSp)
                {
                    acc = maxSp;
                }
            }
            

            if (acc < 1000)
            {
                acc = 1000;
            }

            //spinDash checking if you are preparing it
            if(stick.Direction.y <= -0.9f)
            {
                spinDashCheck = true;
            }
            else
            {
                spinDashCheck = false;
            }
            //right
            if (stick.Direction.x >= 0.85)
            {
                right = true;
                sp.flipX = false;
                
            }

            //left
            if (stick.Direction.x <= -0.85)
            {
                left = true;
                sp.flipX = true;
                
            }
            //if(rb.linearVelocity.x <=)
            //idel
            if (v2.x == 0 && acc == 1000)
            {
                left = false;
                right = false;
            }

            

            
        }

        public void CheckForMovement()
        {
            
            if(stick.Direction.x >= 0.7f || stick.Direction.x <= -0.7f)
                sm.ChangeState(movement);
            
        }

        public void CheckForIdel()
        {
           
            if(stick.Direction.x == 0 && isGrounded())
                sm.ChangeState(idel);
            
        }
        
        public void CheckForSpinDash()
        {
            if(spinDashCheck == true && isGrounded() && isCharging == true)
            {
                
                sm.ChangeState(spinDash);
            }
        }
        
        public void CheckForJump()
        {
            if (jumping == true && isGrounded() && spinDashCheck == false)
            {
                rb.AddForce(Vector2.up * jumpFroce);
                sm.ChangeState(jump);
                
                jumping = false;
            }
        }
        public void CheckForFall()
        {
            if(isGrounded() == false)
            {
                sm.ChangeState(fall);
            }

        }

        public void CheckForDead()
        {
            if(hit == true)
            {
                sm.ChangeState(dead);
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                rb.AddForce(Vector2.up * jumpFroce);
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.CompareTag("Laser"))
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
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



