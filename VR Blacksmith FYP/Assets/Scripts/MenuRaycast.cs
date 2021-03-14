
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuRaycast : MonoBehaviour
{
    private int layerMask = 1 << 11;
    // Update is called once per frame
    void Update()
    {
        foreach (OVRGrabber hand in gameObject.GetComponentsInChildren<OVRGrabber>())
        {
            RaycastHit hit;
            Vector3 rayPos = new Vector3(hand.gameObject.transform.position.x, hand.gameObject.transform.position.y, hand.gameObject.transform.position.z + 0.1F);
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick) || OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
            {
                hand.gameObject.GetComponent<LineRenderer>().enabled = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstick) || OVRInput.GetUp(OVRInput.Button.SecondaryThumbstick))
            {
                hand.GetComponent<LineRenderer>().enabled = false;
                if (Physics.Raycast(rayPos, hand.gameObject.transform.forward, out hit, Mathf.Infinity, layerMask))
                {
                    Debug.Log("Hit: " + hit.collider.name);
                    if(hit.collider.name == "Exit")
                    {
                        Debug.Log("Exit");
                        Application.Quit();
                    }
                    if(hit.collider.name == "Start")
                    {
                        Debug.Log("Start");
                        SceneManager.LoadScene(1);
                    }
                }
            }
        }
    }
}
