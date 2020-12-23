using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CombosData", menuName = "FighterDatas/CombosData")]
public class CombosData : ScriptableObject
{
    [Tooltip("La lista de combos del luchador")]
    public List<Combo> combas = new List<Combo>();
    [Tooltip("Lista de Ataque básicos")]
    public List<Attack> basicAttacks = new List<Attack>();
}
