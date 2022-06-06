using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTextSystem : MonoBehaviour
{
    [SerializeField] private int LevelIndex;
    
    [SerializeField] private Text Uptext, Downtext;

    [SerializeField] private GraphicRaycaster levelGraphicRaycaster;

    [SerializeField] private GameObject Pistal;

    [SerializeField] private GameObject Level_1_Object;

    [SerializeField] private GameObject Level_2_Object;

    [SerializeField] private GameObject Level_3_Object;

    [SerializeField] private GameObject Level_4_Object;

    [SerializeField] private GameObject StartButton;
    
    // Start is called before the first frame update
    void Start()
    {
        LevelIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetativeLevelSystem()
    {
        gameObject.SetActive(false);
    }

    public void OpenGraphicRaycaster()
    {
        levelGraphicRaycaster.ignoreReversedGraphics = true;
    }
    
    public void CloseGraphicRaycaster()
    {
        levelGraphicRaycaster.ignoreReversedGraphics = false;
    }

    public void StartGame()
    {
        if (LevelIndex == 1)
        {
            StartLevelOne();
        }
        else if(LevelIndex == 2)
        {
            StartLevelTwo();
        }
        else if(LevelIndex == 3)
        {
            StartLevelThree();
        }
        else if(LevelIndex == 4)
        {
            
        }
    }

    public void NextLevel()
    {
        LevelIndex++;
    }

    public void Level_1_ObjectSetAtive()
    {
        SetStartButtonAtive(true);
    }

    public void StartLevelOne()
    {
        Level_1_Object.SetActive(true);
    }
    
    public void StartLevelTwo()
    {
        Level_2_Object.SetActive(true);
    }

    public void StartLevelThree()
    {
        Level_3_Object.SetActive(true);
    }
    
    public void StartLevelFour()
    {
        Level_4_Object.SetActive(true);
    }

    public void SetPistal()
    {
        Pistal.SetActive(true);
    }

        public void SetUpText(string text)
    {
        Uptext.text = text;
    }
    
    public void SetDownText(string text)
    {
        Downtext.text = text;
    }

    public void SetStartButtonAtive(bool _Ative)
    {
        StartButton.SetActive(_Ative);
    }
}
