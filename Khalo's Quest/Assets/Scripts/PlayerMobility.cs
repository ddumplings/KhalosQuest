using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

    public float speed;

    void Update()
    {
        pointTowardsMouse();
        move();
    }

    void pointTowardsMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.right = direction;
    }

    void move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        transform.Translate(xAxis * speed, yAxis * speed, 0, Space.World);
    }
}
