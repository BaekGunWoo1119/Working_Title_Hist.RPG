using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class VirtualJoystick : MonoBehaviour
{
    //조이스틱 변수 지정
    private VisualElement m_JoystickBack;
    private VisualElement m_JoystickHandle;
    private Vector2 m_JoystickPointerDownPosition;
    private Vector2 m_JoystickDelta; //-1 과 1 사이 값(GetAxis와 동일)

    public Rigidbody playerRigidbody;

    public float moveSpeed = 15.0f;
    public float rotSpeed = 5.0f;

    void Start()
    {
        // Rigidbody의 중력 옵션을 이용해 Y축 이동을 제한
        playerRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    }
    void OnEnable()
    {
        //UI Document에서 조이스틱 받아와서 설정
        var root = GetComponent<UIDocument>().rootVisualElement;
        m_JoystickBack = root.Q("JoystickBack");
        m_JoystickHandle = root.Q("JoystickHandle");
        m_JoystickHandle.RegisterCallback<PointerDownEvent>(OnPointerDown);
        m_JoystickHandle.RegisterCallback<PointerUpEvent>(OnPointerUp);
        m_JoystickHandle.RegisterCallback<PointerMoveEvent>(OnPointerMove);
    }

    void Update()
    {
        if (m_JoystickDelta != Vector2.zero)
        {
            float horizontalInput = m_JoystickDelta.x; // 조이스틱의 가로 이동 값
            float verticalInput = m_JoystickDelta.y; // 조이스틱의 세로 이동 값

            // 이동 방향 벡터 계산
            Vector3 moveDirection = new Vector3(m_JoystickDelta.x, 0f, -m_JoystickDelta.y).normalized;

            // 목표 회전 각도 계산
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;

            // 실제 회전 적용
            playerRigidbody.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // 실제 이동 적용
            Vector3 moveVelocity = moveDirection * moveSpeed * Time.deltaTime;
            playerRigidbody.transform.Translate(moveVelocity, Space.World);

            //움직임이 있을 때
            if (moveVelocity != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveVelocity);
                playerRigidbody.transform.rotation = Quaternion.Lerp(playerRigidbody.transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
            }

            if (moveVelocity.magnitude > 0f)
            {
                PlayerAnim.SetWalkingAnimation(true);
                PlayerAnim.SetIdleAnimation(false);
            }
            else
            {
                PlayerAnim.SetWalkingAnimation(false);
                PlayerAnim.SetIdleAnimation(true);
            }

        }
        //움직임이 없을 때
        else
        {
            PlayerAnim.SetWalkingAnimation(false);
            PlayerAnim.SetIdleAnimation(true);
        }
    }

    //조이스틱 포인터 설정
    void OnPointerDown(PointerDownEvent e)
    {
        m_JoystickHandle.CapturePointer(e.pointerId);
        m_JoystickPointerDownPosition = e.position;
    }

    void OnPointerUp(PointerUpEvent e)
    {
        m_JoystickHandle.ReleasePointer(e.pointerId);
        m_JoystickHandle.transform.position = Vector3.zero;
        m_JoystickDelta = Vector2.zero;
    }

    void OnPointerMove(PointerMoveEvent e)
    {
        if (!m_JoystickHandle.HasPointerCapture(e.pointerId))
            return;
        var pointerCurrentPosition = (Vector2)e.position;
        var pointerMaxDelta = (m_JoystickBack.worldBound.size - m_JoystickHandle.worldBound.size) / 2;
        var pointerDelta = Clamp(pointerCurrentPosition - m_JoystickPointerDownPosition, -pointerMaxDelta,
            pointerMaxDelta);
        m_JoystickHandle.transform.position = pointerDelta;
        m_JoystickDelta = pointerDelta / pointerMaxDelta;
    }

    static Vector2 Clamp(Vector2 v, Vector2 min, Vector2 max) =>
        new Vector2(Mathf.Clamp(v.x, min.x, max.x), Mathf.Clamp(v.y, min.y, max.y));
}
