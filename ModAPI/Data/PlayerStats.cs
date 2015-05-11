using UnityEngine;
using System.Collections;

[DoNotSerializePublic]
public class PlayerStats
{
    [SerializeThis]
    public int Armor;
    [SerializeThis]
    public float Energy;
    [SerializeThis]
    public float Fullness;
    [SerializeThis]
    public float Health;
    [SerializeThis]
    public float Stamina;
}