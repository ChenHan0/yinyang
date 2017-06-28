using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameStateManager.SetCurrentState(TitleState.Instance);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
