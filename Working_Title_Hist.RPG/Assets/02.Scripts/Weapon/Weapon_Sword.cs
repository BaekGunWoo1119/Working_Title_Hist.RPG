using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public BoxCollider Attack_Area;
    public TrailRenderer traillEffect;

    public void Use()
    {
        StartCoroutine("Swing");
    }

    void Awake()
    {

    }

    IEnumerator Swing()
    {
        //yield return new WaitForSeconds(0.01f);
        Attack_Area.enabled = true;
        traillEffect.enabled = true;
        yield return new WaitForSeconds(0.25f);
        Attack_Area.enabled = false;
        //yield return new WaitForSeconds(0.1f);
        traillEffect.enabled = false;
    }
}
