using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    float speed;

    Vector2 laserTrajectory;
    bool isReady;

    private void Awake()
    {
        speed = 10f;
        isReady = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetTrajectory(Vector2 trajectory)
    {
        laserTrajectory = trajectory.normalized;
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;

            position += laserTrajectory * speed * Time.deltaTime;

            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if((transform.position.x < min.x)|| (transform.position.x > max.x)||(transform.position.y < min.y) || (transform.position.y > max.y))
                {
                Destroy(gameObject);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerShipTag")
        {
            Destroy(gameObject);
        }
    }
}
