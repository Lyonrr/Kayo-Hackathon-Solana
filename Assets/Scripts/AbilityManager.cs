using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    public static AbilityManager instance;

    // Méthode d'accès statique (point d'accès global)

    [SerializeField] private TMPro.TextMeshProUGUI fightButtonText;
    [SerializeField] private Button fightButton;
    [SerializeField] private Image fightButtonImage;
    [SerializeField] private Color fightButtonDisabled;
    [SerializeField] private Color fightButtonEnabled;
    [SerializeField] private CanvasGroup abilityCanvas;
    [SerializeField] private CanvasGroup myFighterCanvas;
    [SerializeField] private CanvasGroup opponentCanvas;

    [SerializeField]
    private int nbAbilitiesMax = 4;

    private int nbAbilitiesSelected = 0;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)

        instance = this;
    }


    public void OnAbilitySelection(bool selected)
    {
        nbAbilitiesSelected += selected ? 1 : -1;
        UpdateUI();
    }

    private void UpdateUI()
    {
        fightButtonText.text = "Fight (" + nbAbilitiesSelected + "/" + nbAbilitiesMax.ToString() + ")";
        bool enableButton = nbAbilitiesSelected >= nbAbilitiesMax;
        fightButton.interactable = enableButton;
        fightButtonImage.color = enableButton ? fightButtonEnabled : fightButtonDisabled;
    }


    public void OnMyFighterButtonClick(bool open)
    {
        OnFighterMenuClick(open, myFighterCanvas);
    }

    public void OnOpponentButtonClick(bool open)
    {
        OnFighterMenuClick(open, opponentCanvas);
    }



    private void OnFighterMenuClick(bool open, CanvasGroup canvasGroup)
    {
        if (open)
        {
            abilityCanvas.alpha = 0.07f;
            canvasGroup.alpha = 1f;
        }

        else
        {
            abilityCanvas.alpha = 1f;
            canvasGroup.alpha = 0f;
        }
        abilityCanvas.blocksRaycasts = abilityCanvas.interactable = !open;
        canvasGroup.blocksRaycasts = canvasGroup.interactable = open;
    }
}
