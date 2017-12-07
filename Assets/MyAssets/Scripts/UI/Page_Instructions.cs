using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_Instructions : DefaultPanel
{
    public GameObject p2;
    public AudioClip[] clips;
    protected override void OnEnable()
    {
        AudioPlayer.Instance.PlayList(clips, p2);
    }

    protected override void OnDisable()
    {
        
    }

    public void OnBtnNextClick()
    {
        UIManager.Instance.Navigate(PageType.CPR);
    }
}
