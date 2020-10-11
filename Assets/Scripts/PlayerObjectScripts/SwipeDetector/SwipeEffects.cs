using UnityEngine;

public class SwipeEffects : MonoBehaviour
{

    

    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }
    private void SwipeDetector_OnSwipe(SwipeData data)
    {

        
        Vector3 newPos=new Vector3();
        if(data.Direction==SwipeDirection.Down)
        {
            newPos=new Vector3(transform.position.x,transform.position.y-1,0);
        }
        if(data.Direction==SwipeDirection.Up)
        {
            newPos=new Vector3(transform.position.x,transform.position.y+1,0);
        }
        if(data.Direction==SwipeDirection.Right)
        {
            newPos=new Vector3(transform.position.x+1,transform.position.y,0);
        }
        if(data.Direction==SwipeDirection.Left)
        {
            newPos=new Vector3(transform.position.x-1,transform.position.y,0);
        }
        transform.position=newPos;
    }
    private void OnDisable()
    {
        SwipeDetector.OnSwipe -= SwipeDetector_OnSwipe;
    }
}