using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCount : MonoBehaviour
{
    public LevelInformation levelInformation;
    private int ballPercentage;
    private int ballCount = 0;
    private Coin coin;
    public bool IsCount = true;
    public int totalBall;
    private int totalColorBall = 0;
    private int totalGreyBall = 0;
    private int totalBigBall = 0;

    Vibrate vibrate = new Vibrate();
    public AudioClip groupBallClip;
    private void Start()
    {
        //Count all the balls in the game.
        coin = GameObject.Find("GamePlay").GetComponent<Coin>();
        for (int i = 0; i < levelInformation.greyBallNumber.Count; i++)
        {
            totalGreyBall += levelInformation.greyBallNumber[i];
        }
        for (int i = 0; i < levelInformation.colorBallNumber.Count; i++)
        {
            totalColorBall += levelInformation.colorBallNumber[i];
        }
        for (int i = 0; i < levelInformation.bigBallNumber.Count; i++)
        {
            totalBigBall += levelInformation.bigBallNumber[i];
        }
        totalBall = totalColorBall + totalGreyBall + (totalBigBall * 8);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorBall")
        {
            ballCount++;
            AudioManager.instances.GroupBallPop();
            BallCounter();
        }
        if (collision.tag == "GreyBall")
        {
            Destroy(collision.gameObject);
            UIManager.instance.LevelFail();
        }
    }

    //Divede bucket ball in percentage
    public void BallCounter()
    {
        ballPercentage = (ballCount * 100) / totalBall;
        UIManager.instance.ballCountText.text = ballPercentage.ToString();

        Result();
    }

    void Result()
    {
        if (ballCount == totalBall)
        {
            GameManager.instances.IsLevelFail = false;
            AudioManager.instances.LevelComplete();
            Invoke("ActiveWinPanel", 1f);
        }

    }



    void ActiveWinPanel()
    {
        coin.SetCoinValue();
        UIManager.instance.ActiveWinPanel();
    }


}
