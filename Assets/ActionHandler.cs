using UnityEngine;

public class ActionHandler : MonoBehaviour
{
	[System.Flags]
	public enum ActionTypes
	{
		Flee = 0,
		Attack = 1,
		Defend = 2,
		Stat = 4
	}

	// [System.Serializable]
	// public struct CombatInfluences
	// {
	// 	[System.Flags]
	// 	public enum FactorInfluencedBy
	// 	{
	// 		Health = 1,
	// 		Strength = 2,
	// 		Defense = 4,
	// 		Dexterity = 8,
	// 		Luck = 16
	// 	}
	// 	public FactorInfluencedBy factorInfluencedBy;
	// 	public float baseValue;

	// 	float heaFac, strFac, defFac, dexFac, lucFac;

	// 	public void SetFactorSourceValue(int OPCODE, float value)
	// 	{
	// 		switch(OPCODE)
	// 		{
	// 			case 0:
	// 				heaFac = value;
	// 			break;
	// 			case 1:
	// 				strFac = value;
	// 			break;
	// 			case 2:
	// 				defFac = value;
	// 			break;
	// 			case 3:
	// 				dexFac = value;
	// 			break;
	// 			case 4:
	// 				lucFac = value;
	// 			break;
	// 		}
	// 	}

	// 	public float GetComputedInfluence(ref float finalValue)
	// 	{
	// 		if((factorInfluencedBy & FactorInfluencedBy.Health) != 0)
	// 			baseValue += heaFac;
				
	// 		if((factorInfluencedBy & FactorInfluencedBy.Health) != 0)
	// 			baseValue += strFac;
				
	// 		if((factorInfluencedBy & FactorInfluencedBy.Health) != 0)
	// 			baseValue += defFac;
				
	// 		if((factorInfluencedBy & FactorInfluencedBy.Health) != 0)
	// 			baseValue += dexFac;
				
	// 		if((factorInfluencedBy & FactorInfluencedBy.Health) != 0)
	// 			baseValue += lucFac;
			
	// 		finalValue = baseValue;
	// 		return finalValue;
	// 	}
	// }

	//public CombatInfluences[] combatInfluences;
	
	[System.Serializable]
	public struct Influences
	{
		public float baseValue;

		[Range(-1, 1)]
		public float healthInfluence, strengthInfluence, defenseInfluence, dexterityInfluence, luckInfluence;
		
		public float GetComputedValue()
		{
			return baseValue * (1 + (healthInfluence + strengthInfluence + defenseInfluence + dexterityInfluence + luckInfluence));
		}
	}

	public Influences healthAlterations, strengthAlterations, defenseAlterations, dexterityAlterations, luckAlterations;
	public float finalHealth, finalStrength, finalDefense, finalDexterity, finalLuck;

	// Start is called before the first frame update
	void Start()
	{
		finalHealth = healthAlterations.GetComputedValue();
		finalStrength = strengthAlterations.GetComputedValue();
		finalDefense = defenseAlterations.GetComputedValue();
		finalDexterity = dexterityAlterations.GetComputedValue();
		finalLuck = luckAlterations.GetComputedValue();
	}

	// Update is called once per frame
	void Update()
	{

	}
}