using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBlockID : MonoBehaviour
{
    private GameObject _block;
    GameObject _gameManager;
    BlockChecker _blockChecker  = default;
    //ブロックの列のID
    public double iD = -1;

    //BlockController _fallBlock;

    private void Start()
    {
        _block = GameObject.FindGameObjectWithTag("Block");
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _blockChecker = _gameManager.GetComponent<BlockChecker>();
        //_block = GameObject.Find("Block1");
    }

    void Update()
    {
        if (_block.GetComponent<BlockController>()._fallBlock == false)
        {
            this.gameObject.transform.parent = null;
            this.tag = "Change";
            _blockChecker.CheckLines();
            iDjudgement();
        }
    }

    void iDjudgement() 
    {
        double n;
        n = this.transform.position.y / 1.5;
        iD = (Math.Floor(n)) - 1;
        Debug.Log("ID=" + iD);
     }
}
