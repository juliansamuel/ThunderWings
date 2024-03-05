using FluentAssertions;
using ThunderWings.Domain.Orders;
using ThunderWings.Domain.Products;

namespace ThunderWings.Domain.UnitTests.Orders
{
    public class OrderTests
    {
        [Fact]
        public void CreatingOrder_SetsOrderIdAndCreationDate()
        {
            // Arrange
            var order = Order.Create();

            // Assert
            order.Id.Should().NotBeNull();
            order.DateCreated.Should().NotBe(default(DateTime));
        }

        [Fact]
        public void AddingOrderItem_SetsCorrectProperties()
        {
            // Arrange
            var order = Order.Create();
            var productId = new ProductId(Guid.NewGuid());
            var price = 10.99m;

            // Act
            order.AddOrderItem(productId, price);
            var orderItem = order.OrderItems.First();

            // Assert
            orderItem.Id.Should().NotBeNull();
            orderItem.OrderId.Should().Be(order.Id);
            orderItem.ProductId.Should().Be(productId);
            orderItem.Price.Should().Be(price);
            orderItem.DateCreated.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void AddingOrderItem_IncreasesCountOfOrderItems()
        {
            // Arrange
            var order = Order.Create();
            var initialCount = order.OrderItems.Count;

            // Act
            order.AddOrderItem(new ProductId(Guid.NewGuid()), 10.0m);

            // Assert
            order.OrderItems.Count.Should().Be(initialCount + 1);
        }

        [Fact]
        public void AddingMultipleOrderItems_IncreasesCountOfOrderItems()
        {
            // Arrange
            var order = Order.Create();
            var productId1 = new ProductId(Guid.NewGuid());
            var productId2 = new ProductId(Guid.NewGuid());
            var price1 = 10.0m;
            var price2 = 20.0m;

            // Act
            order.AddOrderItem(productId1, price1);
            order.AddOrderItem(productId2, price2);

            // Assert
            Assert.Equal(2, order.OrderItems.Count);
        }

        [Fact]
        public void GettingOrderItems_ReturnsReadOnlyListOfOrderItems()
        {
            // Arrange
            var order = Order.Create();
            var productId = new ProductId(Guid.NewGuid());
            order.AddOrderItem(productId, 10.0m);

            // Act
            var orderItems = order.OrderItems;

            // Assert
            orderItems.Should().BeOfType<List<OrderItem>>().And.Subject.As<List<OrderItem>>().Should().BeEquivalentTo(order.OrderItems);
        }

        [Fact]
        public void RemovingExistingOrderItem_DecreasesCountOfOrderItems()
        {
            // Arrange
            var order = Order.Create();
            var productId = new ProductId(Guid.NewGuid());
            order.AddOrderItem(productId, 10.0m);
            var initialCount = order.OrderItems.Count;

            // Act
            order.RemoveOrderItem(order.OrderItems.First().Id);

            // Assert
            order.OrderItems.Count.Should().Be(initialCount - 1);
        }

        [Fact]
        public void RemovingNonExistingOrderItem_ThrowsException()
        {
            // Arrange
            var order = Order.Create();

            // Act
            var act = () => order.RemoveOrderItem(new OrderItemId(Guid.NewGuid()));

            // Assert
            act.Should().Throw<OrderItemNotFoundException>();
        }

        [Fact]
        public void RemovingLastOrderItem_SetsOrderItemsListToEmptyList()
        {
            // Arrange
            var order = Order.Create();
            var productId = new ProductId(Guid.NewGuid());
            var price = 10.99m;
            order.AddOrderItem(productId, price);

            // Act
            order.RemoveOrderItem(order.OrderItems.First().Id);

            // Assert
            order.OrderItems.Should().BeEmpty();
        }

        // placing an order sets the order placement date
        [Fact]
        public void PlacingOrder_SetsOrderPlacementDate()
        {
            // Arrange
            var order = Order.Create();

            // Act
            order.PlaceOrder();

            // Assert
            order.DatePlaced.Should().NotBeNull();
        }
    }
}