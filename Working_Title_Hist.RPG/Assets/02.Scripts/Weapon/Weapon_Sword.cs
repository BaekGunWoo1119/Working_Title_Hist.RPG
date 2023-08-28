using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Weapon_Sword : MonoBehaviour
{

    public enum Type
    {
        Melee,
        Range
    };
    public Type type;
    public int Attack_Damage;
    public float Attack_rate;
    public SphereCollider Attack_Area;
    public VisualEffect visualEffect;

    public void Use()
    {
        StartCoroutine("Swing");
    }

    void Awake()
    {

    }

    IEnumerator Swing()
    {
        WeaponBoxManager.WeaponRotate();
        Attack_Area.enabled = true;
        visualEffect.Play();
        yield return new WaitForSeconds(0.2f);
        Attack_Area.enabled = false;
        //yield return new WaitForSeconds(0.1f);
        visualEffect.Stop();
    }
}
