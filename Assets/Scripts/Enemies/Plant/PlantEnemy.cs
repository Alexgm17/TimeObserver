using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;

    public float waitedTimeToAttack = 3;

    public Animator animator;

    public GameObject bulletPrefab;

    public Transform launchSpawnPoint;

    private void Start()
    {
        waitedTime = waitedTimeToAttack;
    }

    private void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitedTimeToAttack;
            animator.Play("PlantAttack");
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
