using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridStructureTests
{
    GridStructure gridStructure;

    [OneTimeSetUp]
    public void Init()
    {
        gridStructure = new GridStructure(3,100,100);
    }


    #region Grid Position Tests
    // A Test behaves as an ordinary method
    [Test]
    public void CalculateGridPositionPasses()
    {
        //Arrange
        var position = new Vector3(5, 3, 5);

        //Act
        var returnPosition = gridStructure.CalculateGridPosition(position);

        //Assert
        Assert.AreEqual(new Vector3(3, 0, 3), returnPosition);
    }

    [Test]
    public void CalculateGridPositionFloatPasses()
    {
        //Arrange
        var position = new Vector3(5.1f, 0, 5.3f);

        //Act
        var returnPosition = gridStructure.CalculateGridPosition(position);

        //Assert
        Assert.AreEqual(new Vector3(3, 0, 3), returnPosition);
    }

    [Test]
    public void CalculateGridPositionFloatFails()
    {
        //Arrange

        var position = new Vector3(3.1f, 0, 0);

        //Act
        var returnPosition = gridStructure.CalculateGridPosition(position);

        //Assert
        Assert.AreNotEqual(new Vector3(0, 0, 0), returnPosition);
    }
    #endregion

    #region Grid Index Tests
    [Test]
    public void PlaceStructure707AndCheckIsTakenPasses()
    {
        //Arrange
        //simulate clicking at this position
        var position = new Vector3(7, 0, 7);

        //Act
        var returnPosition = gridStructure.CalculateGridPosition(position);
        GameObject testObject = new GameObject();
        gridStructure.PlaceStructureOnGrid(testObject,returnPosition);

        //Assert
        Assert.IsTrue(gridStructure.IsCellTaken(position));
    }
    #endregion


}
