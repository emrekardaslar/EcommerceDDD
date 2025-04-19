using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceDDD.API.Controllers;
using EcommerceDDD.Application.Services.Products;
using EcommerceDDD.Domain.Entities.Products;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EcommerceDDD.API.Tests.Controllers;

public class CategoriesControllerTests
{
    private readonly Mock<ICategoryService> _mockCategoryService;
    private readonly CategoriesController _controller;

    public CategoriesControllerTests()
    {
        _mockCategoryService = new Mock<ICategoryService>();
        _controller = new CategoriesController(_mockCategoryService.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithCategories()
    {
        // Arrange
        var categories = new List<Category>
        {
            new Category("Test Category 1", "Description 1"),
            new Category("Test Category 2", "Description 2")
        };
        _mockCategoryService.Setup(service => service.GetAllAsync())
            .ReturnsAsync(categories);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<Category>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetById_ReturnsOkResult_WhenCategoryExists()
    {
        // Arrange
        var category = new Category("Test Category", "Test Description");
        _mockCategoryService.Setup(service => service.GetByIdAsync(category.Id))
            .ReturnsAsync(category);

        // Act
        var result = await _controller.GetById(category.Id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Category>(okResult.Value);
        Assert.Equal(category.Id, returnValue.Id);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();
        _mockCategoryService.Setup(service => service.GetByIdAsync(nonExistentId))
            .ThrowsAsync(new KeyNotFoundException());

        // Act
        var result = await _controller.GetById(nonExistentId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Create_ReturnsCreatedAtAction_WhenCategoryIsValid()
    {
        // Arrange
        var request = new CreateCategoryRequest("New Category", "New Description");
        var category = new Category(request.Name, request.Description);
        _mockCategoryService.Setup(service => service.CreateCategoryAsync(request.Name, request.Description))
            .ReturnsAsync(category);

        // Act
        var result = await _controller.Create(request);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<Category>(createdAtActionResult.Value);
        Assert.Equal(category.Id, returnValue.Id);
    }

    [Fact]
    public async Task Update_ReturnsNoContent_WhenCategoryExists()
    {
        // Arrange
        var id = Guid.NewGuid();
        var request = new CreateCategoryRequest("Updated Category", "Updated Description");
        _mockCategoryService.Setup(service => service.UpdateCategoryAsync(id, request.Name, request.Description))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Update(id, request);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Update_ReturnsNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();
        var request = new CreateCategoryRequest("Updated Category", "Updated Description");
        _mockCategoryService.Setup(service => service.UpdateCategoryAsync(nonExistentId, request.Name, request.Description))
            .ThrowsAsync(new KeyNotFoundException());

        // Act
        var result = await _controller.Update(nonExistentId, request);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNoContent_WhenCategoryExists()
    {
        // Arrange
        var id = Guid.NewGuid();
        _mockCategoryService.Setup(service => service.DeleteCategoryAsync(id))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Delete(id);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();
        _mockCategoryService.Setup(service => service.DeleteCategoryAsync(nonExistentId))
            .ThrowsAsync(new KeyNotFoundException());

        // Act
        var result = await _controller.Delete(nonExistentId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Activate_ReturnsNoContent_WhenCategoryExists()
    {
        // Arrange
        var id = Guid.NewGuid();
        _mockCategoryService.Setup(service => service.ActivateCategoryAsync(id))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Activate(id);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Activate_ReturnsNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();
        _mockCategoryService.Setup(service => service.ActivateCategoryAsync(nonExistentId))
            .ThrowsAsync(new KeyNotFoundException());

        // Act
        var result = await _controller.Activate(nonExistentId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Deactivate_ReturnsNoContent_WhenCategoryExists()
    {
        // Arrange
        var id = Guid.NewGuid();
        _mockCategoryService.Setup(service => service.DeactivateCategoryAsync(id))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Deactivate(id);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Deactivate_ReturnsNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();
        _mockCategoryService.Setup(service => service.DeactivateCategoryAsync(nonExistentId))
            .ThrowsAsync(new KeyNotFoundException());

        // Act
        var result = await _controller.Deactivate(nonExistentId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
} 