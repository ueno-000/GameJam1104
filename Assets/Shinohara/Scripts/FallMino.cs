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
    bool _isMove = true;
    float _time = 0f;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (_isMove)
        {
            FallMinoFunc();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _isMove = false;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            _isMove = true;
        }
        
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

            GameManager.CurrentBlocks[0, 0] = Mathf.Clamp(GameManager.CurrentBlocks[0, 0], 0, 20);
            GameManager.CurrentBlocks[1, 0] = Mathf.Clamp(GameManager.CurrentBlocks[1, 0], 0, 20);
            GameManager.CurrentBlocks[2, 0] = Mathf.Clamp(GameManager.CurrentBlocks[2, 0], 0, 20);
            GameManager.CurrentBlocks[3, 0] = Mathf.Clamp(GameManager.CurrentBlocks[3, 0], 0, 20);
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
