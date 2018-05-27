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
}
