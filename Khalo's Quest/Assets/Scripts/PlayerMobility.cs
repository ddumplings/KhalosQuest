using UnityEngine;
using System.Collections.Generic;

public class PlayerMobility : MonoBehaviour {

    public float speed;
    public GameObject projectilePrefab;
    private List<GameObject> projectiles = new List<GameObject>();
    private float projectileVelocity = 100;

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
        if (Input.GetButtonDown("Fire1")) //&& Time.time > timeUntilFire)
        {
            //timeUntilFire = Time.time + 1 / fireRate;
            GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, transform.rotation);
            /*Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosition);
            GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, new Quaternion(mousePos.x, mousePos.y, transform.rotation.z, Quaternion.identity.w));
            */
            projectiles.Add(bullet);
        }

        for (int i = 0; i < projectiles.Count; i++)
        {
            GameObject goBullet = projectiles[i];
            if (goBullet != null)
            {
                goBullet.transform.Translate(new Vector3(0, 1) * Time.deltaTime * projectileVelocity);
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
