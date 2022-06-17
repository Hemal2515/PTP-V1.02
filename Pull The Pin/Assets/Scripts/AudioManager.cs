using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Image muteImage;
    public Image SoundImage;
    public Button button;
    public bool IsSoundOn1 = true;

    public static AudioManager instances;
    public AudioSource audioSource;

    public AudioClip bombBlast;
    public AudioClip buttonClick;
    public AudioClip gameOver;
    public AudioClip groupBallPop;
    public AudioClip halfLevelComplete;
    public AudioClip levelComplete;
    public AudioClip pullThePin;
    public AudioClip singleBallPop;

    // Start is called before the first frame update
    void Start()
    {
        if (instances != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instances = this;
        }
        IsSoundOn1 = PlayerPrefs.GetInt("IsSoundOn") == 1 ? true : false;
        //Debug.Log(IsSoundOn1);
        SoundOn(IsSoundOn1);
    }

    public void OnButttonClick()
    {
        // Make sound mute or unmute

        SoundOn(IsSoundOn1);
    }

    public void SoundOn(bool IsSoundOn)
    {

        if (!IsSoundOn)
        {
            //Debug.Log("SoundOn On");
            audioSource.mute = false;
            SoundImage.enabled = true;
            muteImage.enabled = false;
            IsSoundOn = false;
            PlayerPrefs.SetInt("IsSoundOn", IsSoundOn ? 1 : 0);
            IsSoundOn1 = true;
        }
        else
        {
            //Debug.Log("SoundOn Off");
            audioSource.mute = true;
            SoundImage.enabled = false;
            muteImage.enabled = true;
            IsSoundOn = true;
            PlayerPrefs.SetInt("IsSoundOn", IsSoundOn ? 1 : 0);
            IsSoundOn1 = false;
        }
    }

    public void BombBlast()
    {
        audioSource.PlayOneShot(bombBlast);
    }

    public void ButtonClick()
    {
        audioSource.PlayOneShot(buttonClick);
    }

    public void GameOver()
    {
        audioSource.PlayOneShot(gameOver);
    }

    public void GroupBallPop()
    {
        audioSource.PlayOneShot(groupBallPop);
    }

    public void HalfLevelComplete()
    {
        audioSource.PlayOneShot(halfLevelComplete);
    }

    public void LevelComplete()
    {
        audioSource.PlayOneShot(levelComplete);
    }

    public void PullThePin()
    {
        audioSource.PlayOneShot(pullThePin);
    }

    public void SingleBallPop()
    {
        audioSource.PlayOneShot(singleBallPop);
    }
    public void SFXAudioPlay(AudioClip audioClip)
    {

        audioSource.PlayOneShot(audioClip);
    }

    public void Vibrate()
    {
        Handheld.Vibrate();
    }
}
