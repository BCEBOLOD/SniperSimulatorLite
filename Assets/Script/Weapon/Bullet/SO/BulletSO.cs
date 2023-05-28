using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Bullet", menuName = "Weapon/New Bullet")]
public class BulletSO : ScriptableObject
{
    [SerializeField] private float _speedBullet;
    public float SpeedBullet => _speedBullet;


    [SerializeField] private float _weightBullet;
    public float WeightBullet => _weightBullet;

}
