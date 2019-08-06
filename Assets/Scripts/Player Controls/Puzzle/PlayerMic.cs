using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMic : MonoBehaviour {
    //Microphone variables
    private AudioSource MicSource;
    public string Mic;
    private int MicSampleRate = 44100;

    //Audio measure
    private float UpdateStep = 0.1f;
    private int MicDataLength = 1024;
    private float CurrentUpdateTime = 0f;
    public float ClipLoudness;
    private float[] ClipSampleData;

    //Echolocation creation
    public Echolocation _echo;
    public Color WaveColor;
    public float WaveInterval;

    // Use this for initialization
    void Start() {
        //Grabs the audio source
        MicSource = GetComponent<AudioSource>();

        //Determines the microphone
        foreach (string Device in Microphone.devices) {
            //If there is no mic
            if (Mic == null) {
                Mic = Device;
            }
            Mic = Device;
        }

        ClipSampleData = new float[MicDataLength];

        MicrophoneUpdate();
    }

    void MicrophoneUpdate() {
        MicSource.Stop();

        //Starts recording the audioclip from the mic
        MicSource.clip = Microphone.Start(Mic, true, 10, MicSampleRate);
        MicSource.loop = true;

        //Mute the sound of the mic
        if (Microphone.IsRecording(Mic)) {
            while (!(Microphone.GetPosition(Mic) > 0)) {
            }
            MicSource.Play();
        }

    }

    void Update() {
        CurrentUpdateTime += Time.deltaTime;
        if (CurrentUpdateTime >= UpdateStep) {
            CurrentUpdateTime = 0f;
            MicSource.clip.GetData(ClipSampleData, MicSource.timeSamples);
            ClipLoudness = 0f;
            foreach (var sample in ClipSampleData) {
                ClipLoudness += Mathf.Abs(sample);
            }
            ClipLoudness /= MicDataLength;
        }

        if (ClipLoudness <= 0.0035f)
        {
            WaveColor = Color.Lerp(Color.gray, Color.black, 6.0f);
            WaveInterval = 0;
            _echo.OnDisable();
        }
        else {
            WaveColor = Color.Lerp(Color.black, Color.gray, 6.0f);
            WaveInterval = 30;
            _echo.OnEnable();
        }
    }

}
