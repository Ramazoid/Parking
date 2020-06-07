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

        string[] soundfils = new string[] { "RSG" };
        
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
        if (!sounds.ContainsKey(sname)) return;
        AudioClip a = sounds[sname];
        //print("playing " + a);
        cliplist.Add(a);
        /*player.clip = a;
        player.Play();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (player!=null && !player.isPlaying &&cliplist!=null && cliplist.Count > 0)
        {
            AudioClip a = cliplist[0];
            player.clip = a;
            player.Play();
            cliplist.RemoveAt(0);
        }
        
    }

    internal static void PlayRandom(string sname, int range)
    {
        if (player!=null && player.isPlaying) player.Stop();
        string n = UnityEngine.Random.Range(1, range).ToString();
        Play(sname + n);
        //print("play random" + n);
    }

    internal static void Stop()
    {
        player.Stop();
    }
}
