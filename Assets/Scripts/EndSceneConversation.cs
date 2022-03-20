using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneConversation : MonoBehaviour
{
	[SerializeField] private float startDelay = 1.0f;
	[SerializeField] private float lineDelay = 2.0f;
	[SerializeField] private float textSpeed = 0.2f;

	[SerializeField] private TMP_Text doctorText = null;
	[SerializeField] private TMP_Text nurseText = null;

	[SerializeField] private string doctorLine_1 = null;
	[SerializeField] private string nurseLine_1 = null;
	[SerializeField] private string doctorLine_2 = null;
	[SerializeField] private string nurseLine_2 = null;
	[SerializeField] private string doctorLine_3 = null;
	[SerializeField] private string nurseLine_3 = null;
	[SerializeField] private string doctorLine_4 = null;
	[SerializeField] private string nurseLine_4 = null;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(EndConversation());
	}


	IEnumerator EndConversation()
	{
		// Line 1
		StartCoroutine(TypeText(doctorText, doctorLine_1, textSpeed, startDelay));
		yield return new WaitForSeconds(lineDelay / 2);
		StartCoroutine(TypeText(nurseText, nurseLine_1, textSpeed, startDelay));
		yield return new WaitForSeconds(lineDelay);
		ResetAllText();
		//Line 2
		StartCoroutine(TypeText(doctorText, doctorLine_2, textSpeed, startDelay));
		yield return new WaitForSeconds(lineDelay / 2);
		StartCoroutine(TypeText(nurseText, nurseLine_2, textSpeed, startDelay));
		yield return new WaitForSeconds(lineDelay);
		ResetAllText();
		// Line 3
		StartCoroutine(TypeText(doctorText, doctorLine_3, textSpeed, startDelay));
		yield return new WaitForSeconds(lineDelay / 2);
		StartCoroutine(TypeText(nurseText, nurseLine_3, textSpeed, startDelay));
		yield return new WaitForSeconds(lineDelay);
		ResetAllText();
		// Line 4
		StartCoroutine(TypeText(doctorText, doctorLine_4, textSpeed, startDelay));
		yield return new WaitForSeconds(lineDelay / 2);
		StartCoroutine(TypeText(nurseText, nurseLine_4, textSpeed, startDelay));
		yield return new WaitForSeconds(8.0f);

		SceneManager.LoadScene(3);
	}

    IEnumerator TypeText(TMP_Text textMeshProText, string textToType, float typeSpeed, float startDelay)
    {
	    // Start delay if applicable
	    yield return new WaitForSeconds(startDelay);

	    for (int i = 0; i < textToType.Length; ++i)
	    {
		    textMeshProText.text += textToType[i];
		    yield return new WaitForSeconds(typeSpeed);
	    }
    }

    private void ResetAllText()
    {
		doctorText.text = null;
		nurseText.text = null;
	}
}
