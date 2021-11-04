using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBlockID : MonoBehaviour
{
    private GameObject _block;
    //ブロックの列のID
    public int iD = -1;

    //BlockController _fallBlock;

    private void Start()
    {
        _block = GameObject.FindGameObjectWithTag("Block");
        //_block = GameObject.Find("Block1");
    }

    void Update()
    {
        if (_block.GetComponent<BlockController>()._fallBlock == false)
        {
            this.gameObject.transform.parent = null;
            this.tag = "End";
        }
    }
}
