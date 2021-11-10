using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStateController : MonoBehaviour
{
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
    }

    //ミノの状態に応じて処理を行う関数
    void CheckBlock()
    {
        while (blockState != BlockState.End)
        {
            switch (blockState)
            {
                case BlockState.Start:
                    //ミノを生成する関数を呼びたい
                    //ミノの種類を取得？
                    blockState = BlockState.Fall;
                    break;

                case BlockState.Fall:
                    //数秒おきに落下していく
                    //落下中に移動キーが押されたら背景の色変化させる
                    //落下移動
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        
                    }

                    //左右移動
                    if (Input.GetKeyDown(KeyCode.A))
                    {

                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {

                    }

                    //回転ボタンが押された際に背景色の変更、下面の変更
                    if (Input.GetButtonDown("Fire1"))
                    {

                    }
                    //落下しきったことを判定してLandingへStateを変更する、下面の判定
                    break;

                case BlockState.Landing:
                    //ミノがはみ出したらEndへ、それ以外はStartへ

                    break;
                    
                case BlockState.End:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
