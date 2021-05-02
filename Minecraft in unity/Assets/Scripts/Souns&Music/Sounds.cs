using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource source;

    [SerializeField]
    private AudioClip[] grassSound;

    [SerializeField]
    private AudioClip[] gravelSound;
    
    [SerializeField]
    private AudioClip[] stoneSound;
    
    [SerializeField]
    private AudioClip[] woodSound;
    
    [SerializeField]
    private AudioClip[] sandSound;
    
    [SerializeField]
    private AudioClip[] snowSound;
   void Start()
   {
       source = GetComponent<AudioSource>();
   }



   
   // Update is called once per frame
    public void DestroyBlockSound(string type)
    {
       // Debug.Log(type);
        switch (type)
        {
            case "grass": //World.blockTypes[BlockType.Type.DIRT]:
                PlaySound(grassSound);
                break;
            case "dirt":
                PlaySound(gravelSound);
                break;
            case "wooden":
                PlaySound(woodSound);
                break;
            case "snow":
                PlaySound(snowSound);
                break;
            case "stone":
                PlaySound(stoneSound);
                break;
            case "sand":
                PlaySound(sandSound);
                break;
            default:
                PlaySound(stoneSound);
                break;
        }
       
    }

    void PlaySound(AudioClip[] clip)
    {
        switch (Random.Range(0,3))
        {
            case 0:
                source.PlayOneShot(clip[0]);
                break;
            case 1:
                source.PlayOneShot(clip[2]);
                break;
            case 2:
                source.PlayOneShot(clip[2]);
                break;
            case 3:
                source.PlayOneShot(clip[3]);
                break;
            
        }
    }
    
}
