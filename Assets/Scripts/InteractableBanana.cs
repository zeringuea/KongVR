namespace VRTK
{
    using UnityEngine;

    public class InteractableBanana : MonoBehaviour
    {
        public VRTK_InteractableObject linkedObject;
        public float spinSpeed = 50f;

        public AudioClip EatingClip;
        public AudioSource audioSource;

        public string teleportToScene = "";

        protected bool spinning, isHeld, eating = false;

        protected virtual void OnEnable()
        {
            spinning = true;
            isHeld = false;
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

            if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed += InteractableObjectUsed;
                linkedObject.InteractableObjectUnused += InteractableObjectUnused;

                linkedObject.InteractableObjectGrabbed += InteractableObjectGrabbed;
                linkedObject.InteractableObjectUngrabbed += InteractableObjectUngrabbed;
            }
        }

        protected virtual void OnDisable()
        {
            if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
                linkedObject.InteractableObjectUnused -= InteractableObjectUnused;
            }
        }

        protected virtual void Update()
        {
            if (spinning)
            {
                transform.Rotate(new Vector3(0f, spinSpeed * Time.deltaTime, 0f));
            }
            if (eating == true && audioSource.isPlaying == false)
            {
                Destroy(gameObject);
            }
        }

        public bool IsHeld()
        {
            return isHeld;
        }

        protected virtual void InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
        {
            spinning = false;
            isHeld = true;
        }

        protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
        {
            spinning = true;
            isHeld = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
        {
            //spinning = true;
            // if (in head trigger range) destroy, increment counter
            Debug.Log("Banana used");
        }

        protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
        {
            //spinning = false;
            Debug.Log("Banana unused");
        }

        public void Eat()
        {
            audioSource.clip = EatingClip;
            audioSource.Play();
            eating = true;
            GetComponent<MeshRenderer>().enabled = false;
            if (teleportToScene != "")
                UnityEngine.SceneManagement.SceneManager.LoadScene(teleportToScene);
        }
    }
}