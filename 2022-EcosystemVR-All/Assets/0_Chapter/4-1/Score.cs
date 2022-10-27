using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeReference]
    Text TextObj;
    static Text ScoreText;
    [SerializeReference]
    FlowerSpawner flowerSpawner;

    static int score = 0;

    public static void AddScore(int a = 100)
    {
        score += a;
        //ScoreText.text = string.Format("被外來種侵襲的比例：{0}", score);
    }

    private void Start()
    {
        flowerSpawner = FindObjectOfType<FlowerSpawner>();
        ScoreText = TextObj;
    }
    private void Update()
    {
        float rate = (float)flowerSpawner.FlowerCount / 25f * 100f;
        //print(rate);
        ScoreText.text = string.Format("被外來種侵襲的比例：\n{0:0.0}%", rate.ToString());
    }
}
