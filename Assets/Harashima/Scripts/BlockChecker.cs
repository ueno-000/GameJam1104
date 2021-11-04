using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
	//コライダーを判定する二次元配列
	static　bool[,] blocks = new bool[20, 10];

    public static bool[,] Blocks { get => blocks; set => blocks = value; }

	//揃ってるかどうか調べる関数
    void CheckLines()
	{
		for (int i = 0; i < 20; i++)
		{
			bool isDelete = true;
			for (int j = 0; j < 10; j++)
			{
				//上から順に調べたいため、「i」ではなく「20-i-1」を使用する
				if (!Blocks[j, 20 - i - 1])
				{
					isDelete = false;
					break;
				}
			}
			//削除できる列であれば削除
			if (isDelete)
			{
				//一列ブロックを削除
				DeleteBlocks(20 - i - 1);
			}
		}
	}

	//揃ってたら消す関数
	void DeleteBlocks(int h)
	{
		//一列ブロックのGameObjectを削除する
		GameObject[] glist = GameObject.FindGameObjectsWithTag("block");
		foreach (GameObject go in glist)
		{
			//問題あり
			if (go.transform.position.y == h)
			{
				Destroy(go);
			}
		}
	}
}
