using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public Animator animator;

    public float moveSpeed = 15.0f;
    public float rotSpeed = 5.0f;
    //private void Move_Pos(Vector3 move) { this.transform.position += move; }
    //private Vector3 Get_Pos() { return this.transform.position; }


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        // Rigidbody�� �߷� �ɼ��� �̿��� Y�� �̵��� ����
        playerRigidbody.constraints = RigidbodyConstraints.FreezePositionY;

    }

    IEnumerator PlayerAttack()
    {
        PlayerAnim.SetWalkingAnimation(false);
        PlayerAnim.SetIdleAnimation(false);
        PlayerAnim.SetPlayerDamage(false);
        PlayerAnim.SetPlayerAttack(true);
        //������ ���� ���� �ִϸ��̼� ����
        yield return new WaitForSeconds(1f);
        PlayerAnim.SetPlayerAttack(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        bool LMB = Input.GetMouseButtonDown(0);

        // �̵� ���� ���� ���
        Vector3 moveDirection = new Vector3(xInput, 0f, zInput).normalized;

        // ��ǥ ȸ�� ���� ���
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;

        // ���� ȸ�� ����
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

        // ���� �̵� ����
        Vector3 moveVelocity = moveDirection * moveSpeed * Time.deltaTime;
        transform.Translate(moveVelocity, Space.World);

        //Vector2 joystickDelta = virtualJoystickInstance.GetJoystickDelta();
        //float pushStrength = virtualJoystickInstance.worldObjectPushStrength;
        //VirtualJoystick.MovePlayer(joystickDelta, pushStrength);

        if (moveVelocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveVelocity);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

        }

        if (moveVelocity.magnitude > 0f)
        {
            PlayerAnim.SetWalkingAnimation(true);
            PlayerAnim.SetIdleAnimation(false);
            PlayerAnim.SetPlayerDamage(false);
        }
        else
        {
            PlayerAnim.SetWalkingAnimation(false);
            PlayerAnim.SetIdleAnimation(true);
        }

        if (LMB)
        {
            StartCoroutine(PlayerAttack());
        }
    }
}
