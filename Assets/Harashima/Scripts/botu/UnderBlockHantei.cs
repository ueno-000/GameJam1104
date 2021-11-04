using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderBlockHantei : MonoBehaviour
{
    GameObject go;

    private void Start()
    {
        go = this.gameObject;
    }
    private void Update()
    {
        if (ColliderScript.ColliderArray1[0,1]&& ColliderScript.ColliderArray1[0, 2] && ColliderScript.ColliderArray1[0, 3]  )
        {
            DestroySelf();
        }
    }
    void DestroySelf()
    {
        Destroy(go);
    }

    void Check()
    {
        

        for (int i = 0;i<10;i++)
        {
            //ColliderScript.ColliderArray1[];
        }
    }
}
