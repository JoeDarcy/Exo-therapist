using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FaceGenerator : MonoBehaviour
{
    // Light sprite mask
    [SerializeField] private GameObject lightSpriteMask = null;
    private GameObject lightSpriteMaskInstance = null;

    // Dark faces, neck and shirt
    private GameObject darkFaceInstance = null;
    [SerializeField] private GameObject darkFace_1 = null;
    [SerializeField] private GameObject darkFace_2 = null;
    [SerializeField] private GameObject darkFace_3 = null;
    [SerializeField] private GameObject darkFace_4 = null;
    [SerializeField] private GameObject darkFace_5 = null;

    private GameObject darkShirtInstance = null;
    [SerializeField] private GameObject darkShirt = null;

    private GameObject darkNeckInstance = null;
    [SerializeField] private GameObject darkNeck = null;

    // Faces
    private GameObject faceInstance = null;
    private Color faceColour;
    [SerializeField] private GameObject face_1 = null;
	[SerializeField] private GameObject face_2 = null;
	[SerializeField] private GameObject face_3 = null;
	[SerializeField] private GameObject face_4 = null;
	[SerializeField] private GameObject face_5 = null;

    // Eyes
    private GameObject eyesInstance = null;
    [SerializeField] private GameObject eyes_1 = null;
    [SerializeField] private GameObject eyes_2 = null;
    [SerializeField] private GameObject eyes_3 = null;
    [SerializeField] private GameObject eyes_4 = null;
    [SerializeField] private GameObject eyes_5 = null;

    // Noses
    private GameObject noseInstance = null;
    [SerializeField] private GameObject nose_1 = null;
    [SerializeField] private GameObject nose_2 = null;
    [SerializeField] private GameObject nose_3 = null;
    [SerializeField] private GameObject nose_4 = null;
    [SerializeField] private GameObject nose_5 = null;

    // Mouths
    private GameObject mouthInstance = null;
    [SerializeField] private GameObject mouth_1 = null;
    [SerializeField] private GameObject mouth_2 = null;
    [SerializeField] private GameObject mouth_3 = null;
    [SerializeField] private GameObject mouth_4 = null;
    [SerializeField] private GameObject mouth_5 = null;

    // Eyebrows
    private GameObject eyebrowsInstance = null;
    [SerializeField] private GameObject eyebrows_1 = null;
    [SerializeField] private GameObject eyebrows_2 = null;
    [SerializeField] private GameObject eyebrows_3 = null;
    [SerializeField] private GameObject eyebrows_4 = null;
    [SerializeField] private GameObject eyebrows_5 = null;

    // Shirt
    private GameObject shirtInstance = null;
    [SerializeField] private GameObject shirt = null;

    // Neck
    private GameObject neckInstance = null;
    [SerializeField] private GameObject neck = null;

    // Trustworthiness
    public static int trustworthiness = 50;
    [SerializeField] private TMP_Text trustworthinessText = null;

    // Facial features 
    private int faceNumber;
    private int eyesNumber;
    private int noseNumber;
    private int mouthNumber;
    private int eyebrowsNumber;

    // Next patient 
    public static bool nextPatient = false;

    
    // Start is called before the first frame update
    void Start()
    {
        // Generate an expanding sprite mask to act as a light
        GenerateLightSpriteMask();

	    // Generate dark version of character
	    GenerateDarkVersion();

	    // Generate first face
	    GenerateFace();
    }
    

    // Update is called once per frame
    void Update()
    {
	    if (nextPatient && Conversation.sessionActive)
	    {
            // Reset trustworthiness level to 50 (neutral)
            trustworthiness = 50;

            // Generate an expanding sprite mask to act as a light
            GenerateLightSpriteMask();

            // Generate new face
            GenerateFace();

            // Generate dark version of character
            GenerateDarkVersion();

            // Update trustworthiness text
            trustworthinessText.text = "Trustworthiness: " + trustworthiness;

            // Reset next patient bool
            nextPatient = false;
	    }
    }

    // Set next patient on button press
    public void NextPatientButtonPressed()
    {
        nextPatient = true;

        Conversation.sessionActive = true;

        DestroyFace();
    }

    // Set hold or discharge button pressed
    public void DecisionMade()
    {
        DestroyFace();
    }

    // Destroy face instance
    private void DestroyFace()
    {
	    Destroy(faceInstance);
	    Destroy(neckInstance);
	    Destroy(shirtInstance);
	    Destroy(lightSpriteMaskInstance);
        Destroy(eyesInstance);
	    Destroy(noseInstance);
	    Destroy(mouthInstance);
	    Destroy(eyebrowsInstance);
	    Destroy(darkFaceInstance);
	    Destroy(darkNeckInstance);
	    Destroy(darkShirtInstance);
    }

    // Generate light sprite mask
    private void GenerateLightSpriteMask()
    {
	    lightSpriteMaskInstance = Instantiate(lightSpriteMask);
    }

    // Generate dark version of character
    private void GenerateDarkVersion()
    {
        // Instantiate dark shirt
        darkShirtInstance = Instantiate(darkShirt);

        // Instantiate dark neck
        darkNeckInstance = Instantiate(darkNeck);
    }

    // Face generation function
    private void GenerateFace()
    {
        // Choose random face
        faceNumber = Random.Range(1, 6);
        // Switch on faceNumber
        switch (faceNumber)
	    {
		    case 1:
			    darkFaceInstance = Instantiate(darkFace_1);
			    faceInstance = Instantiate(face_1);
			    trustworthiness += 5;
			    break;
		    case 2:
			    darkFaceInstance = Instantiate(darkFace_2);
                faceInstance = Instantiate(face_2);
			    trustworthiness -= 5;
			    break;
		    case 3:
			    darkFaceInstance = Instantiate(darkFace_3);
                faceInstance = Instantiate(face_3);
			    trustworthiness -= 15;
			    break;
		    case 4:
			    darkFaceInstance = Instantiate(darkFace_4);
                faceInstance = Instantiate(face_4);
			    trustworthiness += 15;
			    break;
		    case 5:
			    darkFaceInstance = Instantiate(darkFace_5);
                faceInstance = Instantiate(face_5);
			    trustworthiness -= 10;
			    break;
		    default:
			    darkFaceInstance = Instantiate(darkFace_1);
                faceInstance = Instantiate(face_1);
			    trustworthiness += 5;
			    break;
	    }

        // Assign random colour to face (within defined range of HSV)
        faceColour = Random.ColorHSV(0, 1, 0.3f, 1, 0.6f, 1);
        faceInstance.GetComponent<SpriteRenderer>().color = faceColour;

        // Instantiate neck and assign random colour (within defined range of HSV)
        neckInstance = Instantiate(neck);
        neckInstance.GetComponent<SpriteRenderer>().color = faceColour;

        // Instantiate shirt and assign random colour (within defined range of HSV)
        shirtInstance = Instantiate(shirt);
        shirtInstance.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0.3f, 0.7f, 0.6f, 0.8f);


        // Choose random eyes
        eyesNumber = Random.Range(1, 6);
        // Switch on eyesNumber
        switch (eyesNumber)
        {
            case 1:
                eyesInstance = Instantiate(eyes_1);
                trustworthiness += 5;
                break;
            case 2:
	            eyesInstance = Instantiate(eyes_2);
                trustworthiness -= 5;
                break;
            case 3:
	            eyesInstance = Instantiate(eyes_3);
                trustworthiness -= 15;
                break;
            case 4:
	            eyesInstance = Instantiate(eyes_4);
                trustworthiness += 15;
                break;
            case 5:
	            eyesInstance = Instantiate(eyes_5);
                trustworthiness -= 10;
                break;
            default:
	            eyesInstance = Instantiate(eyes_1);
                trustworthiness += 5;
                break;
        }

        // Choose random nose
        noseNumber = Random.Range(1, 6);
        // Switch on noseNumber
        switch (noseNumber)
        {
            case 1:
                noseInstance = Instantiate(nose_1);
                trustworthiness -= 10;
                break;
            case 2:
	            noseInstance = Instantiate(nose_2);
                trustworthiness += 5;
                break;
            case 3:
	            noseInstance = Instantiate(nose_3);
                trustworthiness += 15;
                break;
            case 4:
	            noseInstance = Instantiate(nose_4);
                trustworthiness -= 5;
                break;
            case 5:
	            noseInstance = Instantiate(nose_5);
                trustworthiness -= 15;
                break;
            default:
	            noseInstance = Instantiate(nose_1);
                trustworthiness -= 10;
                break;
        }

        // Choose random mouth
        mouthNumber = Random.Range(1, 6);
        // Switch on mouthNumber
        switch (mouthNumber)
        {
            case 1:
	            mouthInstance = Instantiate(mouth_1);
                trustworthiness += 15;
                break;
            case 2:
	            mouthInstance = Instantiate(mouth_2);
                trustworthiness -= 10;
                break;
            case 3:
	            mouthInstance = Instantiate(mouth_3);
                trustworthiness += 5;
                break;
            case 4:
	            mouthInstance = Instantiate(mouth_4);
                trustworthiness += 10;
                break;
            case 5:
	            mouthInstance = Instantiate(mouth_5);
                trustworthiness -= 15;
                break;
            default:
	            mouthInstance = Instantiate(mouth_1);
                trustworthiness += 15;
                break;
        }

        // Choose random eyebrows
        eyebrowsNumber = Random.Range(1, 6);
        // Switch on eyebrowsNumber
        switch (eyebrowsNumber)
        {
            case 1:
	            eyebrowsInstance = Instantiate(eyebrows_1);
                trustworthiness += 10;
                break;
            case 2:
	            eyebrowsInstance = Instantiate(eyebrows_2);
                trustworthiness += 5;
                break;
            case 3:
	            eyebrowsInstance = Instantiate(eyebrows_3);
                trustworthiness -= 10;
                break;
            case 4:
	            eyebrowsInstance = Instantiate(eyebrows_4);
                trustworthiness -= 5;
                break;
            case 5:
	            eyebrowsInstance = Instantiate(eyebrows_5);
                trustworthiness -= 15;
                break;
            default:
	            eyebrowsInstance = Instantiate(eyebrows_1);
                trustworthiness += 10;
                break;
        }
    }
}
