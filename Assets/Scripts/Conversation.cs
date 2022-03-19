using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    // Text references for patient, doctor and nurse
    [SerializeField] private TMP_Text patientText = null;
    [SerializeField] private TMP_Text doctorText = null;
    [SerializeField] private TMP_Text nurseText = null;
    [SerializeField] private TMP_Text adminText = null;
    private string adminTextLine;

    // Text backgrounds
    [SerializeField] private GameObject doctorTextBackground = null;
    [SerializeField] private GameObject patientTextBackground = null;

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

    // Doctors score
    private int doctorScore = 5;
    private int doctorScorePreviousFrame = 5;

    // Admin text strings for each level of warning
    [SerializeField] private string adminTextFirstVerbalWarning;
    [SerializeField] private string adminTextSecondVerbalWarning;
    [SerializeField] private string adminTextFirstWrittenWarning;
    [SerializeField] private string adminTextSecondWrittenWarning;
    [SerializeField] private string adminTextDismissal;

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

    // Nurse text lines for hold (Trustworthy)
    [SerializeField] private string holdTrustworthyNurseTextLine_1 = null;
    [SerializeField] private string holdTrustworthyNurseTextLine_2 = null;
    [SerializeField] private string holdTrustworthyNurseTextLine_3 = null;
    [SerializeField] private string holdTrustworthyNurseTextLine_4 = null;
    [SerializeField] private string holdTrustworthyNurseTextLine_5 = null;
    [SerializeField] private string holdTrustworthyNurseTextLine_6 = null;
    [SerializeField] private string holdTrustworthyNurseTextLine_7 = null;
    [SerializeField] private string holdTrustworthyNurseTextLine_8 = null;
    [SerializeField] private string holdTrustworthyNurseTextLine_9 = null;
    [SerializeField] private string holdTrustworthyNurseTextLine_10 = null;

    // Nurse text lines for discharge (Trustworthy)
    [SerializeField] private string dischargeTrustworthyNurseTextLine_1 = null;
    [SerializeField] private string dischargeTrustworthyNurseTextLine_2 = null;
    [SerializeField] private string dischargeTrustworthyNurseTextLine_3 = null;
    [SerializeField] private string dischargeTrustworthyNurseTextLine_4 = null;
    [SerializeField] private string dischargeTrustworthyNurseTextLine_5 = null;
    [SerializeField] private string dischargeTrustworthyNurseTextLine_6 = null;
    [SerializeField] private string dischargeTrustworthyNurseTextLine_7 = null;
    [SerializeField] private string dischargeTrustworthyNurseTextLine_8 = null;
    [SerializeField] private string dischargeTrustworthyNurseTextLine_9 = null;
    [SerializeField] private string dischargeTrustworthyNurseTextLine_10 = null;

    // Nurse text lines for hold (Untrustworthy)
    [SerializeField] private string holdUntrustworthyNurseTextLine_1 = null;
    [SerializeField] private string holdUntrustworthyNurseTextLine_2 = null;
    [SerializeField] private string holdUntrustworthyNurseTextLine_3 = null;
    [SerializeField] private string holdUntrustworthyNurseTextLine_4 = null;
    [SerializeField] private string holdUntrustworthyNurseTextLine_5 = null;
    [SerializeField] private string holdUntrustworthyNurseTextLine_6 = null;
    [SerializeField] private string holdUntrustworthyNurseTextLine_7 = null;
    [SerializeField] private string holdUntrustworthyNurseTextLine_8 = null;
    [SerializeField] private string holdUntrustworthyNurseTextLine_9 = null;
    [SerializeField] private string holdUntrustworthyNurseTextLine_10 = null;

    // Nurse text lines for discharge (Untrustworthy)
    [SerializeField] private string dischargeUntrustworthyNurseTextLine_1 = null;
    [SerializeField] private string dischargeUntrustworthyNurseTextLine_2 = null;
    [SerializeField] private string dischargeUntrustworthyNurseTextLine_3 = null;
    [SerializeField] private string dischargeUntrustworthyNurseTextLine_4 = null;
    [SerializeField] private string dischargeUntrustworthyNurseTextLine_5 = null;
    [SerializeField] private string dischargeUntrustworthyNurseTextLine_6 = null;
    [SerializeField] private string dischargeUntrustworthyNurseTextLine_7 = null;
    [SerializeField] private string dischargeUntrustworthyNurseTextLine_8 = null;
    [SerializeField] private string dischargeUntrustworthyNurseTextLine_9 = null;
    [SerializeField] private string dischargeUntrustworthyNurseTextLine_10 = null;

    // Nurse text line
    private int holdPatientTextNumber = 0;
    private int dischargePatientTextNumber = 0;
    private string nurseTextLine = null;

    // Nurse movement animator
    [SerializeField] private Animator nurseAnimator = null;

    // Nurse letter movement animator
    [SerializeField] private Animator nurseLetterAnimator = null;

    // Admin letter movement animator
    [SerializeField] private Animator adminLetterAnimator = null;

    // Text delay
    [SerializeField] private float textDelay = 0.0f;

    // Session active
    public static bool sessionActive = true;

    // Session results
    private bool decisionMade = false;

    // Doctors decision
    private bool holdPatient = false;
    private bool dischargePatient = false;

    // UI buttons 
    [SerializeField] private Button nextPatientButton = null;
    [SerializeField] private Button holdPatientButton = null;
    [SerializeField] private Button dischargePatientButton = null;

    
    // Update is called once per frame
    void Update()
    {
	    if (sessionActive)
	    {
		    // Set up new session
		    StartCoroutine(NewSession());

            // Deactivate session
            sessionActive = false;
        }

        if (decisionMade)
        {
            // Get results of session from nurse
            StartCoroutine(ResultsOfSession());

            // Disable hold and discharge patient buttons interactions
            holdPatientButton.interactable = false;
            dischargePatientButton.interactable = false;

            // Reset results
            decisionMade = false;
        }
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

    // Disable next patient button interactions and enable hold and discharge patient buttons interactions
    private void SetUpDecisionButtons()
    {
	    // Disable next patient button interactions
	    nextPatientButton.interactable = false;
	    // Enable hold and discharge patient buttons interactions
	    holdPatientButton.interactable = true;
	    dischargePatientButton.interactable = true;
    }

    // Enable next patient button interactions and Disable hold and discharge patient buttons interactions
    private void SetUpNextPatientButton()
    {
	    // Enable next patient button interactions
	    nextPatientButton.interactable = true;
	    // Disable hold and discharge patient buttons interactions
	    holdPatientButton.interactable = false;
	    dischargePatientButton.interactable = false;
    }

    // New session set up
    IEnumerator NewSession()
    {
        // Trigger admin letter enter animation
        adminLetterAnimator.SetBool("LetterEnter", false);   // Reset admin letter enter bool
        adminLetterAnimator.SetBool("LetterExit", true);   // Set admin letter exit bool

        // Trigger nurse letter exit animation
        nurseLetterAnimator.SetBool("LetterEnter", false);   // Reset nurse letter enter bool
        nurseLetterAnimator.SetBool("LetterExit", true);   // Set nurse letter exit bool

        // Pause then print doctor text
        yield return new WaitForSeconds(textDelay * 2);
        // Activate text background for doctor
        doctorTextBackground.SetActive(true);
        StartCoroutine(TypeText(doctorText , DoctorText(), 0.02f, 0.0f));
        // Pause then print patient response
	    yield return new WaitForSeconds(textDelay * 2);
        // Activate text background for patient
        patientTextBackground.SetActive(true);
        StartCoroutine(TypeText(patientText, PatientText(), 0.02f, 0.0f));
        yield return new WaitForSeconds(textDelay * 2);

        // Enable decision buttons and disable next patient button
        SetUpDecisionButtons();
    }

    // Results of session
    IEnumerator ResultsOfSession()
    {
	    // Deactivate text backgrounds for doctor and patient
        doctorTextBackground.SetActive(false);
        patientTextBackground.SetActive(false);

        // Trigger nurse enter animation
        nurseAnimator.SetBool("NurseExit", false);  // Reset nurse exit bool
        nurseAnimator.SetBool("NurseEnter", true);  // Set nurse enter bool
        yield return new WaitForSeconds(textDelay * 2);

        // Trigger nurse letter enter animation
        nurseLetterAnimator.SetBool("LetterExit", false);   // Reset nurse letter exit bool
        nurseLetterAnimator.SetBool("LetterEnter", true);   // Set nurse letter enter bool

        // Set nurse response
        StartCoroutine(TypeText(nurseText, NurseText(), 0.02f, 1.8f));
        yield return new WaitForSeconds(textDelay * 5);

        // Admin text if score is less than previous frame
        if (doctorScore < doctorScorePreviousFrame)
        {
            // Trigger admin letter enter animation
            adminLetterAnimator.SetBool("LetterExit", false);   // Reset admin letter exit bool
            adminLetterAnimator.SetBool("LetterEnter", true);   // Set admin letter enter bool
            yield return new WaitForSeconds(0.5f);
            ResetAllText();

            StartCoroutine(TypeText(adminText, AdminText(), 0.02f, 1.8f));
        }

        // Output doctor's score
        Debug.Log("Doctor's Score: " + doctorScore);

        // Set doctors score from previous session
        doctorScorePreviousFrame = doctorScore;

        // Trigger nurse exit animation
        nurseAnimator.SetBool("NurseEnter", false);  // Reset nurse enter bool
        nurseAnimator.SetBool("NurseExit", true);
        yield return new WaitForSeconds(textDelay / 2);

        // Enable next patient button
        SetUpNextPatientButton();
    }

    // Admin text
    private string AdminText()
    {
	    switch (doctorScore)
	    {
            case 4:
	            adminTextLine = adminTextFirstVerbalWarning;
                break;
            case 3:
	            adminTextLine = adminTextSecondVerbalWarning;
                break;
            case 2:
                adminTextLine = adminTextFirstWrittenWarning;
                break;
            case 1:
                adminTextLine = adminTextSecondWrittenWarning;
                break;
            case 0:
                adminTextLine = adminTextDismissal;
                break;
        }
        return adminTextLine;
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

    // Nurse text
    private string NurseText()
    {
        if (holdPatient)
        {
            if (FaceGenerator.trustworthiness >= 50)
            {
                // Decrement doctor's score
                doctorScore -= 1;

                holdPatientTextNumber = Random.Range(1, 11);

                switch (holdPatientTextNumber)
                {
                    case 1:
                        nurseTextLine = holdTrustworthyNurseTextLine_1;
                        break;
                    case 2:
                        nurseTextLine = holdTrustworthyNurseTextLine_2;
                        break;
                    case 3:
                        nurseTextLine = holdTrustworthyNurseTextLine_3;
                        break;
                    case 4:
                        nurseTextLine = holdTrustworthyNurseTextLine_4;
                        break;
                    case 5:
                        nurseTextLine = holdTrustworthyNurseTextLine_5;
                        break;
                    case 6:
                        nurseTextLine = holdTrustworthyNurseTextLine_6;
                        break;
                    case 7:
                        nurseTextLine = holdTrustworthyNurseTextLine_7;
                        break;
                    case 8:
                        nurseTextLine = holdTrustworthyNurseTextLine_8;
                        break;
                    case 9:
                        nurseTextLine = holdTrustworthyNurseTextLine_9;
                        break;
                    case 10:
                        nurseTextLine = holdTrustworthyNurseTextLine_10;
                        break;
                    default:
                        nurseTextLine = holdTrustworthyNurseTextLine_1;
                        break;
                }
            }

            if (FaceGenerator.trustworthiness < 50)
            {
	            holdPatientTextNumber = Random.Range(1, 11);

                switch (holdPatientTextNumber)
                {
                    case 1:
                        nurseTextLine = holdUntrustworthyNurseTextLine_1;
                        break;
                    case 2:
                        nurseTextLine = holdUntrustworthyNurseTextLine_2;
                        break;
                    case 3:
                        nurseTextLine = holdUntrustworthyNurseTextLine_3;
                        break;
                    case 4:
                        nurseTextLine = holdUntrustworthyNurseTextLine_4;
                        break;
                    case 5:
                        nurseTextLine = holdUntrustworthyNurseTextLine_5;
                        break;
                    case 6:
                        nurseTextLine = holdUntrustworthyNurseTextLine_6;
                        break;
                    case 7:
                        nurseTextLine = holdUntrustworthyNurseTextLine_7;
                        break;
                    case 8:
                        nurseTextLine = holdUntrustworthyNurseTextLine_8;
                        break;
                    case 9:
                        nurseTextLine = holdUntrustworthyNurseTextLine_9;
                        break;
                    case 10:
                        nurseTextLine = holdUntrustworthyNurseTextLine_10;
                        break;
                    default:
                        nurseTextLine = holdUntrustworthyNurseTextLine_1;
                        break;
                }
            }
        }

        if (dischargePatient)
        {
            if (FaceGenerator.trustworthiness >= 50)
            {
	            dischargePatientTextNumber = Random.Range(1, 11);

                switch (dischargePatientTextNumber)
                {
                    case 1:
                        nurseTextLine = dischargeTrustworthyNurseTextLine_1;
                        break;
                    case 2:
                        nurseTextLine = dischargeTrustworthyNurseTextLine_2;
                        break;
                    case 3:
                        nurseTextLine = dischargeTrustworthyNurseTextLine_3;
                        break;
                    case 4:
                        nurseTextLine = dischargeTrustworthyNurseTextLine_4;
                        break;
                    case 5:
                        nurseTextLine = dischargeTrustworthyNurseTextLine_5;
                        break;
                    case 6:
                        nurseTextLine = dischargeTrustworthyNurseTextLine_6;
                        break;
                    case 7:
                        nurseTextLine = dischargeTrustworthyNurseTextLine_7;
                        break;
                    case 8:
                        nurseTextLine = dischargeTrustworthyNurseTextLine_8;
                        break;
                    case 9:
                        nurseTextLine = dischargeTrustworthyNurseTextLine_9;
                        break;
                    case 10:
                        nurseTextLine = dischargeTrustworthyNurseTextLine_10;
                        break;
                    default:
                        nurseTextLine = dischargeTrustworthyNurseTextLine_1;
                        break;
                }
            }

            if (FaceGenerator.trustworthiness < 50)
            {
                // Decrement doctor's score
                doctorScore -= 1;

                dischargePatientTextNumber = Random.Range(1, 11);

                switch (dischargePatientTextNumber)
                {
                    case 1:
                        nurseTextLine = dischargeUntrustworthyNurseTextLine_1;
                        break;
                    case 2:
                        nurseTextLine = dischargeUntrustworthyNurseTextLine_2;
                        break;
                    case 3:
                        nurseTextLine = dischargeUntrustworthyNurseTextLine_3;
                        break;
                    case 4:
                        nurseTextLine = dischargeUntrustworthyNurseTextLine_4;
                        break;
                    case 5:
                        nurseTextLine = dischargeUntrustworthyNurseTextLine_5;
                        break;
                    case 6:
                        nurseTextLine = dischargeUntrustworthyNurseTextLine_6;
                        break;
                    case 7:
                        nurseTextLine = dischargeUntrustworthyNurseTextLine_7;
                        break;
                    case 8:
                        nurseTextLine = dischargeUntrustworthyNurseTextLine_8;
                        break;
                    case 9:
                        nurseTextLine = dischargeUntrustworthyNurseTextLine_9;
                        break;
                    case 10:
                        nurseTextLine = dischargeUntrustworthyNurseTextLine_10;
                        break;
                    default:
                        nurseTextLine = dischargeUntrustworthyNurseTextLine_1;
                        break;
                }
            }
        }

        // Reset hold and discharge bools
        holdPatient = false;
        dischargePatient = false;

        // Return nurse line
        return "Hello Doctor, here are the results of your last session: " + nurseTextLine;
    }


	// Reset all text
	public void ResetAllText()
	{
        patientName = null;
        patientSex = null;
        patientTextLine = null;
        doctorText.text = null;
        patientText.text = null;
        nurseText.text = null;
        adminText.text = null;
    }

    // Trigger results
    public void TriggerResults()
    {
        decisionMade = true;
    }

    // Hold patient
    public void HoldPatient()
    {
        holdPatient = true;
    }

    // Discharge patient
    public void DischargePatient()
    {
        dischargePatient = true;
    }
}
