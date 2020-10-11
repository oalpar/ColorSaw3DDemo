using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteUnconnectedNodes : MonoBehaviour
{
    List<Transform> keepAliveForWin= new List<Transform>();
    List<Vector3> markedForDeletion = new List<Vector3>();
    public bool won=false;
    public IDictionary<Vector3,GameObject> destroyForWinCorToObj = new Dictionary<Vector3,GameObject>() ;
    void Start()
    {
        Debug.Assert(transform.childCount==2);
        for (int i = 0; i < transform.childCount; i++)
         {
             Transform child = transform.GetChild(i);
             if (child.name == "Destroy")
             {
                 foreach(Transform c in child)
                 {
                    destroyForWinCorToObj.Add(c.transform.localPosition,c.gameObject);
                 }
             }
             else if(child.name=="KeepAlive")
             {
                 foreach(Transform c in child)
                 {
                    keepAliveForWin.Add(c.transform);
                 }
             }
         }
    }
    void Update() {
        DeleteMarked();
        BFSandDestroyUnconnected();
        CheckWin();
    }

    void CheckWin()
    {
        if(destroyForWinCorToObj.Count==0&&won==false)
        {
            won=true;
        }
    }
    void DeleteMarked()
    {
        foreach(Vector3 toDel in markedForDeletion)
        {
            destroyForWinCorToObj.Remove(toDel);
        }
        markedForDeletion=new List<Vector3>();
    }

    public void MarkForDeletion(Vector3 cor)
    {
        markedForDeletion.Add(cor);
    }
    public void BFSandDestroyUnconnected()
    {
        
        HashSet<Vector3> visited=new HashSet<Vector3>();
        BFS(visited);
        DestroyUnconnected(visited);

    }
    void BFS(HashSet<Vector3> visited)
    {
        int[] iterator = new int[5];
        iterator[0]=-1;
        iterator[1]=0;
        iterator[2]=1;
        iterator[3]=0;
        iterator[4]=-1;
        Queue<Vector3> q= new Queue<Vector3>();
        foreach (Transform t  in keepAliveForWin)
        {
            visited.Add(t.localPosition);
            q.Enqueue(t.localPosition);
        }
        while(q.Count!=0)
        {
            Vector3 cur = q.Peek();
            q.Dequeue();
            for(int k=0;k<4;k++)
            {
                Vector3 newCor= new Vector3(cur.x+iterator[k],cur.y+iterator[k+1],0);
                if(!visited.Contains(newCor)&&destroyForWinCorToObj.ContainsKey(newCor))
                {
                    visited.Add(newCor);
                    q.Enqueue(newCor);
                }
            }
        }
    }
    void DestroyUnconnected(HashSet<Vector3> visited)
    {
        List<GameObject> toDeleteObjs= new List<GameObject>();
        List<Vector3> toDeleteFromMap = new List<Vector3>();
        foreach(KeyValuePair<Vector3,GameObject> index in destroyForWinCorToObj)
        {
            if(!visited.Contains(index.Key))
            {
                toDeleteObjs.Add(index.Value);
                toDeleteFromMap.Add(index.Key);
            }
        }
        foreach (Vector3 cor in toDeleteFromMap) //This is not done in the prior loop to keep iterator safe
        {
            destroyForWinCorToObj.Remove(cor);
        }

       // UniformShuffleList(toDeleteObjs);
        DeleteObjects(toDeleteObjs);
    }
    void UniformShuffleList(List<GameObject> list) //Incase the objects should be destroyed with an interval, making the objects randomized might look better on screen.
    {
        for (int i = 0; i < list.Count; i++) 
        {
            GameObject temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

   void DeleteObjects(List<GameObject> toDelete) 
    {
        foreach(GameObject obj in toDelete)
        {
            obj.gameObject.GetComponent<ObjectDestroyer>().DestroyObject();
        }
    }
    
}
