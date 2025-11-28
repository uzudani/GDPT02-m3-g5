using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooterController : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private float fireRange;
    [SerializeField] private Bullet Bullet;
    private float lastShotTime;

    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float minDistance = fireRange;

        GameObject theNearest = null; //GIULIO!!!
        //Se non ci sono nemici tutto ok (CHECK) e non occupiamo ulteriore memoria
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(enemy.transform.position, transform.position);

            if (distance < minDistance)
            {
                theNearest = enemy;
                minDistance = distance;
            }
        }
        return theNearest;
    }

    private void Update()
    {
        if (Time.time - lastShotTime > fireRate)
        {
            lastShotTime = Time.time;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject nearEnemy = FindNearestEnemy();

        if (nearEnemy) //!= null sottointeso
        {
            Vector2 direction = (nearEnemy.transform.position - transform.position).normalized;
            Bullet bulletPlus = Instantiate(Bullet);
            bulletPlus.transform.position = transform.position;
            bulletPlus.SetUp(direction);
        }
    }
}
