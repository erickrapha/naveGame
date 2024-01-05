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
        TocarSom(this.hitEnemy);
    }
    public void TocarSomDieEnemy()
    {
        TocarSom(this.dieEnemy);
    }
    public void TocarSomLaser()
    {
        TocarSom(this.laser, 0.1f);
    }
    private void TocarSom(AudioClip audioClip, float volume = 0.5f)
    {
        this.audioSource.PlayOneShot(audioClip, volume);
    }
}
