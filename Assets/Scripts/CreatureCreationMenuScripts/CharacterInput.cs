using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInput : MonoBehaviour {
    private string _creatureName;
    private int _creatureHealth, _armorClass, _initiative;
    //the array is going to be in the order of [0] = ability score, [1] = ability mod, [2] = ability save
    //passives are in the order of [0] = perception, [1] = investigation, [2] = insight
    private int[] _strength = new int[3], _dexterity = new int[3], _constitution = new int[3], 
                  _intelligence = new int[3], _wisdom = new int[3], _charisma = new int[3], _passives = new int[3];

    //I know that this function is a bit on the beefy side, but it's still better than keeping 20+ seperate functions.
    //as it turns out, all inputFields can actually just default to taking ints
    public void inputValue(string input) {
        int temp;
        //start with seeing if it's the name because it doesn't need to be converted to an int
        if(this.transform.parent.name == "creatureName") {
            _creatureName = input;
            Debug.Log(_creatureName);
        //next three are prefab checks because they need special input
        } else if(this.transform.name == "AbilityScoreInputField") {
            if(int.TryParse(input, out temp)) {
                findPrefab(this.transform.parent.name, 0, temp);
            }
        } else if(this.transform.name == "AbilityBonusInputField") {
            if (int.TryParse(input, out temp)) {
                findPrefab(this.transform.parent.name, 1, temp);
            }
        } else if (this.transform.name == "AbilitySaveInputField") {
            if (int.TryParse(input, out temp)) {
                findPrefab(this.transform.parent.name, 2, temp);
            }
        //the rest
        } else {
            if(int.TryParse(input, out temp)) {
                //since we can't just automatically set the value based on name alone,
                //this switch will be the selector
                switch(this.transform.parent.name) {
                    case "creatureHealth":
                        _creatureHealth = temp;
                        Debug.Log(_creatureHealth);
                        break;
                    case "armorClass":
                        _armorClass = temp;
                        Debug.Log(_armorClass);
                        break;
                    case "initiative":
                        _initiative = temp;
                        Debug.Log(_initiative);
                        break;
                    case "perception":
                        _passives[0] = temp;
                        Debug.Log(_passives[0]);
                        break;
                    case "investigation":
                        _passives[1] = temp;
                        Debug.Log(_passives[1]);
                        break;
                    case "insight":
                        _passives[2] = temp;
                        Debug.Log(_passives[2]);
                        break;
                }
            }
        }
    }

    //finds which prefab is being used and sets the respective value.
    private void findPrefab(string name, int index, int valueToSet) {
        switch(name) {
            case "strength":
                _strength[index] = valueToSet;
                Debug.Log(_strength[index]);
                break;
            case "dexterity":
                _dexterity[index] = valueToSet;
                Debug.Log(_dexterity[index]);
                break;
            case "constitution":
                _constitution[index] = valueToSet;
                Debug.Log(_constitution[index]);
                break;
            case "intelligence":
                _intelligence[index] = valueToSet;
                Debug.Log(_intelligence[index]);
                break;
            case "wisdom":
                _wisdom[index] = valueToSet;
                Debug.Log(_wisdom[index]);
                break;
            case "charisma":
                _charisma[index] = valueToSet;
                Debug.Log(_charisma[index]);
                break;
        }
    }
}