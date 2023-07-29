using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Bow : MonoBehaviour
{
    public enum Type
    {
        Melee,
        Range
    };

    public Type type;
    public int Attack_Damage;
    public float Attack_rate;
    public GameObject Arrow;
    public Transform FirePos;

    public void Use()
    {
        StartCoroutine("Shooting");
    }

    void Awake()
    {

    }

    void Update()
    {
        
    }

    IEnumerator Shooting()
    {
        Instantiate(Arrow, FirePos.transform.position, FirePos.transform.rotation);
        yield return new WaitForSeconds(0.0f);
    }
}
