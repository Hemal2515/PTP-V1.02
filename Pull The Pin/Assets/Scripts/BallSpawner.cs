using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public LevelInformation levelInformation;
    public GameObject colorBallPrefab;
    public GameObject greyBallPrefab;
    public GameObject bigBallPrefab;
    [SerializeField] Transform ballParent;

    public Transform colorBallTransform;
    public Transform greyBallTransform;

    private void Start()
    {
        //Spawn colorBall

        StartCoroutine(InstantiateBalls());
    }

    public IEnumerator InstantiateBalls()
    {
        for (int i = 0; i < levelInformation.colorBallNumber.Count; i++)
        {
            for (int j = 0; j < levelInformation.colorBallNumber[i]; j++)
            {
                GameObject obj = Instantiate(colorBallPrefab, levelInformation.colorBallPosition[i].transform.position, Quaternion.identity, colorBallTransform);
                float randomNumber = Random.Range(0.4f, 0.65f);
                obj.transform.localScale = new Vector3(randomNumber, randomNumber, randomNumber);
                obj.GetComponent<SpriteRenderer>().color = GameManager.instances.color[Random.Range(0, GameManager.instances.color.Count)];
                yield return null;
            }

        }

        //Spawn Greyball
        for (int k = 0; k < levelInformation.greyBallPosition.Count; k++)
        {
            for (int i = 0; i < levelInformation.greyBallNumber[k]; i++)
            {
                GameObject obj = Instantiate(greyBallPrefab, levelInformation.greyBallPosition[k].transform.position, Quaternion.identity, greyBallTransform);
                float randomNumber = Random.Range(0.4f, 0.65f);
                obj.transform.localScale = new Vector3(randomNumber, randomNumber, randomNumber);
                yield return null;
            }
        }

        for (int i = 0; i < levelInformation.bigBallNumber.Count; i++)
        {
            for (int j = 0; j < levelInformation.bigBallNumber[i]; j++)
            {
                Instantiate(bigBallPrefab, levelInformation.bigBallPosition[i].transform.position, Quaternion.identity, ballParent);

                yield return null;
            }
        }
    }

}

