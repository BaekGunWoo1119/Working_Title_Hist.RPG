using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class E_HPBarManager : MonoBehaviour
{
    public Slider healthSlider;
    public Image progressBarImage;
    private Transform Cam;
    public Canvas canvas;

    private float maxHealth = S_EnemyCtrl.MaxHP;
    private float currentHealth = S_EnemyCtrl.HP;

    void Start()
    {
        Cam = Camera.main.transform;
    }
   
    void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        float healthRatio = currentHealth / maxHealth;

        healthSlider.value = healthRatio;

        transform.LookAt(transform.position + Cam.rotation * Vector3.forward, Cam.rotation * Vector3.up);   
    }
}
