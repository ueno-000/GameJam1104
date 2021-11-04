using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
	//コライダーを判定する二次元配列
	static　bool[,] blocks = new bool[20, 11];

    public static bool[,] Blocks { get => blocks; set => blocks = value; }

	//揃ってるかどうか調べる関数
    public void CheckLines()
	{
		for (int i = 0; i < 18; i++)
		{
			bool isDelete = true;
			for (int j = 0; j < 10; j++)
			{
				//上から順に調べたいため、「i」ではなく「20-i-1」を使用する
				if (!Blocks[18-i-1,j])
				{
					isDelete = false;
					break;
				}
			}
			//削除できる列であれば削除
			if (isDelete)
			{
				//一列ブロックを削除
				DeleteBlocks(18	 - i - 1);
			}
		}
	}

	//揃ってたら消す関数
	public void DeleteBlocks(int h)
	{
		//一列ブロックのGameObjectを削除する
		GameObject[] glist = GameObject.FindGameObjectsWithTag("Change");
		foreach (GameObject go in glist)
		{
            if (go.name == "dodai")
            {
				Debug.Log("dotdai");
            }
			else if (go.GetComponent<OneBlockID>().iD == h)
			{
				Debug.Log("消える");
				Destroy(go);
			}
		}
	}
}
