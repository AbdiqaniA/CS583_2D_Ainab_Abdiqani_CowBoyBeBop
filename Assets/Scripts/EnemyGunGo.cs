using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunGo : MonoBehaviour
{
    public GameObject EnemyGo; //bullet prefab
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyLaser",1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnemyLaser()
    {
        GameObject playerShip = GameObject.Find("PlayerShip");

        if(playerShip != null)
        {
            GameObject laser = (GameObject)Instantiate(EnemyGo);

            laser.transform.position = transform.position;

            Vector2 trajectory = playerShip.transform.position - laser.transform.position;

            laser.GetComponent<EnemyLaser>().SetTrajectory(trajectory);
        }
    }
}
