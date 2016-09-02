using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public abstract class GameplayObject
{
    public float Health { get; protected set; }
    public float HealthMax { get; protected set; }
    public float Speed { get; protected set; }
    public bool Alive { get; protected set; }

    public GameplayObject(float healthmax, float speed)
    {
        HealthMax = healthmax;
        Health = HealthMax;
        Speed = speed;
        Alive = true;
    }

    public void TakeDamage(float damages)
    {
        Health -= damages;
        if (Health <= 0)
        {
            Health = 0;
            Alive = false;
        }
    }
}