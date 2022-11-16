using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Helpers;
using ASP.Net.MediatR.Contacts.Repositories;
using ASP.Net.MediatR.Services.Services;
using ASP.Net.MediatR.Services.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;

namespace ASP.Net.MediatR.Services.Tests;

public class UserServiceTest
{
    private readonly UserService _sut;
    private readonly Mock<IUserRepository> _mockRepository = new();
    private readonly Mock<IPasswordHasher> _mockHasher = new();
    private readonly UserHelper _userHelper = new();

    public UserServiceTest()
    {
        _sut = new UserService(_mockRepository.Object, _mockHasher.Object);
    }

    [Fact]
    public async Task Add_User_Successed_Test()
    {
        var (addedId, oldPassword, userDto) = _userHelper.CreateUserDataForAdd();

        var addedResult = _userHelper.CreateExecResult(addedId, false, false, null!);

        _mockHasher.Setup(x => x.HashPassword(userDto.Password))
            .ReturnsAsync(It.IsAny<string>());

        _mockRepository.Setup(x => x.AddAsyns(userDto, default))
            .ReturnsAsync(addedResult);

        var result = await _sut.AddAsyns(userDto, default);

        using var _ = new AssertionScope();
        
        result.Data.Should().Be(addedId);
        result.HasErrors.Should().BeFalse();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().BeNullOrEmpty();
        _mockHasher.Verify(x => x.HashPassword(oldPassword), Times.Once);
        _mockRepository.Verify(x => x.AddAsyns(userDto, default), Times.Once);
    }

    [Fact]
    public async Task Add_User_Failed_Test()
    {
        var (addedId, oldPassword, userDto) = _userHelper.CreateUserDataForAdd();
        var errorMessage = "Cannot insert value";

        var addedResult = _userHelper.CreateExecResult<Guid>(default, true, false, new string[] { errorMessage });

        _mockHasher.Setup(x => x.HashPassword(userDto.Password))
            .ReturnsAsync(It.IsAny<string>());

        _mockRepository.Setup(x => x.AddAsyns(userDto, default))
            .ReturnsAsync(addedResult);

        var result = await _sut.AddAsyns(userDto, default);

        using var _ = new AssertionScope();

        result.Data.Should().NotBe(addedId);
        result.Data.Should().Be(Guid.Empty);
        result.HasErrors.Should().BeTrue();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
        result.Errors.First().Should().BeEquivalentTo(errorMessage);
        _mockHasher.Verify(x => x.HashPassword(oldPassword), Times.Once);
        _mockRepository.Verify(x => x.AddAsyns(userDto, default), Times.Once);

    }

    [Fact]
    public async Task Add_User_Range_Success_Test()
    {
        var (ids, users) = _userHelper.CreateUsersDataForAdd();

        var addedResult = _userHelper.CreateExecResult(ids, false, false, null!);

        _mockRepository.Setup(x => x.AddRangeAsync(users, default))
            .ReturnsAsync(addedResult);
        _mockHasher.Setup(x => x.HashPassword(It.IsAny<string>()))
            .ReturnsAsync(It.IsAny<string>());

        var result = await _sut.AddRangeAsync(users, default);

        using var _ = new AssertionScope();

        result.Should().BeEquivalentTo(addedResult);
        result.Data.Should().BeSameAs(ids);
        result.HasErrors.Should().BeFalse();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().BeNullOrEmpty();
        _mockHasher.Verify(x => x.HashPassword(It.IsAny<string>()), Times.Exactly(users.Count()));
        _mockRepository.Verify(x => x.AddRangeAsync(users, default), Times.Once);
    }

    [Fact]
    public async Task Add_User_Range_Failed_Test()
    {
        var (ids, users) = _userHelper.CreateUsersDataForAdd();
        var errorMessage = "Cannot insert value";

        var addedResult = _userHelper.CreateExecResult<IEnumerable<Guid>>(default!, true, false, new string[] { errorMessage });

        _mockHasher.Setup(x => x.HashPassword(It.IsAny<string>()))
            .ReturnsAsync(It.IsAny<string>());
        _mockRepository.Setup(x => x.AddRangeAsync(users, default))
            .ReturnsAsync(addedResult);

        var result = await _sut.AddRangeAsync(users, default);

        using var _ = new AssertionScope();

        result.Should().BeEquivalentTo(addedResult);
        result.Data.Should().BeNullOrEmpty();
        result.HasErrors.Should().BeTrue();
        result.IsSystemError.Should().BeFalse();
        result.Errors.First().Should().BeEquivalentTo(errorMessage);
        result.Errors.Should().NotBeNullOrEmpty();
        _mockHasher.Verify(x => x.HashPassword(It.IsAny<string>()), Times.AtLeastOnce);
        _mockRepository.Verify(x => x.AddRangeAsync(users, default), Times.Once);
    }

    [Fact]
    public async Task Update_User_Success_Test()
    {
        var userDto = _userHelper.CreateUser(Guid.NewGuid());

        var updateResult = _userHelper.CreateExecResult(false, false, null!); 

        _mockRepository.Setup(x => x.UpdateAsync(userDto, default))
            .ReturnsAsync(updateResult);

        var result = await _sut.UpdateAsync(userDto, default);

        using var _ = new AssertionScope();

        result.Should().BeEquivalentTo(updateResult);
        result.HasErrors.Should().BeFalse();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().BeNullOrEmpty();
        _mockRepository.Verify(x => x.UpdateAsync(userDto, default), Times.Once);
    }

    [Fact]
    public async Task Update_User_Failed_Test()
    {
        var userDto = _userHelper.CreateUser(Guid.NewGuid());
        var errorMessage = $"Item with id ({userDto.Id}) does not exist in (Users) table";

        var updateResult = _userHelper.CreateExecResult(true, false, new string[] { errorMessage });

        _mockRepository.Setup(x => x.UpdateAsync(userDto, default))
            .ReturnsAsync(updateResult);

        var result = await _sut.UpdateAsync(userDto, default);

        using var _ = new AssertionScope();

        result.Should().BeEquivalentTo(updateResult);
        result.HasErrors.Should().BeTrue();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.First().Should().BeEquivalentTo(errorMessage);
        _mockRepository.Verify(x => x.UpdateAsync(userDto, default), Times.Once);
        _mockHasher.Verify(x => x.HashPassword(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task Delete_User_Success_Test()
    {
        var id = Guid.NewGuid();

        var deleteResult = _userHelper.CreateExecResult(false, false, null!);

        _mockRepository.Setup(x => x.DeleteAsync(id, default))
            .ReturnsAsync(deleteResult);

        var result = await _sut.DeleteAsync(id, default);

        using var _ = new AssertionScope();

        result.Should().BeEquivalentTo(deleteResult);
        result.HasErrors.Should().BeFalse();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().BeNullOrEmpty();
        _mockRepository.Verify(x => x.DeleteAsync(id, default), Times.Once);
        _mockHasher.Verify(x => x.HashPassword(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task Delete_User_Failed_Test()
    {
        var id = Guid.NewGuid();
        var errorMessage = "The item doesn`t exist in Users";

        var deleteResult = _userHelper.CreateExecResult(true, false, new string[] { errorMessage });

        _mockRepository.Setup(x => x.DeleteAsync(id, default))
            .ReturnsAsync(deleteResult);

        var result = await _sut.DeleteAsync(id, default);

        using var _ = new AssertionScope();

        result.Should().BeEquivalentTo(deleteResult);
        result.HasErrors.Should().BeTrue();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.First().Should().BeEquivalentTo(errorMessage);
        _mockRepository.Verify(x => x.DeleteAsync(id, default), Times.Once);
        _mockHasher.Verify(x => x.HashPassword(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task Delete_User_Range_Success_Test()
    {
        var ids = _userHelper.CreateIds();

        var deleteResult = _userHelper.CreateExecResult(false, false, null!);

        _mockRepository.Setup(x => x.DeleteRangeAsync(ids, default))
            .ReturnsAsync(deleteResult);

        var result = await _sut.DeleteRangeAsync(ids, default);

        using var _ = new AssertionScope();

        result.Should().BeEquivalentTo(deleteResult);
        result.HasErrors.Should().BeFalse();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().BeNullOrEmpty();
        _mockRepository.Verify(x => x.DeleteRangeAsync(ids, default), Times.Once);
        _mockHasher.Verify(x => x.HashPassword(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task Delete_User_Range_Failed_Test()
    {
        var ids = _userHelper.CreateIds();
        var errorMessage = $"There are no items in table Users";

        var deleteResult = _userHelper.CreateExecResult(true, false, new string[] { errorMessage });

        _mockRepository.Setup(x => x.DeleteRangeAsync(ids, default))
            .ReturnsAsync(deleteResult);

        var result = await _sut.DeleteRangeAsync(ids, default);

        using var _ = new AssertionScope();

        result.Should().BeEquivalentTo(deleteResult);
        result.HasErrors.Should().BeTrue();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.First().Should().BeEquivalentTo(errorMessage);
        _mockRepository.Verify(x => x.DeleteRangeAsync(ids, default), Times.Once);
        _mockHasher.Verify(x => x.HashPassword(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task Get_User_Success_Test()
    {
        var id = Guid.NewGuid();

        var user = _userHelper.CreateUser(id);
        var userResult = _userHelper.CreateExecResult(user, false, false, null!);

        _mockRepository.Setup(x => x.GetAsync(id, default))
            .ReturnsAsync(userResult);

        var result = await _sut.GetAsync(id, default);

        using var _ = new AssertionScope();

        result.Should().BeEquivalentTo(userResult);
        result.Data.Should().NotBeNull();
        result.Data.Should().BeOfType<UserDto>();
        result.Data.Should().BeEquivalentTo(user);
        result.HasErrors.Should().BeFalse();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().BeNullOrEmpty();
        _mockRepository.Verify(x => x.GetAsync(id, default), Times.Once);
        _mockHasher.Verify(x => x.HashPassword(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task Get_User_Failed_Test()
    {
        var id = Guid.NewGuid();
        var errorMessage = "The item with current id doen`t exist in the table Users";

        var userResult = _userHelper.CreateExecResult<UserDto>(null!, true, false, new string[] { errorMessage });

        _mockRepository.Setup(x => x.GetAsync(id, default))
            .ReturnsAsync(userResult);

        var result = await _sut.GetAsync(id, default);

        using var _ = new AssertionScope();

        result.Should().BeEquivalentTo(userResult);
        result.Data.Should().BeNull();
        result.HasErrors.Should().BeTrue();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.First().Should().BeEquivalentTo(errorMessage);
        _mockRepository.Verify(x => x.GetAsync(id, default), Times.Once);
        _mockHasher.Verify(x => x.HashPassword(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task Get_All_Users_Test()
    {
        var users = _userHelper.CreateUsers();

        var getResult = _userHelper.CreateExecResult(users, false, false, null!);

        _mockRepository.Setup(x => x.GetAsync(default))
            .ReturnsAsync(getResult);

        var result = await _sut.GetAsync(default);

        using var _ = new AssertionScope();

        result.Data.Should().NotBeNullOrEmpty();
        result.Data.Should().BeOfType<List<UserDto>>();
        result.Data.Should().BeEquivalentTo(users);
        result.HasErrors.Should().BeFalse();
        result.IsSystemError.Should().BeFalse();
        result.Errors.Should().BeNullOrEmpty();
        _mockRepository.Verify(x => x.GetAsync(default), Times.Once);
        _mockHasher.Verify(x => x.HashPassword(It.IsAny<string>()), Times.Never);
    }
}