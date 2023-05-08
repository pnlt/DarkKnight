using System.Collections;
using UnityEngine;

public class SafeGroundSaver : MonoBehaviour
{
    [SerializeField] private float saveFrequency = 3f;

    public Vector2 SafeGroundLocation { get; private set;} = new Vector2(0f, 0f);
    private Coroutine safeGroundCoroutine;
    private GroundCheck groundCheck;

    private void Start()
    {
        safeGroundCoroutine = StartCoroutine(SaveGroundLocation());
        
        SafeGroundLocation = transform.position;
        groundCheck = GetComponent<GroundCheck>();
    }

    private IEnumerator SaveGroundLocation()
    {
        float elapsedTime = 0f;
        while(elapsedTime < saveFrequency){
            elapsedTime += Time.deltaTime;
            yield return null;

        }
        if (groundCheck.IsGrounded()) 
        {

        SafeGroundLocation = transform.position;
        }

        safeGroundCoroutine = StartCoroutine(SaveGroundLocation());
    }

    public void WarpPlayerToSafeGround()
    {
        transform.position = SafeGroundLocation;
    }
}

