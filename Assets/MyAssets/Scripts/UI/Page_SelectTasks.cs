using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_SelectTasks : DefaultPanel
{
    public void OnBtnCarCrashClick()
    {
        UIManager.Instance.Navigate(PageType.LookAtDummy);
    }
}
