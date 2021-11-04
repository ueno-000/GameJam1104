using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移を管理する
/// スクリプト
/// </summary>
public class SceneChangeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// タイトルに遷移する
    /// </summary>
    public void TransitionTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    /// <summary>
    /// ゲームシーンに遷移する
    /// </summary>
   　public void TransitionGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
