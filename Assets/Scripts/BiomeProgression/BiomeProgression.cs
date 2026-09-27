using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Game.Core;
using Game.Data;

namespace Game.GameState
{
    public class BiomeProgression
    {
        private readonly List<BiomePhase> _biomePhases;

        private BiomeType _currentBiome;
        public BiomeType CurrentBiome => _currentBiome;

        private int _currentBiomeIndex;

        public bool LastPhaseReached => _currentBiomeIndex == _biomePhases.Count - 1; 

        public BiomeProgression(GameStateConfigSo data)
        {
            _biomePhases = data.BiomePhasesData.Biomes;
            _currentBiomeIndex = 0;

            _currentBiome = _biomePhases[_currentBiomeIndex].BiomeType;
        }       

        public IEnumerator ChangeBiomeRoutine()
        {
            _currentBiomeIndex++;
            _currentBiome = _biomePhases[_currentBiomeIndex].BiomeType;
            yield return new WaitForSeconds(_biomePhases[_currentBiomeIndex].ChangeTime);
        }
    }
}

