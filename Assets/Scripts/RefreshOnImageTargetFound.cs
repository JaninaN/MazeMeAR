using UnityEngine;
using System.Collections;
using Vuforia;

public class RefreshOnImageTargetFound : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private Transform playerTrans;
    private CharacterController playerController;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
            playerController = GetComponentInChildren<CharacterController>();
        }
        
    }

    public void refresh()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = GetComponentInChildren<CharacterController>();
        playerTrans.position = new Vector3(playerController.transform.position.x, 0.02f, playerController.transform.position.z);
    }

    // Is called if the Camera starts or stops mentioning an Image Target
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // set position of unitychan
            if(playerTrans != null)
            {
                playerTrans.position = new Vector3(playerController.transform.position.x, 0.02f, playerController.transform.position.z);
            }
            
            // disable collected Keys 
            GameObject[] keys = GameObject.FindGameObjectsWithTag("Key");
            foreach(GameObject key in keys)
            {
                if (key.GetComponent<KeyOptions>().isInactive())
                {
                    key.GetComponent<KeyOptions>().deactivate();
                }
            }
        }
    }
}
