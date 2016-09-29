using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class FightMenuButton : MonoBehaviour, IPointerEnterHandler, ISelectHandler,IDeselectHandler {

	public bool hasSubMenu = false;
	public Sprite noSubMenuSprite, subMenuInactiveSprite, subMenuActiveSprite;

	private bool isSelected = false;

	private GameObject eventSystem;
	private Image image;
	private Button button;
	private FightMenuPrime fightMenuPrime;

	// Use this for initialization
	void Start () {
		eventSystem = GameObject.Find ("EventSystem");
		image = GetComponent<Image> ();
		button = GetComponent<Button> ();

		if (hasSubMenu){
			ChangeSprite (subMenuInactiveSprite);
		} else {
			ChangeSprite (noSubMenuSprite);
		}

		button.onClick.AddListener (MyOnClick);

		fightMenuPrime = FindObjectOfType<FightMenuPrime> ();

	}

	void Update () {
		if(Input.GetKeyDown("right")){
			if (isSelected && hasSubMenu) {
				button.onClick.Invoke ();
			}
		}
	}
	
	public void EmboldenText() {
		GetComponentInChildren<Text>().fontStyle = FontStyle.Bold;
	}

	private void UnboldenText() {
		GetComponentInChildren<Text>().fontStyle = FontStyle.Normal;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		OnSelect(eventData);
	}

	public void OnSelect(BaseEventData eventData) {

		if (eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().currentSelectedGameObject != gameObject){
			eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (gameObject);
		}
			
		EmboldenText();

		isSelected = true;

	}

	public void OnDeselect(BaseEventData eventData) {
		UnboldenText ();

		isSelected = false;
	}

	public void ChangeSprite(Sprite sprite) {
		image.overrideSprite = sprite;
	}

	void MyOnClick(){

		if(hasSubMenu) {
			ChangeSprite (subMenuActiveSprite);
		}

		fightMenuPrime.QuietOtherButtons (this);

	}

}
