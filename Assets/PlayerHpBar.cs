using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayerHpBar : MonoBehaviour
{
    public Slider hpSlider;

    public RawImage screemEffect;

    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hurt(0.1f);
        }
    }

    public void Hurt(float _value)
    {
        hpSlider.value -= _value;

        var a = 1 - hpSlider.value;
        var m_color = screemEffect.color;
        m_color.a = a;
        
        videoPlayer.SetDirectAudioVolume(1 , a);
        screemEffect.color = m_color;
    }
}
