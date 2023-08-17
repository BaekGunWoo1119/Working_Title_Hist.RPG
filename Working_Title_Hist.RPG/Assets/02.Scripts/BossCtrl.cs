using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject AngryEffect;
    public int numBullets = 8;       
    public float bulletSpeed = 10f;  

    public float rotationSpeed = 30.0f; 
    public float damage = 20f;         
    public float moveSpeed = 2f;
    private Vector3 initialPosition;
    private float angle = 0f;

    private Transform playerTransform;
    private Rigidbody rb;

    public float chargeSpeed = 5.0f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;

        StartCoroutine(Think());
    }
    void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, playerTransform.position));
    }

    IEnumerator Think()
    {
        yield return new WaitForSeconds(0.1f);

        int ranAction = Random.Range(0, 5);
        switch (ranAction)
        {
            case 0:
            case 1:
                StartCoroutine(SwingAttack());
                break;
            case 2:
                StartCoroutine(RushAttack());
                break;
            case 3:
                StartCoroutine(ShootAttack());
                break;
            case 4:
                StartCoroutine(JumpAttack());
                break;
        }
    }

    IEnumerator SwingAttack()
    {
        yield return new WaitForSeconds(0.2f);

        Debug.Log("보스 : 회전공격");
        float elapsedTime = 0.0f; // 경과 시간

        while (elapsedTime < 5.0f)
        {
            // 물체를 회전합니다.
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        StartCoroutine(Think());
    }

    IEnumerator RushAttack()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(AngryEffect, transform.position, transform.rotation);
        yield return new WaitForSeconds(2.0f);

        Debug.Log("보스 : 돌진공격");

        Vector3 targetPosition = playerTransform.position - (playerTransform.forward * 2.0f);

        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;
        float startTime = Time.time;

        while (Time.time - startTime < 1.5f)
        {
            rb.AddForce(direction * chargeSpeed);
            yield return null;
        }

        rb.velocity = Vector3.zero;

        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Think());
    }

    IEnumerator ShootAttack()
    {
        yield return new WaitForSeconds(0.2f);

        Debug.Log("보스 : 발사공격");

        Vector3 playerDirection = playerTransform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(playerDirection);

        float angleStep = 180f / numBullets; 

        for (int i = 0; i < numBullets; i++)
        {
            float angle = i * angleStep; 
            Quaternion rotation = Quaternion.Euler(0f, angle, 0f) * lookRotation; // 플레이어 방향을 추가한 회전값
            rotation *= Quaternion.Euler(0f, 270f, 0f); // y축으로 90도 회전

            GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);
            yield return new WaitForSeconds(0.1f);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bullet.transform.forward * bulletSpeed;
        }
        
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Think());
    }
    
    IEnumerator JumpAttack()
    {

        Debug.Log("보스 : 점프공격");

        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Think());
    }
}
