using UnityEngine;
using System.Collections;



public class movementGhosts : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var move = Random.value % 2;
        if (move == 0)
        {
            Vector3 position = this.transform.position;
            position.x -= 0.1f;
            this.transform.position = position;
        }
        if (Random.value == 1)
        {
            Vector3 position = this.transform.position;
            position.x += 0.1f;
            this.transform.position = position;
        }
        if (Random.value == -1)
        {
            Vector3 position = this.transform.position;
            position.z += 0.1f;
            this.transform.position = position;
        }
        if (Random.value == 0)
        {
            Vector3 position = this.transform.position;
            position.z -= 0.1f;
            this.transform.position = position;
        }

    }
}
