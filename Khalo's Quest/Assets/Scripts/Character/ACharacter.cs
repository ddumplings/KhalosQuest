using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACharacter : ICharacter
{
    public abstract void attack();
    public abstract Vector2 getPosition();
    public abstract void move();

    int health;
    int energy;
    int speed;
    int stamina;
    int knowledge;
    int durability;
}
