using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance;

    private void Start()
    {
        Instance = this;
    }

    public void PlayList(AudioClip[] clipArray, GameObject obj)
    {
        StartCoroutine(_PlayList(clipArray, obj));
    }

    IEnumerator _PlayList(AudioClip[] clipArray, GameObject obj)
    {
        AudioSource source = obj.GetComponent<AudioSource>();
        int num = 0;

        if (source == null)
        {
            source = obj.AddComponent<AudioSource>();
        }

        while (clipArray.Length > 0 && clipArray.Length > num)
        {
            if (clipArray[num] == null)
            {
                num++;
                continue;
            }
            AudioClip clipA = clipArray[num];
            source.clip = clipA;
            source.volume = 1f;
            source.pitch = 1f;
            source.spatialBlend = 1f;
            source.Play();
            num++;
            yield return new WaitForSeconds(clipA.length);
            yield return null;
        }
        yield break;
    }
}
