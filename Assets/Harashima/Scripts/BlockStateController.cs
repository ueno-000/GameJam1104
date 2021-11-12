using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class BlockStateController : MonoBehaviour
{
    float _time = 0f;
    GameObject[] _blocks = new GameObject[4];
    Color _colorcode;

    //string _color;
    //生成後から着地するまでのミノの状態を管理するenum
    enum BlockState
    {
        Start,
        Fall,
        Landing,
        End
    }

    BlockState blockState;
    void Start()
    {
        blockState = BlockState.Start;
        //CheckBlock();
    }
    void Update()
    {
        //_time += Time.deltaTime;
        CheckBlock();
    }

    //ミノの状態に応じて処理を行う関数
    void CheckBlock()
    {
        GameManager gm = GetComponent<GameManager>();
        string _color;
        switch (blockState)
        {
            case BlockState.Start:
                //ミノを生成する関数を呼びたい
                //gm.SelectMino();
                //ミノの種類を取得？

                blockState = BlockState.Fall;
                break;

            case BlockState.Fall:
                //数秒おきに落下していく関数呼ぶ
                //落下中に移動キーが押されたら背景の色変化させる
                //落下移動
                //ここで下のブロックの判定と一番下にいるかの判定
                _color = GameManager.SelectColorName;
                if (_color == "Red")
                {
                    _colorcode = Color.red;
                }
                else if (_color == "Blue")
                {
                    _colorcode = Color.blue;
                }
                else if (_color =="Green")
                {

                }
                else if (_color == "Purple")
                {
                    _colorcode = Color.blue;
                }
                else if (_color == "Orange")
                {

                }
                else if (_color == "Yellow")
                {
                    _colorcode = Color.blue;
                }
                else if (_color == "LigthBlue")
                {

                }


                if (Input.GetKeyDown(KeyCode.S))
                {

                }

                //左右移動
                if (Input.GetKeyDown(KeyCode.A))
                {
                    Debug.Log("Aおされた");
                    if (_color == "Red")
                    {
                        _blocks[0] = GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]];
                        _blocks[1] = GameManager.Blocks[GameManager.CurrentBlocks[1, 0], GameManager.CurrentBlocks[1, 1]];
                        _blocks[2] = GameManager.Blocks[GameManager.CurrentBlocks[2, 0], GameManager.CurrentBlocks[2, 1]];
                        _blocks[3] = GameManager.Blocks[GameManager.CurrentBlocks[3, 0], GameManager.CurrentBlocks[3, 1]];

                        Array.ForEach(_blocks, g => g.GetComponent<SpriteRenderer>().color = Color.white);

                        GameManager.CurrentBlocks[0, 1] -= 1;
                        GameManager.CurrentBlocks[1, 1] -= 1;
                        GameManager.CurrentBlocks[2, 1] -= 1;
                        GameManager.CurrentBlocks[3, 1] -= 1;

                        _blocks[0] = GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]];
                        _blocks[1] = GameManager.Blocks[GameManager.CurrentBlocks[1, 0], GameManager.CurrentBlocks[1, 1]];
                        _blocks[2] = GameManager.Blocks[GameManager.CurrentBlocks[2, 0], GameManager.CurrentBlocks[2, 1]];
                        _blocks[3] = GameManager.Blocks[GameManager.CurrentBlocks[3, 0], GameManager.CurrentBlocks[3, 1]];

                        _blocks[0].GetComponent<SpriteRenderer>().color = Color.red;
                        _blocks[1].GetComponent<SpriteRenderer>().color = Color.red;
                        _blocks[2].GetComponent<SpriteRenderer>().color = Color.red;
                        _blocks[3].GetComponent<SpriteRenderer>().color = Color.red;

                        Array.ForEach(_blocks, g => g.GetComponent<SpriteRenderer>().color = Color.red);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    _blocks[0] = GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]];
                    _blocks[1] = GameManager.Blocks[GameManager.CurrentBlocks[1, 0], GameManager.CurrentBlocks[1, 1]];
                    _blocks[2] = GameManager.Blocks[GameManager.CurrentBlocks[2, 0], GameManager.CurrentBlocks[2, 1]];
                    _blocks[3] = GameManager.Blocks[GameManager.CurrentBlocks[3, 0], GameManager.CurrentBlocks[3, 1]];

                    Array.ForEach(_blocks, g => g.GetComponent<SpriteRenderer>().color = Color.white);

                    GameManager.CurrentBlocks[0, 1] += 1;
                    GameManager.CurrentBlocks[1, 1] += 1;
                    GameManager.CurrentBlocks[2, 1] += 1;
                    GameManager.CurrentBlocks[3, 1] += 1;

                    _blocks[0] = GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]];
                    _blocks[1] = GameManager.Blocks[GameManager.CurrentBlocks[1, 0], GameManager.CurrentBlocks[1, 1]];
                    _blocks[2] = GameManager.Blocks[GameManager.CurrentBlocks[2, 0], GameManager.CurrentBlocks[2, 1]];
                    _blocks[3] = GameManager.Blocks[GameManager.CurrentBlocks[3, 0], GameManager.CurrentBlocks[3, 1]];

                    _blocks[0].GetComponent<SpriteRenderer>().color = Color.red;
                    _blocks[1].GetComponent<SpriteRenderer>().color = Color.red;
                    _blocks[2].GetComponent<SpriteRenderer>().color = Color.red;
                    _blocks[3].GetComponent<SpriteRenderer>().color = Color.red;

                    Array.ForEach(_blocks, g => g.GetComponent<SpriteRenderer>().color = Color.red);
                }

                //回転ボタンが押された際に背景色の変更、下面の変更
                if (Input.GetButtonDown("Fire1"))
                {
                    _blocks[0] = GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]];
                    _blocks[1] = GameManager.Blocks[GameManager.CurrentBlocks[1, 0], GameManager.CurrentBlocks[1, 1]];
                    _blocks[2] = GameManager.Blocks[GameManager.CurrentBlocks[2, 0], GameManager.CurrentBlocks[2, 1]];
                    _blocks[3] = GameManager.Blocks[GameManager.CurrentBlocks[3, 0], GameManager.CurrentBlocks[3, 1]];

                    Array.ForEach(_blocks, g => g.GetComponent<SpriteRenderer>().color = Color.white);

                    GameManager.CurrentBlocks[0, 1] += 1;
                    GameManager.CurrentBlocks[1, 1] += 1;
                    GameManager.CurrentBlocks[2, 1] += 1;
                    GameManager.CurrentBlocks[3, 1] += 1;

                    _blocks[0] = GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]];
                    _blocks[1] = GameManager.Blocks[GameManager.CurrentBlocks[1, 0], GameManager.CurrentBlocks[1, 1]];
                    _blocks[2] = GameManager.Blocks[GameManager.CurrentBlocks[2, 0], GameManager.CurrentBlocks[2, 1]];
                    _blocks[3] = GameManager.Blocks[GameManager.CurrentBlocks[3, 0], GameManager.CurrentBlocks[3, 1]];

                    _blocks[0].GetComponent<SpriteRenderer>().color = Color.red;
                    _blocks[1].GetComponent<SpriteRenderer>().color = Color.red;
                    _blocks[2].GetComponent<SpriteRenderer>().color = Color.red;
                    _blocks[3].GetComponent<SpriteRenderer>().color = Color.red;

                    Array.ForEach(_blocks, g => g.GetComponent<SpriteRenderer>().color = Color.red);
                }
                //落下しきったことを判定してLandingへStateを変更する、下面の判定
                break;

            case BlockState.Landing:
                //
                //tag変更
                //FallMInoのBool型をFalseに
                //ミノがはみ出したらEndへ、それ以外はStartへ
                //２００回回す、tagの数が１０個だったら消す、それ以外のタグが１個でもあったらbreak

                break;

            case BlockState.End:
                break;
        }

    }

    // Update is called once per frame
}
