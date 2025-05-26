using UnityEngine;

public class StudyOperator : MonoBehaviour
{
    public int currentLevel = 10;
    public int maxLevel = 99;
    void Start()
    {
        string msg = currentLevel >= maxLevel ? " 현재 만렙입니다." : "현재 만렙이 아닙니다.";

        int levelPoint = currentLevel >= maxLevel ? 0 : 1;

        currentLevel += levelPoint;

        Debug.Log(msg);
    }
    void Update()
    {
        
    }
}
