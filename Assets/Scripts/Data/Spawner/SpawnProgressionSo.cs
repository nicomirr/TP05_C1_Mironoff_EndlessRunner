using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SpawnProgressionSo", menuName = "Scriptable Objects/SpawnProgressionSo")]
public class SpawnProgressionSo : ScriptableObject
{
    [SerializeField] private List<SpawnPhaseSo> _spawnPhases;
    public List<SpawnPhaseSo> SpawnPhases => _spawnPhases;
    
}
