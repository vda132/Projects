using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Repositories;
using ASP.Net.MediatR.CRUD.Result;
using ASP.Net.MediatR.Services.Services;
using ASP.Net.MediatR.Services.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;

namespace ASP.Net.MediatR.Services.Tests;

public class RoleServiceTest
{
    private readonly RoleService _sut;
    private readonly Mock<IRoleRepository> _mockRepo = new();
    private RoleHelper _roleHelper = new RoleHelper();

    public RoleServiceTest()
    {
        _sut = new(_mockRepo.Object);
    }

    [Fact]
    public async Task Get_All_Roles_Test()
    {
        var roles = _roleHelper.CreateRoles();

        var getResult = _roleHelper.CreateExecResult(roles, false, false, null!);

        _mockRepo.Setup(x => x.GetAsync(default))
            .ReturnsAsync(getResult);

        var result = await _sut.GetAsync(default);

        using var _ = new AssertionScope();

        result.Data.Should().NotBeNullOrEmpty();
        result.Data.Should().BeOfType<List<RoleDto>>();
        result.Data.Should().BeEquivalentTo(roles);
        result.HasErrors.Should().BeFalse();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().BeNullOrEmpty();
        _mockRepo.Verify(x => x.GetAsync(default), Times.Once);
    }
}
