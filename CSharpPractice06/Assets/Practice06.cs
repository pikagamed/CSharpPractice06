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

    //類別沒有實例化時預設為null
    public Student s3;
    public Color color1;  //Color是Unity內建的Struct

    public Data data1;
    public Data data2 = new Data(10,50,250);

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

        #region 結構

        Debug.Log("未實例化class："+s3);
        Debug.Log("未實例化struct：" + color1);

        //實質型別vs參考型別
        //參考型別
        Student s = s3;
        s.score = 100;
        Debug.Log("區域變數s：" + s.score);
        Debug.Log("全域變數s3：" + s3.score);
        //實質型別
        Data d = data2;
        d.level = 999;
        Debug.Log("區域變數d：" + d.level);
        Debug.Log("全域變數data2：" + data2.level);

        #endregion
    }


}

[System.Serializable]
public struct Data
{
    public int level;   //結構中不可宣告初始值，除非該欄位為const或static
    public const int baseValue = 10;    //常數欄位可以初始化
    public static int count = 1;            //靜態欄位可以初始化
    public float attack;
    public float _healthPoint;

    public float HP { get => _healthPoint; set => _healthPoint = value; }   //屬性的使用同class

    //宣告建構子時，必須明確給予每一個欄位初始值
    public Data( int getLevel, float getAttack, float getHealPoint)
    {
        level = getLevel;
        attack = getAttack;
        _healthPoint = getHealPoint;
    }
}
