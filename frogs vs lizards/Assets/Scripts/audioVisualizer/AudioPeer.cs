using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    float[] _samples = new float[512];
    AudioSource _audioSourse;
    float[] _freqBand = new float[16];
    float[] _bandbuffer = new float[16];
    float[] _bufferDecrease = new float[16];
    float[] _freqBandHighest = new float[16];
    public static float[] _audioBand = new float[16];
    public static float[] _audioBandBuffer = new float[16];
    void Start()
    {
        _audioSourse = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
    }

    void GetSpectrumAudioSource()
    {
        _audioSourse.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 16; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(1, i) * 2;
            if (i == 15)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }
            average /= count;
            _freqBand[i] = average * 10;
        }
    }
    void BandBuffer()
    {
        for (int g = 0; g < 16; ++g)
        {
            if (_freqBand[g] > _bandbuffer[g])
            {
                _bandbuffer[g] = _freqBand[g];
                _bufferDecrease[g] = 0.005f;
            }
            if (_freqBand[g] < _bandbuffer[g])
            {
                _bandbuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }
    }
    void CreateAudioBands()
    {
        for (int i = 0; i < 16; i++)
        {
            if (_freqBand[i] > _freqBandHighest[i])
            {
                _freqBandHighest[i] = _freqBand[i];
            }
            _audioBand[i] = (_freqBand[i] / _freqBandHighest[i]);
            _audioBandBuffer[i] = (_bandbuffer[i] / _freqBandHighest[i]);
        }
    }
}

