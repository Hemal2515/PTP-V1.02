using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public GameObject colorBallPrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "BigBall")
        {

            GameObject bigBall = collision.gameObject;
            Destroy(bigBall);
            StartCoroutine(SpawnBall());
        }

    }

    public IEnumerator SpawnBall()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject obj = Instantiate(colorBallPrefab, this.transform.position + new Vector3(0, 0.27f, 0), Quaternion.identity, this.transform);
            float randomNumber = Random.Range(0.4f, 0.7f);
            obj.transform.localScale = new Vector3(randomNumber, randomNumber, randomNumber);
            obj.GetComponent<SpriteRenderer>().color = GameManager.instances.color[Random.Range(0, GameManager.instances.color.Count)];
            yield return null;
        }
    }
}
