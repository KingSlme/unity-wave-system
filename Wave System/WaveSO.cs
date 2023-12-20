using UnityEngine;

[CreateAssetMenu(fileName = "NewWaveSO", menuName = "WaveSO")]
public class WaveSO : ScriptableObject
{
    [System.Serializable]
    public struct EntityGroup
    {
        public Transform _transform;
        public int _amount;
    }

    [SerializeField] private EntityGroup[] _entityGroups;

    public EntityGroup[] EntityGroups => _entityGroups;
}