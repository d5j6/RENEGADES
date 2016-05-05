//Unity
using UnityEngine;

//C#
using System;
using System.Collections;
using System.Collections.Generic;

namespace RENEGADES.Audio
{
    [AddComponentMenu("Base/Sound Controller")]

    public class SoundObject
    {
        public AudioSource source;
        public GameObject sourceGO;
        public Transform sourceTR;
        public AudioClip clip;
        public string name;

        public SoundObject(AudioClip aClip, string aName, float aVolume)
        {
            //in this (the constructor) we create a new audio source and store the details of the sound itself
            sourceGO = new GameObject("AudioSource_" + aName);
            sourceGO.transform.SetParent(UnityEngine.Object.FindObjectOfType<BaseSoundController>().transform);
            sourceTR = sourceGO.transform;
            source = sourceGO.AddComponent<AudioSource>();
            source.name = "AudioSource_" + aName;
            source.playOnAwake = false;
            source.clip = aClip;
            source.volume = aVolume;
            clip = aClip;
            name = aName;
        }

        //2D Sound
        public void PlaySound()
        {
            source.spatialBlend = 0.0f;
            source.PlayOneShot(clip);
        }

        //3D Sound
        public void PlaySound(Vector3 position)
        {
            source.spatialBlend = 1.0f;
            sourceTR.position = position;
            source.PlayOneShot(clip);
        }

    }

    public class BaseSoundController : MonoBehaviour
    {
        [Header("Audio Clips")]
        public AudioClip[] audioClips;
        private int totalSounds;
        private ArrayList soundObjectList;
        private SoundObject tempSoundObj;

        private Dictionary<Sounds.Sound, int> easySearch;

        void Start()
        {
            soundObjectList = new ArrayList();
            easySearch = new Dictionary<Sounds.Sound, int>();

            foreach (AudioClip theSound in audioClips)
            {
                easySearch.Add((Sounds.Sound)Enum.Parse(typeof(Sounds.Sound), theSound.name), totalSounds);
                tempSoundObj = new SoundObject(theSound, theSound.name, 1);
                soundObjectList.Add(tempSoundObj);
                totalSounds++;
            }
        }

        //play sound 2D
        public void PlaySound(Sounds.Sound sound)
        {
            Execute(easySearch[sound]);
        }

        //play sound 3D
        public void PlaySound(Sounds.Sound sound,Vector3 position)
        {
            Execute(easySearch[sound],position);
        }


        //Plays a sound by the index number on the array 2D
        private void Execute(int anIndexNumber)
        {
            if (soundObjectList == null) return;

            tempSoundObj = (SoundObject)soundObjectList[anIndexNumber];
            tempSoundObj.PlaySound();
        }

        //Plays a sound by the index number on the array 3D
        private void Execute(int anIndexNumber, Vector3 position)
        {
            if (soundObjectList == null) return;

            tempSoundObj = (SoundObject)soundObjectList[anIndexNumber];
            tempSoundObj.PlaySound(position);
        }

    }
}