using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Cube : MonoBehaviour
{
    [SerializeField] private bool IsGaze;

    public void SetGaze(bool _IsGaze)
    {
        IsGaze = _IsGaze;
    }

    public bool GetIsGaze()
    {
        return IsGaze;
    }
}
