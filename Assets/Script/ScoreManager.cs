using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreManagerData", menuName = "ScriptableObjects/ScoreManager", order = 1)]
public class ScoreManager : ScriptableObject
{


    public float bestscore = 0.0f;
    public void setScore(float newScore, int trackNumber)
    {
    if (bestscore < newScore)
    bestscore = newScore;
    }
}
