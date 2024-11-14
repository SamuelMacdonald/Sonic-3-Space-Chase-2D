using UnityEngine;

namespace Sonic2D
{
    public class SonicScript : MonoBehaviour
    {

        public float MaxSpeed = 20f;
        public float Acceleration = 5f;
        public Rigidbody2D rb;
        public StateMachine sm;




        private void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {
            sm = gameObject.AddComponent<StateMachine>();


            // add new states here


            // initialise the statemachine with the default state
           // sm.Init();
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            string s;
            s = string.Format(" state={0}\nLast state={1}", sm.CurrentState, sm.LastState);




        }


        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();

        }

    }
}    



