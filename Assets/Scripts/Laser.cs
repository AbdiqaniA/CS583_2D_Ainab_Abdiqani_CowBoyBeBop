using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	public GameObject laserEffect;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject effect = Instantiate(laserEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);
		Destroy(gameObject);
	}
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyShipTag")
        {
            Destroy(gameObject);
        }
    }
}
