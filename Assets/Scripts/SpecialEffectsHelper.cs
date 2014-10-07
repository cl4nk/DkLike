using UnityEngine;

public class SpecialEffectsHelper : MonoBehaviour
{

	public static SpecialEffectsHelper Instance;
	
	public ParticleSystem Explosion;
	
	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SpecialEffectsHelper!");
		}
		
		Instance = this;
	}

	public void Explosionplayer(Vector3 position)
	{
		// BOUM!!!!!!!!!
		instantiate(Explosion, position);

	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
			) as ParticleSystem;
		
		// Destruction programmée
		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
			);
		
		return newParticleSystem;
	}
}