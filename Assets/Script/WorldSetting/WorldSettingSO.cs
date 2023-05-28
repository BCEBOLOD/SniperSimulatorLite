using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New world Setting", menuName = "Setting/World")]
public class WorldSettingSO : ScriptableObject
{
    [SerializeField] private float _speed; // ��������� �������� ����
    [SerializeField] private float _gravity; // ��������� ���������� �������
    [SerializeField] private float _airResistance; // ����������� ������������� ������

    public float Speed => _speed;
    public float Gravity => _gravity;
    public float AirResistance => _airResistance;
}
