﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newcontroller : MonoBehaviour
{

    public float speed;
    public GameObject CannonBallPrefab;
    public Transform CannonBallSpawnPoint;
    private float angle;
    public float AngleIncrement = 5f;
    public float PowerIncrement = 5f;
    public float cannon_Power;
    public float MaxPower = 100f;
    public float MinPower = 1f;
    private const int max_angle = 90;
    private const int min_angle = 0;
    public Text powerText;
    public Text angleText;


    public void fire()
    {
        //Debug.Log("Called Fire");
        var cannonBall = Instantiate(CannonBallPrefab, CannonBallSpawnPoint.position , Quaternion.identity) as GameObject;
        Rigidbody2D cannonBallRigidbody = cannonBall.GetComponent<Rigidbody2D>();
        cannonBallRigidbody.velocity = Quaternion.Euler(0, 0, angle) * Vector3.right * cannon_Power;
    }
    public void angle_Up()
    {
        //Debug.Log("Called Angle Up");
        if (angle >= max_angle) return;
        angle += AngleIncrement;
        angleText.text = "Angle = " + angle;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void angle_Down()
    {
        if (angle <= min_angle) return;
        angle -= AngleIncrement;
        angleText.text = "Angle = " + angle;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


    public void PowerUp()
    {
        if (cannon_Power + PowerIncrement > MaxPower) return;
        cannon_Power += PowerIncrement;
        powerText.text = "Power = " + cannon_Power;
    }
    public void PowerDown()
    {
        if (cannon_Power - PowerIncrement < MinPower) return;
        cannon_Power -= PowerIncrement;
        powerText.text = "Power = " + cannon_Power;
    }

    // Use this for initialization
    void Start()
    {
        powerText.text = "Power = " + cannon_Power;
        angleText.text = "Angle = " + angle;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Inside Update");
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.root.position += Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.root.position += Vector3.left * speed;
        }
    }

}
