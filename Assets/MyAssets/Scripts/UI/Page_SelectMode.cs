using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_SelectMode : DefaultPanel
{
    public void OnBtnCprTrainingClick()
    {
        UIManager.Instance.Navigate(PageType.Connecting);
    }
}
