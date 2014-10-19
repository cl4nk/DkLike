using UnityEngine;


public class Explosion_tete : MonoBehaviour
{

	public static Explosion_tete Instance;
	
	public ParticleSystem explosion_tete;
	
	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of Explosion_tete!");
		}
		
		Instance = this;
	}

	public void Explosion(Vector3 position)
	{
		instantiate(explosion_tete, position);

	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
			) as ParticleSystem;

		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
			);
		
		return newParticleSystem;
	}
}