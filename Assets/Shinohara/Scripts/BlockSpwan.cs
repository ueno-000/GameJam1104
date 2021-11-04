using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックを生成するスクリプト
/// </summary>
public class BlockSpwan : MonoBehaviour
{
    /// <summary>ブロック達</summary>
    [SerializeField] GameObject[] m_blocks = default;
    /// <summary>次のブロックを生成するフラグ true=生成</summary>
    private static bool m_spwanFlag = false;
    /// <summary>ブロックを生成する場所</summary>
    Vector2 m_blockSpwaner = default;
    /// <summary>次のブロックを生成するフラグ true=生成</summary>
    public static bool SpwanFlag { get => m_spwanFlag; set => m_spwanFlag = value; }

    // Start is called before the first frame update
    void Start()
    {
        m_blockSpwaner = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstantBlock();
        }
    }

    /// <summary>
    /// 次のブロックをランダムに選択し生成する
    /// </summary>
    public void InstantBlock()
    {
        int index = Random.Range(0, 8);
        Instantiate(m_blocks[index], m_blockSpwaner, Quaternion.identity);
    }
}
