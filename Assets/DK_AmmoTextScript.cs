using TMPro;
using UnityEngine;

public class DK_AmmoTextScript : MonoBehaviour
{
    public TextMeshProUGUI TextMesh;
    private void Awake()
    {
        TextMesh = GetComponent<TextMeshProUGUI>();
    }
}
