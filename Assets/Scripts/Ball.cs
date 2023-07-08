using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Velocity = 1;
    public float Mass = 1;
    public bool IsBigMass;

    public int Count;

    public Ball OtherBall;

    public float CollisionDistance;

    public bool CheckCollision;

    float lastPos;

    bool hit;

    public void Init(float mass, float velocity)
    {
        Mass = mass;
        Velocity = velocity;

    }

    float lastTime;

    private void FixedUpdate() 
    {
        if(Time.timeScale == 0)
            return;

        transform.position += new Vector3(Velocity * Time.deltaTime, 0, 0);



        float d = Vector3.Distance(transform.position, OtherBall.transform.position);
        float d_wall = Vector3.Distance(transform.position, GameManager.Instance.WallPos);
        if(CheckCollision && !hit)
        {
            bool flag = false;
            if(d < CollisionDistance)
            {
                Count++;

                Velocity *= -1;
                float va0 = Velocity * -1;
                Velocity = ((OtherBall.Mass * (va0 - 2*OtherBall.Velocity)-Mass*va0)/(-(Mass + OtherBall.Mass)));
                //Velocity = GetVelocity(OtherBall);
                //Debug.Log(Mass + "/" + OtherBall.Mass +"/" + OtherBall.Velocity);
                OtherBall.Velocity =  (Velocity + va0 - OtherBall.Velocity); //(va0 - OtherBall.Velocity + Velocity);
                flag = true;
                print(OtherBall.Velocity);
                //print(Count + $" | 작은거 속도: {Velocity}, 큰거 속도: {OtherBall.Velocity} | 시간차 {time}");

                
                //Time.timeScale = 0 ;
            }
            if(d_wall <= 0.5f+0.1f)
            {
                Count++;
                Velocity *= -1;
                flag = true;
                transform.position = new Vector3(-12+0.75f, -5.45f, 0);
            }

            GameManager.Instance.UpdateText(Count);

            hit = flag;
        }
        else
        {
            hit = false;
        }
    }

    

    public float GetVelocity(Ball otherBall)
    {
        return (otherBall.Mass * (Velocity - 2 * otherBall.Velocity) - Mass*Velocity)
        /-(Mass + otherBall.Mass);
    }

    
}
