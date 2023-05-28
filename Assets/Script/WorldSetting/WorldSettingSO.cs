using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New world Setting", menuName = "Setting/World")]
public class WorldSettingSO : ScriptableObject
{
    [SerializeField] private float _speed; // начальная скорость пули
    [SerializeField] private float _gravity; // ускорение свободного падения
    [SerializeField] private float _airResistance; // коэффициент сопротивления воздух

    public float Speed => _speed;
    public float Gravity => _gravity;
    public float AirResistance => _airResistance;
}
