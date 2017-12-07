using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_Final : DefaultPanel
{
    public AudioClip[] clips;

    public void OnBtnReturnClick()
    {
        StartCoroutine(_OnBtnReturnClick());
    }

    IEnumerator _OnBtnReturnClick()
    {
        GameObject p1 = GameObject.Find("p1");
        p1.GetComponent<Animator>().CrossFade("Retrieve", .2f);
        yield return new WaitForSeconds(2f);
        AudioPlayer.Instance.PlayList(clips, p1);
        yield return new WaitForSeconds(5f);
        p1.SetActive(false);
        p1.transform.position = new Vector3(0, -1, 2.785f);
        UIManager.Instance.Navigate(PageType.AdjustView);
    }
}
