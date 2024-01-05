using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip hitNave;

    [SerializeField]
    private AudioClip dieNave;

    [SerializeField]
    private AudioClip hitEnemy;

    [SerializeField]
    private AudioClip dieEnemy;

    [SerializeField]
    private AudioClip laser;

    [SerializeField]
    private AudioSource audioSource;

    public void TocarSomHitNave()
    {
        TocarSom(this.hitNave);
    }
    public void TocarSomDieNave()
    {
        TocarSom(this.dieNave);
    }
    public void TocarSomHitEnemy()
    {
        TocarSom(this.hitEnemy, 1.0f);
    }
    public void TocarSomDieEnemy()
    {
        TocarSom(this.dieEnemy, 0.25f);
    }
    public void TocarSomLaser()
    {
        TocarSom(this.laser, 0.05f);
    }
    private void TocarSom(AudioClip audioClip, float volume = 0.5f)
    {
        this.audioSource.PlayOneShot(audioClip, volume);
    }
}
