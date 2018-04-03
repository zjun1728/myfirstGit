using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RegisterPanelScripts : MonoBehaviour {

    private string m_UserName;
    private string m_PassWord;
    private Button m_ResterButton;
    private Button m_CloseRegisterButton;

    private Text m_UserNameInputText;
    private Text m_PassWordInputText;
    
    private GameObject m_RepeatUserNameText;
    private GameObject m_StartPanel;
    
    void Awake() {
        m_UserNameInputText = transform.Find("UserName_InputField").transform.Find("Text").GetComponent<Text>();
        m_PassWordInputText = transform.Find("PassWord_InputField").transform.Find("Text").GetComponent<Text>();
        m_RepeatUserNameText = transform.Find("RepeatUserName_Text").gameObject;
        m_ResterButton = transform.Find("Register_Button").GetComponent<Button>();
        m_StartPanel = transform.root.Find("Start_Panel").gameObject;
        m_CloseRegisterButton = transform.Find("CloseRegisterPanel_Button").GetComponent<Button>();
    }

    void Start() {
        m_RepeatUserNameText.gameObject.SetActive(false);
        m_ResterButton.onClick.AddListener(OnResterButtonClick);
        m_CloseRegisterButton.onClick.AddListener(OnClickCloseRegisterButton);
    }
    // 注册按钮点击事件
    void OnResterButtonClick() {
    m_UserName = m_UserNameInputText.text;
        m_PassWord = m_PassWordInputText.text;
        if (PlayerPrefs.HasKey(m_UserName))
        {
            //显示提示面板
            m_RepeatUserNameText.gameObject.SetActive(true);
            Invoke("HideRepeatText", 1f);
        }
        else if(m_UserName!=""&&m_PassWord!=""){
            PlayerPrefs.SetString(m_UserName, m_PassWord);
            m_StartPanel.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    // 关闭注册面板按钮
    void OnClickCloseRegisterButton() {
        m_StartPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }


    //隐藏提示面板
    void HideRepeatText()
    {
        m_RepeatUserNameText.SetActive(false);
    }
}
