using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBlockHantei : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("ok");
        //transform.root.gameObject.GetComponent<ParentHantei>().TopHit();
        
    }
    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
