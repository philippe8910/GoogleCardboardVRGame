using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level_3_System : MonoBehaviour
{
    [SerializeField] private UnityEvent EnterLevel;
    
    [SerializeField] private List<Level_3_Cube> LevelCube = new List<Level_3_Cube>();

    public void CheckAllCube()
    {
        if (CheckCube())
        {
            EnterLevel.Invoke();
            Debug.Log("EndLevel_3");
        }
    }
    
    

    private bool CheckCube()
    {
        bool IsAllComplite = true;

        for (int i = 0 ; i < LevelCube.Count ; i++)
        {
            if (!LevelCube[i].ReturnIsDestory())
            {
                IsAllComplite = false;
            }
        }

        return IsAllComplite;
    }
}
