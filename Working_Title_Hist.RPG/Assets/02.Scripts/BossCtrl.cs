using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;  // 보스 총알 프리팹
    public int numBullets = 8;       // 총알 개수
    public float bulletSpeed = 10f;  // 총알 속도

    public float rotationSpeed = 180f; // 회전 속도 (도는 속도)
    public float damage = 20f;         // 공격 데미지
    public float moveSpeed = 2f;
    private Vector3 initialPosition;
    private float angle = 0f;
    private Transform player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialPosition = transform.position;
    }
    private void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0;
        transform.position += directionToPlayer.normalized * moveSpeed * Time.deltaTime;
        RotateAndAttack();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButton(1))
        {
        }
    }
    private void Shoot()
    {
        float angleStep = 360f / numBullets; // 각도 간격 계산

        for (int i = 0; i < numBullets; i++)
        {
            float angle = i * angleStep; // 현재 총알의 각도 계산
            Quaternion rotation = Quaternion.Euler(0f, angle, 0f); // 각도에 대한 회전

            GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bullet.transform.forward * bulletSpeed;
        }
    }

    private void RotateAndAttack()
    {
        angle += rotationSpeed * Time.deltaTime;
        if (angle >= 360f)
            angle -= 360f;

        Quaternion newRotation = Quaternion.Euler(0f, angle, 0f);
        transform.rotation = newRotation;
    }
}
