using UnityEngine;
using System.Collections;

public class EnemyHitScript : MonoBehaviour {

    public int damageTo; //Damage that this enemy deals out

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Handles getting hit by a bullet
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag.Equals("Bullet"))
        {
            Destroy(c.gameObject);
            Destroy(gameObject);
        }

        if (c.gameObject.tag.Equals("Player"))
        {
            float speed = c.gameObject.GetComponent<PlayerMobility>().speed;
            c.transform.Translate(Input.GetAxis("Horizontal") * speed * -50, Input.GetAxis("Vertical") * speed * -50, 0, Space.World);
            c.gameObject.GetComponent<ACharacter>().takeDamage(damageTo);
        }
    }
}
