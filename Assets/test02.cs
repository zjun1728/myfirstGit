using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test02 : MonoBehaviour {

    public Text m_Text;
    int Count;
    void Start () {
        // test01.instance.myEvent += ShowText;
        test01.instance.myJust += ShowJust;
        test01.instance.myJust += printtt;
        m_Text.text = "0";
    }
	 void ShowText (int num) {
          m_Text.text = num.ToString();
    }

    void ShowJust() {
        Count += 1;
        m_Text.text = Count.ToString();
    }

    void printtt() {
        print(23213);
    }
}
