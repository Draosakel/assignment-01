using System.Collections.Generic;

namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void Flatten()
    {
        // ((1, 2), (3, 4), (5, 6)) -> (1, 2, 3, 4, 5, 6)
        // Arrange
        var input = new List<List<int>> { new List<int> { 1, 2 }, new List<int> { 3, 4 }, new List<int> { 5, 6 } };

        // Act
        var flat = Assignment1.Iterators.Flatten<int>(input);

        // Assert
        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, flat);
    }

    [Fact]
    public void Flatten_empty()
    {
        // Arrange
        var input = new List<List<int>>();

        // Act
        var flat = Assignment1.Iterators.Flatten<int>(input);

        // Assert
        Assert.Equal(new List<int>(), flat);
    }

    [Fact]
    public void Flatten_different_list_sizes()
    {
        // Arrange
        var input = new List<List<int>> { new List<int> { 1 }, new List<int> { 2, 3 }, new List<int> { 4, 5, 6 } };

        // Act
        var flat = Assignment1.Iterators.Flatten<int>(input);

        // Assert
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6 }, flat);
    }

    [Fact]
    public void Filter()
    {
        // Arrange
        var input = new List<int> { 1, 6, 2, 4, 5, 3 };

        // Act
        var filtered = Assignment1.Iterators.Filter(input, i => i > 3);

        // Assert
        Assert.Equal(new[] { 6, 4, 5 }, filtered);
    }
}