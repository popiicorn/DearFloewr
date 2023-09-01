using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ParticleSystem))]
public class StoppedScript : MonoBehaviour
{
	[SerializeField] UnityEvent OnComplete;
	void Start()
	{
		var main = GetComponent<ParticleSystem>().main;

		// StopAction��Callback�ɐݒ肵�Ă���K�v������
		main.stopAction = ParticleSystemStopAction.Callback;
	}

	void OnParticleSystemStopped()
	{
		OnComplete?.Invoke();
	}

}