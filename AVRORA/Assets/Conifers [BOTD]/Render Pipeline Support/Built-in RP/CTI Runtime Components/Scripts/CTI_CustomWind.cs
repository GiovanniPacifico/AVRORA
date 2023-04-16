using UnityEngine;
using System.Collections;

namespace CTI {

    [RequireComponent(typeof(WindZone))]
    public class CTI_CustomWind : MonoBehaviour {

			    public float radius = 10.0f;
			    public float maxDistance = 50.0f;
			    public float maxExhalation = 1.0f;
			    public float maxInhalation = -1.0f;
			    public float windMultiplier = 1.0f;
			    public KeyCode inhalationKey = KeyCode.A;
			    public KeyCode exhalationKey = KeyCode.D;
			    public string characterTag = "Yellow";

			    private Transform characterTransform;
			    private WindZone windZone;
			    private float inhalation = 0.0f;
			    private float exhalation = 0.0f;

			    void Start() {
			        characterTransform = GameObject.FindGameObjectWithTag(characterTag).transform;
			        windZone = GetComponent<WindZone>();
			    }

			    void Update() {
			        float distanceToCharacter = Vector3.Distance(transform.position, characterTransform.position);
			        float intensity = 0.0f;

			        if (distanceToCharacter <= radius) {
			            intensity = 1.0f;
			        }
			        else if (distanceToCharacter < maxDistance) {
			            intensity = 1.0f - ((distanceToCharacter - radius) / (maxDistance - radius));
			        }

			        windZone.windMain = intensity * windMultiplier;

			        if (Input.GetKey(inhalationKey)) {
			            inhalation += Time.deltaTime;
			            inhalation = Mathf.Clamp(inhalation, 0.0f, maxInhalation);
			            exhalation = 0.0f;
			        }
			        else if (Input.GetKey(exhalationKey)) {
			            exhalation += Time.deltaTime;
			            exhalation = Mathf.Clamp(exhalation, 0.0f, maxExhalation);
			            inhalation = 0.0f;
			        }
			        else {
			            inhalation = 0.0f;
			            exhalation = 0.0f;
			        }

			        float bendFactor = exhalation - inhalation;
			        Shader.SetGlobalFloat("_BendFactor", bendFactor);
			    }
    }
}
