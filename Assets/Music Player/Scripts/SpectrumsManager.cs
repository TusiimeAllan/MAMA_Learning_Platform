using UnityEngine;
using System.Collections;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

[DisallowMultipleComponent]
[ExecuteInEditMode]
public class SpectrumsManager : MonoBehaviour
{
	/// <summary>
	/// The spectrums transfrom references 
	/// </summary>
	public Transform[] spectrums;
	
	/// <summary>
	/// The number of spectrums.
	/// </summary>
	[Range(0,500)]
	public int spectrumsNumber = 65;
	
	/// <summary>
	/// The width of the specturm.
	/// </summary>
	[Range(0,1)]
	public float specturmWidth = 0.1f;

	[Range(0,1)]
	/// <summary>
	/// The minimum height of the spectrum.
	/// </summary>
	public float spectrumMinHeight = 0.02f;

	/// <summary>
	/// The specturm height factor.
	/// </summary>
	[Range(-10,10)]
	public float specturmHeightFactor = 4f;
	
	/// <summary>
	/// The x-offset between spectrums.
	/// </summary>
	[Range(0,10)]
	public float xOffset = 0.07f;
	
	/// <summary>
	/// The audio source referene.
	/// </summary>
	public AudioSource audioSource;
	
	/// <summary>
	/// The specturm prefab.
	/// </summary>
	public GameObject specturmPrefab;
	
	/// <summary>
	/// The spectrum parent reference.
	/// </summary>
	public Transform spectrumParent;
	
	/// <summary>
	/// The number of samples (must be power of two ie 128/256/512 etc).
	/// </summary>
	public int numberOfSamples = 4096;
	
	/// <summary>
	/// The channel.
	/// </summary>
	public int channel;
	
	/// <summary>
	/// The FFT window reference.
	/// </summary>
	public FFTWindow window = FFTWindow.Rectangular;

	/// <summary>
	/// The specturm height factor sign.
	/// </summary>
	private float specturmHeightFactorSign;
	
	/// <summary>
	/// The absolute value of the specturm height factor.
	/// </summary>
	private float specturmHeightFactorAbs;
	
	/// <summary>
	/// The spetrum spawn point transform reference.
	/// </summary>
	public Transform spetrumSpawnPointTransform;
	
	/// <summary>
	/// The color of the spectrums.
	/// </summary>
	public Color spectrumColor;
	
	/// <summary>
	/// The samples.
	/// </summary>
	[HideInInspector]
	public float[] samples;
	
	/// <summary>
	/// The spectrum in the world space.
	/// </summary>
	private GameObject spectrum;

	/// <summary>
	/// The specturm name prefix.
	/// </summary>
	private string specturmPrefix = "Specturm";

	private int previousSpecturmNumber = -1;

	// Use this for initialization
	void Start ()
	{
		specturmHeightFactorSign = Mathf.Sign (specturmHeightFactor);
		specturmHeightFactorAbs = Mathf.Abs (specturmHeightFactor);
		samples = new float[numberOfSamples];
		
		if (audioSource == null) {
			Debug.LogWarning ("AudioSoruce is undefined in <i>"+name+"</i>");
		}	

		if (Application.isPlaying) {
			//Create Specturms
			InitSpectrums ();
		}
	}
	
	/// <summary>
	/// Initialize the Audio Spectrums
	/// </summary>
	private void InitSpectrums ()
	{
		if (specturmPrefab == null) {
			Debug.LogWarning ("Spectrum prefab is undefined in <i>"+name+"</i>");
			return;
		}
		
		if (spectrumParent == null) {
			Debug.LogWarning ("Spectrum parent is undefined in <i>"+name+"</i>");
			return;
		}

		string spectrumName = null;

		//Destroy unused spectrums
		if (previousSpecturmNumber != spectrumsNumber) {
			if(previousSpecturmNumber !=-1 && spectrumsNumber < previousSpecturmNumber){
				for (int i=spectrumsNumber; i< previousSpecturmNumber; i++) {
					spectrumName = specturmPrefix  + (i + 1);
					Destroy(spectrumParent.Find(spectrumName).gameObject);
				}
			}
			previousSpecturmNumber = spectrumsNumber;
			spectrums = new Transform[spectrumsNumber];
		}

		//Create and update spectrums
		for (int i=0; i<spectrumsNumber; i++) {
			spectrumName = specturmPrefix  + (i + 1);
			Transform hierarchySpecturm = spectrumParent.Find(spectrumName);
			if(hierarchySpecturm == null){
				//Create new spectrum,set the position,set the name,set the color,set the parent
				GameObject spectrum = Instantiate (specturmPrefab, Vector3.zero, Quaternion.identity) as GameObject;
				spectrum.name = spectrumName;
				spectrum.transform.parent = spectrumParent;
				Vector3 tempPosition = new Vector3 (spetrumSpawnPointTransform.position.x + (i * (specturmWidth + xOffset)), spetrumSpawnPointTransform.position.y, spectrumParent.transform.position.z);
				spectrum.transform.position = tempPosition;
				spectrum.GetComponent<SpriteRenderer> ().color = spectrumColor;
				spectrum.transform.localScale = new Vector3 (specturmWidth,spectrumMinHeight,1);
				spectrums [i] = spectrum.transform;
			}else{
				//Update the specturm
				hierarchySpecturm.GetComponent<SpriteRenderer> ().color = spectrumColor;
				hierarchySpecturm.transform.localScale = new Vector3 (specturmWidth,spectrumMinHeight,1);
				spectrums [i] = hierarchySpecturm;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!Application.isPlaying) {
			InitSpectrums ();
			return;
		}

		if (audioSource == null) {
			return;
		}
		
		//Get the spectrum's data
		AudioListener.GetSpectrumData (samples, channel, window);
		
		//Set up the scale of each spectrum 
		for (int i= 0; i< spectrums.Length; i++) {
			if (spectrums [i] == null) {
				continue;
			}

			spectrums [i].localScale = new  Vector3 (specturmWidth, specturmHeightFactorSign * Mathf.Clamp (specturmHeightFactorAbs * samples [i],spectrumMinHeight,Mathf.Infinity), 1);
		}
	}	
}