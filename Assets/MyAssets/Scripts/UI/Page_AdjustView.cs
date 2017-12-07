using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_AdjustView : DefaultPanel
{
    public void OnBtnClick()
    {
        UIManager.Instance.Navigate(PageType.SelectMode);
    }
}
