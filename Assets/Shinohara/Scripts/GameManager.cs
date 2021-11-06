using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
            _blocks[y, x].GetComponent<SpriteRenderer>().color = Color.red;
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
}
