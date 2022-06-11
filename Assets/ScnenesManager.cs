using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScnenesManager : MonoBehaviour
{
    public void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
