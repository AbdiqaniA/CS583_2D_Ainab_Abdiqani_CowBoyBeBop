using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    GameObject scoreUIText;

    public GameObject ExplosionEvent;
	float speed;
    // Start is called before the first frame update
    void Start()
    {
		speed = 5f;
        scoreUIText = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 position = transform.position;


		position = new Vector2(position.x, position.y - speed * Time.deltaTime);

		transform.position = position;

		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if(transform.position.y < min.y)
		{
			Destroy(gameObject);
		}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "PlayerShipTag") || (collision.tag == "PlayerLaserTag"))
        {
            PlayExplosion();

            scoreUIText.GetComponent<GameScoreScrip>().Score += 100;

            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionEvent);

        explosion.transform.position = transform.position;
    }
}
  