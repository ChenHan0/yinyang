using UnityEngine;
using System.Collections;

public class ScorePoint : MonoBehaviour {
    private string str;
    private int num;

	// Use this for initialization
	void Start () {
        str = name.Substring(name.Length - 1, 1);
        num = int.Parse(str) - 1;
    }

    public void GetThisPoint(RunnerPlayer runner)
    {
        if (num != 0 && !runner.points[num - 1])
        {
            return;
        }

        runner.points[num] = true;

        if (num == 0)
        {
            Debug.Log(0);
            for (int i = 0; i < runner.points.Length; i++)
                if (!runner.points[i])
                    return;

            runner.FinishRun();
        }
    }
}
