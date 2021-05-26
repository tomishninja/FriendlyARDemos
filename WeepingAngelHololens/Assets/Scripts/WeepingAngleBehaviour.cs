using UnityEngine;

public class WeepingAngleBehaviour : MonoBehaviour
{
    public Vector3 StartingDistanceFromUser = new Vector3(0,0,10);

    public float AmountToMoveEachSecond = 1;

    private bool isFacingUser = false;

    // Start is called before the first frame update
    void Start()
    {
        // we have the assumption that main camera starts at 0,0,0 in unity;
        gameObject.transform.position = StartingDistanceFromUser;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFacingUser)
        {
            if (Vector3.Distance(gameObject.transform.position, Camera.main.transform.position) > 0.5)
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Camera.main.transform.position, AmountToMoveEachSecond / 60);
            gameObject.transform.LookAt(Camera.main.transform.position);
        }
    }

    private void OnBecameInvisible()
    {
        isFacingUser = false;
    }

    private void OnBecameVisible()
    {
        isFacingUser = true;
    }
}
