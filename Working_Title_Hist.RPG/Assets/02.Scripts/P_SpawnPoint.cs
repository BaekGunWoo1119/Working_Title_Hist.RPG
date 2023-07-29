using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtClosestEnemy : MonoBehaviour
{
    private void Update()
    {
        Transform closestEnemy = FindClosestEnemy();

        if (closestEnemy != null)
        {
            // LookAt the closest enemy without changing the up direction (y-axis)
            transform.LookAt(new Vector3(closestEnemy.position.x, transform.position.y, closestEnemy.position.z));
        }
    }

    private Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy;
    }
}