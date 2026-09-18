using Game.Core;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnCategoryWeight", menuName = "Scriptable Objects/SpawnCategoryWeight")]
public class SpawnCategoryWeight : ScriptableObject
{
    [SerializeField] private SpawnableObjectFamily _family;
    public SpawnableObjectFamily Family => _family;

    [SerializeField] private SpawnableObjectCategory _category;
    public SpawnableObjectCategory Category => _category;

    [SerializeField] private int _weight; 
    public int Weight => _weight;
}
