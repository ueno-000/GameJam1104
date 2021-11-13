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
    [SerializeField]int _rotate = 1;

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
                if (Input.GetKeyDown(KeyCode.A))
                {

                    Debug.Log("Aおされた");

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

                    _blocks[0].GetComponent<SpriteRenderer>().color = _colorcode;
                    _blocks[1].GetComponent<SpriteRenderer>().color = _colorcode;
                    _blocks[2].GetComponent<SpriteRenderer>().color = _colorcode;
                    _blocks[3].GetComponent<SpriteRenderer>().color = _colorcode;

                    Array.ForEach(_blocks, g => g.GetComponent<SpriteRenderer>().color = _colorcode);
                }

                //回転ボタンが押された際に背景色の変更、rotateの変更
                //３ブロック以上長いミノは他のブロックと接地していても例外的に回転できる
                if (Input.GetButtonDown("Fire1"))
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
                    if (_rotate == 1 && GameManager.Blocks[GameManager.CurrentBlocks[3,0]-1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End" )
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 2 && GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 3 && GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                    else if (_rotate == 1 && GameManager.Blocks[GameManager.CurrentBlocks[3, 0] - 1, GameManager.CurrentBlocks[3, 1]].gameObject.tag == "End")
                    {
                        blockState = BlockState.Landing;
                    }
                }
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
