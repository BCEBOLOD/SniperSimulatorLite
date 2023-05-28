using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletManager _bulletManager;
    [SerializeField] private bool _fly;// тру когда пуля летит 
    private Rigidbody _rb;
    private Vector3 _startVelocity;
    private Vector3 _startPosition;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _bulletManager = GetComponentInParent<BulletManager>();        
    }
    private void Start()
    {
        _rb.maxAngularVelocity = 1000;
        _startVelocity = _bulletManager.Weapon.MuzzleFlashPosition.forward * _bulletManager.Weapon.CorrectWeapon.StartBulletSpeed;
    }
    private void Update()
    {
        Vector3 displacement = transform.position - _startPosition;
        Vector3 gravityForce = Vector3.down * _bulletManager.SettingWorld.Gravity * displacement.magnitude;
        Vector3 airResistanceForce = -_startVelocity.normalized * _bulletManager.SettingWorld.AirResistance * _bulletManager.Weapon.CorrectWeapon.StartBulletSpeed * _startVelocity.sqrMagnitude;

        Vector3 acceleration = (gravityForce + airResistanceForce) / GetComponent<Rigidbody>().mass;
        _startVelocity += acceleration * Time.deltaTime;
        transform.position += _startVelocity * Time.deltaTime;
    }
    public void OnShoot()
    {
       
    }


    public void EnterPool()
    {
        transform.parent = _bulletManager.transform;
        transform.position = Vector3.zero;
    }
    public void ExitPool()
    {
      //  transform.parent = null;
      transform.SetParent(null);
        transform.localScale = _bulletManager.PrefabBullet.transform.localScale;
        transform.position = _bulletManager.transform.position;
        gameObject.SetActive(true);
        _rb.velocity = _bulletManager.Weapon.MuzzleFlashPosition.gameObject.transform.forward * _bulletManager.Bullet.SpeedBullet;

        _startVelocity = _bulletManager.Weapon.MuzzleFlashPosition.forward * _bulletManager.Weapon.CorrectWeapon.StartBulletSpeed;
        _startPosition = _bulletManager.Weapon.MuzzleFlashPosition.position;
    }
}
