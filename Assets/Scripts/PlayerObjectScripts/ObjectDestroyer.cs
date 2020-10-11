using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject deathEffect;
    void OnTriggerEnter(Collider other)
    {
        if(tag=="KeepAliveForWin"&&other.tag=="Obstacle")
        {
            GameObject.FindGameObjectsWithTag("UI")[0].GetComponent<UIScript>().LoadDeathScreen();
        }
        else if(other.tag=="Obstacle"){
        transform.parent.parent.gameObject.GetComponent<DeleteUnconnectedNodes>().MarkForDeletion(transform.localPosition);
        DestroyObject();
        }
    }
    public void DestroyObject()
    {
        GameObject explosion = Instantiate(deathEffect,transform.position,Quaternion.identity);
        explosion.GetComponent<ParticleSystemRenderer>().material=GetComponent<MeshRenderer>().material;
        explosion.transform.Rotate(180,0,0);
        Destroy(explosion,2);
        Destroy(gameObject); 
    }
}
