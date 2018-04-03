using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class test01 : MonoBehaviour {
    public static test01 instance;
    public delegate void Test01Delegate(int num);
    public event Test01Delegate myEvent;
    public int num;

    public delegate void Test01just();
    public event Test01just myJust;


    void Awake() {
        instance = this;
        num = 0;
    }
    
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            //num += 1;
            //myEvent(num);

            myJust();

        }
        if (Input.GetMouseButtonDown(1))
        {
            //num -= 1;
            //myEvent(num);
        }
    }    
}
