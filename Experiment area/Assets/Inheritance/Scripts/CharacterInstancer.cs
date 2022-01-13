using UnityEngine;

public class CharacterInstancer : MonoBehaviour
{
    private WizardCharacter wizConfig;
    public WizardCharacter wizSetUpObj;
    public ColorList colorListObj;

    void Start()
    {
        wizConfig = ScriptableObject.CreateInstance<WizardCharacter>(); //creating the instance of the character within the instancer
        /*        manual setup for color
        wizConfig.skinColor = Color.red; //changing something WizardCharacter inherited (manual setup)
        wizConfig.wizardHatColor = Color.magenta; //changing something WizardCharacter initialized (manual setup)
        */
        
        
        wizConfig.wizardHatColor = wizSetUpObj.wizardHatColor; //Sets wizConfig hat color to wizSetUp hat color
        var num = Random.Range(0, colorListObj.colors.Count - 1);
        
        wizConfig.Walk();
        print(wizConfig.wizardHatColor);
    }
}
