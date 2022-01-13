using UnityEngine;

[CreateAssetMenu]
public class WizardCharacter : CharacterBase
{
    public Color wizardHatColor = Color.blue;//unique to WizardCharacter
    //still inherits skin color from CharacterBase

    public override void Walk() //allows you to override the default inherited walk
    {
        base.Walk();
    }
}
