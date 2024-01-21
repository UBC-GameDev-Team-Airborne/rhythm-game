using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SongParser : MonoBehaviour
{
    public string filePath;

    public Dictionary<string, string> data {get; private set;}

    public Queue<Tuple<int,int,float,float>> beatmap {get; private set;}

    void Start()
    {
        System.IO.StreamReader f = new System.IO.StreamReader(Application.persistentDataPath + "/Songs/" + filePath);
        data = new Dictionary<string, string>();

        string s;

        while((s = f.ReadLine()) != null)
        {
            if(s == "[Beatmap]")
            {
                break;
            }
            if(s == "" || s[0] == '[')
            {
                continue;
            }
            int i = s.IndexOf(':');
            if(i>=0 && i+2 <= s.Length)
            {
                data.Add(s.Substring(0, i), s.Substring(i+2));
            }
            else if(i >= 0)
            {
                data.Add(s.Substring(0,i), "");
            }
        }

        beatmap = new Queue<Tuple<int,int,float,float>>();
        while((s = f.ReadLine()) != null)
        {
            string[] note = s.Split(',');
            beatmap.Enqueue(Tuple.Create(Convert.ToInt32(note[0]), Convert.ToInt32(note[1]), Convert.ToSingle(note[2]), Convert.ToSingle(note[3])));
        }
    }
}
