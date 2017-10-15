using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;


[TestFixture]
public class ActionMasterTest
{
    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    [SetUp]
    public void SetUp() {
        pinFalls = new List<int>();
    }

    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn() {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02Bowl8ReturnsTidy() {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T03SecondBowlReturnsEndTurn() {
        int[] rolls = { 3, 5 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T04BowlingASpare() {
        int[] rolls = { 8, 2 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T05FinishingTheGame() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    
    [Test]
    public void T06StrikeOnTheLastFrame() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5, 5 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    
    [Test]
    public void T07SpareOnTheLastFrame() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 10 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    
    [Test]
    public void T08PerfectEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    
    [Test]
    public void T09StrikeOnASpare() {
    }
    
    [Test]
    public void T10UnityCourseTestOnAboveTestAndCode()
    {
        pinFalls.Add(0);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
        pinFalls.Add(5);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
        pinFalls.Add(4);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }
    
    [Test]
    public void T11StartGameTurkey()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }
}
