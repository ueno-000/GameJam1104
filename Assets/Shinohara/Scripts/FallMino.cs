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
    
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject go = GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]];
            go.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}
