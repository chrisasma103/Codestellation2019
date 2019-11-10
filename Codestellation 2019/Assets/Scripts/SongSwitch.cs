using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSwitch : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;

    private int idx;
    public bool switching;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        if (!switching && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) != 0)
        {
            idx = (idx + 1) % clips.Length;
            Debug.Log(idx);
            audioSource.clip = clips[idx];
            audioSource.Play();
            switching = true;
        } else if (switching && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 0)
        {
            switching = false;
        }
    }
}
