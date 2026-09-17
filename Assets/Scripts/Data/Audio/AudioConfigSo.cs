using UnityEngine;
using System.Collections.Generic;
using Game.Data;

[CreateAssetMenu(fileName = "AudioConfigSo", menuName = "Scriptable Objects/AudioConfigSo")]
public class AudioConfigSo : ScriptableObject
{
    [SerializeField] private List<AudioDataSo> _audios;
    public List<AudioDataSo> Audios => _audios;
}
