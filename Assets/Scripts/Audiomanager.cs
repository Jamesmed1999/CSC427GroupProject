using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class audiodelay{
	public string[] clips;
	public float[] delay;
	public int maxlen;
	public int len;

	public audiodelay(int l){
		maxlen=l;
		len=-1;
		clips = new string[l];
		delay = new float[l];
		for(int i=0;i<l;i++){
			clips[i]="";
			delay[i]=0;
		}
	}
	public bool canplay(string n,float d){
		for(int i=0;i<len;i++){
			if(string.Equals(clips[i],n)){
				if(delay[i] - Time.time > 0)return false;
				else{
					delay[i]=Time.time+d;
					return true;
				}
			}
		}
		if(len+1>maxlen)return false;
		len++;
		clips[len]=n;
		delay[len]=Time.time+d;
		return true;
	}
}
public class Audiomanager : MonoBehaviour
{
	public static Audiomanager S;
	[Header("Set in Inspector")]
	public AudioClip[] Clips;
	[Header("Set Dynamically")]
	public int numDelayClips;
	public audiodelay delays;
	public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
		numDelayClips=Clips.Length;
		if(S==null)S=this;
		else Destroy(this);
		delays = new audiodelay(numDelayClips);
        audioSource=GetComponent<AudioSource>();
    }
	//I wanna be able to have little idea whats going on, but play() always working with magic code
	public void play(AudioClip audio,float v){audioSource.PlayOneShot(audio,v);}
	public void play(AudioClip audio){play(audio,1f);}
    public void play(float d,AudioClip audio){play(d,audio,1f);}
	public void play(float d,AudioClip audio,float v){if(delays.canplay(audio.name,d))play(audio,v);}
	public void play(int i){if(i<Clips.Length)play(Clips[i],1f);}
	public void play(int i,float v){if(i<Clips.Length)play(Clips[i],v);}
	public void play(float d,int i){
		if(i<Clips.Length && delays.canplay(Clips[i].name,d))play(Clips[i],1f);}
	public void play(float d,int i,float v){
		if(i<Clips.Length && delays.canplay(Clips[i].name,d))play(Clips[i],v);}
	public void play(string n){
		for(int i=0;i<Clips.Length-1;i++){
			if(string.Equals(n, Clips[i].name)){
				play(Clips[i],1f);
			}
		}
	}public void play(string n,float v){
		for(int i=0;i<Clips.Length-1;i++){
			if(string.Equals(n, Clips[i].name)){
				play(Clips[i],v);
			}
		}
	}public void play(float d,string n){
		for(int i=0;i<Clips.Length-1;i++){
			if(string.Equals(n, Clips[i].name)){
				if(delays.canplay(Clips[i].name,d))play(Clips[i],1f);
			}
		}
	}public void play(float d,string n,float v){
		for(int i=0;i<Clips.Length-1;i++){
			if(string.Equals(n, Clips[i].name)){
				if(delays.canplay(Clips[i].name,d))play(Clips[i],v);
			}
		}
	}
}
