using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class XboxRightStick : MonoBehaviour
{
    public AudioClip[] slow;
    public AudioClip[] fast;
    public AudioClip[] keep;

    public Text bpmText;
    public Text prompt;
    public float start;
    public float beats;

    float totalTimeWeSpentInLastFiveHits;
    int totalHit = 0;
    float lastTime;

    void Start()
    {

        StartCoroutine("checkController");
    }

    IEnumerator checkController()
    {
        while (true)
        {
            if (Input.GetKeyDown("joystick button 9"))
            {
                start = Time.time;
                Invoke("Repeater", 0.0f);
                yield break;
            }
            yield return null;
        }
    }

    void Repeater()
    {
        StopAllCoroutines();
        StartCoroutine(CheckForOneEffectivePulse());
    }




    IEnumerator CheckForOneEffectivePulse()
    {
        totalTimeWeSpentInLastFiveHits = 0;
        totalHit = 0;
        bool firstPressed = false;

        while (true)
        {
            //Debug.Log(totalTimeWeSpentInLastFiveHits);
            Debug.Log(totalHit);
            totalTimeWeSpentInLastFiveHits += Time.deltaTime;

            if (Input.GetKeyDown("joystick button 9"))
            {
                if (!firstPressed)
                {
                    firstPressed = true;
                    totalTimeWeSpentInLastFiveHits += (Time.time - lastTime) / 2;
                    Debug.Log((Time.time - lastTime) / 2);
                }
                totalHit++;
            }



            if (totalHit == 5)
            {
                int speed = (int)((60f / totalTimeWeSpentInLastFiveHits) * 5f + 8f);
                if (speed >= 110)
                {
                    prompt.text = "Too Fast";
                    AudioPlayer.Instance.PlayList(fast, this.gameObject);
                }
                else if (speed < 90)
                {
                    prompt.text = "Too Slow";
                    AudioPlayer.Instance.PlayList(slow, this.gameObject);
                }
                else
                {
                    prompt.text = "Keep Going";
                    AudioPlayer.Instance.PlayList(keep, this.gameObject);
                }
                bpmText.text = "Your Speed: " + speed + " beats per minute";
                yield return new WaitForEndOfFrame();
                lastTime = Time.time;
                StartCoroutine(CheckForOneEffectivePulse());
                yield break;
            }
            yield return null;
        }
    }


    /*  private void FixedUpdate()
      {
          ControllerTest();
          //TimeSpan elapsed = start - DateTime.Now;
          elapsed = elapsed.Duration();
          float seconds = (float)elapsed.TotalSeconds;
          float bpm = beats / seconds;
          float yourTime= 60.0f / seconds;
          float yourBeats = beats * yourTime;

          bpmText.text = "Your Speed: " + Mathf.Round(yourBeats) + " beats per minute";

          if (yourBeats >= 104) {
              prompt.text = "Too Fast!";

          }
          else if(yourBeats <=96)
          {
              prompt.text = "Too Slow!";
          }
          else
          {
              prompt.text = "Keep Going!";
          }



      }


      void rateOfChange()
      {

      }
      void ControllerTest()
      {
          bool xbox_rs = Input.GetKeyDown("joystick button 9");

          if (xbox_rs)
          {
              beats++;
          }
      }
      */
}