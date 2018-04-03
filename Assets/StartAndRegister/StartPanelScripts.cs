using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartPanelScripts : MonoBehaviour {
    
    private Button m_StartButton;
    private Button m_RegisterButton;
    private Button m_EnterGameButton;
    private Text m_UserNameInputText;
    private Text m_PassWordInputText;

    private GameObject m_RepeatUserNameText;
    private GameObject m_RegisterPanel;
    private string m_UserName;
    private string m_PassWord;
    
    void Awake()
    {
        m_RegisterButton = transform.Find("Register_Button").GetComponent<Button>();
        m_StartButton = transform.Find("Start_Button").GetComponent<Button>();
        m_UserNameInputText = transform.Find("UserName_InputField").transform.Find("Text").GetComponent<Text>();
        m_PassWordInputText = transform.Find("PassWord_InputField").transform.Find("Text").GetComponent<Text>();
        m_RepeatUserNameText = transform.Find("RepeatUserName_Text").gameObject;
        m_RegisterPanel = transform.root.Find("Register_Panel").gameObject;
        m_EnterGameButton = transform.Find("Eenter_Button").GetComponent<Button>();
    }

    void Start() {

        m_RepeatUserNameText.SetActive(false);
        m_RegisterPanel.gameObject.SetActive(false);


        //注册按钮事件
        m_StartButton.onClick.AddListener(OnClickStartButton);
        m_RegisterButton.onClick.AddListener(OnClickRegisterButton);
        m_EnterGameButton.onClick.AddListener(OnClickEnterGameButton);
    }

    // 开始按钮点击事件
    void OnClickStartButton() {
        m_UserName = m_UserNameInputText.text;
        m_PassWord = m_PassWordInputText.text;
        if (!PlayerPrefs.HasKey(m_UserName) || PlayerPrefs.GetString(m_UserName) != m_PassWord)
        {
            m_RepeatUserNameText.gameObject.SetActive(true);
            Invoke("HideRepeatText", 1f);
        }
        else if(PlayerPrefs.HasKey(m_UserName) && PlayerPrefs.GetString(m_UserName) == m_PassWord&&m_UserName!=""&&m_PassWord!="")
        {
            // 跳转场景 进入游戏
            print("进入游戏");
       // AsyncOperation ao= SceneManager.LoadSceneAsync(1);
        }
    }


    // 注册按钮点击事件
    void OnClickRegisterButton() {
        // 显示注册面板 隐藏当前面板
        m_RegisterPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    // 注册直接进入游戏界面
    void OnClickEnterGameButton() {
        print("执行进入游戏命令");
        //  AsyncOperation ao = SceneManager.LoadSceneAsync(1);
    }


    //隐藏提示面板
    void HideRepeatText()
    {
        m_RepeatUserNameText.SetActive(false);
    }

    






}
