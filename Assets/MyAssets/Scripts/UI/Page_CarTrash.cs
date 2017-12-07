using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_CarTrash : DefaultPanel
{
    public void OnBtnPlayAnimation()
    {
        UIManager.Instance.Navigate(PageType.Instructions);
    }
}
