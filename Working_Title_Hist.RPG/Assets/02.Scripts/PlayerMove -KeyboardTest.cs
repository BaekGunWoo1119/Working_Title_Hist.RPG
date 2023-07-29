using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public Animator animator;

    public GameObject Skillprefab;
    public GameObject Skill2prefab;
    public Transform SkillSpawn;

    public float moveSpeed = 15.0f;
    public float rotSpeed = 5.0f;
    //private void Move_Pos(Vector3 move) { this.transform.position += move; }
    //private Vector3 Get_Pos() { return this.transform.position; }

    private float ATKDelay;

    private float SkillDelay;
    private float Skill2Delay;
    private float Skill2_Interval;
    public Weapon_Sword Weapon_Sword;


    public Weapon_Bow Weapon_Bow;
    public Weapon_Spear Weapon_Spear;
    public WeaponCtrl WeaponCtrl;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        // Rigidbody�� �߷� �ɼ��� �̿��� Y�� �̵��� ����
        playerRigidbody.constraints = RigidbodyConstraints.FreezePositionY;

        Weapon_Sword.traillEffect.enabled = false;
        Weapon_Sword.Attack_Area.enabled = false;
    }

    IEnumerator PlayerAttack()
    {
        PlayerAnim.SetWalkingAnimation(false);
        PlayerAnim.SetIdleAnimation(false);
        PlayerAnim.SetPlayerAttack(true);
        
        yield return new WaitForSeconds(0.1f);
        PlayerAnim.SetPlayerAttack(false);
    }

    // Update is called once per frame
    void Update()
    {

        ATKDelay += Time.deltaTime;
        SkillDelay += Time.deltaTime;
        Skill2Delay += Time.deltaTime;
        Skill2_Interval += Time.deltaTime;

        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // �̵� ���� ���� ���
        Vector3 moveDirection = new Vector3(xInput, 0f, zInput).normalized;


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
            // ��ǥ ȸ�� ���� ���
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;

            // ���� ȸ�� ����
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            PlayerAnim.SetWalkingAnimation(true);
            PlayerAnim.SetIdleAnimation(false);
        }
        else
        {

            PlayerAnim.SetWalkingAnimation(false);
            PlayerAnim.SetIdleAnimation(true);
        }

        if(ATKDelay > PlayerState.PlayerATK_Rate)
        {
            if(WeaponCtrl.type == WeaponCtrl.Weapon_Type.SWORD)
            {
                ATKDelay = 0;
                StartCoroutine(PlayerAttack());
                Debug.Log("공격");

                Weapon_Sword.Use();
            }
            if(WeaponCtrl.type == WeaponCtrl.Weapon_Type.BOW)
            {
                ATKDelay = 0;
                Debug.Log("공격");
                Weapon_Bow.Use();
            }
        }
        //좌클릭 누르면 스킬 나가게, 3초 딜레이
        if (Input.GetMouseButton(0) && SkillDelay >= 3.0f)
        {
            Instantiate(Skillprefab, SkillSpawn.transform.position, SkillSpawn.transform.rotation);
            SkillDelay = 0;
        }
        //우클릭 누르면 스킬 나가게, 3초 딜레이
        if (Input.GetMouseButton(1) && Skill2Delay >= 3.0f)
        {
            StartCoroutine(Skill2());
        }
    }
    IEnumerator Skill2()
    {
        Skill2Delay = 0;
        Instantiate(Skill2prefab, SkillSpawn.transform.position, SkillSpawn.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(Skill2prefab, SkillSpawn.transform.position, SkillSpawn.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(Skill2prefab, SkillSpawn.transform.position, SkillSpawn.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(Skill2prefab, SkillSpawn.transform.position, SkillSpawn.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(Skill2prefab, SkillSpawn.transform.position, SkillSpawn.transform.rotation);
    }
}
