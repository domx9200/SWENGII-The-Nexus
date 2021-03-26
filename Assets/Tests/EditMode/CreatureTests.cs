using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class creatureTests
    {

        [Test]
        public void CreatureCreateTest()
        {
            string name = "intput";
            int hp = 120, ac = 21, initiative = 7;
            int[,] abilities = new int[6, 3] {{10,0,1}, {12,1,2}, {14,2,3}, {16,3,4}, {18,4,5}, {20,5,6}};
            int[] passives = new int[3] {15,17,19};
            Creature test = new Creature(name, hp, ac, initiative, abilities, passives);

            //if by the end of the long test bullshit passed is 25 pass, otherwise fail
            int passed = 0;
            passed += testVariable<string>(name, test._Name);
            passed += testVariable<int>(hp, test._HP);
            passed += testVariable<int>(ac, test._AC);
            passed += testVariable<int>(initiative, test._Initiative);
            passed += (testVariable<int[]>(passives, test._Passives) * 3);
            for(int i = 0; i < 3; i++)
            {
                passed += testVariable<int>(abilities[0, i], test._Strength[i]);
                passed += testVariable<int>(abilities[1, i], test._Dexterity[i]);
                passed += testVariable<int>(abilities[2, i], test._Constitution[i]);
                passed += testVariable<int>(abilities[3, i], test._Intelligence[i]);
                passed += testVariable<int>(abilities[4, i], test._Wisdom[i]);
                passed += testVariable<int>(abilities[5, i], test._Charisma[i]);
            }
            Assert.AreEqual(25, passed);
        }


        private int testVariable<T>(T variable, T valueToTest)
        {
            if(variable.Equals(valueToTest))
            {
                return 1;
            }
            return 0;
        }
    }
}
