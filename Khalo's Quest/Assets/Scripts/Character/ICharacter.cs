using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter {

    // move the Character
    void move();

    // return the position of the Character
    Vector2 getPosition();

    // character attacks
    void attack();

    //getters for stats
    int getHealth();
    int getEnergy();
    int getSpeed();
    int getStamina();
    int getKnowledge();
    int getDurability();
    int getStrength();

    //returns the damage dealt to 
    int damageDealt(ICharacter enemy);
}
