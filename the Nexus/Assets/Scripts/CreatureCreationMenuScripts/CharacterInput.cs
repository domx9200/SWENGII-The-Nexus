using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
        private string _creatureName;
        private string _HP, _AC, _Initiative;
        private string _strengthScore, _dexterityScore, _constitutionScore, _wisdomScore, _intelligenceScore, _charismaScore;
        private string _strengthBonus, _dexterityBonus, _constitutionBonus, _wisdomBonus, _intelligenceBonus, _charismaBonus;
        private string _strengthSave, _dexteritySave, _constitutionSave, _wisdomSave, _intelligenceSave,_charismaSave;
        private string _passivePerception, _passiveInvestigation, _passiveInsight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadName(string s)
	{
        _creatureName = s;
        Debug.Log(_creatureName);
	}

    public void ReadHealth(string s)
    {
        _HP = s;
        Debug.Log(_HP);
    }

    public void ReadArmor(string s)
	{
        _AC = s;
        Debug.Log(_AC);
	}

    public void ReadInitiative(string s)
	{
        _Initiative = s;
        Debug.Log(_Initiative);
	}

    public void ReadStrength(string s)
	{
        _strengthScore = s;
        Debug.Log(_strengthScore);
	}

    public void ReadDexterity(string s)
	{
        _dexterityScore = s;
        Debug.Log(_dexterityScore);
	}

    public void ReadConstitution(string s)
	{
        _constitutionScore = s;
        Debug.Log(_constitutionScore);
	}

    public void ReadWisdom(string s)
	{
        _wisdomScore = s;
        Debug.Log(_wisdomScore);
	}

    public void ReadIntelligence(string s)
	{
        _intelligenceScore = s;
        Debug.Log(_intelligenceScore);
	}

    public void ReadCharisma(string s)
	{
        _charismaScore = s;
        Debug.Log(_charismaScore);
	}

    public void ReadStrengthBonus(string s)
    {
        _strengthBonus = s;
        Debug.Log(_strengthBonus);
    }

    public void ReadDexterityBonus(string s)
    {
        _dexterityBonus = s;
        Debug.Log(_dexterityBonus);
    }

    public void ReadConstitutionBonus(string s)
    {
        _constitutionBonus = s;
        Debug.Log(_constitutionBonus);
    }

    public void ReadWisdomBonus(string s)
    {
        _wisdomBonus = s;
        Debug.Log(_wisdomBonus);
    }

    public void ReadIntelligenceBonus(string s)
	{
        _intelligenceBonus = s;
        Debug.Log(_intelligenceBonus);
	}

    public void ReadCharismaBonus(string s)
    {
        _charismaBonus = s;
        Debug.Log(_charismaBonus);
    }

    public void ReadStrengthSave(string s)
    {
        _strengthSave = s;
        Debug.Log(_strengthSave);
    }

    public void ReadDexteritySave(string s)
    {
        _dexteritySave = s;
        Debug.Log(_dexteritySave);
    }

    public void ReadConstitutionSave(string s)
    {
        _constitutionSave = s;
        Debug.Log(_constitutionSave);
    }

    public void ReadWisdomSave(string s)
    {
        _wisdomSave = s;
        Debug.Log(_wisdomSave);
    }

    public void ReadIntelligenceSave(string s)
	{
        _intelligenceSave = s;
        Debug.Log(_intelligenceSave);
	}

    public void ReadCharismaSave(string s)
    {
        _charismaSave = s;
        Debug.Log(_charismaSave);
    }

    public void ReadPassivePerception(string s)
	{
        _passivePerception = s;
        Debug.Log(_passivePerception);
	}

    public void ReadPassiveInvestigation(string s)
    {
        _passiveInvestigation = s;
        Debug.Log(_passiveInvestigation);
    }

    public void ReadPassiveInsight(string s)
    {
        _passiveInsight = s;
        Debug.Log(_passiveInsight);
    }
}
