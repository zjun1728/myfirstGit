using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OhterThingScripts : MonoBehaviour {
    
	void Start () {
        ButtonTest.instance.OnButtonClickDel += print;
        ButtonTest.instance.OnButtonClickDel += print02;
        ButtonTest.instance.sendstring += ReveiceString;
    }
	
	void print (ButtonInfo info) {
        print(info.id+"————传递消息成功");
        switch (info.id)
        {
            case 0:
                print("点击了第一个按钮");
                break;
            case 1:
                print("点击了第二个按钮");
                break;
            case 2:
                print("点击了第三个按钮");
                break;
            case 3:
                print("点击了第四个按钮");
                break;
        }
    }

    void print02(ButtonInfo info) {
        print(info.id + "————消息重用---成功");
    }

  void ReveiceString(string str)
    {
        print(str);
    }
}
