using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [SerializeField] ButtonManager buttonManager;
    private bool isTriggered;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            LaunchController.collisionAmount++;
        }
        else if (collision.gameObject.CompareTag("Finish") && !LaunchController.isFinished)
        {
            Debug.Log("Finised");
            LaunchController.isFinished = true;
            buttonManager.Finish();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            LaunchController.collisionAmount--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered)
        {
            isTriggered = true;
            buttonManager.Fail();
        }
    }
}
