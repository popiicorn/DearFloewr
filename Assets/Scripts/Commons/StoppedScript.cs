using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ParticleSystem))]
public class StoppedScript : MonoBehaviour
{
	[SerializeField] UnityEvent OnComplete;
	void Start()
	{
		var main = GetComponent<ParticleSystem>().main;

		// StopAction‚ÍCallback‚Éİ’è‚µ‚Ä‚¢‚é•K—v‚ª‚ ‚é
		main.stopAction = ParticleSystemStopAction.Callback;
	}

	void OnParticleSystemStopped()
	{
		OnComplete?.Invoke();
	}

}