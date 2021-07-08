using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform objTransform;
    public enum GameMode { start, lose, playing, restart}

    public GameMode gameMode;
    private Vector3 shootCoordinates;
    private Vector3 lineTrajectory;
    public static int collisionAmount;
    public static bool isFinished;
    [SerializeField] private LineRenderer line;

    public IEnumerator ForceController()
    {
        yield return new WaitForSeconds(1f);
        while (gameMode == GameMode.playing)
        {
            if (Input.GetKey(KeyCode.Mouse0) && collisionAmount > 0)
            {
                lineTrajectory = (shootCoordinates - Input.mousePosition)/100;
                DrawTrajectory(objTransform.position, lineTrajectory);

            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && collisionAmount > 0)
            {
                shootCoordinates = Input.mousePosition;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0) && collisionAmount > 0)
            {
                shootCoordinates -= Input.mousePosition;
                line.positionCount = 0;
                rb.AddForce(shootCoordinates / 20, ForceMode.Impulse);
            }

            yield return null;
        }
    }

    void DrawTrajectory(Vector3 startPos, Vector3 startVelocity)
    {
        int verts = 100;
        line.positionCount = 100;

        Vector3 pos = startPos;
        Vector3 vel = startVelocity;
        Vector3 grav = Physics.gravity;
        for (var i = 0; i < verts; i++)
        {
            line.SetPosition(i, new Vector3(pos.x, pos.y, -3));
            vel += grav * Time.fixedDeltaTime;
            pos += vel * Time.fixedDeltaTime;
        }
    }
}
