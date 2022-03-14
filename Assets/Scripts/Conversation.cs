using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Conversation : MonoBehaviour
{
    // Text references for patient, doctor and nurse
    [SerializeField] private TMP_Text patientText = null;
    [SerializeField] private TMP_Text doctorText = null;
    [SerializeField] private TMP_Text nurseText = null;

    // Patient text lines
    [SerializeField] private string patientTextLine_1 = null;
    [SerializeField] private string patientTextLine_2 = null;
    [SerializeField] private string patientTextLine_3 = null;
    [SerializeField] private string patientTextLine_4 = null;
    [SerializeField] private string patientTextLine_5 = null;
    [SerializeField] private string patientTextLine_6 = null;
    [SerializeField] private string patientTextLine_7 = null;
    [SerializeField] private string patientTextLine_8 = null;
    [SerializeField] private string patientTextLine_9 = null;
    [SerializeField] private string patientTextLine_10 = null;

    // Patient text line number and string
    private int patientTextLineNumber = 0;
    private string patientTextLine = null;

    // Patient sex number, sex string, name number and name string
    private int patientSexNumber = 0;
    private string patientSex = null;
    private int patientNameNumber = 0;
    private string patientName = null;

    // Patient names
    [SerializeField] private string patientName_1 = null;
    [SerializeField] private string patientName_2 = null;
    [SerializeField] private string patientName_3 = null;
    [SerializeField] private string patientName_4 = null;
    [SerializeField] private string patientName_5 = null;
    [SerializeField] private string patientName_6 = null;
    [SerializeField] private string patientName_7 = null;
    [SerializeField] private string patientName_8 = null;
    [SerializeField] private string patientName_9 = null;
    [SerializeField] private string patientName_10 = null;

    // Text delay
    [SerializeField] private float textDelay = 0.0f;

    // Session active
    private bool sessionActive = true;

    // Start is called before the first frame update
    void Start()
    {
	    
    }

    // Update is called once per frame
    void Update()
    {
	    if (sessionActive)
	    {
		    
		    StartCoroutine(NewSession());
		    
		    

            sessionActive = false;
        }


	    //nurseText.text = "Hi I am the nurse";
    }

    // Pause
    IEnumerator NewSession()
    {
	    yield return new WaitForSeconds(textDelay);
        doctorText.text = DoctorText();
	    yield return new WaitForSeconds(textDelay);
        patientText.text = PatientText();
    }

    // Patient text
    private string PatientText()
    {
	    patientTextLineNumber = Random.Range(1, 11);

	    switch (patientTextLineNumber)
	    {
            case 1:
	            patientTextLine = patientTextLine_1;
                break;
            case 2:
	            patientTextLine = patientTextLine_2;
	            break;
            case 3:
	            patientTextLine = patientTextLine_3;
	            break;
            case 4:
	            patientTextLine = patientTextLine_4;
	            break;
            case 5:
	            patientTextLine = patientTextLine_5;
	            break;
            case 6:
	            patientTextLine = patientTextLine_6;
	            break;
            case 7:
	            patientTextLine = patientTextLine_7;
	            break;
            case 8:
	            patientTextLine = patientTextLine_8;
	            break;
            case 9:
	            patientTextLine = patientTextLine_9;
	            break;
            case 10:
	            patientTextLine = patientTextLine_10;
	            break;
            default:
	            patientTextLine = patientTextLine_1;
                break;
        }

	    return patientTextLine;
    }

    // Doctor text
    private string DoctorText()
    {
        // Patient sex
	    patientSexNumber = Random.Range(1, 4);

	    switch (patientSexNumber)
	    {
            case 1:
	            patientSex = "Mr. ";
                break;
            case 2:
	            patientSex = "Mrs. ";
                break;
            case 3:
	            patientSex = "Miss. ";
	            break;
            default:
	            patientSex = "Mr. ";
                break;
	    }

        // Patient name
	    patientNameNumber = Random.Range(1, 11);

	    switch (patientNameNumber)
	    {
            case 1:
	            patientName = patientName_1;
                break;
            case 2:
	            patientName = patientName_2;
	            break;
            case 3:
	            patientName = patientName_3;
	            break;
            case 4:
	            patientName = patientName_4;
	            break;
            case 5:
	            patientName = patientName_5;
	            break;
            case 6:
	            patientName = patientName_6;
	            break;
            case 7:
	            patientName = patientName_7;
	            break;
            case 8:
	            patientName = patientName_8;
	            break;
            case 9:
	            patientName = patientName_9;
	            break;
            case 10:
	            patientName = patientName_10;
	            break;
            default:
	            patientName = patientName_1;
                break;
	    }

	    return "Hello, " + patientSex + patientName + ". How are you feeling today?";
    }

	// Reset all text
	public void ResetAllText()
	{
        patientName = null;
        patientSex = null;
        patientTextLine = null;
        doctorText.text = null;
        patientText.text = null;

        // Restart session
        sessionActive = true;
    }
}
