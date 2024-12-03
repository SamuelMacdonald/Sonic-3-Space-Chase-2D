using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject laser;
    public Transform laserpoint;

    private float timer;
    public GameObject sonic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        float distance = Vector2.Distance(transform.position, sonic.transform.position);
        
        if(distance < 11)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                timer = 0;
                shoot();
            }
        }

    }

    public void shoot()
    {
        Instantiate(laser, laserpoint.position, Quaternion.identity);
    }
}
