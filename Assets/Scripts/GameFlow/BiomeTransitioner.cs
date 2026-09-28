using UnityEngine;
using System;
using System.Collections;
using Game.Events;
using Game.Data;
using Game.Core;

namespace Game.GameFlow
{
    public class BiomeTransitioner
    {
        private readonly GameStateConfigSo _data;

        private readonly BiomeProgression _biomeProgression;

        private readonly ICoroutineRunner _coroutineRunner;

        private readonly ICoroutineStopper _coroutineStopper;

        private Coroutine _transitionRoutine;

        public event Action OnWorldMovementResetRequested;

        public BiomeType CurrentBiome => _biomeProgression.CurrentBiome;

        public BiomeTransitioner(GameStateConfigSo data, ICoroutineRunner coroutineRunner, ICoroutineStopper coroutineStopper)
        {
            _biomeProgression = new BiomeProgression(data);

            _data = data;
            _coroutineRunner = coroutineRunner;
            _coroutineStopper = coroutineStopper;
        }

        public void ChangeBiome()
        {
            if (_biomeProgression.LastPhaseReached) return;

            if (_transitionRoutine != null) return;

            _transitionRoutine = _coroutineRunner.RunCoroutine(ChangeBiomeRoutine());
        }

        private IEnumerator ChangeBiomeRoutine()
        {
            yield return _biomeProgression.ChangeBiomeRoutine();

            SpawnerEvents.RaiseStopSpawners();

            InputEvents.RaisePauseInputDisableRequest();

            yield return new WaitForSeconds(_data.BiomesTransitionTime);

            ScreenTransitionEvents.RaiseRequestFadeOut();

            yield return new WaitForSeconds(_data.BiomesTransitionTime);

            InputEvents.RaisePauseInputEnableRequest();

            RaiseWorldMovementResetRequested();

            WorldEvents.RaiseBiomeTypeBroadcast(_biomeProgression.CurrentBiome);

            ScreenTransitionEvents.RaiseRequestFadeIn();

            _transitionRoutine = null;
        }

        private void RaiseWorldMovementResetRequested()
        {
            OnWorldMovementResetRequested?.Invoke();
        }

        public void StopTransition()
        {
            if (_transitionRoutine == null)
                return;

            _coroutineStopper.FinalizeCoroutine(_transitionRoutine);

            _transitionRoutine = null;
        }

        

    }

}
