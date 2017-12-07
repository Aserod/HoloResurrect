using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_CarTrash : DefaultPanel
{
    public Animator man;
    public AudioClip[] clip;

    protected override void OnEnable()
    {

    }

    public void OnBtnPlayAnimation()
    {
        StartCoroutine(WaitUntilAnimationEnd());
    }

    IEnumerator WaitUntilAnimationEnd()
    {
        bool play = false;
        man.gameObject.SetActive(true);
        man.CrossFade("Info", 0.2f, 0);
        yield return new WaitForSeconds(0.3f);
        while (true)
        {
            AnimatorStateInfo info = man.GetCurrentAnimatorStateInfo(0);
            if(info.normalizedTime >= 0.5f && !play)
            {
                AudioPlayer.Instance.PlayList(clip, man.gameObject);
                play = true;
            }

            if(info.normalizedTime >= 0.95f)
            {
                man.CrossFade("Shock", 0.2f, 0);
                break;
            }
            yield return null;
        }
        UIManager.Instance.Navigate(PageType.Instructions);
        yield break;
    }
}
