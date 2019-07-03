using UnityEngine;

public static class ScoreManager
{
    public static void CheckScore(int score, int pass)
    {
        Debug.Log( score>=pass ? "及格":"不及格" );
    }
}
