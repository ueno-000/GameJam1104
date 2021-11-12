using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// 生成したミノを落下
/// させるスクリプト
/// </summary>
public class FallMino : MonoBehaviour
{
    /// <summary>minoを落とす間隔</summary>
    [SerializeField] float _fallInterval = 0;

    GameObject[] _mino = new GameObject[4];

    float _time = 0f;
    void Start()
    {
        
    }

   
    void Update()
    {
        FallMinoFunc();
    }

    /// <summary>
    /// minoを落とす関数
    /// </summary>
    public void FallMinoFunc()
    {
        _time += Time.deltaTime;
       
        

        if (_time >= _fallInterval)
        {
            _time = 0;
           
            _mino[0] = GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]];
            _mino[1] = GameManager.Blocks[GameManager.CurrentBlocks[1, 0], GameManager.CurrentBlocks[1, 1]];
            _mino[2] = GameManager.Blocks[GameManager.CurrentBlocks[2, 0], GameManager.CurrentBlocks[2, 1]];
            _mino[3] = GameManager.Blocks[GameManager.CurrentBlocks[3, 0], GameManager.CurrentBlocks[3, 1]];

            Array.ForEach(_mino, g => g.GetComponent<SpriteRenderer>().color = Color.white);

            GameManager.CurrentBlocks[0, 0] += -1;
            GameManager.CurrentBlocks[1, 0] += -1;
            GameManager.CurrentBlocks[2, 0] += -1;
            GameManager.CurrentBlocks[3, 0] += -1;

            _mino[0] = GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]];
            _mino[1] = GameManager.Blocks[GameManager.CurrentBlocks[1, 0], GameManager.CurrentBlocks[1, 1]];
            _mino[2] = GameManager.Blocks[GameManager.CurrentBlocks[2, 0], GameManager.CurrentBlocks[2, 1]];
            _mino[3] = GameManager.Blocks[GameManager.CurrentBlocks[3, 0], GameManager.CurrentBlocks[3, 1]];

            Array.ForEach(_mino, g => g.GetComponent<SpriteRenderer>().color = Color.red);

        }
    }
}
