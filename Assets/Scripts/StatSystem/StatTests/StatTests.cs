using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StatTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void StatTestsSimplePasses()
    {
        // Use the Assert class to test conditions
        var expected = 4f;
        var stat = new Stat(1);
        stat.AddModifier(new StatModifier(2f));
        stat.AddModifier(new StatModifier(2f));

        var actual = stat.GetValue();
        Assert.AreEqual(expected, actual);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator StatTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
