using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistal : MonoBehaviour
{
    [SerializeField] private Vector3 StartPos;

    [SerializeField] private GameObject GunPos;

    [SerializeField] private Text BulletText;

    [SerializeField] private int BulletCount = 6;

    [SerializeField] private bool isReloading = false;

    [SerializeField] private BoxCollider boxCollider;
    
    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource fireSoundEffect;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Transform firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLerp());
        BulletText.text = "" + BulletCount;

        fireSoundEffect = GetComponent<AudioSource>();
    }

    public void StartGet()
    {
        StartCoroutine(StartGetGun());
    }

    public void GunDisenableBox()
    {
        Destroy(boxCollider);
    }

    private IEnumerator StartLerp()
    {
        transform.position = Vector3.Lerp(transform.position, StartPos, 0.1f);
        
        
        if (Vector3.Distance(transform.position , StartPos) <= 0.01f)
        {
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(.01f);
            StartCoroutine(StartLerp());
        }
    }

    private IEnumerator StartGetGun()
    {
        transform.position = Vector3.Lerp(transform.position, GunPos.transform.position, 0.1f);
        transform.rotation = Quaternion.Lerp(transform.rotation , GunPos.transform.rotation , 0.1f);
        
        if (Vector3.Distance(transform.position , GunPos.transform.position) <= 0.01f)
        {
            transform.parent = GameObject.Find("Hand").transform;
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(.01f);
            StartCoroutine(StartGetGun());
        }
    }

    public void Shooting()
    {
        /*
        if(isReloading) return;

        BulletCount--;
        BulletText.text = "" + BulletCount;

        if (BulletCount <= 0)
        {
            isReloading = true;
            Invoke("UnReloading" , 2);
        }
        */
        
        animator.Play("HandFire");
        fireSoundEffect.Play();

        Instantiate(bulletPrefab, firePoint.position, firePoint.transform.rotation);
    }

    public void UnReloading()
    {
        isReloading = false;
        BulletCount = 6;
    }

    public bool BulletCheck()
    {
        if (BulletCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
