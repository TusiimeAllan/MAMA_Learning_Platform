using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

[RequireComponent(typeof(AudioSource))]
[DisallowMultipleComponent]

public class MusicPlayer : MonoBehaviour
{
    /// <summary>
    /// The clips list.
    /// </summary>
    public List<MusicClip> musicClips = new List<MusicClip>();

    /// <summary>
    /// The audio source reference.
    /// </summary>
    public AudioSource audioSource;

    /// <summary>
    /// The total time of the audio clip.
    /// </summary>
    private string totalTime = "00:00";

    /// <summary>
    /// The index of the current clip.
    /// </summary>
    [HideInInspector]
    public int currentClipIndex;

    /// <summary>
    /// Whether a click down on the music player .
    /// </summary>
    private bool musicPlayerClickDown;

    /// <summary>
    /// Whether the music player is interrupted.
    /// </summary>
    private bool interrupted;

    /// <summary>
    /// Whether the music player is  muted.
    /// </summary>
    private bool muted;

    /// <summary>
    /// The music time.
    /// </summary>
    public MusicTime musicTime;

    /// <summary>
    /// The sound level slider reference.
    /// </summary>
    public Slider soundLevelSlider;

    /// <summary>
    /// The music slider reference.
    /// </summary>
    public Slider musicSlider;

    /// <summary>
    /// The music clip number.
    /// </summary>
    public Text musicClipNumber;

    /// <summary>
    /// The current audio clip.
    /// </summary>
    [HideInInspector]
    public AudioClip currentAudioClip;

    /// <summary>
    /// The sound volume icons.
    /// Contains a set of volume icons from the highest level to the lowest level
    /// </summary>
    public Sprite[] soundVolumeIcons;

    /// <summary>
    /// The loop icons.
    /// Contains two sprites for the loop button (OFF and ON)
    /// </summary>
    public Sprite[] loopIcons;

    /// <summary>
    /// The shuffle icons.
    /// Contains two sprites for the shuffle button (OFF and ON)
    /// </summary>
    public Sprite[] shuffleIcons;

    /// <summary>
    /// The play icon sprite.
    /// </summary>
    public Sprite playIcon;

    /// <summary>
    /// The pause icon sprite.
    /// </summary>
    public Sprite pauseIcon;

    /// <summary>
    /// The loading icon sprite.
    /// </summary>
    public Sprite loadingIcon;

    /// <summary>
    /// The download progress image.
    /// </summary>
    public Image downloadProgressImage;

    /// <summary>
    /// The loop button image reference.
    /// </summary>
    public Image loopButtonImage;

    /// <summary>
    /// The shuffle button image reference.
    /// </summary>
    public Image shuffleButtonImage;

    /// <summary>
    /// The sound button image reference.
    /// </summary>
    public Image soundButtonImage;

    /// <summary>
    /// The play button image reference.
    /// </summary>
    public Image playButtonImage;

    /// <summary>
    /// Whether to play the first audio clip on start.
    /// </summary>
    public bool playOnStart = true;

    /// <summary>
    /// The animator of music info.
    /// </summary>
    public Animator musicInfoAnimator;

    /// <summary>
    /// Whether the click began on music slider or not.
    /// </summary>
    [HideInInspector]
    public bool clickBeganOnMusicSlider;

    /// <summary>
    /// Used for editor.
    /// </summary>
    [HideInInspector]
    public bool showContents;

    /// <summary>
    /// Whether the music player loop is enabled or not
    /// </summary>
    private bool loop = true;

    /// <summary>
    /// Whether to shuffle playing music clips or not.
    /// </summary>
    private bool shuffle;

    /// <summary>
    /// The static instance of this class.
    /// </summary>
    public static MusicPlayer instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        //Setting up the references
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (soundLevelSlider == null)
        {
            soundLevelSlider = GameObject.FindGameObjectWithTag("SoundLevelSlider").GetComponent<Slider>();
        }

        if (musicSlider == null)
        {
            musicSlider = GameObject.FindGameObjectWithTag("MusicSlider").GetComponent<Slider>();
        }

        if (musicTime == null)
        {
            musicTime = GameObject.FindGameObjectWithTag("MusicTime").GetComponent<MusicTime>();
        }

        if (musicInfoAnimator == null)
        {
            GameObject musicInfo = GameObject.Find("Music Info");
            if (musicInfo != null)
                musicInfoAnimator = musicInfo.GetComponent<Animator>();
        }

        //Set sound level slider boundary
        soundLevelSlider.minValue = 0;
        soundLevelSlider.maxValue = 1;

        SetLoopIcon();

        //Set the initial music audio clip
        if (shuffle)
        {
            SetUpRandomMusicAudioClip();
        }
        else
        {
            SetUpMusicAudioClip(0, playOnStart);
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            //Set time of the audio clip
            musicTime.SetTime(musicSlider.value, totalTime);

            //Set the sound volume
            audioSource.volume = soundLevelSlider.value;

            if (audioSource.isPlaying)
            {
                if (!clickBeganOnMusicSlider)
                {
                    SetMusicSliderValue();
                }
            }

            if (currentAudioClip != null)
            {
                //automatically go to the next music clip ,when the current music clip is fnished
                if (currentAudioClip.length - 0.1f <= musicSlider.value && !Interrupted && !clickBeganOnMusicSlider)
                {
                    NextMusicClip();
                }

                if (musicClips[currentClipIndex].type == MusicClip.Type.URL)
                {
                    if (!PlayListItem.AudioClipDownloaded())
                    {
                        SetDownloadProgress(PlayListItem.GetAudioClipDownloadProgress());
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }

    }

    /// <summary>
    /// Set the value of music slider.
    /// </summary>
    private void SetMusicSliderValue()
    {
        musicSlider.value = audioSource.time;
    }

    /// <summary>
    /// Set the audio clip.
    /// </summary>
    /// <param name="audioClip">The Audio clip.</param>
    public void SetAudioClip(AudioClip audioClip)
    {
        this.currentAudioClip = audioClip;
    }

    /// <summary>
    /// Play the audio clip at time.
    /// </summary>
    /// <param name="time">time in seconds.</param>
    public void PlayAudioClipAtTime(float time)
    {
        if (currentAudioClip == null)
        {
            return;
        }

        //Clamp music slider value, if music type is ur
        if (musicClips[currentClipIndex].type == MusicClip.Type.URL)
        {
            time = Mathf.Clamp(time, 0, PlayListItem.GetAudioClipDownloadProgress() * currentAudioClip.length);
        }

        if (Mathf.Approximately(time, currentAudioClip.length))
        {
            NextMusicClip();
            return;
        }

        playButtonImage.sprite = pauseIcon;
        interrupted = false;
        audioSource.time = Mathf.Clamp(time, 0, currentAudioClip.length - 0.01f);
        audioSource.Play();
    }

    /// <summary>
    /// Play the current audio clip.
    /// </summary>
    public void PlayAudioClip()
    {
        playButtonImage.sprite = pauseIcon;
        interrupted = false;
        if (currentAudioClip != null)
        {
            //Clamp music slider value, if music type is ur
            if (musicClips[currentClipIndex].type == MusicClip.Type.URL)
            {
                musicSlider.value = Mathf.Clamp(musicSlider.value, 0, PlayListItem.GetAudioClipDownloadProgress() * currentAudioClip.length);
            }
            audioSource.time = Mathf.Clamp(musicSlider.value, 0, currentAudioClip.length - 0.01f);
        }
        audioSource.Play();
        PlayList.instance.SetPauseIcon(currentClipIndex);
    }

    /// <summary>
    /// Pause the audio clip.
    /// </summary>
    public void PauseAudioClip()
    {
        playButtonImage.sprite = playIcon;
        interrupted = true;
        audioSource.Pause();
        PlayList.instance.SetPlayIcon(currentClipIndex);
    }

    /// <summary>
    /// Stop the music audio clip.
    /// </summary>
    public void StopMusicAudioClip()
    {
        interrupted = true;
        playButtonImage.sprite = playIcon;
        audioSource.Stop();
        audioSource.time = 0;
        SetMusicSliderValue();
        PlayList.instance.SetPlayIcon(currentClipIndex);
    }

    /// <summary>
    /// Mute the audio clip.
    /// </summary>
    public void MuteAudioClip()
    {
        soundButtonImage.sprite = soundVolumeIcons[3];
        muted = true;
        audioSource.mute = true;
    }

    /// <summary>
    /// Unmute the audio clip.
    /// </summary>
    public void UnMuteAudioClip()
    {
        soundButtonImage.sprite = soundVolumeIcons[0];
        muted = false;
        audioSource.mute = false;
    }

    /// <summary>
    /// Toggle the audio source loop.
    /// </summary>
    public void ToggleLoop()
    {
        loop = !loop;
        SetLoopIcon();
    }

    /// <summary>
    /// Toggle the shuffle.
    /// </summary>
    public void ToggleShuffle()
    {
        shuffle = !shuffle;
        SetShuffleIcon();
    }

    /// <summary>
    /// Set the loop icon.
    /// </summary>
    private void SetLoopIcon()
    {
        if (loop)
        {
            loopButtonImage.sprite = loopIcons[1];
        }
        else
        {
            loopButtonImage.sprite = loopIcons[0];
        }
    }

    /// <summary>
    /// Set the shuffle icon.
    /// </summary>
    private void SetShuffleIcon()
    {
        if (shuffle)
        {
            shuffleButtonImage.sprite = shuffleIcons[1];
        }
        else
        {
            shuffleButtonImage.sprite = shuffleIcons[0];
        }
    }

    /// <summary>
    ///Play the next music audio clip
    /// </summary>
    public void NextMusicClip()
    {
        if (shuffle)
        {
            SetUpRandomMusicAudioClip();
        }
        else
        {
            if (loop)
            {
                if (currentClipIndex == musicClips.Count - 1)
                {
                    SetUpMusicAudioClip(0, !interrupted);
                    return;
                }
            }

            if (currentClipIndex + 1 < musicClips.Count)
            {
                SetUpMusicAudioClip(currentClipIndex + 1, !interrupted);
            }
            else
            {
                StopMusicAudioClip();
            }
        }

    }

    /// <summary>
    /// Play the previous music audio clip.
    /// </summary>
    public void PreviousMusicClip()
    {
        if (shuffle)
        {
            SetUpRandomMusicAudioClip();
        }
        else
        {
            if (loop)
            {
                if (currentClipIndex == 0)
                {
                    SetUpMusicAudioClip(musicClips.Count - 1, !interrupted);
                    return;
                }
            }

            if (currentClipIndex - 1 >= 0)
            {
                SetUpMusicAudioClip(currentClipIndex - 1, !interrupted);
            }
        }
    }

    private static int prevURL = -1;

    /// <summary>
    /// Set up the music audio clip for the audio source.
    /// </summary>
    /// <param name="index">Index.</param>
    /// <param name="playClip">If set to true , then play the clip.</param>
    public void SetUpMusicAudioClip(int index, bool playClip)
    {
        if (!(index >= 0 && index < musicClips.Count))
        {
            return;
        }

        StopMusicAudioClip();

        ToggleMusicInfoAnimator();

        PlayList.instance.UnSelectItem(currentClipIndex);

        currentClipIndex = index;
        currentAudioClip = musicClips[index].audioClip;
        if (currentAudioClip != null)
        {
            SetUpTotalTime();
        }
        else
        {
            if (musicClips[index].type == MusicPlayer.MusicClip.Type.BUILT_IN)
            {
                Debug.Log("AudioClip is undefined");
            }
        }

        if (prevURL != -1)
        {
            PlayList.instance.GetItem(prevURL).Reset();
        }
        prevURL = index;

        if (musicClips[index].type == MusicPlayer.MusicClip.Type.URL)
        {
            PlayList.instance.GetItem(index).LoadAudioClipFromURL(playClip);
        }
        else
        {
            SetDownloadProgress(1);

            audioSource.clip = currentAudioClip;

            if (playClip)
            {
                PlayAudioClip();
            }
        }

        musicClipNumber.text = (index + 1) + "/" + musicClips.Count;

        PlayList.instance.SelectItem(index, playClip);
    }

    /// <summary>
    /// Set up total time of the current audio clip.
    /// </summary>
    public void SetUpTotalTime()
    {
        if (currentAudioClip != null)
        {
            musicSlider.minValue = 0;
            musicSlider.maxValue = currentAudioClip.length;
            totalTime = CommonUtil.TimeToString(currentAudioClip.length);
        }
    }

    /// <summary>
    /// Set up random music audio clip.
    /// </summary>
    private void SetUpRandomMusicAudioClip()
    {
        int index = GetRandomMusicClipIndex();
        if (index != -1)
        {
            SetUpMusicAudioClip(index, !interrupted);
        }
    }

    /// <summary>
    /// Toggle the music info animator.
    /// </summary>
    private void ToggleMusicInfoAnimator()
    {
        if (musicInfoAnimator != null)
            musicInfoAnimator.SetTrigger("Toggle");
    }

    /// <summary>
    /// Get a random music clip index.
    /// </summary>
    /// <returns>The random music clip index.</returns>
    public int GetRandomMusicClipIndex()
    {
        int index = -1;
        List<int> indexes = new List<int>();
        for (int i = 0; i < musicClips.Count; i++)
        {
            if (currentClipIndex == i)
                continue;
            indexes.Add(i);
        }

        if (indexes.Count != 0)
            index = indexes[UnityEngine.Random.Range(0, indexes.Count)];

        return index;
    }

    void OnDestroy()
    {
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
    }

    /// <summary>
    /// Set the download progress.
    /// </summary>
    /// <param name="value">Value.</param>
    public void SetDownloadProgress(float value)
    {

        if (value + 0.05f > 1)
        {
            value = 1;
        }

        if (downloadProgressImage != null)
            downloadProgressImage.fillAmount = value;
    }

    public bool Interrupted
    {
        get { return this.interrupted; }
    }

    public bool IsPlaying
    {
        get { return this.audioSource.isPlaying; }
    }

    public bool Muted
    {
        get { return this.muted; }
    }

    public bool isLoop
    {
        get { return this.loop; }
    }

    [System.Serializable]
    public class MusicClip
    {
        public bool showContents = true;
        public AudioClip audioClip;
        public AudioType audioType = AudioType.UNKNOWN;
        public string url;
        public Sprite icon;
        public string name;
        public Type type;

        public enum Type
        {
            BUILT_IN,
            URL
        }

        ;
    }
}