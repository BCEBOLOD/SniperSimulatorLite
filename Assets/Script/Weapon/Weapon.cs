using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponSO _weapon;
    [SerializeField] private BulletSO _bullet;

    [SerializeField] private BulletManager _bulletManager;

    [SerializeField] private Transform _muzzleFlashPosition;

    [SerializeField] private int _correctAmmo;//������� ���������� ������ � ��������
    [SerializeField] private float _correctTimeReload;// ������� ����� �����������
    [SerializeField] private float _correctTimeFirerate;// ������� ����� ���������������� 

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

        // ��������� ����������� ��������
        // (��� ��������� ������ �������� � �������)
        // ����� ����� �� ��� �������� �� ����� �����������
        // ...

        // ��������� �������� ������������ ��������
        animator.SetTrigger("EjectMagazine");

        // ���� ��������� ����� ��� ���������� ��������
        yield return new WaitForSeconds(reloadTime);

        // �������� ������� �� ����� (��� �� ��������� ������)
        // ...

        // ��������� �������� �������� ������ ��������
        animator.SetTrigger("InsertMagazine");

        // ���� ��������� ����� ��� ���������� ��������
        yield return new WaitForSeconds(reloadTime);

        // ��������� �������� �������������� �������
        animator.SetTrigger("ChamberRound");

        // ���� ��������� ����� ��� ���������� ��������
        yield return new WaitForSeconds(chamberTime);

        // �������� ����������� ��������
        // (��� ������������ ������ �������� � �������)
        // ...

        isReloading = false;
    }
}


