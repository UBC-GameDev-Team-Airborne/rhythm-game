using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NoteSpawner : MonoBehaviour
{
    public SongParser sp;

    public GameObject note;

    public float noteSpeed;

    private float startTime;

    private float delay;

    private Queue<Tuple<int,int,float,float>> beatmap;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        if(noteSpeed <= 11)
        {
            delay = -0.5f*noteSpeed+6;
        }
        else
        {
            delay = -0.1f*noteSpeed+1.6f;
        }
        
        beatmap = new Queue<Tuple<int,int,float,float>>(sp.beatmap);
        Console.WriteLine(beatmap);
    }

    void SpawnNote(int layer, float lx, float rx)
    {
        Instantiate(note, new Vector3((lx+rx)/2-5, 6.5f, 0), Quaternion.identity);
    }

    void Update()
    {
        while(beatmap.Count != 0 && beatmap.Peek().Item1 <= (Time.time - startTime + delay)*1000)
        {
            Tuple<int,int,float,float> n = beatmap.Dequeue();
            SpawnNote(n.Item2, n.Item3, n.Item4);
        }
    }
}
