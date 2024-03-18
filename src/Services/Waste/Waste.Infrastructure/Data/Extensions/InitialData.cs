namespace Waste.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        private static readonly string roomId1 = "7506213d-3b5f-4498-b35c-9169a600ff10";
        private static readonly string roomId2 = "0f42ff42-f701-48c9-a7b5-c56ad78f55b1";

        private static readonly string productId1 = "f3c58f4e-4e49-4180-ba4c-0a2e8cddc58c";
        private static readonly string productId2 = "2b05fc3d-2e2e-4e88-8a91-2dcf3a01c3d1";

        private static readonly string wasteId1 = "bb63acb6-3aaf-433d-9784-e5e9a6ad6b06";
        private static readonly string wasteId2 = "142f0efe-9e11-4808-a7f6-fcb564908772";

        private static readonly string wasteItemId1 = "05d3a746-fb2c-4d7a-9861-103d9e112637";
        private static readonly string wasteItemId2 = "ce0e148b-9906-45a1-b037-b46ea99ca85a";

        public static IEnumerable<Room> Rooms
        {
            get
            {
                try
                {
                    return new List<Room>
                    {
                        Room.Create(RoomId.Of(Guid.Parse(roomId1)), "Room 1", "Description for Room 1"),
                        Room.Create(RoomId.Of(Guid.Parse(roomId2)), "Room 2", "Description for Room 2")
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Room), ex.Message);
                }
            }
        }

        public static IEnumerable<Product> Products
        {
            get
            {
                try
                {
                    return new List<Product>
                    {
                        Product.Create(ProductId.Of(Guid.Parse(productId1)), "Product 1", 10.0m),
                        Product.Create(ProductId.Of(Guid.Parse(productId2)), "Product 2", 15.0m)
                    };
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Product), ex.Message);
                }
            }
        }

        public static IEnumerable<Domain.Models.Waste> Wastes
        {
            get
            {
                try
                {
                    var waste1 = Domain.Models.Waste.Create(
                        id: WasteId.Of(Guid.Parse(wasteId1)),
                        roomId: RoomId.Of(Guid.Parse(roomId1)),
                        pickupLocation: new Address("Pickup Street 1", "Pickup City 1", "Pickup State 1", "12345", "Pickup Country 1", "1234567890", "pickup@example.com"),
                        dropOffLocation: new Address("Drop-off Street 1", "Drop-off City 1", "Drop-off State 1", "54321", "Drop-off Country 1", "0987654321", "dropoff@example.com"),
                        status: WasteStatus.Pending,
                        color: WasteColor.Black);

                    var waste2 = Domain.Models.Waste.Create(
                        id: WasteId.Of(Guid.Parse(wasteId2)),
                        roomId: RoomId.Of(Guid.Parse(roomId2)),
                        pickupLocation: new Address("Pickup Street 2", "Pickup City 2", "Pickup State 2", "54321", "Pickup Country 2", "1234567890", "pickup2@example.com"),
                        dropOffLocation: new Address("Drop-off Street 2", "Drop-off City 2", "Drop-off State 2", "12345", "Drop-off Country 2", "0987654321", "dropoff2@example.com"),
                        status: WasteStatus.Pending,
                        color: WasteColor.Black);

                    waste1.AddItem(waste1.Id, ProductId.Of(Guid.Parse(productId1)), 1, 3);
                    waste2.AddItem(waste2.Id, ProductId.Of(Guid.Parse(productId2)), 1, 5);

                    var wastes = new List<Domain.Models.Waste>
                    {
                        waste1,
                        waste2
                    };

                    return wastes;
                }
                catch (Exception ex)
                {
                    throw new EntityCreationException(nameof(Domain.Models.Waste), ex.Message);
                }
            }
        }
    }
}
