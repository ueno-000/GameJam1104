using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    //コライダーを判定する二次元配列



    //各コライダーの要素数の設定
    [SerializeField] int tate = 0;
    [SerializeField] int yoko = 0;

    //コライダーに入ったら配列をtrueにする
    private void OnTriggerStay2D(Collider2D collision)
    {
        BlockChecker.Blocks[tate, yoko] = true;
        //Debug.Log(tate + " " + yoko + BlockChecker.Blocks[tate, yoko]);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        BlockChecker.Blocks[tate, yoko] = false;
    }
}
