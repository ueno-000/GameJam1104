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
    /// <summary>操作中のミノのobject(各マス)</summary>
    GameObject[] _mino = new GameObject[4];
    /// <summary>true = 操作中のミノのが落下して来る</summary>
    static bool _isMoveing = true;
    /// <summary>経過時間が入る</summary>
    float _time = 0f;
    /// <summary>true = 操作中のミノのが落下して来る</summary>
    public static bool IsMoveing { get => _isMoveing; set => _isMoveing = value; }

    void Start()
    {
        
    }

   
    void Update()
    {
        if (_isMoveing && GameManager.CurrentBlocks[0, 0] != 1 && GameManager.CurrentBlocks[1, 0] != 1 && GameManager.CurrentBlocks[2, 0] != 1 && GameManager.CurrentBlocks[3, 0] != 1)
        {
            FallMinoFunc();
        }
        else if (GameManager.CurrentBlocks[0, 0] == 1 || GameManager.CurrentBlocks[1, 0] == 1 || GameManager.CurrentBlocks[2, 0] == 1 || GameManager.CurrentBlocks[3, 0] == 1)
        {
            _isMoveing = false;
        }

        //Debug.Log(GameManager.CurrentBlocks[0, 0]);
        //Debug.Log(GameManager.CurrentBlocks[0, 0]);

        //MinoLimit();

        GameManager.CurrentBlocks[0, 0] = Mathf.Clamp(GameManager.CurrentBlocks[0, 0], 0, 20);
        GameManager.CurrentBlocks[1, 0] = Mathf.Clamp(GameManager.CurrentBlocks[1, 0], 0, 20);
        GameManager.CurrentBlocks[2, 0] = Mathf.Clamp(GameManager.CurrentBlocks[2, 0], 0, 20);
        GameManager.CurrentBlocks[3, 0] = Mathf.Clamp(GameManager.CurrentBlocks[3, 0], 0, 20);


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

            GameManager.CurrentBlocks[0, 0] -= 1;
            GameManager.CurrentBlocks[1, 0] -= 1;
            GameManager.CurrentBlocks[2, 0] -= 1;
            GameManager.CurrentBlocks[3, 0] -= 1;

            _mino[0] = GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]];
            _mino[1] = GameManager.Blocks[GameManager.CurrentBlocks[1, 0], GameManager.CurrentBlocks[1, 1]];
            _mino[2] = GameManager.Blocks[GameManager.CurrentBlocks[2, 0], GameManager.CurrentBlocks[2, 1]];
            _mino[3] = GameManager.Blocks[GameManager.CurrentBlocks[3, 0], GameManager.CurrentBlocks[3, 1]];

            Array.ForEach(_mino, g => g.GetComponent<SpriteRenderer>().color = ChangeColor(GameManager.SelectColorName));
        }

        
    }

    /// <summary>
    /// 操作中のミノ色を変える
    /// </summary>
    /// <param name="colorName">色の名前</param>
    /// <returns></returns>
    public Color ChangeColor(string colorName)
    {
        Color minoColor = default;
        switch (colorName)
        {
            case "Red":
                minoColor = Color.red;
                break;
            case "Blue":
                minoColor = Color.blue;
                break;
            case "Green":
                minoColor = Color.green;
                break;
            case "Purple":
                minoColor = new Color(0.5f, 0, 1f);
                break;
            case "Orange":
                minoColor = new Color(1f, 0.5f, 0);
                break;
            case "Yellow":
                minoColor = Color.yellow;
                break;
            case "LigthBlue":
                minoColor = new Color(0, 0.9f, 1);
                break;
        }
        return minoColor;
    }
}

 //&& GameManager.CurrentBlocks[0, 1] != 9 && GameManager.CurrentBlocks[1, 1] != 9 && GameManager.CurrentBlocks[2, 1] != 9 && GameManager.CurrentBlocks[3, 1] != 9