using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject GameManager;
	public float moveSpeed = 12f;
	public Rigidbody2D rb;
    public GameObject ExplosionEvent;

    public Text LivesUIText;

    const int maxLives = 3;
    int currentLives;

    public void Init()
    {
        currentLives = maxLives;

        LivesUIText.text = currentLives.ToString();

        transform.position = new Vector2(0, -4);

        gameObject.SetActive(true);

    }

	Vector2 movement;


	void Update()
	{
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

	}

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

		if (transform.position.x <= -7.3f)
		{
			transform.position = new Vector2(-7.3f, transform.position.y);
		}
		else if (transform.position.x >= 7.3f)
		{
			transform.position = new Vector2(7.3f, transform.position.y);
		}

		// Y axis
		if (transform.position.y <= -5.81f)
		{
			transform.position = new Vector2(transform.position.x, -5.81f);
		}
		else if (transform.position.y >= 4.74f)
		{
			transform.position = new Vector2(transform.position.x, 4.74f);
		}

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if ((collision.tag == "EnemyShipTag") || collision.tag == "EnemyLaserTag")
        {
            Explode();

            currentLives--;

            LivesUIText.text = currentLives.ToString();

            if (currentLives == 0)
            {
                GameManager.GetComponent<GameManagerScript>().SetGameManagerState(GameManagerScript.GameManagerState.GameOver);

                gameObject.SetActive(false);
            }
        }
    }

    void Explode()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionEvent);

        explosion.transform.position = transform.position;
    }
}
