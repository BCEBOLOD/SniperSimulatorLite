using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponSO _weapon;
    [SerializeField] private BulletSO _bullet;

    [SerializeField] private BulletManager _bulletManager;

    [SerializeField] private Transform _muzzleFlashPosition;

    [SerializeField] private int _correctAmmo;//текущее количество патрон в магазине
    [SerializeField] private float _correctTimeReload;// текущее время перезарядки
    [SerializeField] private float _correctTimeFirerate;// текущее время скорострельности 

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private bool _canFire;

    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private float chamberTime = 1f;
    [SerializeField] private Animator animator;

    [SerializeField] private bool isReloading = false;


    private IEnumerator coroutine;

    public Transform MuzzleFlashPosition => _muzzleFlashPosition;

    public WeaponSO CorrectWeapon => _weapon;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        Init();
    }
    private void Update()
    {
        //if ( _correctTimeFirerate <= 0 && _correctAmmo > 0 && _canFire && !isReloading)
        //    OnShoot();
        //else

        if (Input.GetKeyDown(KeyCode.R) && _correctAmmo != CorrectWeapon.MaxAmmo)
            Reload();


            _correctTimeFirerate -= 1 * Time.deltaTime;
    }
    public void OnShoot()
    {
        if (_correctTimeFirerate <= 0 && _correctAmmo > 0 && _canFire && !isReloading)
        {
            _correctAmmo--;
        _correctTimeFirerate = CorrectWeapon.FireRate;
        _audioSource.Play();
            _bulletManager.OnShoot();
        }

    }
    private void Init()
    {
        _audioSource.clip = CorrectWeapon.ShotAudio;
        _correctAmmo = CorrectWeapon.MaxAmmo;
    }
    private void Reload()
    {
        if (!isReloading)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }

    private IEnumerator ReloadCoroutine()
    {
        isReloading = true;

        // Выключаем возможность стрелять
        // (или блокируем другие действия с оружием)
        // чтобы игрок не мог стрелять во время перезарядки
        // ...

        // Запускаем анимацию вытаскивания магазина
        animator.SetTrigger("EjectMagazine");

        // Ждем некоторое время для завершения анимации
        yield return new WaitForSeconds(reloadTime);

        // Заменяем магазин на новый (или же заполняем старый)
        // ...

        // Запускаем анимацию одевания нового магазина
        animator.SetTrigger("InsertMagazine");

        // Ждем некоторое время для завершения анимации
        yield return new WaitForSeconds(reloadTime);

        // Запускаем анимацию передергивания затвора
        animator.SetTrigger("ChamberRound");

        // Ждем некоторое время для завершения анимации
        yield return new WaitForSeconds(chamberTime);

        // Включаем возможность стрелять
        // (или разблокируем другие действия с оружием)
        // ...

        isReloading = false;
    }
}


