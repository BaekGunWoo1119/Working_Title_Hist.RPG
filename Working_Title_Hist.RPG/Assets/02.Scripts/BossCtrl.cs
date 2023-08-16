using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;  // ���� �Ѿ� ������
    public int numBullets = 8;       // �Ѿ� ����
    public float bulletSpeed = 10f;  // �Ѿ� �ӵ�

    public float rotationSpeed = 180f; // ȸ�� �ӵ� (���� �ӵ�)
    public float damage = 20f;         // ���� ������
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
        float angleStep = 360f / numBullets; // ���� ���� ���

        for (int i = 0; i < numBullets; i++)
        {
            float angle = i * angleStep; // ���� �Ѿ��� ���� ���
            Quaternion rotation = Quaternion.Euler(0f, angle, 0f); // ������ ���� ȸ��

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
