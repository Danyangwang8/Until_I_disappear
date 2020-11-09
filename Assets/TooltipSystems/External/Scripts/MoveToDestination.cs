#region Author
/*
     
     Jones St. Lewis Cropper (caLLow)
     
     Another caLLowCreation
     
     Visit us on Google+ and other social media outlets @caLLowCreation
     
     Thanks for using our product.
     
     Send questions/comments/concerns/requests to 
      e-mail: caLLowCreation@gmail.com
      subject: Mobile Tooltip Systems Demo  
     
*/
#endregion

using UnityEngine;

namespace TooltipSystems.Extras
{
    /// <summary>
    /// Moves a transform to a destination along a direction vector
    /// </summary>
    [AddComponentMenu("Mobile Tooltip Systems/Extras/Move To Destination", 5)]
    public class MoveToDestination : MonoBehaviour
    {
        public float speed = 1.0f;
        public bool canMove { get; set; }

        Vector3 m_Direction = Vector3.zero;
        Transform m_Trans = null;
        Vector3 m_NewPosition = Vector3.zero;

        void Awake()
        {
            canMove = false;
            m_Trans = transform;
            m_NewPosition = transform.position;
        }

        public void OnRequestTooltip(TooltipUIEventData eventData)
        {
            RaycastHit hit;
            Ray ray;
            if (eventData.camera)
            {
                ray = eventData.camera.ScreenPointToRay(eventData.position);
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(eventData.position);
            }
            if (Physics.Raycast(ray, out hit))
            {
                float y = m_NewPosition.y;
                m_NewPosition = hit.point;
                m_NewPosition.y = y;
                canMove = true;
            }
        }

        void Update()
        {
            if(canMove)
            {
                m_Direction = m_NewPosition - transform.position;
                m_Trans.Translate(m_Direction * speed * Time.deltaTime);
            }
        }
       
        public void Stop()
        {
            canMove = false;
        }

        public void Go()
        {
            canMove = true;
        }

        public void Bounce()
        {
            speed *= -1;
        }
    }
}