using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of AudioManager");
        }
        Instance = this;
    }


    [field: SerializeField] public EventReference AttackShout { get; private set; }

    private void Start()
    {

    }






    public void PlayAttackShout(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

}
