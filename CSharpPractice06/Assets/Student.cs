using UnityEngine;

[System.Serializable]
public class Student
{
    public int score;
    public static int passScore;

    public static int count;

    //靜態方法內只能存取靜態成員、類別
    public static void StudentAdd()
    {
        count++;
        Debug.Log("目前學生數量：" + count);
    }

}
