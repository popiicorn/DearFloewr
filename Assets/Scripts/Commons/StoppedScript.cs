using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ParticleSystem))]
public class StoppedScript : MonoBehaviour
{
	[SerializeField] UnityEvent OnComplete;
	void Start()
	{
		var main = GetComponent<ParticleSystem>().main;

		// StopActionはCallbackに設定している必要がある
		main.stopAction = ParticleSystemStopAction.Callback;
	}

	void OnParticleSystemStopped()
	{
		OnComplete?.Invoke();
	}

}