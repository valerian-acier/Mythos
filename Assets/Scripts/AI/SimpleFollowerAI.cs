﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollowerAI : MonoBehaviour {

    float moveSpeed = 7; 
    float rotationSpeed = 10;
    bool isFollowing = false;
    [SerializeField]
    GameObject player;

	// Use this for initialization
	void Start () {
		
	}


    public void follow(){
        isFollowing = true;
    }

    public void unFollow(){
        isFollowing = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(isFollowing){
            Quaternion onlyY = Quaternion.Euler(0, 1, 0);
            transform.rotation =  Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position)*onlyY, rotationSpeed * Time.deltaTime);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
	}
}