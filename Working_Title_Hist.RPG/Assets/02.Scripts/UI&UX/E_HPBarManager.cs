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
    // ü�� ���� �����ϴ� �Լ�
    void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        // ü�� ���� ��� (0~1)
        float healthRatio = currentHealth / maxHealth;

        // Slider�� value�� ü�� ���� �Ҵ�
        healthSlider.value = healthRatio;

        // ProgressBar �̹����� ���� ������Ʈ (����: ü���� 30% ������ �� ������, �� �ܿ��� ���)
        //progressBarImage.color = (healthRatio <= 0.3f) ? Color.red : Color.green;

        // ���� ������Ʈ ȸ����
        Quaternion parentRotation = parentObject.rotation;

        // ȸ������ �ݴ� ������ ĵ������ ����
        canvas.transform.rotation = Quaternion.Inverse(parentRotation);
    }
}
