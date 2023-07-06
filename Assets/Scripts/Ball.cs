using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Velocity = 1;
    public float Mass = 1;
    public int Dir = -1;
    public bool IsBigMass;

    public Ball OtherBall;

    public float CollisionDistance;

    public bool CheckCollision;

    float lastPos;

    bool hit;

    public void Init(float mass, float velocity)
    {
        Mass = mass;
        Velocity = velocity;
        Dir = -1;
    }

    private void Update() 
    {
        if(Time.timeScale == 0)
            return;

        transform.position = new Vector3(Velocity/Mass * Dir * Time.deltaTime, 0, 0) + transform.position;
        lastPos = transform.position.x;

        float d = Vector3.Distance(transform.position, OtherBall.transform.position);
        float d_wall = Vector3.Distance(transform.position, GameManager.Instance.WallPos);
        if(CheckCollision && !hit)
        {
            bool flag = false;
            if(d <= CollisionDistance)
            {
                Dir *= -1;
                Velocity = GetVelocity(Mass, OtherBall.Mass, OtherBall.Velocity);
                Debug.Log(Mass + "/" + OtherBall.Mass +"/" + OtherBall.Velocity);
                //OtherBall.Velocity = GetVelocity(OtherBall.Mass, Mass, OtherBall.Velocity);
                flag = true;
            }
            else if(d_wall <= 0.5f+0.1f/2f)
            {
                Dir *= -1;
                flag = true;
            }

            hit = flag;
        }
        else
        {
            hit = false;
        }
    }

    

    public float GetVelocity(float thisMass, float otherMass, float otherVelocity)
    {
        return (GameManager.PEnergy - (otherMass * otherVelocity))/thisMass;
    }
}
