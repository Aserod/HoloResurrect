using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_Connecting : DefaultPanel
{
    protected override void OnEnable()
    {
        StartCoroutine(WaitForConnected());
    }

    protected override void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator WaitForConnected()
    {
        yield return new WaitForSeconds(2f);
        UIManager.Instance.Navigate(PageType.Connected);
    }
}
