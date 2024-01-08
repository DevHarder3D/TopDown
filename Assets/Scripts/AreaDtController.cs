using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDtController : MonoBehaviour
{
    public string tagTargetDetection = "Player";

    public List<Collider2D> detectObj = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == tagTargetDetection)
        {
            detectObj.Add(other);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == tagTargetDetection)
        {
            detectObj.Remove(other);
        }
    }
}
