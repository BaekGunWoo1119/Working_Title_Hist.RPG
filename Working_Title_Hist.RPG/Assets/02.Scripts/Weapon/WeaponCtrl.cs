using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : MonoBehaviour
{
    public GameObject[] Weapons;

    public enum Weapon_Type
    {
        SWORD,
        HAMMER,
        SPEAR,
        AXE,
        BOW,
        NONE
    }

    public Weapon_Type type;

    void Start()
    {
        type = Weapon_Type.NONE;
        Weapon_Change();
    }

    public void Weapon_Change()
    {
        if(type == Weapon_Type.SWORD)
        {
            Weapons[0].SetActive(true);
        } 
        else if(type == Weapon_Type.HAMMER)
        {
            
        }
        else if(type == Weapon_Type.SPEAR)
        {
            Weapons[1].SetActive(true);
        }
        else if(type == Weapon_Type.AXE)
        {
            
        }   
        else if(type == Weapon_Type.BOW)
        {
            Weapons[2].SetActive(true);
        }
    }
}
