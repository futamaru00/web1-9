﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0;
    int ratio = 2;
    float speed = -0.03f;
    int appleNum = 4;
    int bombNum = 5;

    public void SetParameter(float span,float speed,int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }

	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            if (ratio != 0)
            {
                this.delta = 0;
                GameObject item;
                int dice = Random.Range(1, 11);
                if (dice <= this.ratio)
                {
                    item = Instantiate(bombPrefab) as GameObject;
                }
                else
                {
                    item = Instantiate(applePrefab) as GameObject;
                }
                float x = Random.Range(-1, 2);
                float z = Random.Range(-1, 2);
                item.transform.position = new Vector3(x, 4, z);
                item.GetComponent<ItemController>().dropSpeed = this.speed;
            }
            else if (ratio == 0)
            {
                this.delta = 0;
                GameObject item;
                for (int i = -1; i < 2; i++)
                {
                    for (int m = -1; m < 2; m++)
                    {
                        int dice = Random.Range(1, 11);
                        if (dice <= 5)
                        {
                            if (bombNum != 0)
                            {
                                item = Instantiate(bombPrefab) as GameObject;
                                bombNum--;
                            }
                            else
                            {
                                item = Instantiate(applePrefab) as GameObject;
                                appleNum--;
                            }
                        }
                        else
                        {
                            if (appleNum != 0)
                            {
                                item = Instantiate(applePrefab) as GameObject;
                                appleNum--;
                            }
                            else
                            {
                                item = Instantiate(bombPrefab) as GameObject;
                                bombNum--;
                            }
                        }
                        float x = i;
                        float z = m;
                        item.transform.position = new Vector3(x, 4, z);
                        item.GetComponent<ItemController>().dropSpeed = this.speed;
                    }
                }
                appleNum = 4;
                bombNum = 5;
            }
        }
	}
}
