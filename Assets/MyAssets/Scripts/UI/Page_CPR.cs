using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_CPR : DefaultPanel
{
    public void OnBtnNextClick()
    {
        UIManager.Instance.Navigate(PageType.Final);
    }
}
