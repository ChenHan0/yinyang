using UnityEngine;
using System.Collections;

public class CatchBall : MonoBehaviour {
    public Player player;

    public float BallVelocity;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            if (other.GetComponent<Rigidbody>().velocity.magnitude >= BallVelocity)
            {

            }

            Destroy(other.gameObject);
            player.CatchBall();
        }
    }

}
