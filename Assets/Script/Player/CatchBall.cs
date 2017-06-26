using UnityEngine;
using System.Collections;

public class CatchBall : MonoBehaviour {
    public Player player;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Destroy(other.gameObject);
            player.CatchBall();
        }
    }

}
