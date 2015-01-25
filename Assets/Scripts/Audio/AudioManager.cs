using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// DEVELOPER: CIHAN
/// Audio manager for playing musics (not effects).
/// It works like DialogManager. Takes necessary inputs for
/// the audio clip wanted to play and plays it.
/// </summary>
public class AudioManager : MonoBehaviour
{
    //ATTRIBUTES
    public Transform m_asBackground;
    public Transform m_asAmbience;
    public Transform m_asFx;

    private bool fuckingBool = true;


    private Dictionary<string, Transform> m_dicAudioSource = new Dictionary<string, Transform>();
    void Start()
    {
        m_dicAudioSource.Add("background", m_asBackground);
        m_dicAudioSource.Add("ambience", m_asAmbience);
        m_dicAudioSource.Add("fx", m_asFx);

        //TODO LIKE BELOW

        //STEP 1: m_arrAudioClips: [0,3]: BACKGROUND MUSIC and RELATED NAME with RESPECT to the CLIP ORDER

        //STEP 2: m_arrAudioClips: [4,12]: AMBIENTS and RELATED NAME with RESPECT to the CLIP ORDER

        //STEP 3: m_arrAudioClips: REST (EFFECTS) with SIMILAR FASHION

        //STEP 1

        /*
        List<string> tempNames = new List<string>();

        tempNames.Add("school");
        tempNames.Add("person");
        tempNames.Add("mouse");
        tempNames.Add("plant");

        List<AudioClip> tempAudios = new List<AudioClip>();

        for (int i = 0; i < 4; i++)
        {
            tempAudios.Add(m_arrAudioClips[i]);
        }

        AudioObject newAudioObj = new AudioObject(tempNames.ToArray(), tempAudios.ToArray());
        m_dicCharAudios.Add("background", newAudioObj);

        tempNames.Clear();
        tempAudios.Clear();

        //STEP 2

        tempNames.Add("person1");
        tempNames.Add("person2");
        tempNames.Add("person3");
        tempNames.Add("mouse1");
        tempNames.Add("mouse2");
        tempNames.Add("mouse3");
        tempNames.Add("plant1");
        tempNames.Add("plant2");
        tempNames.Add("plant3");

        for (int i = 4; i < 13; i++)
        {
            tempAudios.Add(m_arrAudioClips[i]);
        }

        newAudioObj = new AudioObject(tempNames.ToArray(), tempAudios.ToArray());
        m_dicCharAudios.Add("ambience", newAudioObj);

        tempNames.Clear();
        tempAudios.Clear();

         */
         
        /*List<string> tempNames = new List<string>();
        List<AudioClip> tempAudios = new List<AudioClip>();

        //Audio for school
        tempNames.Add("school");
        tempAudios.Add(m_arrAudioClips[0]);

        AudioObject newAudioObj = new AudioObject(tempNames.ToArray(), tempAudios.ToArray());
        m_dicCharAudios.Add("school", newAudioObj);

        tempNames.Clear();
        tempAudios.Clear();

        //Audio for Person
        tempNames.Add("person");
        tempNames.Add("date1");
        tempNames.Add("date2");
        tempNames.Add("date3");

        for (int i = 1; i < 5; i++)
        {
            tempAudios.Add(m_arrAudioClips[i]);
        }

        newAudioObj = new AudioObject(tempNames.ToArray(), tempAudios.ToArray());
        m_dicCharAudios.Add("person", newAudioObj);

        tempNames.Clear();
        tempAudios.Clear();

        //Audio for Moose
        tempNames.Add("moose");
        tempNames.Add("date1");
        tempNames.Add("date2");
        tempNames.Add("date3");

        for (int i = 5; i < 9; i++)
        {
            tempAudios.Add(m_arrAudioClips[i]);
        }

        newAudioObj = new AudioObject(tempNames.ToArray(), tempAudios.ToArray());
        m_dicCharAudios.Add("moose", newAudioObj);

        tempNames.Clear();
        tempAudios.Clear();


        //Audio for Plant
        tempNames.Add("plant");
        tempNames.Add("date1");
        tempNames.Add("date2");
        tempNames.Add("date3");

        for (int i = 9; i < 13; i++)
        {
            tempAudios.Add(m_arrAudioClips[i]);
        }

        newAudioObj = new AudioObject(tempNames.ToArray(), tempAudios.ToArray());
        m_dicCharAudios.Add("plant", newAudioObj);

        tempNames.Clear();
        tempAudios.Clear();
         * */

    }

    void Update()
    {
        if (fuckingBool)
        {
            fuckingBool = false;

            playOnly("background", "school");
        }
    }

    //METHODS

    /// <summary>
    /// Play the selected clip
    /// </summary>
    /// <param name="charName">Name of the character</param>
    /// <param name="clipName">Name of the place</param>
    public void playOnly(string elementName, string clipName)
    {
        Transform currentTransfrom = m_dicAudioSource[elementName];
        currentTransfrom.GetComponent<AudioObject>().playOnly(clipName);



        /*AudioObject currentObject = m_dicCharAudios[elementName];
        currentObject.playOnly(clipName);*/
    }

    public void playOneShot(string elementName, string clipName)
    {
        Transform currentTransfrom = m_dicAudioSource[elementName];
        currentTransfrom.GetComponent<AudioObject>().playOneShot(clipName);

        /*AudioObject currentObject = m_dicCharAudios[elementName];
        currentObject.playOneShot(clipName);*/
    }

    public void stop(string elementName)
    {
        Transform currentTransfrom = m_dicAudioSource[elementName];
        currentTransfrom.GetComponent<AudioObject>().stop();

       /* AudioObject currentObject = m_dicCharAudios[charName];
        currentObject.stop();*/
    }


}
