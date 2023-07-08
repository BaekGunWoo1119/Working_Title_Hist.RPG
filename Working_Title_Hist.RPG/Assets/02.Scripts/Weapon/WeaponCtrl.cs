using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : MonoBehaviour
{
    public GameObject[] Weapons;
    public bool[] HasWeapons;

    public enum Weapon_Type
    {
        SWORD,
        HAMMER,
        SPEAR,
        AXE,
        BOW
    }

    public Weapon_Type type;

    public void Weapon_Change()
    {
        if(type == Weapon_Type.SWORD)
        {   
            
        } 
        else if(type == Weapon_Type.HAMMER)
        {
            
        }
        else if(type == Weapon_Type.SPEAR)
        {
            
        }
        else if(type == Weapon_Type.AXE)
        {
            
        }   
        else if(type == Weapon_Type.BOW)
        {
            
        }
    }

    

}
