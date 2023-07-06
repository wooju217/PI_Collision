using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float Mass1;
    public float Velocity1;

    public float Mass2;
    public float Velocity2;

    public Vector3 WallPos;
    public Ball[] Balls;

    public static float PEnergy;

    private void Awake() 
    {
        Instance = this;    
    }

    void Start()
    {
        Mass1 = Balls[0].Mass;
        Velocity1 = Balls[0].Velocity;
        Mass2 = Balls[1].Mass;
        Velocity2 = Balls[1].Velocity;

        //에너지 보존 법칙
        PEnergy = Mass1 * Velocity1 + Mass2 * Velocity2;
    }
}
