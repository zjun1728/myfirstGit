using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test03 : MonoBehaviour {

    int[] ints;
    void Awake() {
        ints = new int[5] { 2, 3, 1, 7, 5 };
    }
	void Start () {
        //冒泡排序
        //for (int i = 0; i < ints.Length-1; i++)
        //{
        //    for (int j = 0; j < ints.Length-1-i; j++)
        //    {
        //        if (ints[j]<ints[j+1])
        //        {
        //            int temp = ints[j];
        //            ints[j] = ints[j + 1];
        //            ints[j + 1] = temp;
        //        }
        //    }
        //    for (int j = 0; j < ints.Length; j++)
        //    {
        //        print(ints[j]);

        //    }
        //}

        //选择排序
        //int min = ints[0];
        //int index = 0;
        //for (int i = 0; i < ints.Length-1; i++)
        //{
        //    min = ints[i];
        //    index = i;
        //    for (int j = i+1; j < ints.Length; j++)
        //    {
        //        if (min>ints[j])
        //        {
        //            min = ints[j];
        //            index = j;
        //        }
        //    }
        //    ints[index] = ints[i];
        //    ints[i] = min;
            
        //}
        //for (int i = 0; i < ints.Length; i++)
        //{
        //    print(ints[i]);
        //}
    }
}
