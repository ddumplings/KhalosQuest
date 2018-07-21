using UnityEngine;
using System.Collections;

public class EnemyHitScript : MonoBehaviour {

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
    }
}
