using UnityEngine;
using UnityEngine.UI;

public class UIFunctions : MonoBehaviour
{
	public Text IDText;

	public InputField IDInput;

	public void SetID()
	{
		if (int.TryParse(IDInput.text, out int newID))
		{
			PlayerPrefs.SetInt("id", newID);

			IDText.text = "ID: " + IDInput.text;
		}
	}
}
