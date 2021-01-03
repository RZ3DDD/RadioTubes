using System;

namespace RadioTubes.MBL.Model
{
    class StoragePart
    {
        public StoragePart(int id, User user, RadioTube radioTube, StorageBox storageBox, int quantity)
        {
            Id = id;
            User = user;
            RadioTube = radioTube;
            StorageBox = storageBox;
            Quantity = quantity;
        }

        public int Id { get; }
        public User User { get; }
        public RadioTube RadioTube { get; set; }
        public StorageBox StorageBox { get; set; }
        public int Quantity { get; set; }
    }
}
