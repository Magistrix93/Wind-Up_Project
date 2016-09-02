using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Character : GameplayObject
{
    public float JumpSpeed;
    public float RunMultiplier;
    public Character() : base(3, 10)
    {
        JumpSpeed = 20f;
        RunMultiplier = 2f;
    }



}
