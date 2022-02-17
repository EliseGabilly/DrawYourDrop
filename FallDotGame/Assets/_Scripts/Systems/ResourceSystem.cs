/// <summary>
/// Repository with scriptable objects, query methods here 
/// Make MonoBehaviour to add some debug/development references in the editor else standard class
/// </summary>
public class ResourceSystem : StaticInstance<ResourceSystem> {


    protected override void Awake() {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources() {
    }

}