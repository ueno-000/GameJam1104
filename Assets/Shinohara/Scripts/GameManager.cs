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
    GameObject[,] _blocks = new GameObject[20, 10];
    /// <summary>土台となる列</summary>
    [SerializeField] GameObject _blockLine = default;
    [Tooltip("一番下の列の高さの位置 プレハブのLineの大きさも関係して来る")]
    /// <summary>一番下の列の高さの位置</summary>
    [SerializeField] float _y = -1f;
    [Tooltip("次の列が生成される場所 指定した数字分上に列が作られる 隙間のないように調整する")]
    /// <summary>次の列が生成される場所 指定した数字分上に列が作られる</summary>
    [SerializeField] float _addHeight = 0;

    MinoColor _selectMino = default;
    //test用の数字
    [SerializeField] int x = 0;
    [SerializeField] int y = 0;
    // Start is called before the first frame update
    void Start()
    {
        //20行列作りたいので20回まわす 土台
        for (var i = 0; i < 20; i++)
        {
           var go = Instantiate(_blockLine, new Vector3(0, _y, 0), Quaternion.identity);
            GetBlock(go, i);
            _y += _addHeight;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectMino();
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

    private void SelectMino()
    {
        int number = Random.Range(0, 7);
        _selectMino = MinoColor.Red + number;
        Debug.Log(_selectMino);
        switch (_selectMino)
        {
            case MinoColor.Red:
                _blocks[19, 5].GetComponent<SpriteRenderer>().color = Color.red;
                _blocks[18, 4].GetComponent<SpriteRenderer>().color = Color.red;
                _blocks[18, 5].GetComponent<SpriteRenderer>().color = Color.red;
                _blocks[17, 4].GetComponent<SpriteRenderer>().color = Color.red;
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
