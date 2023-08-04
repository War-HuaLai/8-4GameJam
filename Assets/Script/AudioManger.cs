using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManger : MonoBehaviour
{
    public static AudioManger Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public void MusicVolume(float volume)//��������
    {
        musicSource.volume = volume;
    }


    //Audio.Istance.PlaySFX("��Ӧ����") ��һ����ڰ��������Ĵ����������Ծ�ͷ��ڰ�����Ծ������
    //���ʧ�ܽ�������Ҫ���־Ͱ�musicPlay.stop
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);


        if (s == null)
        {
            Debug.Log("δ�ҵ�����");
        }
        else
        {
            if (!musicSource.isPlaying)
            {
                musicSource.clip = s.Get();
                musicSource.Play();
                return;
            }
            if (musicSource.clip == s.Get())
                return;
            musicSource.clip = s.Get();
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }


    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        //������һ���ַ������͵Ĳ��� name����ʾҪ���ŵ���Ч���ơ�������� sfxSounds �����в������������ƥ��� Sound ���󣬲�ʹ�� PlayOneShot() ����������Ч��
        if (s == null)
        {
            Debug.Log("δ�ҵ�����");
        }
        else
        {
            if (!sfxSource.isPlaying)
            {
                sfxSource.PlayOneShot(s.Get());
                return;
            }
            if (sfxSource.clip == s.Get())
                return;
            sfxSource.PlayOneShot(s.Get());
            /*����Ҫ��ͬһ��ʱ�䲥��N��AudioClipʱ�������ַ���PlayClipAtPoint()��PlayOneShot()
                1.��ͬ��
                �����������ǲ�����AudioClip���Զ��ر��Զ�����
                2.��ͬ��
                PlayClipAtPoint()���ŵ���3D��Ч
                PlayOneShot()���ŵ���2D��Ч
                PlayClipAtPoint�Ǿ�̬��������PlayOneShot���ǡ�����˵����Ҫʹ��PlayOneShot����������ָ��ʵ�����Ķ���
            */
        }
    }


    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }


    //����ģ��
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }


    public void ToggleSfx()//�����Ƿ���
    {
        sfxSource.mute = !sfxSource.mute;
    }


    private void Awake()
    {


        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
            Instance = this;
        }
    }
    private void Start()
    {
        //PlayMusic("");
    }
}