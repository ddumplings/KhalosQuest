using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ACharacter : MonoBehaviour, ICharacter
{
    // basic stats
    [SerializeField] private int health;
    [SerializeField] private int energy;
    [SerializeField] private int speed;
    [SerializeField] private int stamina;
    [SerializeField] private int knowledge;
    [SerializeField] private int durability;
    [SerializeField] private int strength;
    [SerializeField] private List<IItem> items;

    public abstract void attack();
    public abstract Vector2 getPosition();
    public abstract void move();

    /*public ACharacter(int health, int energy, int speed, int stamina, int knowledge, int durability, int strength)
    {
        this.health = health;
        this.energy = energy;
        this.speed = speed;
        this.stamina = stamina;
        this.knowledge = knowledge;
        this.durability = durability;
        this.strength = strength;
        //
    }*/

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

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Destroy(gameObject);
            //SceneManager.LoadScene("GameOver");
            Debug.Log("You died!");
        }
        Debug.Log(health);
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void setEnergy(int energy)
    {
        this.energy = energy;
    }

    public void setSpeed(int speed)
    {
        this.speed = speed;
    }

    public void setStamina(int stamina)
    {
        this.stamina = stamina;
    }

    public void setKnowledge(int knowledge)
    {
        this.knowledge = knowledge;
    }

    public void setDurability(int durability)
    {
        this.durability = durability;
    }

    public void setStrength(int strength)
    {
        this.strength = strength;
    }
}
