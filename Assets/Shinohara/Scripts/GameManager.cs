using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

/// <summary>
/// ゲーム開始から終了まで管理する
///スクリプト
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary> ブロックの場所 最初の添え字が行,2番目が列</summary>
    static GameObject[,] _blocks = new GameObject[20, 10];
    /// <summary>操作中ミノの各マス</summary>
    static int[,] _currentBlocks = new int[4, 2];
    /// <summary>土台となる列</summary>
    [SerializeField] GameObject _blockLine = default;
    [Tooltip("一番下の列の高さの位置 プレハブのLineの大きさも関係して来る")]
    /// <summary>一番下の列の高さの位置</summary>
    [SerializeField] float _y = -1f;
    [Tooltip("次の列が生成される場所 指定した数字分上に列が作られる 隙間のないように調整する")]
    /// <summary>次の列が生成される場所 指定した数字分上に列が作られる</summary>
    [SerializeField] float _addHeight = 0;
    
    /// <summary>生成したミノ（操作中ミノ）</summary>
    MinoColor _selectMino = MinoColor.Red;
    /// <summary>生成されたミノ色の名前</summary>
    static string _selectColorName = "";
    /// <summary>操作中ミノの各マス</summary>
    public static int[,] CurrentBlocks { get => _currentBlocks; set => _currentBlocks = value; }
    /// <summary> ブロックの場所 最初の添え字が行,2番目が列</summary>
    public static GameObject[,] Blocks { get => _blocks; set => _blocks = value; }
    /// <summary>生成されたミノ色の名前</summary>
    public static string SelectColorName { get => _selectColorName; set => _selectColorName = value; }

    void Start()
    {
        //20行列作りたいので20回まわす 土台
        for (var i = 0; i < 20; i++)
        {
            var go = Instantiate(_blockLine, new Vector3(0, _y, 0), Quaternion.identity);
            GetBlock(go, i);
            _y += _addHeight;

        }
        SelectMino();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }   
    }

    /// <summary>
    /// 生成したlineから一マスを取得して配列に代入する関数
    /// </summary>
    /// <param name="line">生成した列</param>
    /// <param name="y">行数</param>
    private void GetBlock(GameObject line, int y)
    {
        for (int x = 0; x < 10; x ++)
        {
            var block = line.transform.GetChild(x).gameObject;
            _blocks[y, x] = block;
        }
    }

    /// <summary>
    /// ランダムでミノを生成　_blocks[19, 5]が各ミノの一番上のブロックになる
    /// </summary>
    public void SelectMino()
    {
        //int number = Random.Range(0, 7);
       // _selectMino = MinoColor.Red + number;

        switch (_selectMino)
        {
            case MinoColor.Red:
                _currentBlocks[0, 0] = 19;
                _currentBlocks[0, 1] = 5;
                _currentBlocks[1, 0] = 18;
                _currentBlocks[1, 1] = 5;
                _currentBlocks[2, 0] = 18;
                _currentBlocks[2, 1] = 6;
                _currentBlocks[3, 0] = 17;
                _currentBlocks[3, 1] = 6;
                _blocks[19, 5].GetComponent<SpriteRenderer>().color = Color.red;
                _blocks[18, 5].GetComponent<SpriteRenderer>().color = Color.red;
                _blocks[18, 6].GetComponent<SpriteRenderer>().color = Color.red;
                _blocks[17, 6].GetComponent<SpriteRenderer>().color = Color.red;
                _selectColorName = "Red";
                break;
            case MinoColor.Blue:
                _blocks[19, 5].GetComponent<SpriteRenderer>().color = Color.blue;
                _blocks[18, 5].GetComponent<SpriteRenderer>().color = Color.blue;
                _blocks[17, 5].GetComponent<SpriteRenderer>().color = Color.blue;
                _blocks[17, 6].GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case MinoColor.Green:
                _blocks[19, 5].GetComponent<SpriteRenderer>().color = Color.green;
                _blocks[18, 5].GetComponent<SpriteRenderer>().color = Color.green;
                _blocks[18, 6].GetComponent<SpriteRenderer>().color = Color.green;
                _blocks[17, 6].GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case MinoColor.Purple:
                _blocks[19, 5].GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 1f);
                _blocks[18, 4].GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 1f);
                _blocks[18, 5].GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 1f);
                _blocks[18, 6].GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 1f);
                break;
            case MinoColor.Orange:
                _blocks[19, 5].GetComponent<SpriteRenderer>().color = new Color(1f ,0.5f, 0);
                _blocks[18, 5].GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0);
                _blocks[17, 5].GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0);
                _blocks[17, 4].GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0);
                break;
            case MinoColor.Yellow:
                _blocks[19, 5].GetComponent<SpriteRenderer>().color = Color.yellow;
                _blocks[19, 6].GetComponent<SpriteRenderer>().color = Color.yellow;
                _blocks[18, 5].GetComponent<SpriteRenderer>().color = Color.yellow;
                _blocks[18, 6].GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case MinoColor.LigthBlue:
                _blocks[19, 5].GetComponent<SpriteRenderer>().color = new Color(0, 0.9f, 1);
                _blocks[18, 5].GetComponent<SpriteRenderer>().color = new Color(0, 0.9f, 1);
                _blocks[17, 5].GetComponent<SpriteRenderer>().color = new Color(0, 0.9f, 1);
                _blocks[16, 5].GetComponent<SpriteRenderer>().color = new Color(0, 0.9f, 1);
                break;
        }
    }
}

/// <summary>
/// この中からランダムで選択しその色のミノ
/// を生成する
/// </summary>
public enum MinoColor
{
    Red,
    Blue,
    Green,
    Purple,
    Orange,
    Yellow,
    LigthBlue
}
