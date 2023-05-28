using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro.EditorUtilities;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private int _numberBullet;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private List<Bullet> _bullets;
    [SerializeField] private BulletSO _bullet;
    [SerializeField] private WorldSettingSO _settingWorld;
    [SerializeField] private Vector3 _startVelocity;
    public BulletSO Bullet=> _bullet;
    public Weapon Weapon  => _weapon;
    public GameObject PrefabBullet => _prefabBullet;
    public WorldSettingSO SettingWorld => _settingWorld;

    public Vector3 StartVelocity  => _startVelocity;

    private void Start()
    {
        for (int i = 0; i < _numberBullet; i++)
        {
            GameObject gameObject = Instantiate(PrefabBullet, transform.gameObject.transform);
            _bullets.Add(gameObject.GetComponent<Bullet>());
            gameObject.SetActive(false);
        }
        _startVelocity = _weapon.MuzzleFlashPosition.forward *  _weapon.CorrectWeapon.StartBulletSpeed;
    }

    public void OnShoot()
    {
       _bullets.First(x=>x.gameObject.activeSelf == false).ExitPool();
    }
}
