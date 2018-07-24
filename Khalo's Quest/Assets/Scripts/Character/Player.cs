using UnityEngine;
using System.Collections;
using System;

public class Player : ACharacter {

    /*public Player(int health, int energy, int speed, int stamina, int knowledge, int durability, int strength) 
        : base(health, energy, speed, stamina, knowledge, durability, strength)
    {
        
    }*/

    void Start()
    {
        //base.setHealth(100);
    }

    public override void attack()
    {
        throw new NotImplementedException();
    }

    public override Vector2 getPosition()
    {
        throw new NotImplementedException();
    }

    public override void move()
    {
        throw new NotImplementedException();
    }
}
