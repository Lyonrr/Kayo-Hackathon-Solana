using UnityEngine;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] AbilityData abilityData;
    [SerializeField] private TMPro.TextMeshProUGUI abilityName;
    [SerializeField] private TMPro.TextMeshProUGUI abilityName2;
    private TMPro.TextMeshProUGUI abilityText;

    public AbilityData AbilityData { get => this.abilityData; }

    private void Start()
    {
        abilityText = GameObject.FindGameObjectWithTag("Description").GetComponent<TMPro.TextMeshProUGUI>();
        if (abilityData == null)
        {
            abilityName.text = abilityName2.text = "";
            return;

        }
        abilityData.Selected = false;
        abilityName.text = abilityName2.text = abilityData.name;
    }
    public void OnSelection(bool selected)
    {
        AbilityManager.instance.OnAbilitySelection(selected);

        if (abilityData == null)
            return;

        abilityData.Selected = selected;
        if (selected)
        {
            abilityText.text = abilityData.Description;
        }

        else
        {
            abilityText.text = "";
        }

    }
}
