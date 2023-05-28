using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/New Weapon")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private string _name_ru;
    [SerializeField] private string _name_eng;
    [SerializeField] private string _name_chine;
    [SerializeField] private string _name_japan;
    [SerializeField] private string _name_ger;
    [SerializeField] private string _name_france;
    [SerializeField] private string _name_italy;
    [SerializeField] private string _name_spain;
    [SerializeField] private string _name_south_korea;

    [SerializeField] private int _maxAmmo;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _damage;
    [SerializeField] private float _startBulletSpeed;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private AudioClip _shotAudio;
    [SerializeField] private AudioClip _reloadSound;

    public int MaxAmmo => _maxAmmo;
    public float ReloadTime => _reloadTime;
    public float FireRate => _fireRate;
    public float Damage => _damage;
    public Sprite Sprite => _sprite;

    public AudioClip ShotAudio  => _shotAudio;
    public AudioClip ReloadSound => _reloadSound;

    public float StartBulletSpeed => _startBulletSpeed; 
}