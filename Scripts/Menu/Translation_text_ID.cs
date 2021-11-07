using UnityEngine;
using TMPro;

public class Translation_text_ID : MonoBehaviour
{
    public int ID_Text;

    [HideInInspector]
    public TextMeshProUGUI UIText;

    private void Awake() {
        UIText = GetComponent<TextMeshProUGUI>();

        Translator.Add(this);
    }

    private void OnEnable() 
    {
        Translator.Update_texts();
    }

    private void OnDestroy() {
        Translator.Delete(this);
    }
}
