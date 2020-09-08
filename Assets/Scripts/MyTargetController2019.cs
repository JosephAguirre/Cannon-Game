using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTargetController2019 : MonoBehaviour
{
    public GameObject expPreFab;
    public Transform expSpawnPoint;
    private int _scoreText;
    public Text ScoreText;
    public AudioClip explodesound;
    private AudioSource MyAudioSrc;

    void Start()
    {
        _scoreText = 0;
        MyAudioSrc = GetComponent<AudioSource>();
        MyAudioSrc.playOnAwake = false;
        MyAudioSrc.clip = explodesound;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CannonBall")
        {
            var ex = Instantiate(expPreFab, expSpawnPoint.position, Quaternion.identity) as GameObject;
            _scoreText++;
            ScoreText.text = "Score = " + _scoreText;
            MyAudioSrc.Play();
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
