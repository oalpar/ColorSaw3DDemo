using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public Transform point1;
    public Transform point2;
    public GameObject ObstacleToMove;
    Transform destination;
    
    void Start()
    {
        
        destination=point1;
    }
    public float rotationSpeedX;
    public float rotationSpeedY;
    public float rotationSpeedZ;



    void Move()
    {

        ObstacleToMove.transform.position=Vector3.MoveTowards(ObstacleToMove.transform.position,destination.position,moveSpeed*Time.deltaTime);
        if(ObstacleToMove.transform.position==point1.position&&destination.position==point1.position)
        {
            destination=point2;
            if(point1.position!=point2.position)
            {
                ChangeRotation();
            }

        }
        else if(ObstacleToMove.transform.position==point2.position&&destination.position==point2.position)
        {
            destination=point1;
            if(point1.position!=point2.position)
            {
                ChangeRotation();
            }
        }
    }

    void ChangeRotation()
    {
                rotationSpeedX*=-1;
                rotationSpeedY*=-1;
                rotationSpeedZ*=-1;
    }
    void Update()
    {
        Move();
        ObstacleToMove.transform.Rotate(rotationSpeedX*Time.deltaTime,rotationSpeedY*Time.deltaTime,rotationSpeedZ*Time.deltaTime);
  
    }
}
