using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public GameObject target;
    public float heightOffset = 1.7f;
    public float distance = 12.0f;

    public float offsetFromWall = 0.1f;
    public float maxDistance = 20f;
    public float minDistance = 0.6f;
    public float xSpeed = 200.0f;
    public float ySpeed = 200.9f;
    public float yMinLimit = -80f;
    public float yMaxLimit = 80.0f;
    public float zoomSpeed = 40f;
    public float autoRotationSpeed = 3.0f;
    public float autoZoomSpeed = 5.0f;

    public LayerMask collisionLayers = -1;
    public bool alwaysRotateToRearofTarget = false;
    public bool allowMouseInputX = true;
    public bool allowMouseInputY = true;

    float xDeg = 0.0f;
    float yDeg = 0.0f;
    float currentDistance;
    float desiredDistance;
    float correctedDistance;
    bool rotateBehind = false;
    bool mouseSideButton = false;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        xDeg = angles.x;
        yDeg = angles.y;
        currentDistance = distance;
        desiredDistance = distance;
        correctedDistance = distance;

        rotateBehind = alwaysRotateToRearofTarget;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Toggle Move"))
        {
            mouseSideButton = !mouseSideButton;
        }
        if (mouseSideButton && (Input.GetAxis("Vertical") != 0) || Input.GetButton("Jump") || (Input.GetMouseButton(0) && Input.GetMouseButton(1)))
        {
            mouseSideButton = false;
        }
        if (GUIUtility.hotControl == 0)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                if (allowMouseInputX)
                {
                    xDeg += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                }
                else
                {
                    RotateBehindTarget();
                }
                if (allowMouseInputY)
                {
                    yDeg -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                }
                if (!alwaysRotateToRearofTarget)
                    rotateBehind = false;
            }
            else if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 || rotateBehind || mouseSideButton)
            {
                RotateBehindTarget();
            }

            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(yDeg, xDeg, 0);

            desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomSpeed * Mathf.Abs(desiredDistance);
            desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);

            correctedDistance = desiredDistance;

            Vector3 vTargetOffset = new Vector3(0, -heightOffset, 0);
            Vector3 position = target.transform.position - (rotation * Vector3.forward * desiredDistance + vTargetOffset);

            RaycastHit collisionHit;
            Vector3 trueTargetPosition = new Vector3(target.transform.position.x, target.transform.position.y + heightOffset, target.transform.position.z);

            bool isCorrected = false;
            if (Physics.Linecast(trueTargetPosition, position, out collisionHit, collisionLayers))
            {
                correctedDistance = Vector3.Distance(trueTargetPosition, collisionHit.point) - offsetFromWall;
                isCorrected = true;
            }

            if (!isCorrected || correctedDistance > currentDistance)
            {
                currentDistance = Mathf.Lerp(currentDistance, correctedDistance, Time.deltaTime * autoZoomSpeed);
            }
            else
            {
                currentDistance = correctedDistance;
            }

            currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

            position = target.transform.position - (rotation * Vector3.forward * currentDistance + vTargetOffset);

            transform.rotation = rotation;
            transform.position = position;




        }
    }

    void RotateBehindTarget()
    {
        float targetRotationAngle = target.transform.eulerAngles.y;
        float currentRotationAngle = transform.eulerAngles.y;
        xDeg = Mathf.LerpAngle(currentRotationAngle, targetRotationAngle, autoRotationSpeed * Time.deltaTime);

        if (targetRotationAngle == currentRotationAngle)
        {
            if (!alwaysRotateToRearofTarget)
                rotateBehind = false;
        }
        else
        {
            rotateBehind = true;
        }
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f)
            angle += 360f;

        if (angle > 360f)
            angle -= 360f;

        return Mathf.Clamp(angle, min, max);
    }
}
