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
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLerp());
        BulletText.text = "" + BulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGet()
    {
        StartCoroutine(StartGetGun());
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
            transform.parent = Camera.main.transform;
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(.01f);
            StartCoroutine(StartGetGun());
        }
    }

    private IEnumerator StartThrow(Transform TargetPos)
    {
        if (Vector3.Distance(transform.position , TargetPos.position) >= 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position , TargetPos.position , 0.1f);
            transform.Rotate(15,0,0);
            yield return new WaitForSeconds(.01f);
            StartCoroutine(StartThrow(TargetPos));
        }
        else
        {
            yield return null;
        }
    }

    public void Shooting()
    {
        BulletCount--;
        BulletText.text = "" + BulletCount;
    }

    public void Throwing(Transform pos)
    {
        transform.parent = null;
        StartCoroutine(StartThrow(pos));
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CanDestoryObject")
        {
            Destroy(gameObject);
            
            if(other.GetComponent<Level_3_Cube>()) other.gameObject.GetComponent<Level_3_Cube>().ThrowingAttack();
            
            other.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        
    }
}
