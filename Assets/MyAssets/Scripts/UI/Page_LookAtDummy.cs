using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_LookAtDummy : DefaultPanel
{
    public void OnBtnCarCrashClick()
    {
        UIManager.Instance.Navigate(PageType.CarCrash);
    }
}
