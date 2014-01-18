using Xunit;
using Moq;
using Pentomino;
using System;
using System.Collections.Generic;

public class ShapeTests
{
    [Fact]
    public void ShapeCanBeConstructedFromAnEnumeration()
    {
        Shape mooseUpsideDown = new Moose().GetShape(Moose.Orientation.FacingLeft);
    }
}

