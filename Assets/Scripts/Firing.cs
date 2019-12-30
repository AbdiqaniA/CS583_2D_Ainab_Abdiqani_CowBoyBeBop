using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
	public Transform firePoint;
	public GameObject laserPrefab;

	public float laserForce = 20f;

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("space"))
		{
            GetComponent<AudioSource>().Play();
            Fire();
		}
    }
    void Fire()
	{
		GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * laserForce, ForceMode2D.Impulse);
	}
}
