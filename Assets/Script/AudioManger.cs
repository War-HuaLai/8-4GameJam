using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManger : MonoBehaviour
{
    public static AudioManger Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;


    public void MusicVolume(float volume)//调节音量
    {
        musicSource.volume = volume;
    }


    //Audio.Istance.PlaySFX("相应音乐") 这一块放在按键触发的代码里，比如跳跃就放在按下跳跃键那里
    //如果失败结束不想要音乐就吧musicPlay.stop
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);


        if (s == null)
        {
            Debug.Log("未找到音乐");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }


    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        //它接受一个字符串类型的参数 name，表示要播放的音效名称。函数会从 sfxSounds 数组中查找与给定名称匹配的 Sound 对象，并使用 PlayOneShot() 方法播放音效。
        if (s == null)
        {
            Debug.Log("未找到音乐");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
            /*当需要在同一个时间播放N中AudioClip时，有两种方法PlayClipAtPoint()和PlayOneShot()
                1.共同点
                两个方法都是播放完AudioClip后自动关闭自动销毁
                2.不同点
                PlayClipAtPoint()播放的是3D音效
                PlayOneShot()播放的是2D音效
                PlayClipAtPoint是静态方法，而PlayOneShot不是。就是说，需要使用PlayOneShot方法，必须指明实例化的对象。
            */
        }
    }


    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }


    //控制模块
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }


    public void ToggleSfx()//控制是否静音
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
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic("");
    }
}