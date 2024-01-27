using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{

    public float noteSpeed;

    private float noteVel;

    // Start is called before the first frame update
    void Start()
    {
        if(noteSpeed <=11)
        {
            noteVel = 20/(-noteSpeed+12);
        }
        else
        {
            noteVel = 100/(-noteSpeed+16);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0,noteVel*Time.deltaTime,0);
    }
}
