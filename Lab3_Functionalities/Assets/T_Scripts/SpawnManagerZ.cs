using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerZ : MonoBehaviour
{
    public GameObject[] MovingObj;
    private PlayerController PCscript;
    private Vector3 SpawnPostion = new Vector3(0.0f, 0.7f, 0.0f);
    private float StartDelay = 3.0f;
    private float Rate = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Rate = Random.Range(3.0f, 8.0f);
        InvokeRepeating("SpawnObstacle", StartDelay, Rate);
        PCscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void SpawnObstacle()
    {
        int index = Random.Range(0, MovingObj.Length);
        int Rightorleft = Random.Range(0, 2);
        if (MovingObj[index].CompareTag("Car"))
        {
            if (Rightorleft == 0)
            {
                SpawnPostion.x = -66.0f;
                SpawnPostion.z = -80.0f;
                MovingObj[index].GetComponent<MoveObstacle>().GoingRight = true;
            }
            else
            {
                SpawnPostion.x = 66.0f;
                SpawnPostion.z = -74.0f;
                MovingObj[index].GetComponent<MoveObstacle>().GoingRight = false;
            }
        }
        else if (MovingObj[index].CompareTag("People"))
        {
            SpawnPostion.y = 0.88f;
            if (Rightorleft == 0)
            {
                SpawnPostion.x = -66.0f;
                SpawnPostion.z = -67.0f;
                MovingObj[index].GetComponent<MoveObstacle>().GoingRight = true;
            }
            else
            {
                SpawnPostion.x = 66.0f;
                SpawnPostion.z = -63.0f;
                MovingObj[index].GetComponent<MoveObstacle>().GoingRight = false;
            }
        }

        Instantiate(MovingObj[index], SpawnPostion, MovingObj[index].transform.rotation);
    }

}
