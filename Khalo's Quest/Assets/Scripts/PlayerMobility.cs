using UnityEngine;
using System.Collections.Generic;

public class PlayerMobility : MonoBehaviour {

    public float speed;
    public GameObject projectilePrefab;
    private List<GameObject> projectiles = new List<GameObject>();
    public float projectileVelocity;

    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;
    public Sprite downSprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        spriteRenderer.sprite = downSprite; // set the sprite to down
    }

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
        Vector2 direction = (Vector2)((mousePos - transform.position));
        direction.Normalize();

        //make it so that it uses the different sprites to change direction
        if (direction.x > 0)
        {
            if (direction.y > 0)
            {
                if (direction.y > direction.x)
                {
                    spriteRenderer.sprite = upSprite;
                } else
                {
                    spriteRenderer.sprite = rightSprite;
                }
            }
            else //y <= 0
            {
                if (System.Math.Abs(direction.y) > direction.x)
                {
                    spriteRenderer.sprite = downSprite;
                }
                else
                {
                    spriteRenderer.sprite = rightSprite;
                }
            }
        }
        else //x <= 0
        {
            if (direction.y > 0)
            {
                if (direction.y > System.Math.Abs(direction.x))
                {
                    spriteRenderer.sprite = upSprite;
                }
                else
                {
                    spriteRenderer.sprite = leftSprite;
                }
            }
            else //y <= 0
            {
                if (System.Math.Abs(direction.y) > System.Math.Abs(direction.x))
                {
                    spriteRenderer.sprite = downSprite;
                }
                else
                {
                    spriteRenderer.sprite = leftSprite;
                }
            }
        }
    }

    void move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        transform.Translate(xAxis * speed, yAxis * speed, 0, Space.World);
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(xAxis * speed, yAxis * speed), ForceMode2D.Force);
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
                                 transform.position + (Vector3)(direction * 50f),
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
