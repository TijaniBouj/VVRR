using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnowmanConstruction : MonoBehaviour
{
    public GameObject bodyLower;
    public GameObject bodyStomach;
    public GameObject hat;
    public GameObject head;

    public Transform assemblyPoint; // Point where the snowman will be assembled

    private bool bodyLowerCollected = false;
    private bool bodyStomachCollected = false;
    private bool hatCollected = false;
    private bool headCollected = false;

    public EnemyActivation enemyActivation; // Reference to the EnemyActivation script

    void Start()
    {
        // Ensure the reference to EnemyActivation script is properly assigned
        if (enemyActivation == null)
        {
            Debug.LogError("EnemyActivation script reference is not assigned in SnowmanConstruction.");
        }
    }

    void Update()
    {
        CheckCompletion();
    }
    void CheckCompletion()
    {
        if (bodyLowerCollected && bodyStomachCollected && hatCollected && headCollected)
        {
            AssembleSnowman();
            enemyActivation.ActivateSmallEnemy(); // Call the method to activate the small enemy
            Debug.Log("Construction completed. Small enemy activated.");
        }
        else
        {
            Debug.Log("Not all parts collected yet.");
        }
    }

    void AssembleSnowman()
    {
        // Move each part to the assembly point
        bodyLower.transform.position = assemblyPoint.position - new Vector3(0f, 0.5f, 0f);
        bodyStomach.transform.position = assemblyPoint.position;
      
        head.transform.position = assemblyPoint.position + new Vector3(0f, 1.2f, 0f);
        hat.transform.position = assemblyPoint.position + new Vector3(0f, 0.7f, 0f);
    }

    // Functions to be called when the parts are collected
    public void CollectBodyLower(XRBaseInteractor interactor)
    {
        bodyLowerCollected = true;
        interactor.gameObject.SetActive(false); // Disable the object that was grabbed
    }

    public void CollectBodyStomach(XRBaseInteractor interactor)
    {
        bodyStomachCollected = true;
        interactor.gameObject.SetActive(false);
    }

    public void CollectHat(XRBaseInteractor interactor)
    {
        hatCollected = true;
        interactor.gameObject.SetActive(false);
    }

    public void CollectHead(XRBaseInteractor interactor)
    {
        headCollected = true;
        interactor.gameObject.SetActive(false);
    }

    
}