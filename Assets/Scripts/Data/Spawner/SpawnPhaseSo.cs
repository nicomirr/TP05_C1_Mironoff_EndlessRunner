using UnityEngine;
using System.Collections.Generic;
using Game.Core;

[CreateAssetMenu(fileName = "SpawnPhaseSo", menuName = "Scriptable Objects/SpawnPhaseSo")]
public class SpawnPhaseSo : ScriptableObject
{
    [SerializeField] private List<SpawnableObjectCategory> _availableCategories;
    public List<SpawnableObjectCategory> AvailableCategories => _availableCategories;

    [SerializeField] private List<SpawnableObjectType> _availableTypes;
    public List<SpawnableObjectType> AvailableTypes => _availableTypes;
}
