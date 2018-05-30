using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

        public GameController GameController;
        private void Start()
        {
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }
            m_Character = GetComponent<ThirdPersonCharacter>();

            m_Character.m_MoveSpeedMultiplier = GameController.Speed;
            m_Character.m_AnimSpeedMultiplier = GameController.Speed;
        }


        private void Update()
        {
            if (GameController.isRunning) {
                if (!m_Jump) {
                    m_Jump = Input.touchCount > 0;
                    //m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                }
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            Vector3 position = this.transform.position;

            if (position.y < -10) {
                GameController.StartLose();
            }
            if(position.x > 530) {
                GameController.StartWin();
            }

            position.z = 0;
            this.transform.position = position;
            if (GameController.isRunning) {
                // read inputs
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
                bool crouch = false;// Input.GetKey(KeyCode.C);

                // we use world-relative directions in the case of no main camera
                //m_Move = v*Vector3.forward + h*Vector3.right;
                m_Move = new Vector3(1, 0, 0);

#if !MOBILE_INPUT
                // walk speed multiplier
                if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

                // pass all parameters to the character control script
                m_Character.Move(m_Move, crouch, m_Jump);
                m_Jump = false;
            }
        }
    }
}