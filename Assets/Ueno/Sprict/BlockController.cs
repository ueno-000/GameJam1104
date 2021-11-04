using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] float _previousTime;
    // Blockが落ちる時間
    [SerializeField] float _fallTime = 1f;
    //ブロックを動かしたときの音
    [SerializeField]AudioSource _audio;
    //1ブロックの大きさ
    [SerializeField]float _oneBlock = 1.5f;
    //動いて良いブロックかの判定
    public bool _fallBlock = true;

    void Update()
    {
        if (_fallBlock == true)
        {
            BlockMove();
        }
    }

    private void BlockMove()
    {
        // 左矢印キーで左に動く
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-_oneBlock, 0, 0);
            _audio.Play();
        }
        // 右矢印キーで右に動く
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(_oneBlock, 0, 0);
            _audio.Play();
        }
        // クリックで４分の１回転
        else if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("マウスクリック");
            transform.Rotate(0, 0, 90);
            _audio.Play();
        }
        // 自動で下に移動させつつ、下矢印キーでも移動する
        else if (Input.GetKeyDown(KeyCode.S) || Time.time - _previousTime >= _fallTime)
        {
            transform.position += new Vector3(0, -_oneBlock, 0);
            _previousTime = Time.time;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "End")
        {
            _fallBlock = false;
            Debug.Log("ブロックと接触した");
            //Destroy(this.gameObject);
        }
    }
}
