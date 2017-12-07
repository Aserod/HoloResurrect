using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_Connected : DefaultPanel
{
    public void OnBtnOKClick()
    {
        UIManager.Instance.Navigate(PageType.SelectTasks);
    }
}
