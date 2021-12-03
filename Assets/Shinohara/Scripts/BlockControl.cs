using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class BlockControl : MonoBehaviour
{
    float _time = 0f;
    GameObject[] _blocks = new GameObject[4];
    Color _colorcode;
    string _currentColoer = "";
    bool _aroundFlag = true;
    bool _isLeftSide = true;
    bool _isRightSide = true;
    bool _leftSideFixed = false;
    bool _rightSideFixd = false;
    [SerializeField] int _rotate = 1;

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
        _isLeftSide = IsLeftSide();
        _isRightSide = IsRightSide();
        CheckSide();
        CheckUnder();
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
                gm.SelectMino();
                _aroundFlag = true;
                blockState = BlockState.Fall;
                break;

            case BlockState.Fall:
                //数秒おきに落下していく関数呼ぶ
                //落下中に移動キーが押されたら背景の色変化させる
                //落下移動
                //ここで下のブロックの判定と一番下にいるかの判定
                _color = GameManager.SelectColorName;
                _currentColoer = _color;
                if (_color == "Red")
                {
                    _colorcode = Color.red;
                }
                else if (_color == "Blue")
                {
                    _colorcode = Color.blue;
                }
                else if (_color == "Green")
                {
                    _colorcode = Color.green;
                }
                else if (_color == "Purple")
                {
                    _colorcode = new Color(0.5f, 0, 1f);
                }
                else if (_color == "Orange")
                {
                    _colorcode = new Color(1f, 0.5f, 0);
                }
                else if (_color == "Yellow")
                {
                    _colorcode = Color.yellow;
                }
                else if (_color == "LigthBlue")
                {
                    _colorcode = new Color(0, 0.9f, 1);
                }


                if (Input.GetKeyDown(KeyCode.S))
                {

                }

                //左右移動
                if (Input.GetKeyDown(KeyCode.A) && _isLeftSide)
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

                    _blocks[0].GetComponent<SpriteRenderer>().color = _colorcode;
                    _blocks[1].GetComponent<SpriteRenderer>().color = _colorcode;
                    _blocks[2].GetComponent<SpriteRenderer>().color = _colorcode;
                    _blocks[3].GetComponent<SpriteRenderer>().color = _colorcode;

                    Array.ForEach(_blocks, g => g.GetComponent<SpriteRenderer>().color = _colorcode);

                }
                else if (Input.GetKeyDown(KeyCode.D) && _isRightSide)
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

                    _blocks[0].GetComponent<SpriteRenderer>().color = _colorcode;
                    _blocks[1].GetComponent<SpriteRenderer>().color = _colorcode;
                    _blocks[2].GetComponent<SpriteRenderer>().color = _colorcode;
                    _blocks[3].GetComponent<SpriteRenderer>().color = _colorcode;

                    Array.ForEach(_blocks, g => g.GetComponent<SpriteRenderer>().color = _colorcode);
                }

                //回転ボタンが押された際に背景色の変更、rotateの変更
                //３ブロック以上長いミノは他のブロックと接地していても例外的に回転できる
                if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
                {

                    _blocks[0] = GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]];
                    _blocks[1] = GameManager.Blocks[GameManager.CurrentBlocks[1, 0], GameManager.CurrentBlocks[1, 1]];
                    _blocks[2] = GameManager.Blocks[GameManager.CurrentBlocks[2, 0], GameManager.CurrentBlocks[2, 1]];
                    _blocks[3] = GameManager.Blocks[GameManager.CurrentBlocks[3, 0], GameManager.CurrentBlocks[3, 1]];

                    Array.ForEach(_blocks, g => g.GetComponent<SpriteRenderer>().color = Color.white);
                    if (_color == "Red")
                    {
                        if (_rotate == 1)
                        {
                            GameManager.CurrentBlocks[0, 0] -= 1;
                            GameManager.CurrentBlocks[0, 1] -= 1;
                            GameManager.CurrentBlocks[2, 0] += 1;
                            GameManager.CurrentBlocks[2, 1] -= 1;
                            GameManager.CurrentBlocks[3, 0] += 2;
                            _rotate = 2;
                        }
                        else if (_rotate == 2)
                        {
                            GameManager.CurrentBlocks[0, 0] -= 1;
                            GameManager.CurrentBlocks[0, 1] += 1;
                            GameManager.CurrentBlocks[2, 0] -= 1;
                            GameManager.CurrentBlocks[2, 1] -= 1;
                            GameManager.CurrentBlocks[3, 1] -= 2;
                            _rotate = 3;
                        }
                        else if (_rotate == 3)
                        {
                            GameManager.CurrentBlocks[0, 0] += 1;
                            GameManager.CurrentBlocks[0, 1] += 1;
                            GameManager.CurrentBlocks[2, 0] -= 1;
                            GameManager.CurrentBlocks[2, 1] += 1;
                            GameManager.CurrentBlocks[3, 0] -= 2;
                            _rotate = 4;
                        }
                        else if (_rotate == 4)
                        {
                            GameManager.CurrentBlocks[0, 0] += 1;
                            GameManager.CurrentBlocks[0, 1] -= 1;
                            GameManager.CurrentBlocks[2, 0] += 1;
                            GameManager.CurrentBlocks[2, 1] += 1;
                            GameManager.CurrentBlocks[3, 1] += 2;
                            _rotate = 1;
                        }
                    }
                    else if (_color == "Blue")
                    {
                        if (_rotate == 1)
                        {
                            GameManager.CurrentBlocks[0, 0] -= 2;
                            GameManager.CurrentBlocks[0, 1] -= 2;
                            GameManager.CurrentBlocks[1, 0] -= 1;
                            GameManager.CurrentBlocks[1, 1] -= 1;
                            GameManager.CurrentBlocks[3, 0] += 1;
                            GameManager.CurrentBlocks[3, 1] -= 1;
                            _rotate = 2;
                        }
                        else if (_rotate == 2)
                        {
                            GameManager.CurrentBlocks[0, 0] -= 2;
                            GameManager.CurrentBlocks[0, 1] += 2;
                            GameManager.CurrentBlocks[1, 0] -= 1;
                            GameManager.CurrentBlocks[1, 1] += 1;
                            GameManager.CurrentBlocks[3, 0] -= 1;
                            GameManager.CurrentBlocks[3, 1] -= 1;
                            _rotate = 3;
                        }
                        else if (_rotate == 3)
                        {
                            GameManager.CurrentBlocks[0, 0] += 2;
                            GameManager.CurrentBlocks[0, 1] += 2;
                            GameManager.CurrentBlocks[1, 0] += 1;
                            GameManager.CurrentBlocks[1, 1] += 1;
                            GameManager.CurrentBlocks[3, 0] -= 1;
                            GameManager.CurrentBlocks[3, 1] += 1;
                            _rotate = 4;
                        }
                        else if (_rotate == 4)
                        {
                            GameManager.CurrentBlocks[0, 0] += 2;
                            GameManager.CurrentBlocks[0, 1] -= 2;
                            GameManager.CurrentBlocks[1, 0] += 1;
                            GameManager.CurrentBlocks[1, 1] -= 1;
                            GameManager.CurrentBlocks[3, 0] += 1;
                            GameManager.CurrentBlocks[3, 1] += 1;
                            _rotate = 1;
                        }
                    }
                    else if (_color == "Green")
                    {
                        if (_rotate == 1)
                        {
                            GameManager.CurrentBlocks[0, 1] -= 2;
                            GameManager.CurrentBlocks[1, 0] += 1;
                            GameManager.CurrentBlocks[1, 1] -= 1;
                            GameManager.CurrentBlocks[3, 0] += 1;
                            GameManager.CurrentBlocks[3, 1] += 1;
                            _rotate = 2;
                        }
                        else if (_rotate == 2)
                        {
                            GameManager.CurrentBlocks[0, 0] -= 2;
                            GameManager.CurrentBlocks[1, 0] -= 1;
                            GameManager.CurrentBlocks[1, 1] -= 1;
                            GameManager.CurrentBlocks[3, 0] += 1;
                            GameManager.CurrentBlocks[3, 1] -= 1;
                            _rotate = 3;
                        }
                        else if (_rotate == 3)
                        {
                            GameManager.CurrentBlocks[0, 1] += 2;
                            GameManager.CurrentBlocks[1, 0] -= 1;
                            GameManager.CurrentBlocks[1, 1] += 1;
                            GameManager.CurrentBlocks[3, 0] -= 1;
                            GameManager.CurrentBlocks[3, 1] -= 1;
                            _rotate = 4;
                        }
                        else if (_rotate == 4)
                        {
                            GameManager.CurrentBlocks[0, 0] += 2;
                            GameManager.CurrentBlocks[1, 0] += 1;
                            GameManager.CurrentBlocks[1, 1] += 1;
                            GameManager.CurrentBlocks[3, 0] -= 1;
                            GameManager.CurrentBlocks[3, 1] += 1;
                            _rotate = 1;
                        }
                    }
                    else if (_color == "Purple")
                    {
                        if (_rotate == 1)
                        {
                            GameManager.CurrentBlocks[0, 0] -= 1;
                            GameManager.CurrentBlocks[0, 1] -= 1;
                            GameManager.CurrentBlocks[1, 0] -= 1;
                            GameManager.CurrentBlocks[1, 1] += 1;
                            GameManager.CurrentBlocks[3, 0] += 1;
                            GameManager.CurrentBlocks[3, 1] -= 1;
                            _rotate = 2;
                        }
                        else if (_rotate == 2)
                        {
                            GameManager.CurrentBlocks[0, 0] -= 1;
                            GameManager.CurrentBlocks[0, 1] += 1;
                            GameManager.CurrentBlocks[1, 0] += 1;
                            GameManager.CurrentBlocks[1, 1] += 1;
                            GameManager.CurrentBlocks[3, 0] -= 1;
                            GameManager.CurrentBlocks[3, 1] -= 1;
                            _rotate = 3;
                        }
                        else if (_rotate == 3)
                        {
                            GameManager.CurrentBlocks[0, 0] += 1;
                            GameManager.CurrentBlocks[0, 1] += 1;
                            GameManager.CurrentBlocks[1, 0] += 1;
                            GameManager.CurrentBlocks[1, 1] -= 1;
                            GameManager.CurrentBlocks[3, 0] -= 1;
                            GameManager.CurrentBlocks[3, 1] += 1;
                            _rotate = 4;
                        }
                        else if (_rotate == 4)
                        {
                            GameManager.CurrentBlocks[0, 0] += 1;
                            GameManager.CurrentBlocks[0, 1] -= 1;
                            GameManager.CurrentBlocks[1, 0] -= 1;
                            GameManager.CurrentBlocks[1, 1] -= 1;
                            GameManager.CurrentBlocks[3, 0] += 1;
                            GameManager.CurrentBlocks[3, 1] += 1;
                            _rotate = 1;
                        }
                    }
                    else if (_color == "Orange")
                    {
                        if (_rotate == 1)
                        {
                            GameManager.CurrentBlocks[0, 0] -= 2;
                            GameManager.CurrentBlocks[0, 1] -= 2;
                            GameManager.CurrentBlocks[1, 0] -= 1;
                            GameManager.CurrentBlocks[1, 1] -= 1;
                            GameManager.CurrentBlocks[3, 0] -= 1;
                            GameManager.CurrentBlocks[3, 1] += 1;
                            _rotate = 2;
                        }
                        else if (_rotate == 2)
                        {
                            GameManager.CurrentBlocks[0, 0] -= 2;
                            GameManager.CurrentBlocks[0, 1] += 2;
                            GameManager.CurrentBlocks[1, 0] -= 1;
                            GameManager.CurrentBlocks[1, 1] += 1;
                            GameManager.CurrentBlocks[3, 0] += 1;
                            GameManager.CurrentBlocks[3, 1] += 1;
                            _rotate = 3;
                        }
                        else if (_rotate == 3)
                        {
                            GameManager.CurrentBlocks[0, 0] += 2;
                            GameManager.CurrentBlocks[0, 1] += 2;
                            GameManager.CurrentBlocks[1, 0] += 1;
                            GameManager.CurrentBlocks[1, 1] += 1;
                            GameManager.CurrentBlocks[3, 0] += 1;
                            GameManager.CurrentBlocks[3, 1] -= 1;
                            _rotate = 4;
                        }
                        else if (_rotate == 4)
                        {
                            GameManager.CurrentBlocks[0, 0] += 2;
                            GameManager.CurrentBlocks[0, 1] -= 2;
                            GameManager.CurrentBlocks[1, 0] += 1;
                            GameManager.CurrentBlocks[1, 1] -= 1;
                            GameManager.CurrentBlocks[3, 0] -= 1;
                            GameManager.CurrentBlocks[3, 1] -= 1;
                            _rotate = 1;
                        }
                    }

                    else if (_color == "LigthBlue")
                    {
                        if (_rotate == 1)
                        {
                            GameManager.CurrentBlocks[0, 0] -= 2;
                            GameManager.CurrentBlocks[0, 1] -= 2;
                            GameManager.CurrentBlocks[1, 0] -= 1;
                            GameManager.CurrentBlocks[1, 1] -= 1;
                            GameManager.CurrentBlocks[3, 0] += 1;
                            GameManager.CurrentBlocks[3, 1] += 1;
                            _rotate = 2;
                        }
                        else if (_rotate == 2)
                        {
                            GameManager.CurrentBlocks[0, 0] -= 2;
                            GameManager.CurrentBlocks[0, 1] += 2;
                            GameManager.CurrentBlocks[1, 0] -= 1;
                            GameManager.CurrentBlocks[1, 1] += 1;
                            GameManager.CurrentBlocks[3, 0] += 1;
                            GameManager.CurrentBlocks[3, 1] -= 1;
                            _rotate = 3;
                        }
                        else if (_rotate == 3)
                        {
                            GameManager.CurrentBlocks[0, 0] += 2;
                            GameManager.CurrentBlocks[0, 1] += 2;
                            GameManager.CurrentBlocks[1, 0] += 1;
                            GameManager.CurrentBlocks[1, 1] += 1;
                            GameManager.CurrentBlocks[3, 0] -= 1;
                            GameManager.CurrentBlocks[3, 1] -= 1;
                            _rotate = 4;
                        }
                        else if (_rotate == 4)
                        {
                            GameManager.CurrentBlocks[0, 0] += 2;
                            GameManager.CurrentBlocks[0, 1] -= 2;
                            GameManager.CurrentBlocks[1, 0] += 1;
                            GameManager.CurrentBlocks[1, 1] -= 1;
                            GameManager.CurrentBlocks[3, 0] -= 1;
                            GameManager.CurrentBlocks[3, 1] += 1;
                            _rotate = 1;
                        }


                    }

                    _blocks[0] = GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]];
                    _blocks[1] = GameManager.Blocks[GameManager.CurrentBlocks[1, 0], GameManager.CurrentBlocks[1, 1]];
                    _blocks[2] = GameManager.Blocks[GameManager.CurrentBlocks[2, 0], GameManager.CurrentBlocks[2, 1]];
                    _blocks[3] = GameManager.Blocks[GameManager.CurrentBlocks[3, 0], GameManager.CurrentBlocks[3, 1]];

                    _blocks[0].GetComponent<SpriteRenderer>().color = _colorcode;
                    _blocks[1].GetComponent<SpriteRenderer>().color = _colorcode;
                    _blocks[2].GetComponent<SpriteRenderer>().color = _colorcode;
                    _blocks[3].GetComponent<SpriteRenderer>().color = _colorcode;

                    Array.ForEach(_blocks, g => g.GetComponent<SpriteRenderer>().color = _colorcode);


                }
                //落下しきったことを判定してLandingへStateを変更する、下面の判定
                if (_color == "Red")
                {
                    if (GameManager.CurrentBlocks[0, 0] == 0 || GameManager.CurrentBlocks[1, 0] == 0 || GameManager.CurrentBlocks[2, 0] == 0 || GameManager.CurrentBlocks[3, 0] == 0)
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 1 && GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 2 && (GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]].gameObject.tag == "End"))
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 3 && GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 4 && (GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End"))
                    {
                        blockState = BlockState.Landing;
                    }
                }
                else if (_color == "Blue")
                {
                    if (GameManager.CurrentBlocks[0, 0] == 0 || GameManager.CurrentBlocks[1, 0] == 0 || GameManager.CurrentBlocks[2, 0] == 0 || GameManager.CurrentBlocks[3, 0] == 0)
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 1 && (GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End"))
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 2 && (GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]].gameObject.tag == "End"))
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 3 && GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 4 && GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                }
                else if (_color == "Green")
                {
                    if (GameManager.CurrentBlocks[0, 0] == 0 || GameManager.CurrentBlocks[1, 0] == 0 || GameManager.CurrentBlocks[2, 0] == 0 || GameManager.CurrentBlocks[3, 0] == 0)
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 1 && GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 2 && (GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End"))
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 3 && GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 4 && (GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]].gameObject.tag == "End"))
                    {
                        blockState = BlockState.Landing;
                    }
                }
                else if (_color == "Purple")
                {
                    if (GameManager.CurrentBlocks[0, 0] == 0 || GameManager.CurrentBlocks[1, 0] == 0 || GameManager.CurrentBlocks[2, 0] == 0 || GameManager.CurrentBlocks[3, 0] == 0)
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 1 && (GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End"))
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 2 && GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 3 && GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 4 && GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                }
                else if (_color == "Orange")
                {
                    if (GameManager.CurrentBlocks[0, 0] == 0 || GameManager.CurrentBlocks[1, 0] == 0 || GameManager.CurrentBlocks[2, 0] == 0 || GameManager.CurrentBlocks[3, 0] == 0)
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 1 && GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 2 && GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 3 && GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 4 && (GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]].gameObject.tag == "End"))
                    {
                        blockState = BlockState.Landing;
                    }
                }
                else if (_color == "Yellow")
                {
                    if (GameManager.CurrentBlocks[0, 0] == 0 || GameManager.CurrentBlocks[1, 0] == 0 || GameManager.CurrentBlocks[2, 0] == 0 || GameManager.CurrentBlocks[3, 0] == 0)
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                }
                else if (_color == "LigthBlue")
                {
                    if (GameManager.CurrentBlocks[0, 0] == 0 || GameManager.CurrentBlocks[1, 0] == 0 || GameManager.CurrentBlocks[2, 0] == 0 || GameManager.CurrentBlocks[3, 0] == 0)
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 1 && GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if ((_rotate == 2 || _rotate == 4) && (GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]].gameObject.tag == "End" || GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End"))
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 3 && GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                }
                break;

            case BlockState.Landing:
                GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1]].tag = "Fixed";
                GameManager.Blocks[GameManager.CurrentBlocks[1, 0], GameManager.CurrentBlocks[1, 1]].tag = "Fixed";
                GameManager.Blocks[GameManager.CurrentBlocks[2, 0], GameManager.CurrentBlocks[2, 1]].tag = "Fixed";
                GameManager.Blocks[GameManager.CurrentBlocks[3, 0], GameManager.CurrentBlocks[3, 1]].tag = "Fixed";
                GameManager.CheckLine();
                FallMino.IsMoveing = false;
                _rotate = 1;
                blockState = BlockState.Start;
                //tag変更
                //FallMInoのBool型をFalseに
                //ミノがはみ出したらEndへ、それ以外はStartへ
                //２００回回す、tagの数が１０個だったら消す、それ以外のタグが１個でもあったらbreak

                break;

            case BlockState.End:
                break;
        }
    }

    private void CheckUnder()
    {
        if (_currentColoer == "Red")
        {
            if (_rotate == 1 && 0 <= GameManager.CurrentBlocks[3, 0] - 1 && 0 <= GameManager.CurrentBlocks[1, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
            else if (_rotate == 2 && 0 <= GameManager.CurrentBlocks[3, 0] - 2)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1] - 1], GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 2, GameManager.CurrentBlocks[2, 1] + 2], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 2, GameManager.CurrentBlocks[3, 1]]);
            }
        }
        else if (_currentColoer == "Green")
        {
            if (_rotate == 1 && 0 <= GameManager.CurrentBlocks[3, 0] - 1 && 0 <= GameManager.CurrentBlocks[1, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
            else if (_rotate == 4 && 0 <= GameManager.CurrentBlocks[3, 0] - 2)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1] - 1], GameManager.Blocks[GameManager.CurrentBlocks[0, 0], GameManager.CurrentBlocks[0, 1] + 1], GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]]);
            }
        }
        else if (_currentColoer == "Purple")
        {
            if (_rotate == 1 && 0 <= GameManager.CurrentBlocks[2, 0] - 1 && 0 <= GameManager.CurrentBlocks[1, 0] - 1 && 0 <= GameManager.CurrentBlocks[3, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]], GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
            else if (_rotate == 2 && 0 <= GameManager.CurrentBlocks[1, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]], GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]]);
            }
            else if (_rotate == 3 && 0 <= GameManager.CurrentBlocks[0, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]], GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
            else if (_rotate == 4 && 0 <= GameManager.CurrentBlocks[3, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]], GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]]);
            }
        }
        else if (_currentColoer == "LigthBlue")
        {
            if (_rotate == 1 && 0 <= GameManager.CurrentBlocks[3, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
            else if (_rotate == 2 && 0 <= GameManager.CurrentBlocks[0, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]], GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]], GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
            else if (_rotate == 3 && 0 <= GameManager.CurrentBlocks[0, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]]);
            }
            else if (_rotate == 4 && 0 <= GameManager.CurrentBlocks[0, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]], GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]], GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
        }
        else if (_currentColoer == "Blue")
        {
            if (_rotate == 1 && 0 <= GameManager.CurrentBlocks[2, 0] - 1 && 0 <= GameManager.CurrentBlocks[3, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
            else if (_rotate == 2 && 0 <= GameManager.CurrentBlocks[0, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]], GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]], GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]]);
            }
            else if (_rotate == 3 && 0 <= GameManager.CurrentBlocks[0, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
            else if (_rotate == 4 && 0 <= GameManager.CurrentBlocks[3, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]], GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
        }
        else if (_currentColoer == "Orange")
        {
            if (_rotate == 1 && 0 <= GameManager.CurrentBlocks[2, 0] - 1 && 0 <= GameManager.CurrentBlocks[3, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
            else if (_rotate == 2 && 0 <= GameManager.CurrentBlocks[3, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]], GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
            else if (_rotate == 3 && 0 <= GameManager.CurrentBlocks[0, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
            }
            else if (_rotate == 4 && 0 <= GameManager.CurrentBlocks[0, 0] - 1)
            {
                BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[0, 0] - 1, GameManager.CurrentBlocks[0, 1]], GameManager.Blocks[GameManager.CurrentBlocks[1, 0] - 1, GameManager.CurrentBlocks[1, 1]], GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]]);
            }
        }
        else if (_currentColoer == "Yellow" && 0 <= GameManager.CurrentBlocks[2, 0] - 1)
        {
            BlockCheck(GameManager.Blocks[GameManager.CurrentBlocks[2, 0] - 1, GameManager.CurrentBlocks[2, 1]], GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]]);
        }
    }

    private void CheckSide()
    {
        if (_currentColoer == "Red")
        {
            IsRight(1, 0, 1);//回転１ 右を調べる
            IsLeft(1, 2, 3);//回転１ 左を調べる
            IsRight(2, 1, 3);//回転 2 右を調べる
            IsLeft(2, 0, 2);//回転 2 左を調べる
        }
        else if (_currentColoer == "Green")
        {
            IsRight(1, 2, 3);//回転１　右を調べる
            IsLeft(1, 0, 1);//回転１　左を調べる
            IsRight(4, 0, 2);//4 右
            IsLeft(4, 1, 3);//4 左    
        }
        else if (_currentColoer == "Purple")
        {
            IsRight(1, 0, 3); //1 右
            IsLeft(1, 0, 1);//1 左
            IsRight(2, 1, 2, 3);//2 右
            IsLeft(2, 0, 1, 3);// 2　左
            IsRight(3, 0, 1);//3 右
            IsLeft(3, 0, 3);//3 左
            IsRight(4, 0, 1, 3);//4 右
            IsLeft(4, 1, 2, 3); //４　左
        }
        else if (_currentColoer == "LigthBlue")
        {
            IsRight(1, 0, 1, 2, 3);//1 右
            IsLeft(1, 0, 1, 2, 3);//1 左
            IsLeft(2, 0); // 2 左
            IsRight(2, 3);　// 2 右
            IsRight(3, 0, 1, 2, 3); //3 R
            IsLeft(3, 0, 1, 2, 3);// 3 L
            IsRight(4, 0);//4R
            IsLeft(4, 3);//4L
        }
        else if (_currentColoer == "Blue")
        {
            IsRight(1, 0, 1, 3);//1R
            IsLeft(1, 0, 1, 2);//1L
            IsLeft(2, 0, 3);//2L
            IsRight(2, 2, 3);//2R
            IsRight(3, 0, 1, 2);//3R
            IsLeft(3, 0, 1, 3);//3L
            IsRight(4, 0, 3);//4R
            IsLeft(4, 2, 3);
        }
        else if (_currentColoer == "Orange")
        {
            IsRight(1, 0, 1, 2);
            IsLeft(1, 0, 1, 3);
            IsRight(2, 2, 3);
            IsLeft(2, 0, 3);
            IsRight(3, 0, 1, 3);
            IsLeft(3, 0, 1, 2);
            IsRight(4, 0, 3);
            IsLeft(4, 2, 3);
        }
        else if (_currentColoer == "Yellow" && 0 <= GameManager.CurrentBlocks[2, 0] - 1)
        {
            IsRight(1, 1, 3);
            IsLeft(1, 2, 3);
        }
    }

    private void ChangeState()
    {
        if (_aroundFlag)
        {
            blockState = BlockState.Landing;
            _aroundFlag = false;
        }
    }

    private void IsRight(int rotate, int index1)
    {
        if (_rotate == rotate && 9 >= GameManager.CurrentBlocks[index1, 1] + 1)
            BlockRightCheck(GameManager.Blocks[GameManager.CurrentBlocks[index1, 0], GameManager.CurrentBlocks[index1, 1] + 1]);
    }

    private void IsRight(int rotate, int index1, int index2)
    {
        if (_rotate == rotate && 9 >= GameManager.CurrentBlocks[index1, 1] + 1 && 9 >= GameManager.CurrentBlocks[index2, 1] + 1)
            BlockRightCheck(GameManager.Blocks[GameManager.CurrentBlocks[index1, 0], GameManager.CurrentBlocks[index1, 1] + 1], GameManager.Blocks[GameManager.CurrentBlocks[index2, 0], GameManager.CurrentBlocks[index2, 1] + 1]);
    }

    private void IsRight(int rotate, int index1, int index2, int index3)
    {
        if (_rotate == rotate && 9 >= GameManager.CurrentBlocks[index1, 1] + 1 && 9 >= GameManager.CurrentBlocks[index2, 1] + 1 && 9 >= GameManager.CurrentBlocks[index3, 1] + 1)
            BlockRightCheck(GameManager.Blocks[GameManager.CurrentBlocks[index1, 0], GameManager.CurrentBlocks[index1, 1] + 1], GameManager.Blocks[GameManager.CurrentBlocks[index2, 0], GameManager.CurrentBlocks[index2, 1] + 1], GameManager.Blocks[GameManager.CurrentBlocks[index3, 0], GameManager.CurrentBlocks[index3, 1] + 1]);
    }

    private void IsRight(int rotate, int index1, int index2, int index3, int index4)
    {
        if (_rotate == rotate && 9 >= GameManager.CurrentBlocks[index1, 1] + 1 && 9 >= GameManager.CurrentBlocks[index2, 1] + 1 && 9 >= GameManager.CurrentBlocks[index3, 1] + 1 && 9 >= GameManager.CurrentBlocks[index4, 1] + 1)
            BlockRightCheck(GameManager.Blocks[GameManager.CurrentBlocks[index1, 0], GameManager.CurrentBlocks[index1, 1] + 1], GameManager.Blocks[GameManager.CurrentBlocks[index2, 0], GameManager.CurrentBlocks[index2, 1] + 1], GameManager.Blocks[GameManager.CurrentBlocks[index3, 0], GameManager.CurrentBlocks[index3, 1] + 1], GameManager.Blocks[GameManager.CurrentBlocks[index4, 0], GameManager.CurrentBlocks[index4, 1] + 1]);
    }

    private void IsLeft(int rotate, int index1)
    {
        if (_rotate == rotate && 0 <= GameManager.CurrentBlocks[index1, 1] - 1)
            BlockLeftCheck(GameManager.Blocks[GameManager.CurrentBlocks[index1, 0], GameManager.CurrentBlocks[index1, 1] - 1]);
    }

    private void IsLeft(int rotate, int index1, int index2)
    {
        if (_rotate == rotate && 0 <= GameManager.CurrentBlocks[index1, 1] - 1 && 0 <= GameManager.CurrentBlocks[index2, 1] - 1)
            BlockLeftCheck(GameManager.Blocks[GameManager.CurrentBlocks[index1, 0], GameManager.CurrentBlocks[index1, 1] - 1], GameManager.Blocks[GameManager.CurrentBlocks[index2, 0], GameManager.CurrentBlocks[index2, 1] - 1]);
    }

    private void IsLeft(int rotate, int index1, int index2, int index3)
    {
        if (_rotate == rotate && 0 <= GameManager.CurrentBlocks[index1, 1] - 1 && 0 <= GameManager.CurrentBlocks[index2, 1] - 1 && 0 <= GameManager.CurrentBlocks[index3, 1] - 1)
            BlockLeftCheck(GameManager.Blocks[GameManager.CurrentBlocks[index1, 0], GameManager.CurrentBlocks[index1, 1] - 1], GameManager.Blocks[GameManager.CurrentBlocks[index2, 0], GameManager.CurrentBlocks[index2, 1] - 1], GameManager.Blocks[GameManager.CurrentBlocks[index3, 0], GameManager.CurrentBlocks[index3, 1] - 1]);
    }

    private void IsLeft(int rotate, int index1, int index2, int index3, int index4)
    {
        if (_rotate == rotate && 0 <= GameManager.CurrentBlocks[index1, 1] - 1 && 0 <= GameManager.CurrentBlocks[index2, 1] - 1 && 0 <= GameManager.CurrentBlocks[index3, 1] - 1 && 0 <= GameManager.CurrentBlocks[index4, 1] - 1)
            BlockLeftCheck(GameManager.Blocks[GameManager.CurrentBlocks[index1, 0], GameManager.CurrentBlocks[index1, 1] - 1], GameManager.Blocks[GameManager.CurrentBlocks[index2, 0], GameManager.CurrentBlocks[index2, 1] - 1], GameManager.Blocks[GameManager.CurrentBlocks[index3, 0], GameManager.CurrentBlocks[index3, 1] - 1], GameManager.Blocks[GameManager.CurrentBlocks[index4, 0], GameManager.CurrentBlocks[index4, 1] - 1]);
    }

    private bool IsLeftSide()
    {
        if (_leftSideFixed)
        {
            return false;
        }
        else
        {
            if (GameManager.CurrentBlocks[0, 1] != 0 && GameManager.CurrentBlocks[1, 1] != 0 && GameManager.CurrentBlocks[2, 1] != 0 && GameManager.CurrentBlocks[3, 1] != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    private bool IsRightSide()
    {
        if (_rightSideFixd)
        {
            return false;
        }
        else
        {
            if (GameManager.CurrentBlocks[0, 1] != 9 && GameManager.CurrentBlocks[1, 1] != 9 && GameManager.CurrentBlocks[2, 1] != 9 && GameManager.CurrentBlocks[3, 1] != 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    private void BlockCheck(GameObject b1)
    {
        if (b1.tag == "Fixed")
        {
            ChangeState();
        }
    }

    private void BlockCheck(GameObject b1, GameObject b2)
    {
        if (b1.tag == "Fixed" || b2.tag == "Fixed")
        {
            ChangeState();
        }
    }

    private void BlockCheck(GameObject b1, GameObject b2, GameObject b3)
    {
        if (b1.tag == "Fixed" || b2.tag == "Fixed" || b3.tag == "Fixed")
        {
            ChangeState();
        }
    }

    private void BlockCheck(GameObject b1, GameObject b2, GameObject b3, GameObject b4)
    {
        if (b1.tag == "Fixed" || b2.tag == "Fixed" || b3.tag == "Fixed" || b4.tag == "Fixed")
        {
            ChangeState();
        }
    }

    private void BlockRightCheck(GameObject b1)
    {
        if (b1.tag == "Fixed")
        {
            _rightSideFixd = true;
        }
        else
        {
            _rightSideFixd = false;
        }
    }

    private void BlockRightCheck(GameObject b1, GameObject b2)
    {
        if (b1.tag == "Fixed" || b2.tag == "Fixed")
        {
            _rightSideFixd = true;
        }
        else
        {
            _rightSideFixd = false;
        }
    }

    private void BlockRightCheck(GameObject b1, GameObject b2, GameObject b3)
    {
        if (b1.tag == "Fixed" || b2.tag == "Fixed" || b3.tag == "Fixed")
        {
            _rightSideFixd = true;
        }
        else
        {
            _rightSideFixd = false;
        }
    }

    private void BlockRightCheck(GameObject b1, GameObject b2, GameObject b3, GameObject b4)
    {
        if (b1.tag == "Fixed" || b2.tag == "Fixed" || b3.tag == "Fixed" || b4.tag == "Fixed")
        {
            _rightSideFixd = true;
        }
        else
        {
            _rightSideFixd = false;
        }
    }

    private void BlockLeftCheck(GameObject b1)
    {
        if (b1.tag == "Fixed")
        {
            _leftSideFixed = true;
        }
        else
        {
            _leftSideFixed = false;
        }
    }

    private void BlockLeftCheck(GameObject b1, GameObject b2)
    {
        if (b1.tag == "Fixed" || b2.tag == "Fixed")
        {
            _leftSideFixed = true;
        }
        else
        {
            _leftSideFixed = false;
        }
    }

    private void BlockLeftCheck(GameObject b1, GameObject b2, GameObject b3)
    {
        if (b1.tag == "Fixed" || b2.tag == "Fixed" || b3.tag == "Fixed")
        {
            _leftSideFixed = true;
        }
        else
        {
            _leftSideFixed = false;
        }
    }

    private void BlockLeftCheck(GameObject b1, GameObject b2, GameObject b3, GameObject b4)
    {
        if (b1.tag == "Fixed" || b2.tag == "Fixed" || b3.tag == "Fixed" || b4.tag == "Fixed")
        {
            _leftSideFixed = true;
        }
        else
        {
            _leftSideFixed = false;
        }
    }

    /// <summary>
    /// 対象マスのいろ変える
    /// </summary>
    /// <param name="index1"></param>
    /// <param name="index2"></param>
    /// <param name="flag">右がtrue　左がfalse</param>
    private void TestColor(int index1, int index2, bool flag)
    {
        if (flag)
        {
            GameManager.Blocks[GameManager.CurrentBlocks[index1, 0], GameManager.CurrentBlocks[index1, 1] + 1].GetComponent<SpriteRenderer>().color = Color.black;
            GameManager.Blocks[GameManager.CurrentBlocks[index2, 0], GameManager.CurrentBlocks[index2, 1] + 1].GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            GameManager.Blocks[GameManager.CurrentBlocks[index1, 0], GameManager.CurrentBlocks[index1, 1] - 1].GetComponent<SpriteRenderer>().color = Color.black;
            GameManager.Blocks[GameManager.CurrentBlocks[index2, 0], GameManager.CurrentBlocks[index2, 1] - 1].GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
