namespace VRTK
{
    using UnityEngine;

    public class InteractableBanana : MonoBehaviour
    {
        public VRTK_InteractableObject linkedObject;
        public float spinSpeed = 50f;
        
        protected bool spinning, isHeld;

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
    }
}