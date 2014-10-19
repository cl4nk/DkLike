using UnityEngine;

public class Explosion_roue : MonoBehaviour
{
	public static Explosion_roue Instance;
	
	public ParticleSystem explosion_roue;
	
	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of Explosion_roue!");
		}
		
		Instance = this;
	}

	public void Explosion(Vector3 position)
	{
		instantiate(explosion_roue, position);
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