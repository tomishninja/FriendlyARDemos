using UnityEngine;

public class WeepingAngleBehaviour : MonoBehaviour
{
    public Vector3 StartingDistanceFromUser = new Vector3(0,0,10);

    public float AmountToMoveEachSecond = 1;

    public GameObject gameObjectToMove;

    private bool isFacingUser = false;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObjectToMove == null)
        {
            this.gameObjectToMove = this.gameObject;
        }

        // we have the assumption that main camera starts at 0,0,0 in unity;
        this.gameObjectToMove.transform.position = StartingDistanceFromUser;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFacingUser)
        {
            if (Vector3.Distance(gameObjectToMove.transform.position, Camera.main.transform.position) > 0.5)
            {
                gameObjectToMove.transform.position = Vector3.MoveTowards(gameObject.transform.position, Camera.main.transform.position, AmountToMoveEachSecond / 60);
                gameObjectToMove.transform.position = new Vector3(gameObjectToMove.transform.position.x, StartingDistanceFromUser.y, gameObjectToMove.transform.position.z);
            }
                
            gameObjectToMove.transform.LookAt(Camera.main.transform.position);
        }
    }

    private void OnBecameInvisible()
    {
        isFacingUser = false;
        Debug.Log("INvisible");
    }

    private void OnBecameVisible()
    {
        isFacingUser = true;
        Debug.Log("visible");
    }
}
