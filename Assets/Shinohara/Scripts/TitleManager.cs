using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルシーンでの機能を管理する
/// スクリプト（シーン遷移など）
/// </summary>
public class TitleManager : MonoBehaviour
{
    /// <summary>遊び方のボタン</summary>
    [SerializeField] Text m_setumeiBtnText = default;
    /// <summary>遊び方UI</summary>
    [SerializeField] GameObject m_setumeiUI = default;
    /// <summary>true = UI表示</summary>
    bool m_setumeiFlag = false;
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

    /// <summary>
    /// 説明UIを表示する
    /// </summary>
    public void SetSetumeiUI()
    {
        if (!m_setumeiFlag)
        {
            m_setumeiUI.SetActive(true);
            m_setumeiFlag = true;
            m_setumeiBtnText.text = "戻る";
        }
        else
        {
            m_setumeiUI.SetActive(false);
            m_setumeiFlag = false;
            m_setumeiBtnText.text = "遊び方";
        }
    }
}
