using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Akino; //自定義命名空間

public class Practice06 : MonoBehaviour
{
    public int A = -7;
    public int B = -100;

    public float numberA = 1.5F;
    public static float NumberB = 2.5F;

    public Student S1 = new Student();
    public Student S2 = new Student();

void Start()
    {
        #region 命名空間
        Debug.Log("A的絕對值："+Math.Abs(A)); //有使用 using System; 
        Debug.Log("B的絕對值："+System.Math.Abs(B)); //如果前段沒有使用 using System; 則必須以以下寫法
        Debug.Log("圓周率：" + Math.PI); //如果前段沒有使用 using System; 則必須以以下寫法

        Debug.Log("計算數字：" + Calculation.Number); //引用自定義的命名空間
 
        //當複數個命名空間中存在相同的類別名稱時，程式無法判斷要參考何者。 因此必須明寫要使用哪個命名空間的
        Debug.Log("Unity隨機數字：" + UnityEngine.Random.Range(1,11));
        System.Random randomNumber = new System.Random();
        Debug.Log("System隨機數字：" + randomNumber.Next());
        #endregion

        #region 靜態
        Debug.Log("非靜態成員：" + this.numberA);
        Debug.Log("靜態成員：" + Practice06.NumberB);

        //非靜態成員
        S1.score = 70;
        S2.score = 50;

        // S1.passScore = 60; //無法透過物件存取靜態成員
        //靜態成員
        Student.passScore = 60;

        //靜態成員(靜態方法)
        Student.StudentAdd();
        Student.StudentAdd();

        //靜態類別不能使用new，避免增加記憶體
        //ScoreManager scoreManager = new ScoreManager(); 

        Debug.Log("學生1");
        ScoreManager.CheckScore(S1.score, Student.passScore);
        Debug.Log("學生2");
        ScoreManager.CheckScore(S2.score, Student.passScore);

        #endregion
    }


}
