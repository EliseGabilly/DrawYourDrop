using UnityEngine;

[CreateAssetMenu(fileName = "Collectible", menuName = "Scriptable/Collectibles")]
public class Items : ScriptableObject {

    [SerializeField]
    private GameObject objPrefab;
    public GameObject GO { get => objPrefab; }

    [SerializeField]
    private float minDiff;
    public float MinDiff { get => minDiff; }

    [SerializeField]
    private float maxDiff;
    public float MaxDiff { get => maxDiff; }

    [SerializeField]
    private bool isPowerUp = false;
    public bool IsPowerUp { get => isPowerUp; }

    [SerializeField]
    private int priority = 0;
    public int Priority { get => priority; }

}