//挂载在所有的button父物体上
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 定义button信息类
/// </summary>
public class ButtonInfo
{
    public int id;
    public GameObject obj;
}
public class ButtonTest : MonoBehaviour {

    public static ButtonTest instance;

    Button[] buttonArr;
    //传递按钮点击的委托
    public delegate void OnButtonClickDelegate(ButtonInfo info);
    public event OnButtonClickDelegate OnButtonClickDel;
   
    Button sendString;
    string str;
    //点击按钮传递字符串的委托
    public delegate void OnSendStringButtonDelegate(string str);
    public event OnSendStringButtonDelegate sendstring;
    
    void Awake() {
        instance = this;
    }

    void Start() {
        //传递String参数
        sendString = GameObject.Find("Button_String").GetComponent<Button>();
        sendString.onClick.AddListener(() => OnSendStringButtonClick(str));

        //传递button点击事件(ButtonInfo 用来区分点击的是哪个按钮)
        buttonArr = transform.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttonArr.Length; i++)
        {
            ButtonInfo info = new ButtonInfo();
            info.id = i;
            info.obj = buttonArr[i].gameObject;
            buttonArr[i].onClick.AddListener(() => OnButtonClick(info));
        }
    }
    // 多个按钮的点击事件
    void OnButtonClick(ButtonInfo info)
    {
        //print(info.id);
        if (OnButtonClickDel != null)
        {
            OnButtonClickDel(info);
        }
    }

    // 传递字符串的点击事件
    void OnSendStringButtonClick(string str) {
        str = "发送消息";
        if (sendstring!=null)
        {
            sendstring(str);
        }
    }
}

