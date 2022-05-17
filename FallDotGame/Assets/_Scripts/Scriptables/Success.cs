using UnityEngine;

[CreateAssetMenu(fileName = "Success", menuName = "Scriptable/Success")]
public class Success : ScriptableObject {

    [SerializeField]
    private Sprite illustration;
    public Sprite Illustration { get => illustration; }

    [SerializeField]
    private string description;
    public string Description { get => description; }

    [SerializeField]
    private int completionStep1;
    public int CompletionStep1 { get => completionStep1; }

    [SerializeField]
    private int completionStep2;
    public int CompletionStep2 { get => completionStep2; }

    [SerializeField]
    private int completionStep3;
    public int CompletionStep3 { get => completionStep3; }

    [SerializeField]
    private int completionStep4;
    public int CompletionStep4 { get => completionStep4; }


}
