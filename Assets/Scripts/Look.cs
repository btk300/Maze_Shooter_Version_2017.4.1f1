using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour 
{
    private float mouseSensitivity;
    public Transform PlayerBody;
    bool CursorLockedVar;
   
	void Start()
    {
        CursorLockedVar = true;
        mouseSensitivity = 2;

        LockCurser(CursorLockedVar);
	}

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = PlayerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotBody.y += rotAmountX;

        transform.rotation = Quaternion.Euler(targetRotCam);
        PlayerBody.rotation = Quaternion.Euler(targetRotBody);

        LockCurser(CursorLockedVar);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CursorLockedVar = !CursorLockedVar;
        }
        
    }

    void LockCurser(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            UnlockCurser();
        }
    }

    void UnlockCurser()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
