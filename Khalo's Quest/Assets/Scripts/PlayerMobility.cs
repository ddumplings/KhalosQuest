using UnityEngine;
using System.Collections.Generic;

public class PlayerMobility : MonoBehaviour {

    public float speed;
    public GameObject projectilePrefab;
    private List<GameObject> projectiles = new List<GameObject>();
    public float projectileVelocity;

    void Update()
    {
        if (Time.deltaTime > 0)
        {
            pointTowardsMouse();
            move();
            shoot();
        }
    }

    void pointTowardsMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        //make it so that it uses the different sprites to change direction instead of rotating thing
        /*if (direction.x)
        {

        }*/

        transform.up = direction;
    }

    void move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        transform.Translate(xAxis * speed, yAxis * speed, 0, Space.World);
    }

    void shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();
            GameObject bullet = (GameObject)Instantiate(
                                 projectilePrefab,
                                 transform.position + (Vector3)(direction * 70f),
                                 Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * projectileVelocity;

            projectiles.Add(bullet);
        }

        for (int i = 0; i < projectiles.Count; i++)
        {
            GameObject goBullet = projectiles[i];
            if (goBullet != null)
            {
                Vector3 bulletScreenPosn = Camera.main.WorldToScreenPoint(goBullet.transform.position);
                if (bulletScreenPosn.y >= Screen.height || bulletScreenPosn.x >= Screen.width
                    || bulletScreenPosn.y <= 0 || bulletScreenPosn.x <= 0)
                {
                    DestroyObject(goBullet);
                    projectiles.Remove(goBullet);
                }
            }
        }
    }
}
