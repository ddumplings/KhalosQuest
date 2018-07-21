using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACharacter : ICharacter
{
    // basic stats
    private int health;
    private int energy;
    private int speed;
    private int stamina;
    private int knowledge;
    private int durability;
    private int strength;

    public abstract void attack();
    public abstract Vector2 getPosition();
    public abstract void move();

    public int getHealth()
    {
        return this.health;
    }

    public int getEnergy()
    {
        return this.energy;
    }

    public int getSpeed()
    {
        return this.speed;
    }

    public int getStamina()
    {
        return this.stamina;
    }

    public int getKnowledge()
    {
        return this.knowledge;
    }

    public int getDurability()
    {
        return this.durability;
    }

    public int getStrength()
    {
        return this.strength;
    }

    public int damageDealt(ICharacter enemy)
    {
        //[(Weapon Attack + Player Strength) - (Enemy Durability)] * (Stability and Resolve Modifiers)
        // return ((this.getAttack() + this.getStrength()) - (enemy.getDurability)) * (this.getResolve(enemy))
        throw new System.NotImplementedException();
    }


}
