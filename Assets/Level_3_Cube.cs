using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_Cube : MonoBehaviour
{
    [SerializeField] private bool IsDestory = false;
    
    [SerializeField] private Pistal MainPistal;

    [SerializeField] private Level_3_System MainLevelSystem;
    // Start is called before the first frame update

    public void OnAttack()
    {
        IsDestory = true;
        
        if (MainPistal.BulletCheck())
        {
            MainPistal.Shooting();
            gameObject.SetActive(false);
            MainLevelSystem.CheckAllCube();
        }
        else
        {
            MainPistal.Throwing(transform);
        }
    }

    public void ThrowingAttack()
    {
        MainLevelSystem.CheckAllCube();
    }

    public bool ReturnIsDestory()
    {
        return IsDestory;
    }
}
