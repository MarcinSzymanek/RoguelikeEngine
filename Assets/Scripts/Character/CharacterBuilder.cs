using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuilder
{
	static public AIBase ChooseAI(AITypes.AIType type, Transform tf){
		if(type ==	AITypes.AIType.BASIC_MELEE){
			return new AIBasicMelee(tf);
		}
		return null;
	}
}
