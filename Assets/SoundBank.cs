using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SoundBank : MonoBehaviour
{
    static public  Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();
    static AudioSource player;
    static public List<AudioClip> cliplist = new List<AudioClip>();

    void Start()
    {

        string[] soundfils = new string[] { "RSG","coin","win" };
        
        foreach (string sname in soundfils)
        {
            AudioClip a = Resources.Load<AudioClip>("Sounds/" + sname);
            sounds.Add(sname, a);
        }
        print("loaded sounds= " + sounds.Count);
        player = GetComponent<AudioSource>();
        
    }
    public static void Play(string sname)
    {
        if (!sounds.ContainsKey(sname)) throw new Exception("Sound[" + sname + "] not found!!!");
        AudioClip a = sounds[sname];
        //print("playing " + a);
        cliplist.Add(a);
        player.clip = a;
        player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (player!=null && !player.isPlaying &&cliplist!=null && cliplist.Count > 0)
        {
            AudioClip a = cliplist[0];
            player.clip = a;
            player.Play();
            cliplist.RemoveAt(0);
        }*/
        
    }
    internal static void Stop()
    {
        player.Stop();
    }
}
