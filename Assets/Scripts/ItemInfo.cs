using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "item")]
public class ItemInfo : ScriptableObject
{
    public new string name;
    public Sprite art;
    public int damage;
    public int durability;


}
