using UFE3D;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "ScriptableObjects/AbilityData", order = 1)]
public class AbilityData : ScriptableObject
{
    [SerializeField] bool selected;
    [SerializeField] string description;
    [SerializeField] MoveInfo[] moves;

    public bool Selected { get => this.selected; set => this.selected = value; }
    public MoveInfo[] Moves { get => this.moves; }
    public string Description { get => this.description; }

    private void OnDisable()
    {
        selected = false;
    }
}