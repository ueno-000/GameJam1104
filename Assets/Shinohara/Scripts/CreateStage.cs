using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStage : MonoBehaviour
{
    [SerializeField] GameObject m_block = default;
    float y = 0f;
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < 20; i++)
        {
            Instantiate(m_block, new Vector3(0, y, 0), Quaternion.identity);
            y += 0.3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
