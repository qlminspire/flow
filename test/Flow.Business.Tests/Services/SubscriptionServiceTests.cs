using Moq;

using Flow.Business.Services.Implementations;
using Flow.DataAccess.Contracts;
using Flow.Entities;

namespace Flow.Business.Tests.Services;

public class SubscriptionServiceTests
{
    private readonly SubscriptionService _subscriptionService;
    private readonly Mock<IUnitOfWork> _unitOfWork;

    public SubscriptionServiceTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _unitOfWork.Setup(x => x.Subscriptions.Create(It.IsAny<Subscription>()));
        _subscriptionService = new SubscriptionService(_unitOfWork.Object, null);
    }
}
