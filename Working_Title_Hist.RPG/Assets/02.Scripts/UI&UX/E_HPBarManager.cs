using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class E_HPBarManager : MonoBehaviour
{
    public Slider healthSlider;
    public Image progressBarImage;
    public Transform parentObject;
    public Canvas canvas;

    private float maxHealth = S_EnemyCtrl.MaxHP;
    private float currentHealth = S_EnemyCtrl.HP;
    // 체력 값을 설정하는 함수
    void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        // 체력 비율 계산 (0~1)
        float healthRatio = currentHealth / maxHealth;

        // Slider의 value에 체력 비율 할당
        healthSlider.value = healthRatio;

        // ProgressBar 이미지의 색상 업데이트 (예시: 체력이 30% 이하일 때 빨간색, 그 외에는 녹색)
        //progressBarImage.color = (healthRatio <= 0.3f) ? Color.red : Color.green;

        // 상위 오브젝트 회전값
        Quaternion parentRotation = parentObject.rotation;

        // 회전값의 반대 방향을 캔버스에 적용
        canvas.transform.rotation = Quaternion.Inverse(parentRotation);
    }
}
